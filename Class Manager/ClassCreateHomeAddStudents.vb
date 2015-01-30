Imports System.Data.SQLite

Public Class ClassCreateHomeAddStudents

    Private Sub ClassCreateHomeAddStudents_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

            DBConn()
            SQLSTR = "SELECT * FROM MasterStudents"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            ListView1.Clear()
            DBConn()
            SQLSTR = "SELECT * FROM MasterStudents WHERE StudentID LIKE '%" & TextBox1.Text & "%' AND FirstName LIKE '" & TextBox2.Text & "%' AND LastName LIKE '" & TextBox3.Text & "%' "
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

    Public Sub ListView1_MouseDown(ByVal sender As Object, _
    ByVal e As MouseEventArgs) Handles ListView1.MouseDown

        Dim selection As ListViewItem = ListView1.GetItemAt(e.X, e.Y)

        If Not (selection Is Nothing) Then
            PictureBox1.Image = System.Drawing.Image.FromFile _
                (selection.SubItems(5).Text)
        End If

        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each item As ListViewItem In ListView1.SelectedItems
            Dim StudentID As Integer : StudentID = CInt(item.SubItems(0).Text)
            Dim FirstName As String : FirstName = item.SubItems(1).Text
            Dim LastName As String : LastName = item.SubItems(2).Text
            SQLSTR = "INSERT INTO '" & TextBox4.Text & "' (StudentID, FirstName, LastName) VALUES ('" & StudentID & "', '" & FirstName & "', '" & LastName & "')"
            DBConn()
            alterDB()
        Next
        MsgBox("Students added!", , msgboxtitle)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        ClassHome.Show()

    End Sub
End Class