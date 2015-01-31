﻿Imports System.Web
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



    Private Sub ImportExcelFileToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Me.Hide()
        ImportExcelHome.Show()

    End Sub

    Private Sub AddAStudentToolStripMenuItem_Click(sender As Object, e As EventArgs)
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

        AddStudent.Enabled = True
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
    End Sub

    Private Sub Update_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseHover

        Update.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Update_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseLeave

        Update.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Email.Click
        EmailStudent.Show()
        Me.Hide()
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                EmailStudent.TextBox3.Text = .SubItems(4).Text

            End With
        End If
    End Sub

    Private Sub Email_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Email.MouseHover

        Email.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Email_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Email.MouseLeave

        Email.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub StudentsHome_Activate(sender As Object, e As EventArgs) Handles MyBase.Activated
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Search.Click
        DBConn()
        SQLSTR = "SELECT * FROM MasterStudents WHERE StudentID LIKE '%" & TextBox2.Text & "%' AND FirstName LIKE '" & TextBox3.Text & "%' AND LastName LIKE '" & TextBox4.Text & "%' "
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
        Me.Hide()
        ImportExcelHome.Show()
    End Sub

    Private Sub Import_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseHover

        Import.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Import_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Import.MouseLeave

        Import.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub ViewStudentsListToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles AddStudent.Click
        Me.Hide()
        AddAStudent.Show()
    End Sub
    Private Sub Add_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddStudent.MouseHover

        AddStudent.Image = My.Resources.Students_Update_and_Contact_pressed

    End Sub
    Private Sub Add_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddStudent.MouseLeave

        AddStudent.Image = My.Resources.Students_Update_and_Contact


    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles Refresh.Click

    End Sub

    Private Sub Refresh_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Refresh.MouseHover

        Refresh.Image = My.Resources.okaypressed

    End Sub
    Private Sub Refresh_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Refresh.MouseLeave

        Refresh.Image = My.Resources.okay


    End Sub

End Class