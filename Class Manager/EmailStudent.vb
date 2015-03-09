Imports System.Data.SqlClient
Imports System.Web
Imports System.IO
Imports System.Net.Mail
Imports System.Data.SQLite

Public Class EmailStudent

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Email.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(TextBox1.Text, TextBox2.Text)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(TextBox1.Text)
            e_mail.To.Add(RichTextBox2.Text)
            e_mail.Subject = TextBox4.Text
            e_mail.IsBodyHtml = False
            e_mail.Body = RichTextBox1.Text()
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

            DBConn()
            SQLSTR = "UPDATE LoginCredentials SET username = '" & TextBox1.Text & "', password = '" & TextBox2.Text & "' WHERE IndexID = 2"
            alterDB()
            SQLDR.Dispose()
            SQLCONN.Close()


        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

    End Sub

    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Email.MouseHover

        Email.Image = My.Resources.arrowpressed

    End Sub
    Private Sub Add_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Email.MouseLeave

        Email.Image = My.Resources.arrow_mail


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        StudentsHome.Show()
        Me.Hide()


    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        StudentsHome.Show()
        Me.Hide()



    End Sub
End Class