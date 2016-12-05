Imports System
Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Entry.TextChanged

    End Sub

    Private Sub Encode_Click(sender As Object, e As EventArgs) Handles Encode.Click
        Dim sText As String
        Dim i As Integer
        Dim lenText As Integer
        Dim Msg As String

        sText = Entry.Text
        lenText = Len(sText)

        For i = 1 To lenText
            Msg = Msg & CStr(Asc(Mid$(sText, i, 1)))
            Msg = Msg + " "
        Next i
        Dim fw As StreamWriter
        If (Entry.Text = "" Or Entry.Text = "Please enter something.") Then
            Entry.Text = "Please enter something."
            Return
        End If
        Dim ReadString As String
        Try
            Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            fw = New StreamWriter(s & "\text.txt", True)
            ReadString = Msg
            fw.WriteLine(ReadString)
        Finally
            fw.Close()
        End Try
    End Sub

    Private Sub Decode_Click(sender As Object, e As EventArgs) Handles Decode.Click
        Dim sText As String
        Dim i As Integer
        Dim lenText As Integer
        Dim Msg As String
        Dim Word As String
        Dim Asc As Integer
        Dim Letter As String
        If (Entry.Text = "" Or Entry.Text = "Please enter something.") Then
            Entry.Text = "Please enter something."
            Return
        End If
        sText = Entry.Text
        lenText = Len(sText)
        Dim Space As Integer
        Space = InStr(1, sText, " ")
        Dim Space2 As Integer
        Space2 = 1
        If GetChar(sText, lenText) <> " " Then
            sText = sText + " "
            lenText = Len(sText)
        End If
        While lenText <> Space
            For i = Space2 To (Space - 1)
                Word = Word + GetChar(sText, i)
            Next i
            Asc = Convert.ToInt32(Word)
            Word = ""
            Letter = Chr(Asc)
            Msg = Msg + Letter
            Space2 = Space + 1
            Space = InStr(Space2, sText, " ")
        End While
        For i = Space2 To (Space - 1)
            Word = Word + GetChar(sText, i)
        Next i
        Asc = Convert.ToInt32(Word)
        Word = ""
        Letter = Chr(Asc)
        Msg = Msg + Letter
        Dim fw As StreamWriter
        Dim ReadString As String
        Try
            Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            fw = New StreamWriter(s & "\Text.txt", True)
            ReadString = Msg
            fw.WriteLine(ReadString)
        Finally
            fw.Close()
        End Try
    End Sub
End Class

