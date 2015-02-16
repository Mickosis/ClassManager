Public Class Home
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Students.Click
        Me.Hide()
        StudentsHome.Show()
    End Sub

    Private Sub Students_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Students.MouseHover

        Students.Image = My.Resources.studentsbuttonpressed

    End Sub
    Private Sub Students_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Students.MouseLeave

        Students.Image = My.Resources.StudentsButton

    End Sub

    Private Sub Classes_Click(sender As Object, e As EventArgs) Handles Classes.Click
        Me.Hide()
        ClassHome.Show()

    End Sub

    Private Sub Classes_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Classes.MouseHover

        Classes.Image = My.Resources.classesbuttonpressed

    End Sub
    Private Sub Classes_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Classes.MouseLeave

        Classes.Image = My.Resources.ClassesButton

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Sync.Click
        Me.Hide()
        ImportExport.Show()
    End Sub

    Private Sub Sync_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sync.MouseHover

        Sync.Image = My.Resources.syncbuttonpressed

    End Sub
    Private Sub Sync_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sync.MouseLeave

        Sync.Image = My.Resources.SyncButton

    End Sub

    Private Sub Close_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close.MouseHover, Sync.MouseHover

        Close.Image = My.Resources.closebuttonpressed

    End Sub
    Private Sub Close_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close.MouseLeave, Sync.MouseLeave

        Close.Image = My.Resources.CloseButton

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
         = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class
