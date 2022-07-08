<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPlayersRecord
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Breturn = New System.Windows.Forms.Button()
        Me.LBnames = New System.Windows.Forms.ListBox()
        Me.LBrecordDB = New System.Windows.Forms.ListBox()
        Me.LBtimeOfRecord = New System.Windows.Forms.ListBox()
        Me.Lname = New System.Windows.Forms.Label()
        Me.LRecordDB = New System.Windows.Forms.Label()
        Me.Lrecord = New System.Windows.Forms.Label()
        Me.Bsorted = New System.Windows.Forms.Button()
        Me.CBplayersdetails = New System.Windows.Forms.ComboBox()
        Me.BshowDetails = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Breturn
        '
        Me.Breturn.Location = New System.Drawing.Point(310, 212)
        Me.Breturn.Name = "Breturn"
        Me.Breturn.Size = New System.Drawing.Size(75, 23)
        Me.Breturn.TabIndex = 0
        Me.Breturn.Text = "Return"
        Me.Breturn.UseVisualStyleBackColor = True
        '
        'LBnames
        '
        Me.LBnames.FormattingEnabled = True
        Me.LBnames.Location = New System.Drawing.Point(15, 47)
        Me.LBnames.Name = "LBnames"
        Me.LBnames.Size = New System.Drawing.Size(120, 147)
        Me.LBnames.TabIndex = 1
        '
        'LBrecordDB
        '
        Me.LBrecordDB.FormattingEnabled = True
        Me.LBrecordDB.Location = New System.Drawing.Point(151, 47)
        Me.LBrecordDB.Name = "LBrecordDB"
        Me.LBrecordDB.Size = New System.Drawing.Size(120, 147)
        Me.LBrecordDB.TabIndex = 2
        '
        'LBtimeOfRecord
        '
        Me.LBtimeOfRecord.FormattingEnabled = True
        Me.LBtimeOfRecord.Location = New System.Drawing.Point(288, 47)
        Me.LBtimeOfRecord.Name = "LBtimeOfRecord"
        Me.LBtimeOfRecord.Size = New System.Drawing.Size(120, 147)
        Me.LBtimeOfRecord.TabIndex = 3
        '
        'Lname
        '
        Me.Lname.AutoSize = True
        Me.Lname.Location = New System.Drawing.Point(34, 18)
        Me.Lname.Name = "Lname"
        Me.Lname.Size = New System.Drawing.Size(75, 13)
        Me.Lname.TabIndex = 5
        Me.Lname.Text = "Players names"
        '
        'LRecordDB
        '
        Me.LRecordDB.Location = New System.Drawing.Point(155, 11)
        Me.LRecordDB.Name = "LRecordDB"
        Me.LRecordDB.Size = New System.Drawing.Size(112, 26)
        Me.LRecordDB.TabIndex = 7
        Me.LRecordDB.Text = "Record discovered " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "boxes"
        Me.LRecordDB.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Lrecord
        '
        Me.Lrecord.AutoSize = True
        Me.Lrecord.Location = New System.Drawing.Point(311, 18)
        Me.Lrecord.Name = "Lrecord"
        Me.Lrecord.Size = New System.Drawing.Size(75, 13)
        Me.Lrecord.TabIndex = 8
        Me.Lrecord.Text = "Time of record"
        '
        'Bsorted
        '
        Me.Bsorted.Location = New System.Drawing.Point(417, 47)
        Me.Bsorted.Name = "Bsorted"
        Me.Bsorted.Size = New System.Drawing.Size(23, 23)
        Me.Bsorted.TabIndex = 9
        Me.Bsorted.UseVisualStyleBackColor = True
        '
        'CBplayersdetails
        '
        Me.CBplayersdetails.FormattingEnabled = True
        Me.CBplayersdetails.Location = New System.Drawing.Point(15, 214)
        Me.CBplayersdetails.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CBplayersdetails.Name = "CBplayersdetails"
        Me.CBplayersdetails.Size = New System.Drawing.Size(120, 21)
        Me.CBplayersdetails.TabIndex = 10
        '
        'BshowDetails
        '
        Me.BshowDetails.Location = New System.Drawing.Point(172, 212)
        Me.BshowDetails.Name = "BshowDetails"
        Me.BshowDetails.Size = New System.Drawing.Size(75, 23)
        Me.BshowDetails.TabIndex = 11
        Me.BshowDetails.Text = "Show details"
        Me.BshowDetails.UseVisualStyleBackColor = True
        '
        'FPlayersRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 280)
        Me.Controls.Add(Me.BshowDetails)
        Me.Controls.Add(Me.CBplayersdetails)
        Me.Controls.Add(Me.Bsorted)
        Me.Controls.Add(Me.Lrecord)
        Me.Controls.Add(Me.LRecordDB)
        Me.Controls.Add(Me.Lname)
        Me.Controls.Add(Me.LBtimeOfRecord)
        Me.Controls.Add(Me.LBrecordDB)
        Me.Controls.Add(Me.LBnames)
        Me.Controls.Add(Me.Breturn)
        Me.Name = "FPlayersRecord"
        Me.Text = "Players Record"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Breturn As Button
    Friend WithEvents LBrecordDB As ListBox
    Friend WithEvents LBtimeOfRecord As ListBox
    Friend WithEvents LBnames As ListBox
    Friend WithEvents Lname As Label
    Friend WithEvents LRecordDB As Label
    Friend WithEvents Lrecord As Label
    Friend WithEvents Bsorted As Button
    Friend WithEvents CBplayersdetails As ComboBox
    Friend WithEvents BshowDetails As Button
End Class
