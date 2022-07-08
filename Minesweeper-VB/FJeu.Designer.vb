<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FJeu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TimerGame = New System.Windows.Forms.Timer(Me.components)
        Me.Ttimer = New System.Windows.Forms.TextBox()
        Me.Bcmdchange = New System.Windows.Forms.Button()
        Me.Bquit = New System.Windows.Forms.Button()
        Me.Bpause = New System.Windows.Forms.Button()
        Me.Lname = New System.Windows.Forms.Label()
        Me.Bnbflags = New System.Windows.Forms.Button()
        Me.Bhelp = New System.Windows.Forms.Button()
        Me.TimerHelp = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TimerGame
        '
        '
        'Ttimer
        '
        Me.Ttimer.Location = New System.Drawing.Point(46, 73)
        Me.Ttimer.Multiline = True
        Me.Ttimer.Name = "Ttimer"
        Me.Ttimer.Size = New System.Drawing.Size(60, 40)
        Me.Ttimer.TabIndex = 0
        '
        'Bcmdchange
        '
        Me.Bcmdchange.Location = New System.Drawing.Point(38, 226)
        Me.Bcmdchange.Name = "Bcmdchange"
        Me.Bcmdchange.Size = New System.Drawing.Size(75, 23)
        Me.Bcmdchange.TabIndex = 1
        Me.Bcmdchange.Text = "Unmask"
        Me.Bcmdchange.UseVisualStyleBackColor = True
        '
        'Bquit
        '
        Me.Bquit.Location = New System.Drawing.Point(38, 304)
        Me.Bquit.Name = "Bquit"
        Me.Bquit.Size = New System.Drawing.Size(75, 23)
        Me.Bquit.TabIndex = 2
        Me.Bquit.Text = "Quit"
        Me.Bquit.UseVisualStyleBackColor = True
        '
        'Bpause
        '
        Me.Bpause.Location = New System.Drawing.Point(38, 265)
        Me.Bpause.Name = "Bpause"
        Me.Bpause.Size = New System.Drawing.Size(75, 23)
        Me.Bpause.TabIndex = 3
        Me.Bpause.Text = "Pause"
        Me.Bpause.UseVisualStyleBackColor = True
        '
        'Lname
        '
        Me.Lname.AutoSize = True
        Me.Lname.Location = New System.Drawing.Point(145, 31)
        Me.Lname.Name = "Lname"
        Me.Lname.Size = New System.Drawing.Size(35, 13)
        Me.Lname.TabIndex = 4
        Me.Lname.Text = "Name"
        '
        'Bnbflags
        '
        Me.Bnbflags.Enabled = False
        Me.Bnbflags.Location = New System.Drawing.Point(46, 139)
        Me.Bnbflags.Name = "Bnbflags"
        Me.Bnbflags.Size = New System.Drawing.Size(58, 30)
        Me.Bnbflags.TabIndex = 5
        Me.Bnbflags.UseVisualStyleBackColor = True
        '
        'Bhelp
        '
        Me.Bhelp.Location = New System.Drawing.Point(55, 186)
        Me.Bhelp.Name = "Bhelp"
        Me.Bhelp.Size = New System.Drawing.Size(40, 25)
        Me.Bhelp.TabIndex = 6
        Me.Bhelp.Text = "Help"
        Me.Bhelp.UseVisualStyleBackColor = True
        '
        'FJeu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 385)
        Me.Controls.Add(Me.Bhelp)
        Me.Controls.Add(Me.Bnbflags)
        Me.Controls.Add(Me.Lname)
        Me.Controls.Add(Me.Bpause)
        Me.Controls.Add(Me.Bquit)
        Me.Controls.Add(Me.Bcmdchange)
        Me.Controls.Add(Me.Ttimer)
        Me.Name = "FJeu"
        Me.Text = "Minesweeper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TimerGame As Timer
    Friend WithEvents Ttimer As TextBox
    Friend WithEvents Bcmdchange As Button
    Friend WithEvents Bquit As Button
    Friend WithEvents Bpause As Button
    Friend WithEvents Lname As Label
    Friend WithEvents Bnbflags As Button
    Friend WithEvents Bhelp As Button
    Friend WithEvents TimerHelp As Timer
End Class
