Imports System.Net

Public Class Form1
    Public 경로 = Environ("appdata") & "\.minecraft\Mods.7z"
    Public WithEvents download As WebClient
    Dim Myprocess1 As System.Diagnostics.Process
    Dim Process1 As New ProcessStartInfo

    Private Sub download_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles download.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        download = New WebClient
        download.DownloadFileTaskAsync("https://www.dropbox.com/s/j7uwpxin3eygkop/Mods.7z?dl=1", 경로)
        My.Computer.FileSystem.WriteAllBytes(Environ("appdata") & "\.minecraft\7z.exe", My.Resources._7z, True)
        Process1.FileName = Environ("appdata") & "\.minecraft\7z.exe"
        Process1.Arguments = "x -y " & """" & Environ("appdata") & "\.minecraft\" & "Mods.7z""" & " -o" & """" & Environ("appdata") & "\.minecraft\"""
        Process1.WindowStyle = ProcessWindowStyle.Hidden
        Myprocess1 = Process.Start(Process1)
        Myprocess1.WaitForExit()
        MsgBox("완료되었습니다")
    End Sub

End Class
