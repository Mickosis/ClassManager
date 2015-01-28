Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class UpdateStudent

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Choose a Profile Photo"
        fdlg.Filter = "Picture Files(*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        fdlg.FilterIndex = 2
        fdlg.RestoreDirectory = True
        If fdlg.ShowDialog() = DialogResult.OK Then
            If File.Exists(fdlg.FileName) = False Then
                MessageBox.Show("Sorry, The File You Specified Does Not Exist.", msgboxtitle)
            Else
                PictureBox1.ImageLocation = fdlg.FileName
            End If

        End If

        TextBox6.Text = fdlg.FileName.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Then
                MsgBox("Student Number Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            ElseIf TextBox2.Text = "" Then
                MsgBox("First Name Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Last Name Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            ElseIf TextBox4.Text = "" Then
                MsgBox("Contact Number Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            ElseIf TextBox5.Text = "" Then
                MsgBox("E-mail Address Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            Else
                Dim sourcepath As String = TextBox6.Text
                Dim DestPath As String = "C:\Mickosis\Class Manager\"
                Dim folderpath As String = TextBox1.Text
                If Not Directory.Exists(DestPath) Then
                    Directory.CreateDirectory(DestPath)
                End If
                Directory.CreateDirectory("C:\Mickosis\Class Manager\" + folderpath)
                Dim file = New FileInfo(TextBox6.Text)
                file.CopyTo(Path.Combine(DestPath, TextBox1.Text, file.Name), True)
                DBConn()
                SQLCMD.Parameters.AddWithValue("@name", Path.Combine(DestPath, TextBox1.Text, file.Name))
                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim data As Byte() = ms.GetBuffer()
                Dim p As New SQLiteParameter("@photo", SqlDbType.Image)
                p.Value = data
                SQLCMD.Parameters.Add(p)
                SQLSTR = "UPDATE MasterStudents SET FirstName= '" & TextBox2.Text & "', LastName= '" & TextBox3.Text & "', ContactNumber= '" & TextBox4.Text & "', EmailAddress= '" & TextBox5.Text & "', path = @name  WHERE StudentID = '" & TextBox1.Text & "'"
                alterDB()
                MsgBox("Update successful!", , msgboxtitle)
                SQLCONN.Close()
                ms.Dispose()
                Me.Hide()
                StudentsHome.Show()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        StudentsHome.Show()

    End Sub
End Class