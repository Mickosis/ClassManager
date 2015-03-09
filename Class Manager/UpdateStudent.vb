Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class UpdateStudent

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Browse.Click
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

    Private Sub Browse_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseHover

        Browse.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Browse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseLeave

        Browse.Image = My.Resources.Browse_and_Update


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Update.Click
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
                If TextBox6.Text = "" Then
                    Dim thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    TextBox6.Text = thepath + "\Class Manager\Class Manager\Resources\Default.png"
                End If
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

                StudentsHome.LoadGrades()
                StudentsHome.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Update_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseHover

        Update.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Update_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseLeave

        Update.Image = My.Resources.Browse_and_Update


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        StudentsHome.Show()
        Me.Hide()

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click

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
End Class