Public Class FPlayersRecord
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
    ''' Compares the best score of a player according to another one's.
    ''' </summary>
    ''' <param name="p1">The first player.</param>
    ''' <param name="p2">The player who is compared.</param>
    ''' <returns></returns>
    Private Function compareScore(p1 As Player, p2 As Player) As Integer
        Dim compareResult = p1.details.bestNbDiscoveredBoxes.CompareTo(p2.details.bestNbDiscoveredBoxes)
        If compareResult = 0 Then
            Return p1.details.timeOfBestRecord.CompareTo(p2.details.timeOfBestRecord)
        End If
        Return compareResult
    End Function

    Private Sub FPlayersRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FMenu.CenterForm(Me, FMenu)
        Me.Icon = New Icon("image\\icon\\record.ico")
        Me.Bsorted.Image = New Bitmap(Image.FromFile("image\\ascending.png"),
                                          New Size(Me.Bsorted.Width - 10, Me.Bsorted.Height - 10))
    End Sub

    Private Sub Breturn_Click(sender As Object, e As EventArgs) Handles Breturn.Click
        Me.Hide()
        FMenu.Show()
    End Sub

    ''' <summary>
    ''' Selecting one of the box lists, it selects the other box lists with the same index as the first one selected
    ''' </summary>
    ''' <param name="sender">the List box thant has been cliqued</param>
    ''' <param name="e"></param>
    Private Sub ListBoxes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles LBnames.SelectedIndexChanged, LBrecordDB.SelectedIndexChanged, LBtimeOfRecord.SelectedIndexChanged

        Dim lb As ListBox = sender
        If lb.Name = "LBnames" Then
            Me.LBrecordDB.SelectedIndex = lb.SelectedIndex
            Me.LBtimeOfRecord.SelectedIndex = lb.SelectedIndex
        End If

        If lb.Name = "LBrecordDB" Then
            Me.LBnames.SelectedIndex = lb.SelectedIndex
            Me.LBtimeOfRecord.SelectedIndex = lb.SelectedIndex
        End If

        If lb.Name = "LBtimeOfRecord" Then
            Me.LBrecordDB.SelectedIndex = lb.SelectedIndex
            Me.LBnames.SelectedIndex = lb.SelectedIndex
        End If
    End Sub

    Private isAscendingOrder = False
    Private sortedPlayersTab() As Players.Player

    ''' <summary>
    ''' Will sorte lists in ascenging or descending order
    ''' </summary>
    ''' <see cref="Players.getNbPlayer()"/>
    ''' <see cref="Players.convSeconds(Double)"/>
    Private Sub reOrder()
        'empties at each opening, avoids data repetition
        Me.LBnames.Items.Clear()
        Me.LBrecordDB.Items.Clear()
        Me.LBtimeOfRecord.Items.Clear()

        If Not isAscendingOrder Then
            For i As UInteger = 0 To Players.getNbPlayer - 1
                Me.LBrecordDB.Items.Add(sortedPlayersTab(i).details.bestNbDiscoveredBoxes)
                Me.LBnames.Items.Add(sortedPlayersTab(i).name)
                Me.LBtimeOfRecord.Items.Add(Players.convSeconds(sortedPlayersTab(i).details.timeOfBestRecord))
            Next i
            isAscendingOrder = True
            Me.Bsorted.Image = New Bitmap(Image.FromFile("image\\ascending.png"),
                                          New Size(Me.Bsorted.Width - 10, Me.Bsorted.Height - 10))
        Else
            For i As Integer = Players.getNbPlayer - 1 To 0 Step -1
                Me.LBrecordDB.Items.Add(sortedPlayersTab(i).details.bestNbDiscoveredBoxes)
                Me.LBnames.Items.Add(sortedPlayersTab(i).name)
                Me.LBtimeOfRecord.Items.Add(Players.convSeconds(sortedPlayersTab(i).details.timeOfBestRecord))
            Next i
            isAscendingOrder = False
            Me.Bsorted.Image = New Bitmap(Image.FromFile("image\\descending.png"),
                                          New Size(Me.Bsorted.Width - 10, Me.Bsorted.Height - 10))
        End If
    End Sub

    ''' <summary>
    ''' In each visible = true it will clear the lists datas and relaod it,
    ''' so that new players are also included in the lists
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <see cref="Players.getNbPlayer()"/>
    ''' <see cref="Players.getPlayers(UInteger)"/>
    ''' <see cref="Players.getName(UInteger)"/>
    ''' <see cref="compareScore(Player, Player)"/>
    ''' <see cref="reOrder()"/>
    ''' 
    Private Sub FPlayersRecord_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            'empties at each opening, avoids data repetition
            Me.CBplayersdetails.Items.Clear()

            If players.getNbPlayer <> 0 Then
                ReDim sortedPlayersTab(Players.getNbPlayer - 1)
                For i As UInteger = 0 To Players.getNbPlayer - 1
                    sortedPlayersTab(i) = Players.getPlayers(i)
                    Me.CBplayersdetails.Items.Add(Players.getName(i))
                Next i

                If Me.CBplayersdetails.Items.Count <> 0 Then Me.CBplayersdetails.SelectedIndex = 0
                Array.Sort(sortedPlayersTab, New Comparison(Of Players.Player)(AddressOf compareScore))

                reOrder()
            End If
        End If
    End Sub

    Private Sub Bsorted_Click(sender As Object, e As EventArgs) Handles Bsorted.Click
        If Me.LBnames.Items.Count <> 0 Then
            reOrder()
        End If
    End Sub

    ''' <summary>
    ''' research if a player is existing
    ''' </summary>
    ''' <param name="playerName">the player to reserch</param>
    ''' <returns>true else false</returns>
    Private Function isAnExistingPlayer(playerName As String) As Boolean
        If Players.getNbPlayer() <> 0 Then
            For i As UInteger = 0 To Players.getNbPlayer() - 1
                If Players.getName(i) = playerName Then Return True
            Next i
        End If
        Return False
    End Function

    ''' <summary>
    ''' Show all the details of a player whene the showDetails Button is pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <see cref="isAnExistingPlayer(String)"/>
    ''' <see cref="Players.toString(String)"/>
    Private Sub BshowDetails_Click(sender As Object, e As EventArgs) Handles BshowDetails.Click
        If Not isAnExistingPlayer(CBplayersdetails.Text) Then
            MsgBox("This player does not exist.", vbOKOnly, "Error")
        Else
            Dim pName As String = Me.CBplayersdetails.Text
            MsgBox(Players.toString(pName))
        End If
    End Sub
End Class