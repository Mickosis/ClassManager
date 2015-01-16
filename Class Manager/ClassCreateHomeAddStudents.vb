﻿Public Class ClassCreateHomeAddStudents

    Private Sub ClassCreateHomeAddStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLCONN.Close()

        Try
            DBConn()
            SQLSTR = "SELECT * FROM MasterStudents"
            readDB()
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
                    .subitems.add(SQLDR("path"))
                End With
            End While
            SQLDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            DBConn()
            SQLSTR = "SELECT * FROM MasterStudents WHERE StudentID LIKE '%" & TextBox1.Text & "%' OR FirstName LIKE '" & TextBox2.Text & "%' OR LastName LIKE '" & TextBox3.Text & "%' "
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
        Catch ex As Exception

            SQLCONN.Close()
        End Try
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
        Try
            For Each item As ListViewItem In ListView1.SelectedItems
                Dim StudentID = Integer.Parse(item.SubItems(0).Text)
                Dim FirstName = item.SubItems(1).Text
                Dim LastName = item.SubItems(2).Text
                DBConn()
                SQLSTR = "INSERT INTO '" & TextBox4.Text & "' (StudentID, FirstName, LastName) VALUES '" & StudentID & "', '" & FirstName & "', '" & LastName & "' "
                alterDB()
                MsgBox("Students succesfully added", msgboxtitle)
            Next
        Catch ex As Exception
        End Try

    End Sub

End Class