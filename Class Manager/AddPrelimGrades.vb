﻿Imports System.Data.SQLite

Public Class AddPrelimGrades




    Private Sub AddPrelimGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ListView1.Columns.Add("Quizzes", 80)
        ListView1.Columns.Add("Attendance", 80)
        ListView1.Columns.Add("Recitation", 80)
        ListView1.Columns.Add("Projects", 80)
        ListView1.Columns.Add("Homework", 80)
        ListView1.Columns.Add("Others", 80)
        ListView1.Columns.Add("Prelim", 80)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("pQuiz"))
                .subitems.add(SQLDR("pAttend"))
                .subitems.add(SQLDR("pRecite"))
                .subitems.add(SQLDR("pProject"))
                .subitems.add(SQLDR("pHomework"))
                .subitems.add(SQLDR("pOthers"))
                .subitems.add(SQLDR("pGrade"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

        DBConn()
        Dim querystring As String = "SELECT pQuiz, pAttend, pRecite, pProject, pHomework, pOthers FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            TextBox2.Text = reader.GetValue(0)
            TextBox3.Text = reader.GetValue(1)
            TextBox4.Text = reader.GetValue(2)
            TextBox5.Text = reader.GetValue(3)
            TextBox6.Text = reader.GetValue(4)
            TextBox7.Text = reader.GetValue(5)
        End While
        reader.Close()
    End Sub

End Class