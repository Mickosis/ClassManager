Imports System.IO
Imports System.Data.SQLite

Public Class AddAStudent

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox4.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub


    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Home.Show()


    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ImportExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        ImportExcelHome.Show()

    End Sub

    Private Sub ViewStudentsListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        StudentsHome.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

   Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Then
                MsgBox("Student Number Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            ElseIf TextBox2.Text = "" Then
                MsgBox("First Name Missing", MsgBoxStyle.OkOnly, msgboxtitle)
            ElseIf TextBox3.Text = "" Then
                MsgBox("Last Name Missing", MsgBoxStyle.OkOnly, msgboxtitle)
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
                SQLSTR = "INSERT INTO MasterStudents (StudentID, FirstName, LastName, ContactNumber, EmailAddress, path) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', @name)"
                alterDB()
                MsgBox("Input successful!", , msgboxtitle)
                SQLCONN.Close()
                SQLCMD.Parameters.Clear()
                PictureBox1.ImageLocation = "C:\Mickosis\Class Manager\Default.png"
                Dim thepath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                TextBox6.Text = "C:\Mickosis\Class Manager\Default.png"
                Me.Hide()
                StudentsHome.LoadGrades()
                StudentsHome.Show()
            End If
        End If
    End Sub

    Public Sub ClearShitOut()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

    End Sub

    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add.MouseHover

        Add.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub SAdd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add.MouseLeave

        Add.Image = My.Resources.addbrowse

    End Sub

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

        Browse.Image = My.Resources.addbrowsepressed

    End Sub
    Private Sub Browse_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browse.MouseLeave

        Browse.Image = My.Resources.addbrowse

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub HomeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        StudentsHome.Show()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class