Imports System.Data.SQLite
Imports System.IO

Public Class ClassCreateHomeAddStudents

    Private Sub ClassCreateHomeAddStudents_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        DBConn()
        SQLSTR = "SELECT * FROM MasterStudents ORDER BY LastName, StudentID"
        readDB()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = True
        ListView1.Clear()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Search.Click
        ListView1.Clear()
        DBConn()
        SQLSTR = "SELECT * FROM MasterStudents WHERE StudentID LIKE '%" & TextBox1.Text & "%' AND FirstName LIKE '" & TextBox2.Text & "%' AND LastName LIKE '" & TextBox3.Text & "%' ORDER BY LastName, StudentID"
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
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub

    Private Sub Search_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.MouseHover

        Search.Image = My.Resources.Browse_and_Update_pressed


    End Sub
    Private Sub Search_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Search.MouseLeave

        Search.Image = My.Resources.Browse_and_Update


    End Sub

    Public Sub ListView1_MouseDown(ByVal sender As Object, _
ByVal e As MouseEventArgs) Handles ListView1.MouseDown

        Dim selection As ListViewItem = ListView1.GetItemAt(e.X, e.Y)
        If Not (selection Is Nothing) Then
            Dim curFile As String = selection.SubItems(5).Text
            If (File.Exists(curFile)) Then
                PictureBox1.Image = System.Drawing.Image.FromFile _
                (selection.SubItems(5).Text)
            Else
                PictureBox1.Image = System.Drawing.Image.FromFile _
                ("C:\Mickosis\Class Manager\Default.png")
            End If
        End If
        Search.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Add.Click
        Try
            For Each item As ListViewItem In ListView1.SelectedItems
                Dim StudentID As Integer : StudentID = CInt(item.SubItems(0).Text)
                Dim FirstName As String : FirstName = item.SubItems(1).Text
                Dim LastName As String : LastName = item.SubItems(2).Text
                SQLSTR = "INSERT INTO '" & TextBox4.Text & "' (StudentID, FirstName, LastName) VALUES ('" & StudentID & "', '" & FirstName & "', '" & LastName & "')"
                DBConn()
                alterDB()
            Next
            MsgBox("Students added!", , msgboxtitle)
            SQLDR.Dispose()
            SQLCONN.Close()
        Catch ex As SQLiteException
            MsgBox("Student already added into the class.")
        End Try

    End Sub


    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add.MouseHover

        Add.Image = My.Resources.importdbasepressed


    End Sub
    Private Sub Add_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Add.MouseLeave

        Add.Image = My.Resources.importdbase


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        AddGrades.TextBox1.Text = TextBox4.Text
        Me.Hide()
        AddGrades.AddGrades()
        AddGrades.Show()
    End Sub
End Class