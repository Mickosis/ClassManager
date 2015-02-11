Imports System.Data.SQLite

Public Class AdminControlLogin

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
                Me.Hide()
                AdminSettings.Show()
            Else
                MsgBox("Incorrect Login!")
                TextBox1.Clear()
                TextBox2.Clear()
                SQLDR.Dispose()
                SQLCONN.Close()
            End If
        End If
    End Sub
End Class