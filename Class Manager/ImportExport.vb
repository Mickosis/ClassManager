Public Class ImportExport

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            My.Computer.FileSystem.CopyFile("ClassRecords.db", "C:\Users\Mico\Desktop\ClassRecords.db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            MsgBox("Export Success!")
            Process.Start("C:\Users\Mico\Desktop\")
        Else
            My.Computer.FileSystem.CopyFile("ClassRecords.db", "C:\Users\Mico\Desktop\" + TextBox2.Text + ".db",
Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
            MsgBox("Export Success!")
            Process.Start("C:\Users\Mico\Desktop\")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.FileSystem.CopyFile(
    TextBox1.Text,
    "C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\ClassRecords.db",
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MsgBox("Import Success!")
        Process.Start("C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using FileDialog As New OpenFileDialog
            FileDialog.Title = "Select database to import"
            FileDialog.Filter = "Class Manager Files|*.db"
            If FileDialog.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = FileDialog.FileName()
                Button1.Enabled = True
            End If
        End Using
    End Sub
End Class