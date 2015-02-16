Imports System.Data.SQLite

Public Class AddGrades

    Private Sub AddGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ClassIntl = TextBox1.Text
        DBConn()
        SQLSTR = "SELECT * FROM '" & ClassIntl & "'"
        readDB()
        ListView1.Clear()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = False
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 80)
        ListView1.Columns.Add("Prelim", 50)
        ListView1.Columns.Add("Midterm", 50)
        ListView1.Columns.Add("Final", 50)
        ListView1.Columns.Add("Semestral", 80)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("pGrade"))
                .subitems.add(SQLDR("mGrade"))
                .subitems.add(SQLDR("fGrade"))
                .subitems.add(SQLDR("semGrade"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

        'Get Admin weights first!!
        Dim pWeight As Integer
        Dim mWeight As Integer
        Dim fWeight As Integer
        DBConn()
        Dim querystring As String = "SELECT PrelimWeight, MidtermWeight, FinalWeight FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            pWeight = reader.GetValue(0)
            mWeight = reader.GetValue(1)
            fWeight = reader.GetValue(2)
        End While
        reader.Close()

        Dim lv As ListViewItem
        For Each lv In ListView1.Items
            Dim pWeighted As Double = pWeight / 100
            Dim mWeighted As Double = mWeight / 100
            Dim fWeighted As Double = fWeight / 100
            Dim pGrade As Double = lv.SubItems(3).Text * pWeighted
            Dim mGrade As Double = lv.SubItems(4).Text * mWeighted
            Dim fGrade As Double = lv.SubItems(5).Text * fWeighted

            Dim semGrade As Integer = pGrade + mGrade + fGrade
            lv.SubItems(6).Text = semGrade

            DBConn()
            SQLSTR = "UPDATE '" & ClassIntl & "' SET semGrade = '" & semGrade & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
            alterDB()
        Next
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        UpdateClass.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ClassIntl = TextBox1.Text
        Me.Hide()
        ClassCreateHomeAddStudents.TextBox4.Text = ClassIntl
        ClassCreateHomeAddStudents.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ClassIntl = TextBox1.Text
        'Get Admin weights first!!
        Dim pWeight As Integer
        Dim mWeight As Integer
        Dim fWeight As Integer
        DBConn()
        Dim querystring As String = "SELECT PrelimWeight, MidtermWeight, FinalWeight FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            pWeight = reader.GetValue(0)
            mWeight = reader.GetValue(1)
            fWeight = reader.GetValue(2)
        End While
        reader.Close()

        Dim lv As ListViewItem
        For Each lv In ListView1.Items
            Dim pWeighted As Double = pWeight / 100
            Dim mWeighted As Double = mWeight / 100
            Dim fWeighted As Double = fWeight / 100
            Dim pGrade As Double = lv.SubItems(3).Text * pWeighted
            Dim mGrade As Double = lv.SubItems(4).Text * mWeighted
            Dim fGrade As Double = lv.SubItems(5).Text * fWeighted

            Dim semGrade As Integer = pGrade + mGrade + fGrade
            lv.SubItems(6).Text = semGrade

            DBConn()
            SQLSTR = "UPDATE '" & ClassIntl & "' SET semGrade = '" & semGrade & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
            alterDB()
        Next
        SQLDR.Dispose()
        SQLCONN.Close()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ClassIntl = TextBox1.Text
        AddPrelimGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddPrelimGrades.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ClassIntl = TextBox1.Text
        AddMidtermGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddMidtermGrades.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ClassIntl = TextBox1.Text
        AddFinalGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddFinalGrades.Show()
    End Sub
End Class





