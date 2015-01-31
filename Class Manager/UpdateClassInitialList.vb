Imports System.Data.SQLite

Public Class UpdateClassInitialList

    Public Sub UpdateClassInitialList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        Dim ClassIntl = TextBox1.Text
        DBConn()
        SQLSTR = "SELECT * FROM '" & ClassIntl & "'"
        readDB()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.MultiSelect = False
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 80)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Students.Click
        Dim ClassIntl = TextBox1.Text
        Me.Hide()
        ClassCreateHomeAddStudents.TextBox4.Text = ClassIntl
        ClassCreateHomeAddStudents.Show()

    End Sub


    Private Sub Students_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Students.MouseHover

        Students.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Students_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Students.MouseLeave

        Students.Image = My.Resources.Browse_and_Update


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Grade.Click
        Dim ClassIntl = TextBox1.Text
        AddGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddGrades.Show()
    End Sub

    Private Sub Grade_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grade.MouseHover

        Grade.Image = My.Resources.Browse_and_Update_pressed

    End Sub
    Private Sub Grade_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grade.MouseLeave

        Grade.Image = My.Resources.Browse_and_Update


    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        ClassHome.Show()

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
      MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
      = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class