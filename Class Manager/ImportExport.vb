Imports System.Data.SQLite
Imports RegawMOD.Android

Public Class ImportExport

    Dim android As AndroidController
    Public thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        My.Computer.FileSystem.CopyFile("C:\Mickosis\ClassRecords", thepath + "\ClassRecords",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MsgBox("Export Success!")
        Process.Start(thepath)

    End Sub


    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
    = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        'Always call UpdateDeviceList() before using AndroidController on devices to get the most updated list
        android.UpdateDeviceList()

        Try
            Dim device As Device = android.GetConnectedDevice()
            Adb.ExecuteAdbCommand(Adb.FormAdbCommand(device, "pull", "/sdcard/ClassManager", "C:\Mickosis\"))
            MsgBox("Pulling succesful!")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
   
    End Sub
    Private Sub Cb2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover

        Button2.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Cb2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Button2.Image = My.Resources.importdbase


    End Sub

    Private Sub ImportExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        android = AndroidController.Instance
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        'Always call UpdateDeviceList() before using AndroidController on devices to get the most updated list
        android.UpdateDeviceList()
        Try
            Dim device As Device = android.GetConnectedDevice()
            Adb.ExecuteAdbCommand(Adb.FormAdbCommand(device, "push", "C:\Mickosis\ClassRecords", " /sdcard/ClassManager"))
            MsgBox("Pushing succesful!")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Cb3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseHover

        Button3.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Cb3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave

        Button3.Image = My.Resources.importdbase


    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click

        Home.Show()
        Me.Hide()
    End Sub
End Class