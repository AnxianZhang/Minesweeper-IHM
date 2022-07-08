<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FHistoric
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LBname = New System.Windows.Forms.ListBox()
        Me.Breturn = New System.Windows.Forms.Button()
        Me.LBtime = New System.Windows.Forms.ListBox()
        Me.LBdiscoveredbox = New System.Windows.Forms.ListBox()
        Me.Lname = New System.Windows.Forms.Label()
        Me.Ltimeplayes = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBdifficulty = New System.Windows.Forms.ListBox()
        Me.Ldifficulty = New System.Windows.Forms.Label()
        Me.LBstate = New System.Windows.Forms.ListBox()
        Me.Lstate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LBname
        '
        Me.LBname.FormattingEnabled = True
        Me.LBname.Location = New System.Drawing.Point(23, 47)
        Me.LBname.Name = "LBname"
        Me.LBname.Size = New System.Drawing.Size(133, 121)
        Me.LBname.TabIndex = 0
        '
        'Breturn
        '
        Me.Breturn.Location = New System.Drawing.Point(196, 197)
        Me.Breturn.Name = "Breturn"
        Me.Breturn.Size = New System.Drawing.Size(75, 23)
        Me.Breturn.TabIndex = 1
        Me.Breturn.Text = "Return"
        Me.Breturn.UseVisualStyleBackColor = True
        '
        'LBtime
        '
        Me.LBtime.FormattingEnabled = True
        Me.LBtime.Location = New System.Drawing.Point(233, 47)
        Me.LBtime.Name = "LBtime"
        Me.LBtime.Size = New System.Drawing.Size(67, 121)
        Me.LBtime.TabIndex = 2
        '
        'LBdiscoveredbox
        '
        Me.LBdiscoveredbox.FormattingEnabled = True
        Me.LBdiscoveredbox.Location = New System.Drawing.Point(305, 47)
        Me.LBdiscoveredbox.Name = "LBdiscoveredbox"
        Me.LBdiscoveredbox.Size = New System.Drawing.Size(67, 121)
        Me.LBdiscoveredbox.TabIndex = 3
        '
        'Lname
        '
        Me.Lname.AutoSize = True
        Me.Lname.Location = New System.Drawing.Point(56, 19)
        Me.Lname.Name = "Lname"
        Me.Lname.Size = New System.Drawing.Size(75, 13)
        Me.Lname.TabIndex = 4
        Me.Lname.Text = "Players names"
        '
        'Ltimeplayes
        '
        Me.Ltimeplayes.AutoSize = True
        Me.Ltimeplayes.Location = New System.Drawing.Point(235, 19)
        Me.Ltimeplayes.Name = "Ltimeplayes"
        Me.Ltimeplayes.Size = New System.Drawing.Size(64, 13)
        Me.Ltimeplayes.TabIndex = 5
        Me.Ltimeplayes.Text = "Time played"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(309, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 26)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Discovered" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "boxes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LBdifficulty
        '
        Me.LBdifficulty.FormattingEnabled = True
        Me.LBdifficulty.Location = New System.Drawing.Point(377, 47)
        Me.LBdifficulty.Name = "LBdifficulty"
        Me.LBdifficulty.Size = New System.Drawing.Size(67, 121)
        Me.LBdifficulty.TabIndex = 7
        '
        'Ldifficulty
        '
        Me.Ldifficulty.AutoSize = True
        Me.Ldifficulty.Location = New System.Drawing.Point(388, 19)
        Me.Ldifficulty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Ldifficulty.Name = "Ldifficulty"
        Me.Ldifficulty.Size = New System.Drawing.Size(47, 13)
        Me.Ldifficulty.TabIndex = 8
        Me.Ldifficulty.Text = "Difficulty"
        '
        'LBstate
        '
        Me.LBstate.FormattingEnabled = True
        Me.LBstate.Location = New System.Drawing.Point(161, 47)
        Me.LBstate.Name = "LBstate"
        Me.LBstate.Size = New System.Drawing.Size(67, 121)
        Me.LBstate.TabIndex = 9
        '
        'Lstate
        '
        Me.Lstate.AutoSize = True
        Me.Lstate.Location = New System.Drawing.Point(179, 19)
        Me.Lstate.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lstate.Name = "Lstate"
        Me.Lstate.Size = New System.Drawing.Size(32, 13)
        Me.Lstate.TabIndex = 10
        Me.Lstate.Text = "State"
        '
        'FHistoric
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 230)
        Me.Controls.Add(Me.Lstate)
        Me.Controls.Add(Me.LBstate)
        Me.Controls.Add(Me.Ldifficulty)
        Me.Controls.Add(Me.LBdifficulty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Ltimeplayes)
        Me.Controls.Add(Me.Lname)
        Me.Controls.Add(Me.LBdiscoveredbox)
        Me.Controls.Add(Me.LBtime)
        Me.Controls.Add(Me.Breturn)
        Me.Controls.Add(Me.LBname)
        Me.Name = "FHistoric"
        Me.Text = "History of games"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBname As ListBox
    Friend WithEvents Breturn As Button
    Friend WithEvents LBtime As ListBox
    Friend WithEvents LBdiscoveredbox As ListBox
    Friend WithEvents Lname As Label
    Friend WithEvents Ltimeplayes As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBdifficulty As ListBox
    Friend WithEvents Ldifficulty As Label
    Friend WithEvents LBstate As ListBox
    Friend WithEvents Lstate As Label
End Class
