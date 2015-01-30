﻿Imports System.Data.SQLite

Public Class UpdateClassInitialList

    Public Sub UpdateClassInitialList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ClassIntl = TextBox1.Text
        Try
            DBConn()
            SQLSTR = "SELECT * FROM '" & ClassIntl & "'"
            readDB()
            ListView1.GridLines = True
            ListView1.FullRowSelect = True
            ListView1.View = View.Details
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
            SQLDR.Close()
        Catch ex As SQLiteException
            MsgBox("An exception occurred:" & ex.Message, , msgboxtitle)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ClassIntl = TextBox1.Text
        Me.Hide()
        ClassCreateHomeAddStudents.TextBox4.Text = ClassIntl
        ClassCreateHomeAddStudents.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ClassIntl = TextBox1.Text
        AddGrades.TextBox1.Text = ClassIntl
        Me.Hide()
        AddGrades.Show()
    End Sub
End Class