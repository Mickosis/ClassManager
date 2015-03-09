Imports System.Web
Imports System.IO
Imports System.Net.Mail
Imports System.Data.SQLite

Public Class StudentsHome

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub

    Public Sub ClearShitOut()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

    End Sub

    Private Sub ImportExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ImportExcelHome.Show()
        Me.Hide()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Home.Show()
        Me.Hide()
    End Sub



    Private Sub ImportExcelFileToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        ImportExcelHome.Show()
        Me.Hide()

    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AddAStudent.Show()
        Me.Hide()

    End Sub

    Private Sub ListView1_MouseDown(ByVal sender As Object, _
ByVal e As MouseEventArgs) Handles ListView1.MouseDown

        Dim selection As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
        If Not (selection Is Nothing) Then
            Dim curFile As String = selection.SubItems(5).Text
            If (File.Exists(curFile)) Then
                PictureBox1.Image = System.Drawing.Image.FromFile _
                (selection.SubItems(5).Text)
                TextBox1.Text = (selection.SubItems(5).Text)
                Update.Enabled = True
                Button1.Enabled = True
                Email.Enabled = True
            Else
                PictureBox1.Image = System.Drawing.Image.FromFile _
                ("C:\Mickosis\Class Manager\Default.png")
                TextBox1.Text = "C:\Mickosis\Class Manager\Default.png"
                Update.Enabled = True
                Button1.Enabled = True
                selection.SubItems(5).Text = "C:\Mickosis\Class Manager\Default.png"
            End If
        Else
            Update.Enabled = False
            Button1.Enabled = False
            Email.Enabled = False
        End If


    End Sub

    Private Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        PictureBox1.Image = Nothing
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                UpdateStudent.TextBox1.Text = .SubItems(0).Text
                UpdateStudent.TextBox2.Text = .SubItems(1).Text
                UpdateStudent.TextBox3.Text = .SubItems(2).Text
                UpdateStudent.TextBox4.Text = .SubItems(3).Text
                UpdateStudent.TextBox5.Text = .SubItems(4).Text
                UpdateStudent.TextBox6.Text = .SubItems(5).Text
                UpdateStudent.PictureBox1.Image = System.Drawing.Image.FromFile _
                    (.SubItems(5).Text)
                UpdateStudent.Show()
                Me.Hide()
            End With
        End If

        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub

    Private Sub Update_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseHover

        Update.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Update_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseLeave

        Update.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Email.Click
        EmailStudent.TextBox1.Clear()
        EmailStudent.TextBox2.Clear()
        EmailStudent.RichTextBox2.Clear()

        Dim list As New List(Of String)
        EmailStudent.Show()
        Me.Hide()
        For Each item As ListViewItem In ListView1.SelectedItems
            list.Add(item.SubItems(4).Text)
            EmailStudent.RichTextBox2.Text = String.Join(", ", list.ToArray)
        Next

        DBConn()
        Dim querystring As String = "SELECT username, password FROM LoginCredentials WHERE IndexID = 2"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            EmailStudent.TextBox1.Text = reader.GetValue(0)
            EmailStudent.TextBox2.Text = reader.GetValue(1)
        End While
        reader.Close()

    End Sub

    Private Sub Email_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Email.MouseHover

        Email.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Email_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Email.MouseLeave

        Email.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Public Sub LoadGrades()
        DBConn()
        SQLSTR = "SELECT * FROM MasterStudents ORDER BY LastName, StudentID"
        readDB()
        ListView1.Clear()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = True
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 80)
        ListView1.Columns.Add("Contact Number", 80)
        ListView1.Columns.Add("E-mail", 80)
        ListView1.Columns.Add("Path", 50)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("ContactNumber"))
                .subitems.add(SQLDR("EmailAddress"))
                .subitems.add(SQLDR("Path"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

    End Sub

    Public Sub CheckText(ByVal sender As Object, e As EventArgs) Handles TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged

        If TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" Then
            Search.Enabled = False
        Else
            Search.Enabled = True
        End If

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Search.Click

        ListView1.Clear()
        DBConn()
        SQLSTR = "SELECT * FROM MasterStudents WHERE StudentID LIKE '%" & TextBox2.Text & "%' AND FirstName LIKE '" & TextBox3.Text & "%' AND LastName LIKE '" & TextBox4.Text & "%' ORDER BY LastName, StudentID"
        readDB()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = False
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 80)
        ListView1.Columns.Add("Contact Number", 80)
        ListView1.Columns.Add("E-mail", 80)
        ListView1.Columns.Add("Path", 10)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("ContactNumber"))
                .subitems.add(SQLDR("EmailAddress"))
                .subitems.add(SQLDR("path"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

    End Sub

    Private Sub Search_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.MouseHover

        Search.Image = My.Resources.okaypressed

    End Sub
    Private Sub Search_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.MouseLeave

        Search.Image = My.Resources.okay

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Import_Click(sender As Object, e As EventArgs) Handles Import.Click

        ImportExcelHome.ClearShitOut()
        ImportExcelHome.Show()
        Me.Hide()
    End Sub

    Private Sub Import_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseHover

        Import.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Import_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseLeave

        Import.Image = My.Resources.Students_Update_and_Contact


    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles AddStudent.Click

        AddAStudent.ClearShitOut()
        AddAStudent.Show()
        Me.Hide()
    End Sub
    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddStudent.MouseHover

        AddStudent.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Add_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddStudent.MouseLeave

        AddStudent.Image = My.Resources.Students_Update_and_Contact


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                Dim DeleteNumber As String = .SubItems(0).Text
                Dim Result = MsgBox("Are you sure you want to delete student?", MessageBoxButtons.YesNo, msgboxtitle)
                DBConn()
                If Result = DialogResult.Yes Then
                    SQLSTR = "DELETE FROM MasterStudents WHERE StudentID = '" & DeleteNumber & "'"
                    alterDB()
                    MsgBox("Student deleted succesfully!", , msgboxtitle)
                    LoadGrades()
                End If
            End With
        End If
    End Sub

    Private Sub Delete_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Delete_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub StudentsHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class