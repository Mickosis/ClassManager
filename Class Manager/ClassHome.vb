Public Class ClassHome

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        ClassCreateHome.RichTextBox1.Clear()
        ClassCreateHome.TextBox1.Clear()
        ClassCreateHome.ComboBox1.Text = ""
        ClassCreateHome.Show()
        Me.Hide()

    End Sub

    Private Sub Create_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Create.MouseHover

        Create.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Create_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Create.MouseLeave

        Create.Image = My.Resources.importdbase


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Update.Click
        UpdateClass.Show()
        Me.Hide()

    End Sub

    Private Sub Update_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseHover

        Update.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Update_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseLeave

        Update.Image = My.Resources.importdbase
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HomeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Home.Show()
        Me.Hide()

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        AdminControlLogin.Show()
        Me.Hide()

    End Sub

    Private Sub Settings_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Settings_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.importdbase
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        QuizMaker.ComboBox1.Text = ""
        QuizMaker.RichTextBox1.Clear()
        QuizMaker.Show()
        Me.Hide()

    End Sub

    Private Sub Settings2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover

        Button2.Image = My.Resources.importdbasepressed

    End Sub
    Private Sub Settings2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Button2.Image = My.Resources.importdbase
    End Sub
End Class