Imports System.Web
Imports System.IO
Imports System.Net.Mail

Public Class StudentsHome

    Private Sub ImportExcelFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
        ImportExcelHome.Show()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Close()
        Home.Show()

    End Sub

    Private Sub ImportExcelFileToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ImportExcelFileToolStripMenuItem.Click
        Me.Close()
        ImportExcelHome.Show()

    End Sub

    Private Sub StudentsHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DBConn()
            SQLSTR = "SELECT * FROM MasterStudents"
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
            SQLDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAStudentToolStripMenuItem.Click
        Me.Close()
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
        UpdateStudent.Show()
        Me.Close()
        PictureBox1.Image = Nothing
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                UpdateStudent.Textbox1.Text = .SubItems(0).Text
                UpdateStudent.Textbox2.Text = .SubItems(1).Text
                UpdateStudent.Textbox3.Text = .SubItems(2).Text
                UpdateStudent.Textbox4.Text = .SubItems(3).Text
                UpdateStudent.TextBox5.Text = .SubItems(4).Text
                UpdateStudent.TextBox6.Text = .SubItems(5).Text
                UpdateStudent.PictureBox1.Image = System.Drawing.Image.FromFile _
                    (.SubItems(5).Text)

            End With
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EmailStudent.Show()
        Me.Close()
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                EmailStudent.TextBox3.Text = .SubItems(4).Text

            End With
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class