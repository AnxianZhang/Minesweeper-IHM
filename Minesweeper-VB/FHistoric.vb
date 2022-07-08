Public Class FHistoric

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

    Private Sub FHistoric_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FMenu.CenterForm(Me, FMenu)
        Me.Icon = New Icon("..\\..\\image\\icon\\historic.ico")
    End Sub

    Private Sub Breturn_Click(sender As Object, e As EventArgs) Handles Breturn.Click
        Me.Hide()
        FMenu.CenterForm(FMenu, Me)
        FMenu.Show()
    End Sub

    ''' <summary>
    ''' Shows the details of a selected player when it changed.
    ''' </summary>
    ''' <param name="sender">The selected player's name in the listBox.</param>
    ''' <param name="e"></param>
    ''' <see cref="Players.convSeconds(Double)"/>
    Private Sub LBname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBname.SelectedIndexChanged
        Dim lb As ListBox = sender
        Dim idxP As UInteger = Players.getIdxPlayer(lb.SelectedItem)

        'empties at each opening, avoids data repetition
        Me.LBdiscoveredbox.Items.Clear()
        Me.LBtime.Items.Clear()
        Me.LBdifficulty.Items.Clear()
        Me.LBstate.Items.Clear()

        For j As Integer = Players.getNbGamePlayed(idxP) - 1 To 0 Step -1
            Dim pTime As UInteger = Players.getTimePlayed(idxP, j)
            Dim pScore As UInteger = Players.getScore(idxP, j)
            Dim pDifficulty As String = Players.getDifficulty(idxP, j)
            Dim pGameState As StateOfGame.State = Players.getStateOfGame(idxP, j)
            Dim state As String = ""

            If pGameState = StateOfGame.State.GAME_LOST Then
                state = "Lost"
            Else
                state = "Won"
            End If
            If pTime = 0 AndAlso pScore = 0 Then
                Me.LBtime.Items.Add("--")
                Me.LBdiscoveredbox.Items.Add("--")
                Me.LBdifficulty.Items.Add(GamePlayed.getStringDifficultyOf(pDifficulty))
                Me.LBstate.Items.Add(state)
            Else
                Me.LBtime.Items.Add(Players.convSeconds(pTime))
                Me.LBdiscoveredbox.Items.Add(pScore)
                Me.LBdifficulty.Items.Add(GamePlayed.getStringDifficultyOf(pDifficulty))
                Me.LBstate.Items.Add(state)
            End If
        Next j
    End Sub

    ''' <summary>
    ''' When the selected index of a listbox (which is not a player's name)
    ''' changed, it selects all the datas which describe the same game. 
    ''' </summary>
    ''' <param name="sender">The selected data which has been changed.</param>
    ''' <param name="e"></param>
    Private Sub LBtime_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles LBtime.SelectedIndexChanged, LBdiscoveredbox.SelectedIndexChanged, LBdifficulty.SelectedIndexChanged, LBstate.SelectedIndexChanged

        Dim lb As ListBox = sender
        If lb.Name = "LBdiscoveredbox" Then
            Me.LBtime.SelectedIndex = lb.SelectedIndex
            Me.LBdifficulty.SelectedIndex = lb.SelectedIndex
            Me.LBstate.SelectedIndex = lb.SelectedIndex
        End If

        If lb.Name = "LBtime" Then
            Me.LBdiscoveredbox.SelectedIndex = lb.SelectedIndex
            Me.LBdifficulty.SelectedIndex = lb.SelectedIndex
            Me.LBstate.SelectedIndex = lb.SelectedIndex
        End If

        If lb.Name = "LBdifficulty" Then
            Me.LBdiscoveredbox.SelectedIndex = lb.SelectedIndex
            Me.LBtime.SelectedIndex = lb.SelectedIndex
            Me.LBstate.SelectedIndex = lb.SelectedIndex
        End If

        If lb.Name = "LBstate" Then
            Me.LBdiscoveredbox.SelectedIndex = lb.SelectedIndex
            Me.LBtime.SelectedIndex = lb.SelectedIndex
            Me.LBdifficulty.SelectedIndex = lb.SelectedIndex
        End If
    End Sub

    ''' <summary>
    ''' Updates the form's content each time it is opened.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FHistoric_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            'empties at each opening, avoids data repetition
            Me.LBname.Items.Clear()
            Me.LBdiscoveredbox.Items.Clear()
            Me.LBtime.Items.Clear()
            Me.LBdifficulty.Items.Clear()
            Me.LBstate.Items.Clear()

            If Players.getNbPlayer() <> 0 Then
                For i As UInteger = 0 To Players.getNbPlayer() - 1
                    Me.LBname.Items.Add(Players.getName(i))
                Next i
            End If
        End If
    End Sub
End Class