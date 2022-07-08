Imports System.Xml
Imports System.IO
Module Players
    Private Const DEFAULT_NB_PLAYERS = 10
    Private Const DEFAUT_NB_GAME_PLAYED = 10
    Private nbPlayer = 0
    Private nbRedimPlayers = 0

    Structure Details
        Dim totalDiscoveredBoxes As UInteger
        Dim totalTimePlayed As UInteger
        Dim bestNbDiscoveredBoxes As UInteger
        Dim timeOfBestRecord As UInteger
        Dim bestDifficulty As GamePlayed.Difficulties
    End Structure

    Structure Player
        Dim name As String
        Dim gamePlayed() As GamePlayed.gamePlayed
        Dim details As Details
        Dim nbGamePlayed As UInteger
        Dim nbRedimGamePlayed As UInteger
    End Structure

    Dim players(DEFAULT_NB_PLAYERS) As Player

    ''' <summary>
    ''' Save a player's last game.
    ''' If the player does not exist in the datas,
    ''' the function will create a new one at the same time.
    ''' </summary>
    ''' <param name="name">The player's name.</param>
    ''' <param name="score">The total number of discovered boxes in the game.</param>
    ''' <param name="timePlayed">The time spent in the game.</param>
    ''' <param name="difficulty">The difficulty level of the game.</param>
    ''' <see cref="hasPlayer(String)"/>
    ''' <see cref="createPlayer(String, Integer, Double, Difficulties)"/>
    ''' <see cref="addGamePlayed(String, Integer, Double, Difficulties)"/>
    Public Sub savePlayer(name As String, score As Integer, timePlayed As Double, difficulty As GamePlayed.Difficulties)
        If nbPlayer >= DEFAULT_NB_PLAYERS + (DEFAULT_NB_PLAYERS * nbRedimPlayers) Then
            ReDim Preserve players(nbPlayer + DEFAULT_NB_PLAYERS)
            nbRedimPlayers += 1
        End If

        If Not hasPlayer(name) Then
            createPlayer(name, score, timePlayed, difficulty)
        Else
            addGamePlayed(name, score, timePlayed, difficulty)
        End If
    End Sub

    ''' <summary>
    ''' Creates a new player and add him to the list of players in the application.
    ''' He is defined by his name with the datas of his first game:
    ''' the number of discovered boxes, the played time and the difficulty level.
    ''' </summary>
    ''' <param name="name">The player's name.</param>
    ''' <param name="score">The total number of discovered boxes.</param>
    ''' <param name="timePlayed">The played time.</param>
    ''' <param name="difficulty">The difficulty level of the game.</param>
    ''' <see cref="GamePlayed.creatGamePlayed(Integer, Double, Difficulties)"/>
    Private Sub createPlayer(name As String, score As Integer, timePlayed As Double, difficulty As GamePlayed.Difficulties)
        Dim p As Player
        p.name = name
        ReDim p.gamePlayed(DEFAUT_NB_GAME_PLAYED)
        p.gamePlayed(p.nbGamePlayed) = GamePlayed.creatGamePlayed(score, timePlayed, difficulty)
        p.details.totalDiscoveredBoxes = 0
        p.details.totalTimePlayed = 0
        p.details.timeOfBestRecord = 0
        p.details.bestNbDiscoveredBoxes = 0
        p.details.bestDifficulty = Nothing
        p.nbGamePlayed += 1
        players(nbPlayer) = p
        nbPlayer += 1
    End Sub

    ''' <summary>
    ''' Adds a game into the list of games played by a specific player.
    ''' </summary>
    ''' <param name="name">The player's name.</param>
    ''' <param name="score">The total number of discovered boxes.</param>
    ''' <param name="timePlayed">The played time.</param>
    ''' <param name="difficulty">The difficulty level of the game.</param>
    ''' <see cref="GamePlayed.creatGamePlayed(Integer, Double, Difficulties)"/>
    Private Sub addGamePlayed(name As String, score As Integer, timePlayed As Double, difficulty As GamePlayed.Difficulties)
        Dim idx As UInteger = getIdxPlayer(name)
        If players(idx).nbGamePlayed >= DEFAUT_NB_GAME_PLAYED + (DEFAUT_NB_GAME_PLAYED * players(idx).nbRedimGamePlayed) Then
            ReDim Preserve players(idx).gamePlayed(players(idx).nbGamePlayed + DEFAUT_NB_GAME_PLAYED)
            players(idx).nbRedimGamePlayed += 1
        End If

        players(idx).gamePlayed(players(idx).nbGamePlayed) = GamePlayed.creatGamePlayed(score, timePlayed, difficulty)
        players(idx).nbGamePlayed = players(idx).nbGamePlayed + 1
    End Sub

    Public Function getIdxPlayer(name As String) As UInteger
        Dim idx As UInteger = 0
        For i As UInteger = 0 To nbPlayer - 1
            If players(i).name = name Then
                idx = i
            End If
        Next i
        Return idx
    End Function

    ''' <summary>
    ''' Look for a player's name in the list of all players
    ''' who are saved in the application datas.
    ''' </summary>
    ''' <param name="name">The wanted player's name.</param>
    ''' <returns>True if the name exists in the application datas,
    '''          False if not.</returns>
    Private Function hasPlayer(name As String) As Boolean
        If nbPlayer = 0 Then Return False
        For i As UInteger = 0 To nbPlayer - 1
            If players(i).name = name Then
                Return True
            End If
        Next i
        Return False
    End Function

    Public Function getNbPlayer() As Integer
        Return nbPlayer
    End Function

    Public Function getNbGamePlayed(idxPlayer As UInteger) As UInteger
        Return players(idxPlayer).nbGamePlayed
    End Function

    Public Function getName(idxPlayer As UInteger) As String
        Return players(idxPlayer).name
    End Function

    Public Function getScore(idxPlayer As UInteger, idxGamePlayed As UInteger) As Integer
        Return players(idxPlayer).gamePlayed(idxGamePlayed).score
    End Function

    Public Function getDifficulty(idxPlayer As UInteger, idxGamePlayed As UInteger) As String
        Return players(idxPlayer).gamePlayed(idxGamePlayed).difficulty
    End Function

    Public Function getTimePlayed(idxPlayer As UInteger, idxScore As UInteger) As Integer
        Return players(idxPlayer).gamePlayed(idxScore).timePlayed
    End Function

    Public Function getStateOfGame(idxPlayer As UInteger, idxScore As UInteger) As StateOfGame.State
        Return players(idxPlayer).gamePlayed(idxScore).stateOfGamePlayed
    End Function

    Public Function getBestNbDiscoveredBoxes(idxPlayer As UInteger) As UInteger
        Return players(idxPlayer).details.bestNbDiscoveredBoxes
    End Function

    Public Function getTotalDiscoveredBoxes(idxPlayer As UInteger) As UInteger
        Return players(idxPlayer).details.totalDiscoveredBoxes
    End Function

    Public Function getTimeOfBestRecord(idx As UInteger) As UInteger
        Return players(idx).details.timeOfBestRecord
    End Function

    Public Function getBestDifficulty(idx As UInteger) As GamePlayed.Difficulties
        Return players(idx).details.bestDifficulty
    End Function

    Public Function getPlayers(idx As UInteger) As Player
        Return players(idx)
    End Function

    Public Function getTotalTimePlayed(idx As UInteger) As UInteger
        Return players(idx).details.totalTimePlayed
    End Function

    ''' <summary>
    ''' Saves the datas from the last game of
    ''' a specific player into his statistics.
    ''' </summary>
    ''' <param name="pIdx">The player's index.</param>
    ''' <param name="gScore">The number of discovered boxes.</param>
    ''' <param name="gTime">The time spent on the game.</param>
    ''' <param name="gDifficulty">The game's level of difficulty.</param>
    Private Sub saveSatistics(pIdx As UInteger, gScore As UInteger, gTime As UInteger, gDifficulty As GamePlayed.Difficulties)
        players(pIdx).gamePlayed(getNbGamePlayed(pIdx) - 1).score = gScore
        players(pIdx).gamePlayed(getNbGamePlayed(pIdx) - 1).timePlayed = gTime
        players(pIdx).gamePlayed(getNbGamePlayed(pIdx) - 1).difficulty = gDifficulty

        'if players has played (has discovered at least one box)
        If gScore > 0 Then
            'if it's his first game
            If players(pIdx).details.bestNbDiscoveredBoxes = 0 AndAlso players(pIdx).details.bestDifficulty = Nothing _
            AndAlso players(pIdx).details.timeOfBestRecord = 0 Then

                players(pIdx).details.bestNbDiscoveredBoxes = gScore
                players(pIdx).details.timeOfBestRecord = gTime
                players(pIdx).details.bestDifficulty = gDifficulty
            Else
                If players(pIdx).details.bestDifficulty = gDifficulty Then
                    If players(pIdx).details.bestNbDiscoveredBoxes = gScore Then
                        If players(pIdx).details.timeOfBestRecord > gTime Then
                            players(pIdx).details.timeOfBestRecord = gTime
                        End If
                    ElseIf players(pIdx).details.bestNbDiscoveredBoxes < gScore Then
                        players(pIdx).details.bestNbDiscoveredBoxes = gScore
                        players(pIdx).details.timeOfBestRecord = gTime
                    End If
                ElseIf players(pIdx).details.bestDifficulty < gDifficulty Then
                    If players(pIdx).details.bestNbDiscoveredBoxes = gScore Then
                        If players(pIdx).details.timeOfBestRecord > gTime Then
                            players(pIdx).details.timeOfBestRecord = gTime
                            players(pIdx).details.bestDifficulty = gDifficulty
                        End If
                    ElseIf players(pIdx).details.bestNbDiscoveredBoxes < gScore Then
                        players(pIdx).details.bestNbDiscoveredBoxes = gScore
                        players(pIdx).details.timeOfBestRecord = gTime
                        players(pIdx).details.bestDifficulty = gDifficulty
                    End If
                End If
            End If
            players(pIdx).details.totalDiscoveredBoxes += gScore
            players(pIdx).details.totalTimePlayed += gTime
        End If
    End Sub

    ''' <summary>
    ''' Saves a game lost by a specific player.
    ''' </summary>
    ''' <param name="pName">The playe's name.</param>
    ''' <param name="gScore">The total number of discovered boxes.</param>
    ''' <param name="gTime">The played time.</param>
    ''' <param name="gDifficulty">The difficulty level of the game.</param>
    ''' <see cref="savePlayer(String, Integer, Double, Difficulties)"/>
    ''' <see cref="saveSatistics(UInteger, UInteger, UInteger, Difficulties)"/>
    Public Sub saveGameLost(pName As String, gScore As UInteger, gTime As UInteger, gDifficulty As GamePlayed.Difficulties)
        savePlayer(pName, gScore, gTime, gDifficulty)

        Dim idx As UInteger = getIdxPlayer(pName)
        saveSatistics(idx, gScore, gTime, gDifficulty)
        players(idx).gamePlayed(getNbGamePlayed(idx) - 1).stateOfGamePlayed = StateOfGame.State.GAME_LOST
    End Sub

    ''' <summary>
    ''' Saves a game won by a specific player.
    ''' </summary>
    ''' <param name="pName">The player's name.</param>
    ''' <param name="gScore">The total number of discovered boxes.</param>
    ''' <param name="gTime">The played time.</param>
    ''' <param name="gDifficulty">The difficulty level of the game.</param>
    ''' <see cref="savePlayer(String, Integer, Double, Difficulties)"/>
    ''' <see cref="saveSatistics(UInteger, UInteger, UInteger, Difficulties)"/>
    Public Sub saveGameWon(pName As String, gScore As UInteger, gTime As UInteger, gDifficulty As GamePlayed.Difficulties)
        savePlayer(pName, gScore, gTime, gDifficulty)

        Dim idx As UInteger = getIdxPlayer(pName)
        saveSatistics(idx, gScore, gTime, gDifficulty)
        players(idx).gamePlayed(getNbGamePlayed(idx) - 1).stateOfGamePlayed = StateOfGame.State.GAME_WON
    End Sub

    Private Const MINUTE = 60
    Private Const HOUR = 3600
    Private Const DAY = 86400

    ''' <summary>
    ''' Converts a time in seconds into minutes, hours and days.
    ''' </summary>
    ''' <param name="s">the initial time in seconds.</param>
    ''' <returns>the converted time.</returns>
    Public Function convSeconds(s As Double) As String
        Dim minutes As String = ""
        Dim hours As String = ""
        Dim days As String = ""
        Dim time As String = ""

        If s >= DAY Then
            days = CStr(s \ DAY) + "j"
            s = s Mod DAY
        End If

        If s >= HOUR Then
            hours = CStr(s \ HOUR) + "h"
            s = s Mod HOUR
        End If
        If s >= MINUTE Then
            minutes = CStr(s \ MINUTE) + "m"
            s = s Mod MINUTE
        End If

        If days <> "" Then time += days + " "
        If hours <> "" Then time += hours + " "
        If minutes <> "" Then time += minutes + " "
        If s >= 0 Then time += CStr(s) + "s"

        Return time
    End Function

    ''' <summary>
    ''' Saves a specific game played by a specific player on an xml file.
    ''' </summary>
    ''' <param name="fSave">The xml file.</param>
    ''' <param name="idxP">The Player's index.</param>
    ''' <param name="idxGamePlayed">The game's index.</param>
    ''' <returns>The xml code which represents the game saved in the file.</returns>
    Private Function savePlayerGamePlayedOnFile(ByRef fSave As XmlDocument, idxP As UInteger, idxGamePlayed As UInteger) As XmlElement
        Dim gamePlayedTag As XmlElement = fSave.CreateElement("gamePlayed")
        Dim scoreTag As XmlElement = fSave.CreateElement("score")
        Dim timePlayedTag As XmlElement = fSave.CreateElement("timePlayed")
        Dim stateOfGamePlayedTag As XmlElement = fSave.CreateElement("stateOfGamePlayed")
        Dim difficultyTag As XmlElement = fSave.CreateElement("difficulty")

        scoreTag.InnerText = getScore(idxP, idxGamePlayed)
        timePlayedTag.InnerText = getTimePlayed(idxP, idxGamePlayed)
        stateOfGamePlayedTag.InnerText = getStateOfGame(idxP, idxGamePlayed)
        difficultyTag.InnerText = getDifficulty(idxP, idxGamePlayed)

        gamePlayedTag.AppendChild(scoreTag)
        gamePlayedTag.AppendChild(timePlayedTag)
        gamePlayedTag.AppendChild(stateOfGamePlayedTag)
        gamePlayedTag.AppendChild(difficultyTag)

        Return gamePlayedTag
    End Function

    ''' <summary>
    ''' Saves a specific player's details on an xml file.
    ''' the details are : the total discovered boxes.
    '''                   the total time played.
    '''                   the best number of discovered boxes.
    '''                   the best time spent by a player to win a game.
    ''' </summary>
    ''' <param name="fSave">The xml file.</param>
    ''' <param name="idxP">THe player's index.</param>
    ''' <returns>The xml code which represents the details saved in the file.</returns>
    Private Function savePlayerDetailsOnFile(ByRef fSave As XmlDocument, idxP As UInteger) As XmlElement
        Dim detailsTag As XmlElement = fSave.CreateElement("details")
        Dim totalDiscoveredBoxesTag As XmlElement = fSave.CreateElement("totalDiscoveredBoxes")
        Dim totalTimePlayedTag As XmlElement = fSave.CreateElement("totalTimePlayed")
        Dim bestNbDiscoveredBoxesTag As XmlElement = fSave.CreateElement("bestNbDiscoveredBoxes")
        Dim timeOfBestRecordTag As XmlElement = fSave.CreateElement("timeOfBestRecord")
        Dim bestDifficultyTag As XmlElement = fSave.CreateElement("bestDifficulty")

        totalDiscoveredBoxesTag.InnerText = players(idxP).details.totalDiscoveredBoxes
        totalTimePlayedTag.InnerText = players(idxP).details.totalTimePlayed
        bestNbDiscoveredBoxesTag.InnerText = players(idxP).details.bestNbDiscoveredBoxes
        timeOfBestRecordTag.InnerText = players(idxP).details.timeOfBestRecord
        bestDifficultyTag.InnerText = players(idxP).details.bestDifficulty

        detailsTag.AppendChild(totalDiscoveredBoxesTag)
        detailsTag.AppendChild(totalTimePlayedTag)
        detailsTag.AppendChild(bestNbDiscoveredBoxesTag)
        detailsTag.AppendChild(timeOfBestRecordTag)
        detailsTag.AppendChild(bestDifficultyTag)

        Return detailsTag
    End Function

    ''' <summary>
    ''' Saves the list of players and all the datas the application collected
    ''' bout them into an xml file.
    ''' </summary>
    ''' <param name="givedFileName">The xml file's name.</param>
    ''' <see cref="savePlayerGamePlayedOnFile(ByRef XmlDocument, UInteger, UInteger)"/>
    ''' <see cref="savePlayerDetailsOnFile(ByRef XmlDocument, UInteger)"/>
    Public Sub savePlayersOnFile(Optional givedFileName As String = "")
        Dim fSave As XmlDocument = New XmlDocument()
        fSave.LoadXml("<players></players>")

        Dim nbRedimPlayersTag As XmlElement = fSave.CreateElement("nbRedimPlayers")
        nbRedimPlayersTag.InnerText = nbRedimPlayers
        fSave.DocumentElement.AppendChild(nbRedimPlayersTag)

        If getNbPlayer() > 0 Then
            For idxP As UInteger = 0 To getNbPlayer() - 1
                Dim playerTag As XmlElement = fSave.CreateElement("player")

                'player
                Dim nameTag As XmlElement = fSave.CreateElement("name")
                Dim nbRedimGamePlayedTag As XmlElement = fSave.CreateElement("nbRedimGamePlayed")
                Dim nbGamePlayedTag As XmlElement = fSave.CreateElement("nbGamePlayed")

                nameTag.InnerText = players(idxP).name
                nbGamePlayedTag.InnerText = players(idxP).nbGamePlayed
                nbRedimGamePlayedTag.InnerText = players(idxP).nbRedimGamePlayed

                playerTag.AppendChild(nameTag)
                playerTag.AppendChild(nbGamePlayedTag)
                playerTag.AppendChild(nbRedimGamePlayedTag)

                For idxGamePlayed As UInteger = 0 To getNbGamePlayed(idxP) - 1
                    playerTag.AppendChild(savePlayerGamePlayedOnFile(fSave, idxP, idxGamePlayed))
                Next idxGamePlayed

                playerTag.AppendChild(savePlayerDetailsOnFile(fSave, idxP))
                fSave.DocumentElement.AppendChild(playerTag)
            Next idxP

            If givedFileName = "" Then
                fSave.Save(Directory.GetCurrentDirectory + "\savedPlayers.xml")
            Else
                givedFileName.Replace(" ", String.Empty)
                fSave.Save(Directory.GetCurrentDirectory + "\" + givedFileName + ".xml")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Affect a specific detail to a specific player.
    ''' </summary>
    ''' <param name="newPlayers">The player.</param>
    ''' <param name="detail">The detail.</param>
    Private Sub loadPlayerDetails(ByRef newPlayers As Player, ByRef detail As Object)
        Select Case detail.LocalName
            Case "totalDiscoveredBoxes"
                newPlayers.details.totalDiscoveredBoxes = detail.InnerText
            Case "totalTimePlayed"
                newPlayers.details.totalTimePlayed = detail.InnerText
            Case "bestNbDiscoveredBoxes"
                newPlayers.details.bestNbDiscoveredBoxes = detail.InnerText
            Case "timeOfBestRecord"
                newPlayers.details.timeOfBestRecord = detail.InnerText
            Case "bestDifficulty"
                newPlayers.details.bestDifficulty = detail.InnerText
        End Select
    End Sub

    ''' <summary>
    ''' Affect a specific data from a specific game to a specific player.
    ''' </summary>
    ''' <param name="newPlayers">The player.</param>
    ''' <param name="gameData">The unique data from the game</param>
    ''' <param name="idxGamePlayed">The game's index.</param>
    Private Sub loadPlayerGamePlayed(ByRef newPlayers As Player, ByRef gameData As Object, idxGamePlayed As UInteger)
        Select Case gameData.LocalName
            Case "score"
                newPlayers.gamePlayed(idxGamePlayed).score = gameData.InnerText
            Case "timePlayed"
                newPlayers.gamePlayed(idxGamePlayed).timePlayed = gameData.InnerText
            Case "stateOfGamePlayed"
                newPlayers.gamePlayed(idxGamePlayed).stateOfGamePlayed = gameData.InnerText
            Case "difficulty"
                newPlayers.gamePlayed(idxGamePlayed).difficulty = gameData.InnerText
        End Select
    End Sub

    ''' <summary>
    ''' Load, into an xml file, the list of players and
    ''' all the datas which were collected by the application.
    ''' </summary>
    ''' <param name="fileName">The xml file's name.</param>
    ''' <see cref="loadPlayerDetails(ByRef Player, ByRef Object)"/>
    ''' <see cref="loadPlayerGamePlayed(ByRef Player, ByRef Object, UInteger)"/>
    Public Sub loadPlayers(fileName As String)
        Console.WriteLine(fileName)
        Dim fSave As XmlDocument = New XmlDocument()
        fSave.Load(fileName)

        nbRedimPlayers = fSave.DocumentElement.GetElementsByTagName("nbRedimPlayers").Item(0).InnerText
        nbPlayer = 0 'resets to 0 when the user changes the backup file

        If nbRedimPlayers <> 0 Then ReDim players(DEFAULT_NB_PLAYERS + (nbRedimPlayers * DEFAULT_NB_PLAYERS))

        Dim playersTags As XmlNodeList = fSave.DocumentElement.GetElementsByTagName("player")

        For Each tags In playersTags
            Dim newPlayers As New Player
            Dim idxGamePlayed As UInteger = 0 'for the nb of game played per players
            For Each playerInfo In tags.ChildNodes
                Select Case playerInfo.LocalName
                    Case "name"
                        newPlayers.name = playerInfo.InnerText
                    Case "nbGamePlayed"
                        newPlayers.nbGamePlayed = playerInfo.InnerText
                    Case "nbRedimGamePlayed"
                        newPlayers.nbRedimGamePlayed = playerInfo.InnerText
                        ReDim newPlayers.gamePlayed(DEFAUT_NB_GAME_PLAYED +
                                                         (newPlayers.nbRedimGamePlayed * DEFAULT_NB_PLAYERS))
                    Case "details"
                        For Each detail In playerInfo
                            loadPlayerDetails(newPlayers, detail)
                        Next detail
                    Case "gamePlayed"
                        For Each gameData In playerInfo
                            loadPlayerGamePlayed(newPlayers, gameData, idxGamePlayed)
                        Next gameData
                        idxGamePlayed += 1
                End Select
            Next playerInfo
            players(nbPlayer) = newPlayers 'nbPlayer --> on line 6
            nbPlayer += 1
            idxGamePlayed = 0 ' = 0 for the next player
        Next tags
    End Sub

    ''' <summary>
    ''' Return all details of a player
    ''' </summary>
    ''' <param name="pname">the player</param>
    ''' <returns>all details</returns>
    ''' <see cref="Players.getBestNbDiscoveredBoxes(UInteger)"/>
    ''' <see cref="Players.getIdxPlayer(String)"/>
    ''' <see cref="Players.getTimeOfBestRecord(UInteger)"/>
    ''' <see cref="getTotalDiscoveredBoxes(UInteger)"/>
    ''' <see cref="getTotalTimePlayed(UInteger)"/>
    ''' <see cref="getNbGamePlayed(UInteger)"/>
    Public Function toString(pname As String) As String
        Return pname & " : " & vbCrLf & "   - Best number of discovered boxes : " &
                getBestNbDiscoveredBoxes(getIdxPlayer(pname)) & vbCrLf &
                "   - Best Time : " & getTimeOfBestRecord(getIdxPlayer(pname)) &
                " seconds. " & vbCrLf & "   - Discovered in total : " _
                & getTotalDiscoveredBoxes(getIdxPlayer(pname)) &
                " boxes." & vbCrLf & "   - Spent in total : " &
                getTotalTimePlayed(getIdxPlayer(pname)) _
                & " seconds." & vbCrLf & "   - Played in total : " &
                getNbGamePlayed(getIdxPlayer(pname)) & " games."
    End Function
End Module