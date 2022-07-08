Module Grid
    Private gameGrid(,) As BoxOfGrid.Box
    Private p As Problem.GameProblem

    ''' <summary>
    ''' Initializes the game grid's dimensions and its number of mines.
    ''' </summary>
    ''' <param name="l">The number of lines.</param>
    ''' <param name="c">The number of columns.</param>
    ''' <param name="m">The number of mines.</param>
    Public Sub initGrid(l As UInteger, c As UInteger, m As UInteger)
        ReDim gameGrid(l - 1, c - 1) ' 0 to 7 so including "0" there is 8 boxes
        For i As UInteger = 0 To l - 1
            For j As UInteger = 0 To c - 1
                gameGrid(i, j).content = 0
                gameGrid(i, j).state = BoxOfGrid.BoxState.HIDE
            Next j
        Next i

        p = Problem.initProblem(gameGrid, l, c, m)
        giveValueAdjacent()
    End Sub

    ''' <summary>
    ''' For each boxe of the game grid, it gives
    ''' the number of mines contained by each adjacent boxes.
    ''' </summary>
    Private Sub giveValueAdjacent()
        Dim line As UInteger = 0
        Dim colum As UInteger = 0

        For i As UInteger = 0 To p.nbMines - 1
            line = Utile.roundMin(p.minesPosition(i) / p.colums)
            colum = p.minesPosition(i) Mod p.colums

            For j As Integer = -1 To 2 - 1
                For k As Integer = -1 To 2 - 1
                    If (line + j) < p.lines AndAlso (line + j) >= 0 AndAlso
                        (colum + k) < p.colums AndAlso (colum + k) >= 0 Then
                        If gameGrid(line + j, colum + k).content >= 0 AndAlso
                            gameGrid(line + j, colum + k).content <= 7 Then
                            gameGrid(line + j, colum + k).content += 1
                        End If
                    End If
                Next k
            Next j
        Next i
    End Sub

    ''' <summary>
    ''' Creates a new move.
    ''' </summary>
    ''' <param name="boxPlayed">The boxe where the move was applied.</param>
    Public Sub play(boxPlayed As String)
        If boxPlayed(0) = "U" Then
            unmask(Utile.numOfBox(boxPlayed))
        Else
            mark(Utile.numOfBox(boxPlayed))
        End If
    End Sub

    ''' <summary>
    ''' Marks a boxe if it was not previously marked.
    ''' Umasks the boxe if not.
    ''' </summary>
    ''' <param name="idxBox">The index of the boxe which was marked.</param>
    ''' <see cref="roundMin(Double)"/>
    Private Sub mark(idxBox As UInteger)
        Dim line As UInteger = Utile.roundMin(idxBox / p.colums)
        Dim colum As UInteger = idxBox Mod p.colums

        If gameGrid(line, colum).state = BoxOfGrid.BoxState.MARK Then
            gameGrid(line, colum).state = BoxOfGrid.BoxState.HIDE
        Else
            gameGrid(line, colum).state = BoxOfGrid.BoxState.MARK
        End If
    End Sub

    ''' <summary>
    ''' Unmasks a box.
    ''' </summary>
    ''' <param name="boxPos">The position of the box.</param>
    ''' <see cref="assignLostTnt()"/>
    ''' <see cref="recurrence(UInteger)"/>
    Private Sub unmask(boxPos As UInteger)
        If checkUp(boxPos) AndAlso Not isMark(boxPos) Then
            assignLostTnt()
        Else
            recurrence(boxPos)
        End If
    End Sub

    ''' <summary>
    ''' Checks if a specific box contains a mine.
    ''' </summary>
    ''' <param name="boxPos">The position of the box.</param>
    ''' <returns>True if the position of the box match to a mine's position.
    '''          False if not.</returns>
    Private Function checkUp(boxPos As UInteger) As Boolean
        For i As UInteger = 0 To p.nbMines - 1
            If p.minesPosition(i) = boxPos Then
                Return True
            End If
        Next i
        Return False
    End Function

    Private Function isMark(boxPos As UInteger) As Boolean
        Dim line As UInteger = Utile.roundMin(boxPos / p.colums)
        Dim colum As UInteger = boxPos Mod p.colums
        Return gameGrid(line, colum).state = BoxOfGrid.BoxState.MARK
    End Function

    ''' <summary>
    ''' Assigns the mines to their respective positions and
    ''' sets all the squares containing a mine to the UNSET state.
    ''' </summary>
    Private Sub assignLostTnt()
        Dim xMine As UInteger = 0
        Dim yMine As UInteger = 0

        For i As UInteger = 0 To p.nbMines - 1
            xMine = Utile.roundMin(p.minesPosition(i) / p.colums)
            yMine = p.minesPosition(i) Mod p.colums

            If gameGrid(xMine, yMine).state <> BoxState.MARK Then
                gameGrid(xMine, yMine).state = BoxOfGrid.BoxState.UNMASK
            End If
        Next
    End Sub

    ''' <summary>
    ''' Unmasks firstly an initial box.
    ''' If the box isn't surrounded by at least a mine,
    ''' keep unmasks the boxes around him until the unmasked
    ''' zone is totally surrounded by numbers.
    ''' Else, the box will show the number of mines arround it.
    ''' </summary>
    ''' <param name="boxPos">The position of the initial box.</param>
    ''' <see cref="roundMin(Double)"/>
    Private Sub recurrence(boxPos As UInteger)
        Dim xBox As UInteger = Utile.roundMin(boxPos / p.colums)
        Dim yBox As UInteger = boxPos Mod p.colums

        If gameGrid(xBox, yBox).state = BoxOfGrid.BoxState.UNMASK OrElse isMark(boxPos) Then
            Return
        End If

        gameGrid(xBox, yBox).state = BoxOfGrid.BoxState.UNMASK

        If gameGrid(xBox, yBox).content >= 1 AndAlso
            gameGrid(xBox, yBox).content <= 8 Then
            Return
        End If

        For i As Integer = -1 To 2 - 1
            For j As Integer = -1 To 2 - 1
                If xBox + i >= 0 And xBox + i < p.lines AndAlso
                    yBox + j >= 0 And yBox + j < p.colums Then
                    If gameGrid(xBox + i, yBox + j).state = BoxOfGrid.BoxState.HIDE OrElse
                        isMark((xBox + i) * p.colums + yBox + j) Then
                        recurrence(((xBox + i) * p.colums) + yBox + j)
                    End If
                End If
            Next
        Next
    End Sub

    Public Function isWon() As Boolean
        Dim cptMarkedTnt As UInteger = 0
        Dim cptUnmaskedbox As UInteger = 0
        Dim totalCase As UInteger = p.lines * p.colums

        For i As UInteger = 0 To p.lines - 1
            For j As UInteger = 0 To p.colums - 1
                If gameGrid(i, j).state = BoxOfGrid.BoxState.MARK And
                        gameGrid(i, j).content = 9 Then
                    cptMarkedTnt += 1
                ElseIf gameGrid(i, j).state = BoxOfGrid.BoxState.UNMASK And
                        gameGrid(i, j).content <= 8 And
                        gameGrid(i, j).content >= 0 Then
                    cptUnmaskedbox += 1
                End If
            Next j
        Next i

        If cptMarkedTnt = p.nbMines OrElse
            cptUnmaskedbox = totalCase - p.nbMines Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function isLost(boxPos As String) As Boolean
        Dim box As UInteger = Utile.numOfBox(boxPos)
        Dim xBox As UInteger = Utile.roundMin(box / p.colums)
        Dim yBox As UInteger = box Mod p.colums

        If gameGrid(xBox, yBox).content = 9 AndAlso boxPos(0) = "U" AndAlso
        Not isMark(Utile.numOfBox(boxPos)) Then
            Return True
        End If
        Return False
    End Function

    Public Function getBoxState(boxPos As UInteger) As BoxOfGrid.BoxState
        Dim i As UInteger = Utile.roundMin(boxPos / p.colums)
        Dim j As UInteger = boxPos Mod p.colums
        Return gameGrid(i, j).state
    End Function

    Public Function getBoxValue(boxPos As UInteger)
        Dim i As UInteger = Utile.roundMin(boxPos / p.colums)
        Dim j As UInteger = boxPos Mod p.colums
        Return gameGrid(i, j).content
    End Function

    Public Function getNbOfUnmaskedBoxes() As UInteger
        Dim nbUMBoxes As UInteger = 0
        For i As UInteger = 0 To p.lines - 1
            For j As UInteger = 0 To p.colums - 1
                If gameGrid(i, j).state = BoxOfGrid.BoxState.UNMASK _
                    AndAlso gameGrid(i, j).content <> 9 Then nbUMBoxes += 1
            Next j
        Next i
        Return nbUMBoxes
    End Function

    ''' <summary>
    ''' Count the number of hidden boxes.
    ''' </summary>
    ''' <returns>The number of hidden boxes.</returns>
    Private Function countHiden() As UInteger
        Dim nbHiddenBox As UInteger = 0
        For i As UInteger = 0 To p.lines - 1
            For j As UInteger = 0 To p.colums - 1
                If gameGrid(i, j).state = BoxOfGrid.BoxState.HIDE Then
                    nbHiddenBox += 1
                End If
            Next j
        Next i
        Return nbHiddenBox
    End Function

    ''' <summary>
    ''' Generate randomly a new correct move.
    ''' </summary>
    ''' <returns></returns>
    Public Function choiceMove() As String
        Dim newMove As String = ""
        Dim rd As New Random()
        Dim numBox As UInteger = rd.Next(1, countHiden() - 1)
        Dim k As UInteger = 0
        For i As UInteger = 0 To p.lines - 1
            For j As UInteger = 0 To p.colums - 1
                If gameGrid(i, j).state = BoxOfGrid.BoxState.HIDE Then
                    If k = numBox Then

                        newMove = i * p.colums + j
                        If gameGrid(i, j).content = 9 Then
                            newMove = "M" + newMove
                        Else
                            newMove = "U" + newMove
                        End If
                    End If
                    k += 1
                End If
            Next j
        Next i
        Return newMove
    End Function
End Module
