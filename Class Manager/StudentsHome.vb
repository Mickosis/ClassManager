Imports System.Web
Imports System.IO
Imports System.Net.Mail
Imports System.Data.SQLite

Public Class StudentsHome

    Private Sub ImportExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        ImportExcelHome.Show()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        Home.Show()

    End Sub

    Private Sub ImportExcelFileToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ImportExcelFileToolStripMenuItem.Click
        Me.Hide()
        ImportExcelHome.Show()

    End Sub

    Private Sub StudentsHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.PerformClick()

    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAStudentToolStripMenuItem.Click
        Me.Hide()
        AddAStudent.Show()
    End Sub

    Private Sub ListView1_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs) Handles ListView1.MouseDown

        Dim selection As ListViewItem = ListView1.GetItemAt(e.X, e.Y)

        If Not (selection Is Nothing) Then
            PictureBox1.Image = System.Drawing.Image.FromFile _
                (selection.SubItems(5).Text)

            TextBox1.Text = (selection.SubItems(4).Text)
        End If

        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EmailStudent.Show()
        Me.Hide()
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                EmailStudent.TextBox3.Text = .SubItems(4).Text

            End With
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim confirm As DialogResult = MsgBox("Do you want to delete student from directory?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            DBConn()
            With ListView1.SelectedItems.Item(0)
                SQLSTR = "DELETE FROM MasterStudents WHERE StudentID = '" & .SubItems(0).Text & "'"
            End With
            alterDB()
            MsgBox("Student removed!")
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DBConn()
        SQLSTR = "SELECT * FROM MasterStudents"
        readDB()
        ListView1.Clear()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = False
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
                .subitems.add(SQLDR("path"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub
End Class