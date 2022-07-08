Public Class FJeu
    'all values below are default values, it can be changed
    Private nbmines = 10

    Private maxFlags = 10
    Private nbFlags = 0

    Private Const maxHelp = 5
    Private nbHelp = 0

    Private timeMax = 60
    Private timeLeft = 60

    Private lines = 8
    Private columns = 8

    Private nbButton = 0

    Private isPause As Boolean = False

    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    ''' <summary>
    ''' Enables a form's default close button.
    ''' </summary>
    ''' <returns>The parameter which was created
    '''          in order to enable the close button.</returns>
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim mdiCp As CreateParams = MyBase.CreateParams
            mdiCp.ClassStyle = mdiCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return mdiCp
        End Get
    End Property

    ' default is to unmask (discovered) a box
    Private selectedMode As BoxOfGrid.BoxState = BoxOfGrid.BoxState.UNMASK

    Private Sub reSizeForm(x As UInteger, y As UInteger)
        Me.Size = New Size(x, y)
    End Sub

    ''' <summary>
    ''' Initializes the game's grid dimensions,
    ''' the time allowed to win the game 
    ''' and the number of mines.
    ''' </summary>
    ''' <param name="l">The grid's number of lines.</param>
    ''' <param name="c">The grid's number of colums.</param>
    ''' <param name="m">The grid's number of mines.</param>
    ''' <param name="t">The time allowed to win the game.</param>
    Private Sub initValues(l As UInteger, c As UInteger, m As UInteger, t As UInteger)
        lines = l
        columns = c
        nbmines = m
        timeMax = t
        timeLeft = t
        maxFlags = m
    End Sub

    Private oneMinute = 60
    Private threeMinutes = 180
    Private fiveMinutes = 300
    Private eightMinutes = 480

    ''' <summary>
    ''' Diverts the form's datas under
    ''' the difficulty which the player selected.
    ''' </summary>
    ''' <see cref="initValues(UInteger, UInteger, UInteger, UInteger)"/>
    Private Sub difficulties()
        Dim d As String = FOptions.selectedDifficulty()

        If d = "Nonsense" Then
            initValues(8, 8, 8 * 8 - 1, oneMinute)
            reSizeForm(515, 424)
        ElseIf d = "Normal" Then
            initValues(12, 12, 30, threeMinutes)
            reSizeForm(620, 550)
        ElseIf d = "Hard" Then
            initValues(16, 16, 40, fiveMinutes)
            reSizeForm(800, 700)
        ElseIf d = "Extreme" Then
            initValues(22, 22, 80, eightMinutes)
            reSizeForm(1100, 880)
        Else
            initValues(8, 8, 10, oneMinute)
            reSizeForm(515, 424)
        End If
    End Sub

    ''' <summary>
    ''' Loads the game's form which respect the theme which has been chosen,
    ''' the selected game's difficulty, the time which is allowed to win the game
    ''' and the number of flags needed to win the game.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <see cref="difficulties()"/>
    ''' <see cref="generate_Button(Integer, Integer)"/>
    ''' <see cref="FMenu.CenterForm(Form, Form)"/>
    ''' <see cref="initGrid(UInteger, UInteger, UInteger)"/>
    Private Sub FTestBoutton_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FOptions.themeChoice(Me)

        'color
        Me.Ttimer.BackColor = Color.GhostWhite

        'button generation
        difficulties()
        For i As Integer = 0 To lines - 1 'lignes
            For j As Integer = 0 To columns - 1 'colonnes
                generate_Button(i, j)
            Next j
        Next i

        FMenu.CenterForm(Me, FMenu)

        'hestetics
        Me.Lname.Font = New Font("", 15, FontStyle.Bold)
        Me.Lname.Text = FMenu.CBname.Text

        Me.Ttimer.Text = "--"
        Me.Ttimer.TextAlign = HorizontalAlignment.Center
        Me.Ttimer.Font = New Font("", 20, FontStyle.Bold)
        Me.Ttimer.Enabled = False

        Dim img As Image = Image.FromFile("image\\drapeau.png")
        Me.Bnbflags.Image = New Bitmap(img, New Size(30, 30))
        Me.Bnbflags.ImageAlign = ContentAlignment.MiddleLeft
        Me.Bnbflags.BackColor = Color.Transparent
        Me.Bnbflags.Text = "     x" + CStr(maxFlags)

        Me.Bcmdchange.BackColor = Color.MidnightBlue
        Me.Bcmdchange.ForeColor = Color.White

        Me.Icon = New Icon("image\\icon\\game.ico")

        'timer
        Me.TimerGame.Interval = 1000

        'start of the game
        Grid.initGrid(lines, columns, nbmines)
    End Sub

    ''' <summary>
    ''' Generates the grid's button
    ''' which represent the boxes of the game.
    ''' </summary>
    ''' <param name="line"></param>
    ''' <param name="column"></param>
    Private Sub generate_Button(line As Integer, column As Integer)
        Dim btn As New Button
        btn.Name = "B" + Convert.ToString(nbButton)
        btn.Location = New Point(column * (btn.Height + 10) + 150, line * (btn.Height + 10) + 70)
        btn.Size = New Size(30, 30)
        btn.BackColor = Color.GhostWhite
        btn.ForeColor = Color.Black

        Me.Controls.Add(btn)

        AddHandler btn.Click, AddressOf btn_clic
        nbButton += 1
    End Sub

    ''' <summary>
    ''' Updates the appearance of all the boxes
    ''' which were affected by the last move.
    ''' </summary>
    ''' <see cref="Utile.numOfBox(String)"/>
    Private Sub updateOfButtons()
        Dim ctrl As Control
        For Each ctrl In Me.Controls
            If TypeName(ctrl) = "Button" Then
                Dim btn As Button = ctrl
                If IsNumeric(Utile.numOfBox(btn.Name)) Then
                    Dim state As BoxOfGrid.BoxState = Grid.getBoxState(Utile.numOfBox(btn.Name))
                    Dim content As UInteger = Grid.getBoxValue(Utile.numOfBox(btn.Name))
                    If state = BoxOfGrid.BoxState.MARK Then
                        Dim img As Image = Image.FromFile("image\\drapeau.png")
                        btn.BackColor = Color.GhostWhite
                        btn.Image = New Bitmap(img, New Size(30, 30))
                    ElseIf state = BoxOfGrid.BoxState.UNMASK Then
                        If content = 0 Then
                            btn.BackColor = Color.Transparent
                            btn.Enabled = False
                        ElseIf content >= 1 AndAlso content <= 8 Then
                            btn.BackColor = Color.Transparent
                            btn.Enabled = False
                            btn.Text = content
                        Else
                            btn.BackColor = Color.GhostWhite
                            Dim img As Image = Image.FromFile("image\\mine.png")
                            btn.Image = New Bitmap(img, New Size(30, 30))
                        End If
                    Else
                        btn.Image = Nothing
                    End If
                End If
            End If
        Next ctrl
    End Sub

    ''' <summary>
    ''' Updates the left flags number after a move.
    ''' </summary>
    ''' <param name="btn">The box where the move is applied.</param>
    ''' <see cref="Utile.numOfBox(String)"/>
    Private Sub updateNbFlags(btn As Button)
        Dim state As BoxOfGrid.BoxState = Grid.getBoxState(Utile.numOfBox(btn.Name))
        Dim content As UInteger = Grid.getBoxValue(Utile.numOfBox(btn.Name))

        If state = BoxState.MARK Then
            nbFlags += 1
        Else
            nbFlags -= 1
        End If

        Me.Bnbflags.Text = "     x" + CStr(maxFlags - nbFlags)
    End Sub

    ''' <summary>
    ''' Manage each event which is related to a box of the grid.
    ''' </summary>
    ''' <param name="sender">The selected box.</param>
    ''' <param name="e"></param>
    ''' <see cref="timer1_tick_manage()"/>
    ''' <see cref="Grid.play(String)"/>
    ''' <see cref="Utile.numOfBox(String)"/>
    ''' <see cref="updateNbFlags(Button)"/>
    ''' <see cref="updateOfButtons()"/>
    ''' <see cref="testIswon()"/>
    ''' <see cref="testIsLost(String)"/>
    Private Sub btn_clic(sender As Object, e As EventArgs)
        Dim btn As Button = sender

        'starts the timer
        If timeLeft = timeMax OrElse isPause Then
            timer1_tick_manage()
            TimerGame.Start()
            isPause = False
        End If

        'the game
        Dim targetedBox As String = ""
        If selectedMode = BoxOfGrid.BoxState.UNMASK Then
            targetedBox += "U" + CStr(Utile.numOfBox(btn.Name))
            Grid.play(targetedBox)
        Else
            If nbFlags < maxFlags OrElse Grid.getBoxState(Utile.numOfBox(btn.Name)) = BoxState.MARK Then
                targetedBox += "M" + CStr(Utile.numOfBox(btn.Name))
                Grid.play(targetedBox)
                updateNbFlags(btn)
            Else
                MsgBox("You have already reached the maximum number of flags")
            End If
        End If

        updateOfButtons()
        testIswon()

        If FOptions.RBactivated.Checked Then
        Else
            testIsLost(targetedBox)
        End If

        Me.Bcmdchange.Focus()
    End Sub

    ''' <summary>
    ''' Checks if the game is won.
    ''' If that is true, the form will show a messageBox and close the form.
    ''' </summary>
    ''' <see cref="Players.saveGameWon(String, UInteger, UInteger, GamePlayed.Difficulties)"/>
    Private Sub testIswon()
        If Grid.isWon() Then
            Me.TimerGame.Stop()
            If Me.Ttimer.Text = "--" Then Me.Ttimer.Text = timeMax
            Players.saveGameWon(FMenu.CBname.Text, Grid.getNbOfUnmaskedBoxes() _
                                , timeMax - Me.Ttimer.Text, GamePlayed.getDifficultyOf(FOptions.getDifficulty))

            MsgBox("Congrats, You won !" & vbCrLf & "You discovered " & Grid.getNbOfUnmaskedBoxes() &
                   " boxes in " & (timeMax - Me.Ttimer.Text) & " seconds.", vbOKOnly, "End game message")

            Me.Close()
            FMenu.Show()
        End If
    End Sub

    ''' <summary>
    ''' Checks if the game is lost.
    ''' If that is true, the form will show a messageBox and close the form.
    ''' </summary>
    ''' <see cref="Players.saveGameLost(String, UInteger, UInteger, GamePlayed.Difficulties)"/>
    Private Sub testIsLost(targetedBox As String)
        If targetedBox <> "" Then
            If Grid.isLost(targetedBox) Then
                Me.TimerGame.Stop()
                If Me.Ttimer.Text = "--" Then Me.Ttimer.Text = timeMax
                If Grid.getNbOfUnmaskedBoxes > 0 Then
                    Players.saveGameLost(FMenu.CBname.Text, Grid.getNbOfUnmaskedBoxes() _
                                     , timeMax - Me.Ttimer.Text, GamePlayed.getDifficultyOf(FOptions.getDifficulty))
                End If
                MsgBox("Nooooo, you lost ...", vbOKOnly, "End game message")

                Me.Close()
                FMenu.Show()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Switches the button's utility each time it is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Bcmdchange_Click(sender As Object, e As EventArgs) Handles Bcmdchange.Click
        If selectedMode = BoxOfGrid.BoxState.UNMASK Then
            selectedMode = BoxOfGrid.BoxState.MARK
            Bcmdchange.Text = "Mark"
            Bcmdchange.BackColor = Color.DarkRed
        Else
            selectedMode = BoxOfGrid.BoxState.UNMASK
            Bcmdchange.Text = "Unmask"
            Bcmdchange.BackColor = Color.MidnightBlue
        End If
    End Sub

    ''' <summary>
    ''' see if the key pressed is a key corresponding to the key assigned in the option,
    ''' if it is the case it will do the corresponding task
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData">The key's</param>
    ''' <remarks>this is an infinite recursive function.</remarks>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = FOptions.getKeyCodeOfTmu AndAlso selectedMode = BoxOfGrid.BoxState.UNMASK Then
            selectedMode = BoxOfGrid.BoxState.MARK
            Bcmdchange.Text = "Mark"
            Bcmdchange.BackColor = Color.DarkRed

            Me.Bcmdchange.Focus()
        ElseIf keyData = FOptions.getKeyCodeOfTmu AndAlso selectedMode = BoxOfGrid.BoxState.MARK Then
            selectedMode = BoxOfGrid.BoxState.UNMASK
            Bcmdchange.Text = "Unmask"
            Bcmdchange.BackColor = Color.MidnightBlue

            Me.Bcmdchange.Focus()
        End If

        If keyData = FOptions.getKeyCodeOfTpause Then
            Me.Bpause.PerformClick()
            Me.Bpause.Focus()
        End If

        If keyData = FOptions.getkeyCodeOfTHelp Then
            Me.Bhelp.PerformClick()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ''' <summary>
    ''' Updates the timer for each second and save the game as lost if it ends.
    ''' </summary>
    ''' <see cref="saveGameLost(String, UInteger, UInteger, GamePlayed.Difficulties)"/>
    Private Sub timer1_tick_manage()
        Me.Ttimer.Text = timeLeft
        timeLeft -= 1

        If timeLeft < 0 Then
            Me.TimerGame.Stop()
            MsgBox("You discovered " & Grid.getNbOfUnmaskedBoxes() &
                   " boxes in " & (timeMax - Me.Ttimer.Text) & " seconds.", vbOKOnly, "End game")
            Players.saveGameLost(FMenu.CBname.Text, Grid.getNbOfUnmaskedBoxes() _
                                     , timeMax - Me.Ttimer.Text, GamePlayed.getDifficultyOf(FOptions.getDifficulty))
            Me.Close()
            FMenu.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerGame.Tick
        timer1_tick_manage()
    End Sub

    Private Sub Bpause_Click(sender As Object, e As EventArgs) Handles Bpause.Click
        If Not isPause AndAlso Me.Ttimer.Text <> "--" Then
            isPause = True
            Me.TimerGame.Stop()
        ElseIf isPause AndAlso Me.Ttimer.Text <> "--" Then
            isPause = False
            Me.TimerGame.Start()
        End If
    End Sub

    ''' <summary>
    ''' Manages the quit button.
    ''' We stop the game's timer and ask the player
    ''' if he really wants to leave the game.
    ''' If he chooses "Yes", the actual game will be saved as "lost"
    ''' if it started, the application will close the form
    ''' and it will show up the "menu".
    ''' If the player chooses "No", the game will continu.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <see cref="saveGameLost(String, UInteger, UInteger, GamePlayed.Difficulties)"/>
    Private Sub Bquit_Click(sender As Object, e As EventArgs) Handles Bquit.Click
        Me.TimerGame.Stop() 'we stop Timer1 because it is on another window
        Dim result As MsgBoxResult
        result = MsgBox("Are you sure you want to leave the game?", vbYesNo, "Confirmation")

        If result = vbYes Then
            If Me.Ttimer.Text = "--" Then Me.Ttimer.Text = timeMax
            If Grid.getNbOfUnmaskedBoxes() > 0 Then
                Players.saveGameLost(FMenu.CBname.Text, Grid.getNbOfUnmaskedBoxes() _
                                     , timeMax - Me.Ttimer.Text, GamePlayed.getDifficultyOf(FOptions.getDifficulty))
            End If
            Me.Close()
            FMenu.Show()
        ElseIf result = vbNo AndAlso Me.Ttimer.Text <> "--" AndAlso Not isPause Then
            Me.TimerGame.Start()
        End If
    End Sub

    ''' <summary>
    ''' Generates randomly a new correct move and
    ''' it will disable the button if the player used all the allowed help.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Bhelp_Click(sender As Object, e As EventArgs) Handles Bhelp.Click
        If nbHelp < maxHelp Then
            Dim nm As String = Grid.choiceMove 'new move
            Dim numBox As UInteger = Utile.numOfBox(nm)

            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeName(ctrl) = "Button" Then
                    Dim btn As Button = ctrl
                    If IsNumeric(Utile.numOfBox(btn.Name)) Then
                        If numBox = Utile.numOfBox(btn.Name) Then
                            If nm(0) = "U" Then
                                btn.BackColor = Color.MidnightBlue
                            Else
                                btn.BackColor = Color.DarkRed
                            End If
                            nbHelp += 1
                        End If
                    End If
                End If
            Next ctrl
        End If
        If nbHelp = maxHelp Then
            Bhelp.Enabled = False
            Bhelp.BackColor = Color.Transparent
            Bquit.Focus()
        End If
    End Sub
End Class