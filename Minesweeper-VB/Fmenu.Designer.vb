<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMenu
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
        Me.CBname = New System.Windows.Forms.ComboBox()
        Me.Bnewgame = New System.Windows.Forms.Button()
        Me.Bexit = New System.Windows.Forms.Button()
        Me.Bhistoric = New System.Windows.Forms.Button()
        Me.Boptions = New System.Windows.Forms.Button()
        Me.PBlogo = New System.Windows.Forms.PictureBox()
        Me.BplayersRecord = New System.Windows.Forms.Button()
        CType(Me.PBlogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBname
        '
        Me.CBname.FormattingEnabled = True
        Me.CBname.Location = New System.Drawing.Point(91, 154)
        Me.CBname.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CBname.Name = "CBname"
        Me.CBname.Size = New System.Drawing.Size(163, 24)
        Me.CBname.TabIndex = 0
        '
        'Bnewgame
        '
        Me.Bnewgame.BackColor = System.Drawing.SystemColors.Control
        Me.Bnewgame.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Bnewgame.Location = New System.Drawing.Point(122, 202)
        Me.Bnewgame.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bnewgame.Name = "Bnewgame"
        Me.Bnewgame.Size = New System.Drawing.Size(100, 28)
        Me.Bnewgame.TabIndex = 1
        Me.Bnewgame.Text = "New Game"
        Me.Bnewgame.UseVisualStyleBackColor = False
        '
        'Bexit
        '
        Me.Bexit.Location = New System.Drawing.Point(122, 305)
        Me.Bexit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bexit.Name = "Bexit"
        Me.Bexit.Size = New System.Drawing.Size(100, 28)
        Me.Bexit.TabIndex = 2
        Me.Bexit.Text = "Exit"
        Me.Bexit.UseVisualStyleBackColor = True
        '
        'Bhistoric
        '
        Me.Bhistoric.Location = New System.Drawing.Point(122, 254)
        Me.Bhistoric.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bhistoric.Name = "Bhistoric"
        Me.Bhistoric.Size = New System.Drawing.Size(100, 28)
        Me.Bhistoric.TabIndex = 3
        Me.Bhistoric.Text = "Historic"
        Me.Bhistoric.UseVisualStyleBackColor = True
        '
        'Boptions
        '
        Me.Boptions.Location = New System.Drawing.Point(13, 351)
        Me.Boptions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Boptions.Name = "Boptions"
        Me.Boptions.Size = New System.Drawing.Size(43, 42)
        Me.Boptions.TabIndex = 4
        Me.Boptions.UseVisualStyleBackColor = True
        '
        'PBlogo
        '
        Me.PBlogo.Location = New System.Drawing.Point(31, 21)
        Me.PBlogo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PBlogo.Name = "PBlogo"
        Me.PBlogo.Size = New System.Drawing.Size(282, 110)
        Me.PBlogo.TabIndex = 5
        Me.PBlogo.TabStop = False
        '
        'BplayersRecord
        '
        Me.BplayersRecord.Location = New System.Drawing.Point(252, 351)
        Me.BplayersRecord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BplayersRecord.Name = "BplayersRecord"
        Me.BplayersRecord.Size = New System.Drawing.Size(79, 42)
        Me.BplayersRecord.TabIndex = 6
        Me.BplayersRecord.Text = "Players record"
        Me.BplayersRecord.UseVisualStyleBackColor = True
        '
        'FMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 406)
        Me.Controls.Add(Me.BplayersRecord)
        Me.Controls.Add(Me.PBlogo)
        Me.Controls.Add(Me.Boptions)
        Me.Controls.Add(Me.Bhistoric)
        Me.Controls.Add(Me.Bexit)
        Me.Controls.Add(Me.Bnewgame)
        Me.Controls.Add(Me.CBname)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FMenu"
        Me.Text = "Menu"
        CType(Me.PBlogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CBname As ComboBox
    Friend WithEvents Bnewgame As Button
    Friend WithEvents Bexit As Button
    Friend WithEvents Bhistoric As Button
    Friend WithEvents Boptions As Button
    Friend WithEvents PBlogo As PictureBox
    Friend WithEvents BplayersRecord As Button
End Class
