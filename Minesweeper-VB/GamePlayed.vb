Module GamePlayed

    Enum Difficulties
        EASY
        NORMAL
        HARD
        EXTREME
        NONSENSE
    End Enum

    Structure gamePlayed
        Dim score As Integer
        Dim timePlayed As UInteger
        Dim stateOfGamePlayed As StateOfGame.State
        Dim difficulty As Difficulties
    End Structure

    ''' <summary>
    ''' Creates a new played game.
    ''' It is defined by its total number of discovered boxes,
    ''' the time spent on the game and its difficulty level.
    ''' </summary>
    ''' <param name="s">The total number of discovered boxes.</param>
    ''' <param name="t">The time spent on the game.</param>
    ''' <param name="d">the difficulty level of the game.</param>
    ''' <returns>The newly created game.</returns>
    Public Function creatGamePlayed(s As Integer, t As Double, d As Difficulties) As gamePlayed
        Dim gP As gamePlayed
        gP.score = s
        gP.timePlayed = t
        gP.difficulty = d
        Return gP
    End Function

    Public Function getDifficultyOf(difficulty As String) As Difficulties
        Select Case difficulty
            Case "Normal"
                Return Difficulties.NORMAL
            Case "Hard"
                Return Difficulties.HARD
            Case "Extreme"
                Return Difficulties.EXTREME
            Case "Nonsense"
                Return Difficulties.NONSENSE
            Case Else
                Return Difficulties.EASY
        End Select
    End Function

    Public Function getStringDifficultyOf(difficulty As Difficulties) As String
        Select Case difficulty
            Case Difficulties.NORMAL
                Return "Normal"
            Case Difficulties.HARD
                Return "Hard"
            Case Difficulties.EXTREME
                Return "Extreme"
            Case Difficulties.NONSENSE
                Return "Nonsense"
            Case Else
                Return "Easy"
        End Select
    End Function
End Module
