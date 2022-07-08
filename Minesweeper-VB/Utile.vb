Imports System.IO

Module Utile
    'possibly change the functions in other modules

    ''' <summary>
    ''' Gets the number of a boxe.
    ''' </summary>
    ''' <param name="nom">The code of the boxe.</param>
    ''' <returns>The number of the boxe.</returns>
    Public Function numOfBox(nom As String)
        Return Mid(nom, 2)
    End Function

    ''' <summary>
    ''' Rounds a float value into its lower integer value.
    ''' </summary>
    ''' <param name="val"></param>
    ''' <returns></returns>
    Public Function roundMin(val As Double) As UInteger
        Return Math.Floor(val)
    End Function

    ''' <summary>
    ''' Gets the name of the file by the path
    ''' </summary>
    ''' <param name="path">the path</param>
    ''' <returns>name of file</returns>
    Public Function getFileName(path As String) As String
        Return Replace(Replace(path, Directory.GetCurrentDirectory, ""), ".xml", "")
    End Function

End Module
