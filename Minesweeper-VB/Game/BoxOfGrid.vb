Module BoxOfGrid
    Enum BoxState
        UNMASK
        MARK
        HIDE
    End Enum

    Structure Box
        Dim content As UInteger
        Dim state As BoxState
    End Structure
End Module
