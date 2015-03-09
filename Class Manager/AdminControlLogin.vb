Imports System.Data.SQLite

Public Class AdminControlLogin
    Dim LoginAttempts = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MsgBox("Please enter a username!")
            TextBox1.Clear()
            TextBox2.Clear()
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please enter a password!")
            TextBox1.Clear()
            TextBox2.Clear()
        Else
            SQLSTR = "SELECT * FROM LoginCredentials WHERE username = '" & TextBox1.Text & "' AND PASSWORD = '" & TextBox2.Text & "'"
            DBConn()
            readDB()
            If SQLDR.Read Then
                MsgBox("Success!")
                TextBox1.Clear()
                TextBox2.Clear()
                SQLDR.Dispose()
                SQLCONN.Close()
                LoginAttempts = 0
                AdminSettings.Show()
                Me.Hide()
            Else
                LoginAttempts += 1
                If LoginAttempts = 1 Then
                    MessageBox.Show("Incorrect password!")
                ElseIf LoginAttempts = 2 Then
                    MessageBox.Show("Incorrect password!")
                ElseIf LoginAttempts = 3 Then
                    MessageBox.Show("Login failed for 3 tries. Closing.")
                    Me.Close()
                End If
                TextBox1.Clear()
                TextBox2.Clear()
                SQLDR.Dispose()
                SQLCONN.Close()
            End If
        End If

    End Sub

    Private Sub Settings_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Settings_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.addbrowse
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click

        ClassHome.Show()
        Me.Hide()
    End Sub

    Private Sub StudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentToolStripMenuItem.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class