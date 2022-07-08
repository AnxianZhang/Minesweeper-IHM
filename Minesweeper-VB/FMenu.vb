Public Class FMenu

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

    ''' <summary>
    ''' Center the position of a form under the previous one's.
    ''' </summary>
    ''' <param name="form">The form which should be centered.</param>
    ''' <param name="parent">The previous form.</param>
    Public Sub CenterForm(form As Form, parent As Form)
        Dim r As Rectangle

        r = parent.RectangleToScreen(parent.ClientRectangle)

        Dim x = r.Left + (r.Width - form.Width) \ 2
        Dim y = r.Top + (r.Height - form.Height) \ 2
        form.Location = New Point(x, y)
    End Sub

    ''' <summary>
    ''' Add the names collected in the list
    ''' of player into the combobox "CBName".
    ''' </summary>
    ''' <see cref="Players.getNbPlayer()"/>
    ''' <see cref="Players.getName(UInteger)"/>
    Public Sub addToCBName()
        For i As UInteger = 0 To Players.getNbPlayer() - 1
            Me.CBname.Items.Add(Players.getName(i))
        Next i
    End Sub

    Public Sub clearCBnom()
        Me.CBname.Items.Clear()
    End Sub

    Private Sub FAccueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'everything below are default values
        FOptions.Theme()
        Me.CenterToScreen()

        CBnomDefaultText()
        Me.CBname.MaxLength = 21
        Me.CBname.AutoCompleteMode = AutoCompleteMode.Suggest
        Me.CBname.AutoCompleteSource = AutoCompleteSource.ListItems

        Me.Bexit.Focus()

        Dim optionImg As Image = Image.FromFile("..\\..\\image\\option.png")
        Me.Boptions.Image = New Bitmap(optionImg, New Size(30, 30))

        Dim logoImg As Image = Image.FromFile("..\\..\\image\\logo.png")
        Me.PBlogo.Image = New Bitmap(logoImg, New Size(PBlogo.Width, PBlogo.Height))

        Me.Icon = New Icon("..\\..\\image\\icon\\menu.ico")
    End Sub

    Private Sub CBnomDefaultText()
        Me.CBname.Text = "Select or add a name"
        Me.CBname.ForeColor = Color.Gray
    End Sub

    Private Sub Bhistoric_Click(sender As Object, e As EventArgs) Handles Bhistoric.Click
        Me.Hide()
        CenterForm(FHistoric, Me)
        FHistoric.Show()
    End Sub

    Private Sub CBnom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBname.Click
        If Me.CBname.Text = "" OrElse Me.CBname.Text = "Select or add a name" Then Me.CBname.Text = ""
    End Sub

    Private Sub CBnom_LostFocus(sender As Object, e As EventArgs) Handles CBname.LostFocus
        If (Me.CBname.Text = "") Then CBnomDefaultText()
    End Sub

    Private cpt = 0

    Private Sub CBnom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CBname.KeyPress
        Me.CBname.ForeColor = Color.Black
    End Sub

    ''' <summary>
    ''' Starts the game form if the name entered has at least 3 characters
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Bnewgame_Click(sender As Object, e As EventArgs) Handles Bnewgame.Click
        If Me.CBname.Text.Length < 3 OrElse Me.CBname.Text = "Select or add a name" Then
            MsgBox("You must enter at least one name of 3 characters !", vbOKOnly, "Error")
        Else
            If Not Me.CBname.Items.Contains(Me.CBname.Text) Then
                Me.CBname.Items.Add(Me.CBname.Text)
            End If

            Me.Hide()
            FJeu.Show()
        End If
    End Sub

    ''' <summary>
    ''' asks the user if he wants to quit the game and then asks if he wants to save the games he has played
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <see cref="FOptions.getFilePath()"/>
    ''' <see cref="Players.getNbPlayer()"/>
    ''' <see cref="Players.savePlayersOnFile(String)"/>
    ''' <see cref="Utile.getFileName(String)"/>
    Private Sub Bexit_Click(sender As Object, e As EventArgs) Handles Bexit.Click
        Dim quitResult As MsgBoxResult
        quitResult = MsgBox("Do you want to leave the application?", vbYesNo, "Confirmation")
        Dim filaPath As String = FOptions.getFilePath()

        If quitResult = vbYes Then
            If Players.getNbPlayer() <> 0 Then
                Dim saveResult As MsgBoxResult
                saveResult = MsgBox("Do you want to save the game ?", vbYesNo, "Confirmation")

                If saveResult = vbYes Then
                    Dim wantToSaveInAnotherName As MsgBoxResult
                    wantToSaveInAnotherName = MsgBox("Do you want to save it in another name ?", vbYesNo, "Save")

                    If wantToSaveInAnotherName = vbYes Then
                        Dim fileName As String
                        fileName = InputBox("Under which name do you want to register the game ?", "Save")
                        Players.savePlayersOnFile(fileName)
                    Else
                        Players.savePlayersOnFile(Utile.getFileName(filaPath))
                    End If
                End If
                Me.Close()
            Else
                Me.Close()
            End If
        End If
    End Sub


    Private Sub Boptions_Click(sender As Object, e As EventArgs) Handles Boptions.Click
        Me.Hide()
        CenterForm(FHistoric, Me)
        FOptions.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BplayersRecord.Click
        Me.Hide()
        CenterForm(FHistoric, Me)
        FPlayersRecord.Show()
    End Sub
End Class