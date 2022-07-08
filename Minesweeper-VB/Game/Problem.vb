Module Problem
    Structure GameProblem
        Dim lines As UInteger
        Dim colums As UInteger
        Dim nbMines As UInteger
        Dim minesPosition() As UInteger
    End Structure

    ''' <summary>
    ''' initializes the problem.
    ''' </summary>
    ''' <param name="g">The game's grid.</param>
    ''' <param name="l">The number of lines.</param>
    ''' <param name="c">The number of colums.</param>
    ''' <param name="m">The nummber of mines.</param>
    ''' <returns>The initialized problem.</returns>
    ''' <see cref="generateMine(ByRef Box(,), UInteger, UInteger, UInteger)"/>
    Public Function initProblem(ByRef g(,) As BoxOfGrid.Box, l As UInteger, c As UInteger, m As UInteger) _
        As GameProblem

        Dim p = New GameProblem
        ReDim p.minesPosition(m - 1)
        p.lines = l
        p.colums = c
        p.nbMines = m
        p.minesPosition = generateMine(g, l, c, m)

        Return p
    End Function

    ''' <summary>
    ''' Mixes the content of each boxe.
    ''' </summary>
    ''' <param name="g">The game's grid.</param>
    ''' <param name="l">The number of lines.</param>
    ''' <param name="c">The number of colums.</param>
    Private Sub shuffle(ByRef g(,) As BoxOfGrid.Box, l As UInteger, c As UInteger)
        Dim random As New Random()
        Dim boxTmp As BoxOfGrid.Box
        Dim randLine As UInteger = 0
        Dim randColumn As UInteger = 0

        For i As UInteger = 0 To l - 1
            For j As UInteger = 0 To c - 1
                randLine = random.Next(0, l - 1)
                randColumn = random.Next(0, c - 1)

                boxTmp = g(i, j)
                g(i, j) = g(randLine, randColumn)
                g(randLine, randColumn) = boxTmp
            Next j
        Next i
    End Sub

    ''' <summary>
    ''' Looks for the position of every mines.
    ''' </summary>
    ''' <param name="g">The game's grid.</param>
    ''' <param name="l">The number of lines.</param>
    ''' <param name="c">The number of colums.</param>
    ''' <param name="m">The nummber of mines.</param>
    ''' <returns>The list of positions of all the mines.</returns>
    Private Function findMinPosition(g(,) As BoxOfGrid.Box, l As UInteger, c As UInteger, m As UInteger) _
        As UInteger()

        Dim minesPosition(m - 1) As UInteger
        Dim value As UInteger = 0
        Dim idxMine = 1

        For i As UInteger = 0 To l - 1
            For j As UInteger = 0 To c - 1
                value = g(i, j).content
                If value = 9 Then
                    minesPosition(idxMine - 1) = (i * c) + j
                    idxMine += 1
                End If
            Next j
        Next i
        Return minesPosition
    End Function

    ''' <summary>
    ''' Generates a game's mines.
    ''' </summary>
    ''' <param name="g">The game's grid.</param>
    ''' <param name="l">The number of lines.</param>
    ''' <param name="c">The number of colums.</param>
    ''' <param name="m">The nummber of mines.</param>
    ''' <returns>The list of positions of all the mines.</returns>
    ''' <see cref="shuffle(ByRef Box(,), UInteger, UInteger)"/>
    ''' <see cref="findMinPosition(Box(,), UInteger, UInteger, UInteger)"/>
    Private Function generateMine(ByRef g(,) As BoxOfGrid.Box, l As UInteger, c As UInteger, m As UInteger) _
        As UInteger()

        Dim idxMine As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0

        While idxMine <> m
            g(i, j).content = 9
            idxMine += 1
            j += 1
            If j = c Then
                j = 0
                i += 1
            End If
        End While
        shuffle(g, l, c)

        Return findMinPosition(g, l, c, m)
    End Function
End Module
