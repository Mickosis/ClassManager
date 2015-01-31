Public Class ImportExport

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Export.Click
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

    Private Sub Export_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.MouseHover

        Export.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Export_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Export.MouseLeave

        Export.Image = My.Resources.addbrowse


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Import.Click
        My.Computer.FileSystem.CopyFile(
    TextBox1.Text,
    "C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\ClassRecords.db",
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        MsgBox("Import Success!")
        Process.Start("C:\Users\Mico\Desktop\Class Manager\Class Manager\bin\Debug\")
    End Sub


    Private Sub Import_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseHover

        Import.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Import_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseLeave

        Import.Image = My.Resources.addbrowse


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Browse.Click
        Using FileDialog As New OpenFileDialog
            FileDialog.Title = "Select database to import"
            FileDialog.Filter = "Class Manager Files|*.db"
            If FileDialog.ShowDialog() = DialogResult.OK Then
                TextBox1.Text = FileDialog.FileName()
                Import.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Browse_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseHover

        Browse.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Browse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseLeave

        Browse.Image = My.Resources.addbrowse


    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
    = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        Home.Show()

    End Sub
End Class