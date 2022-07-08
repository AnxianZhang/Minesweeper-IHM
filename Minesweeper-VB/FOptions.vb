Public Class FOptions
    Private keyCodeOfTmu = 0
    Private keyCodeOfTpause = 0
    Private keyCodeOfTHelp = 0

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
    ''' Sets the color theme of a specific form 
    ''' </summary>
    ''' <param name="f"></param>
    ''' <param name="FbC"></param>
    ''' <see cref="changeTheme(Form, Color, Color)"/>
    Public Sub Theme(Optional f As Form = Nothing, Optional FbC As Color = Nothing)
        Dim fC As Color 'form color
        Dim cC As Color 'control color
        If FbC = Nothing Then
            fC = Color.Lavender
        Else
            fC = FbC
        End If

        cC = Color.GhostWhite

        If f Is Nothing Then
            changeTheme(Me, fC, cC)
            changeTheme(FMenu, fC, cC)
            changeTheme(FHistoric, fC, cC)
            changeTheme(FJeu, fC, cC)
            changeTheme(FPlayersRecord, fC, cC)
        Else
            changeTheme(FJeu, fC, cC)
        End If
    End Sub

    ''' <summary>
    ''' Affects a specific form's background color
    ''' and the color of its controls.
    ''' </summary>
    ''' <param name="f"></param>
    ''' <param name="fC"></param>
    ''' <param name="cC"></param>
    Private Sub changeTheme(f As Form, fC As Color, cC As Color)
        f.BackColor = fC
        Dim GB As GroupBox = Nothing
        For Each ctrl As Control In f.Controls
            If TypeName(ctrl) = "Button" Then
                ctrl.BackColor = cC
            ElseIf TypeName(ctrl) = "GroupBox" Then
                GB = ctrl
                For Each ctrl2 As Control In GB.Controls
                    If TypeName(ctrl2) = "Button" AndAlso ctrl2.Enabled Then
                        ctrl2.BackColor = cC
                    End If
                Next ctrl2
            End If
        Next ctrl
    End Sub

    ''' <summary>
    ''' Looks for the theme which has been chosen and applies it.
    ''' </summary>
    ''' <param name="f">The form where the theme should be applied.</param>
    ''' <see cref="Theme(Form, Color)"/>
    Public Sub themeChoice(Optional f As Form = Nothing)
        If Not Blightpink.Enabled Then
            Theme(, Color.LightPink)
        ElseIf Not BblanchedAlmond.Enabled Then
            Theme(, Color.BlanchedAlmond)
        ElseIf Not BLightSteelBlue.Enabled Then
            Theme(, Color.LightSteelBlue)
        ElseIf Not BLightCoral.Enabled Then
            Theme(, Color.LightCoral)
        Else
            Theme()
        End If
    End Sub

    ''' <summary>
    ''' Looks for the selected difficulty.
    ''' </summary>
    ''' <returns>the difficulty selected</returns>
    Public Function selectedDifficulty() As String
        Dim btn As Button
        Dim s As String = ""
        For Each btn In GBdifficulty.Controls
            If Not btn.Enabled Then
                s = btn.Text
            End If
        Next btn
        Return s
    End Function

    Private defaultMUkeypress = "c" ' MU = mark/unmask
    Private defaultPausekeypress = "p"
    Private defaultHelpkeypress = "h"

    Private Sub FOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme()
        FMenu.CenterForm(Me, FMenu)

        Me.Icon = New Icon("image\\icon\\option.ico")

        ' indicate default settings
        Me.Beasy.BackColor = Color.Transparent
        Me.BLavender.Enabled = False
        Me.BLavender.BackColor = Color.Transparent

        Me.RBdeactivated.Checked = True

        Me.Tnewmu.Text = defaultMUkeypress
        Me.Tnewmu.MaxLength = 1
        Me.Tnewpause.Text = defaultPausekeypress
        Me.Tnewpause.MaxLength = 1
        Me.TnewHelp.Text = defaultHelpkeypress
        Me.TnewHelp.MaxLength = 1

    End Sub

    Private Sub Breturn_Click(sender As Object, e As EventArgs) Handles Breturn.Click
        Me.Hide()
        FMenu.Show()
    End Sub

    ''' <summary>
    ''' Manage the aspect of a groupBox's buttons.
    ''' </summary>
    ''' <param name="gB">The groupBox.</param>
    Private Sub disableEnabledButton(gB As GroupBox)
        Dim btn As Button
        For Each btn In gB.Controls
            If Not btn.Enabled Then
                btn.Enabled = True
                btn.BackColor = Color.GhostWhite
            End If
        Next btn
    End Sub

    ''' <summary>
    ''' Changed the selected buttont into enable and change the difficulty
    ''' </summary>
    ''' <param name="sender">the button</param>
    ''' <param name="e"></param>
    ''' <see cref="disableEnabledButton(GroupBox)"/>
    Private Sub Bdifficulty_Click(sender As Object, e As EventArgs) _
        Handles Beasy.Click, Bnormal.Click, Bhard.Click, Bexetreme.Click, BnoSense.Click
        Dim btn As Button = sender
        disableEnabledButton(GBdifficulty)
        btn.Enabled = False
        btn.BackColor = Color.Transparent
        Breturn.Focus()
    End Sub

    ''' <summary>
    ''' Changed the selected button into enable and the theme of the application
    ''' </summary>
    ''' <param name="sender">the button</param>
    ''' <param name="e"></param>
    ''' <see cref="disableEnabledButton(GroupBox)"/>
    ''' <see cref="themeChoice(Form)"/>
    Private Sub Btheme_Click(sender As Object, e As EventArgs) _
        Handles BLavender.Click, Blightpink.Click, BblanchedAlmond.Click, BLightSteelBlue.Click, BLightCoral.Click
        Dim btn As Button = sender
        disableEnabledButton(GBtheme)
        btn.Enabled = False
        btn.BackColor = Color.Transparent
        themeChoice()
        Breturn.Focus()
    End Sub

    ''' <summary>
    ''' Retun the difficuty selected
    ''' </summary>
    ''' <returns>the difficulty</returns>
    Public Function getDifficulty() As String
        Dim btn As Button
        For Each btn In GBdifficulty.Controls
            If Not btn.Enabled Then
                Return btn.Text
            End If
        Next btn
        Return "Easy"
    End Function

    Private Function isEmpty(t As TextBox) As Boolean
        Return t.Text = ""
    End Function

    ''' <summary>
    ''' sets the default value if the text box is empty
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tmu_LostFocus(sender As Object, e As EventArgs) Handles Tnewmu.LostFocus
        If isEmpty(Me.Tnewmu) Then Me.Tnewmu.Text = defaultMUkeypress
    End Sub

    ''' <summary>
    ''' sets the default value if the text box is empty
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tpause_LostFocus(sender As Object, e As EventArgs) Handles Tnewpause.LostFocus
        If isEmpty(Me.Tnewpause) Then Me.Tnewpause.Text = defaultPausekeypress
    End Sub

    ''' <summary>
    ''' sets the default value if the text box is empty
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TnewHelp_LostFocus(sender As Object, e As EventArgs) Handles TnewHelp.LostFocus
        If isEmpty(Me.TnewHelp) Then Me.TnewHelp.Text = defaultHelpkeypress
    End Sub

    ''' <summary>
    ''' takes the keycode of the pressed key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tmu_KeyDown(sender As Object, e As KeyEventArgs) Handles Tnewmu.KeyUp
        If Me.Tnewmu.Text <> Me.TnewHelp.Text Or Me.Tnewmu.Text <> Me.Tnewpause.Text Then
            keyCodeOfTmu = e.KeyCode
        End If
    End Sub

    ''' <summary>
    ''' takes the keycode of the pressed key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tpause_KeyDown(sender As Object, e As KeyEventArgs) Handles Tnewpause.KeyUp
        If Me.Tnewpause.Text <> Me.TnewHelp.Text Or Me.Tnewpause.Text <> Me.Tnewmu.Text Then
            keyCodeOfTpause = e.KeyCode
        End If
    End Sub

    ''' <summary>
    ''' takes the keycode of the pressed key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TnewHelp_KeyDown(sender As Object, e As KeyEventArgs) Handles TnewHelp.KeyUp
        If Me.TnewHelp.Text <> Me.Tnewmu.Text Or Me.TnewHelp.Text <> Me.Tnewpause.Text Then
            keyCodeOfTHelp = e.KeyCode
        End If
    End Sub

    Public Function getKeyCodeOfTmu() As UInteger
        If keyCodeOfTmu = 0 Then Return 67 'default keybord key
        Return keyCodeOfTmu
    End Function

    Public Function getKeyCodeOfTpause() As UInteger
        If keyCodeOfTpause = 0 Then Return 80 'default keybord key
        Return keyCodeOfTpause
    End Function

    Public Function getkeyCodeOfTHelp() As UInteger
        If keyCodeOfTHelp = 0 Then Return 72 'default keybord key
        Return keyCodeOfTHelp
    End Function

    Public Function getFilePath()
        Return Me.TxmlDoc.Text
    End Function

    ''' <summary>
    ''' Will try to laod players datas
    ''' </summary>
    Private Sub TxmlDoc_LostFocus_Manage()
        Try
            Players.loadPlayers(TxmlDoc.Text)
        Catch ex As Exception
            MsgBox("The path to your file does not exist.", vbOKOnly, "Error")
        End Try
    End Sub

    Private Sub TxmlDoc_LostFocus(sender As Object, e As EventArgs) Handles TxmlDoc.LostFocus
        If TxmlDoc.Text <> "" Then TxmlDoc_LostFocus_Manage()
    End Sub

    ''' <summary>
    ''' opens a file explorer when the button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <see cref="TxmlDoc_LostFocus_Manage()"/>
    ''' <see cref="Players.getNbPlayer()"/>
    ''' <see cref="FMenu.addToCBName()"/>
    Private Sub Bbrowse_Click(sender As Object, e As EventArgs) Handles Bbrowse.Click
        Dim explorer As New OpenFileDialog

        explorer.Filter = "Fichier xml (*.xml)|*.xml"
        explorer.RestoreDirectory = True

        If explorer.ShowDialog = DialogResult.OK Then
            Me.TxmlDoc.Text = explorer.FileName
            TxmlDoc_LostFocus_Manage()

            'updates the menu comboBox every time a new file is loaded
            FMenu.clearCBnom()
            FMenu.addToCBName()
        End If
    End Sub

    ''' <summary>
    ''' Manage the 3 texts box that change controls.
    ''' Will check if a asigned key is already asigned, if this key is
    ''' already asigned then it will reset the default key
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Tnew_TextChanged(sender As Object, e As EventArgs) _
        Handles Tnewmu.TextChanged, Tnewpause.TextChanged, TnewHelp.TextChanged
        Dim txt As TextBox = sender
        If txt.Name = "Tnewmu" Then
            If txt.Text = Me.TnewHelp.Text OrElse txt.Text = Me.Tnewpause.Text Then
                MsgBox(txt.Text & " is already used." & vbCrLf &
                       "please choose an unused key.", vbOKOnly, "Error")
                Me.Tnewmu.Text = ""
            End If
        ElseIf txt.Name = "Tnewpause" Then
            If txt.Text = Me.TnewHelp.Text OrElse txt.Text = Me.Tnewmu.Text Then
                MsgBox(txt.Text & " is already used." & vbCrLf &
                       "please choose an unused key.", vbOKOnly, "Error")
                Me.Tnewpause.Text = ""
            End If
        Else
            If txt.Text = Me.Tnewmu.Text OrElse txt.Text = Me.Tnewpause.Text Then
                MsgBox(txt.Text & " is already used." & vbCrLf &
                       "please choose an unused key.", vbOKOnly, "Error")
                Me.TnewHelp.Text = ""
            End If
        End If
    End Sub
End Class