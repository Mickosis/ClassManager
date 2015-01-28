Imports System.Data.SqlClient
Imports System.Web
Imports System.IO
Imports System.Net.Mail

Public Class EmailStudent

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
            e_mail.To.Add(TextBox3.Text)
            e_mail.Subject = TextBox4.Text
            e_mail.IsBodyHtml = False
            e_mail.Body = RichTextBox1.Text()
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        StudentsHome.Show()

    End Sub
End Class