﻿Imports System.Data.SQLite
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class AddPrelimGrades

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                GradeMe.Label18.Text = .SubItems(0).Text
                GradeMe.Label1.Text = .SubItems(1).Text
                GradeMe.Label2.Text = .SubItems(2).Text
                GradeMe.TextBox1.Text = .SubItems(3).Text
                GradeMe.TextBox2.Text = .SubItems(4).Text
                GradeMe.TextBox3.Text = .SubItems(5).Text
                GradeMe.TextBox4.Text = .SubItems(6).Text
                GradeMe.TextBox5.Text = .SubItems(7).Text
                GradeMe.TextBox6.Text = .SubItems(8).Text
                GradeMe.TextBox7.Text = .SubItems(9).Text
                GradeMe.Show()
            End With
        End If
    End Sub

    Public Sub LoadGrades()
        Dim ClassIntl = TextBox1.Text
        DBConn()
        SQLSTR = "SELECT * FROM '" & ClassIntl & "' ORDER BY LastName, StudentID"
        readDB()
        ListView1.Clear()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.MultiSelect = False
        ListView1.Columns.Add("StudentID", 80)
        ListView1.Columns.Add("First Name", 80)
        ListView1.Columns.Add("Last Name", 80)
        ListView1.Columns.Add("Quizzes", 50)
        ListView1.Columns.Add("Attendance", 50)
        ListView1.Columns.Add("Recitation", 50)
        ListView1.Columns.Add("Projects", 50)
        ListView1.Columns.Add("Homework", 50)
        ListView1.Columns.Add("Others", 50)
        ListView1.Columns.Add("Exam", 50)
        ListView1.Columns.Add("Prelim", 50)
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
                .subitems.add(SQLDR("pExam"))
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
        SQLDR.Dispose()
        SQLCONN.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim C1 As Double = TextBox2.Text
        Dim C2 As Double = TextBox3.Text
        Dim C3 As Double = TextBox4.Text
        Dim C4 As Double = TextBox5.Text
        Dim C5 As Double = TextBox6.Text
        Dim C6 As Double = TextBox7.Text
        Dim ComputeCheck = C1 + C2 + C3 + C4 + C5 + C6
        Dim ClassIntl = TextBox1.Text

        'Get Admin weights first!!
        Dim PmTotalCS As Double
        Dim PmExam As Double
        Dim FTotalCS As Double
        Dim FExam As Double
        Dim PassMark As Double
        DBConn()
        Dim querystring As String = "SELECT PMTotalCS, PMEXam, FTotalCS, FExam, PassingMark FROM GlobalGrades"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            PmTotalCS = reader.GetValue(0)
            PmExam = reader.GetValue(1)
            FTotalCS = reader.GetValue(2)
            FExam = reader.GetValue(3)
            PassMark = reader.GetValue(4)
        End While
        reader.Close()


        If ComputeCheck > 100 Then
            MsgBox("Criteria must not exceed 100, current is " & ComputeCheck)
        ElseIf ComputeCheck < 100 Then
            MsgBox("Criteria must be equal to 100, current is " & ComputeCheck)
        Else
            DBConn()
            SQLSTR = "UPDATE MasterClasslist SET pQuiz = '" & TextBox2.Text & "', pAttend = '" & TextBox3.Text & "', pRecite = '" & TextBox4.Text & "', pProject = '" & TextBox5.Text & "', pHomework = '" & TextBox6.Text & "', pOthers = '" & TextBox7.Text & "' WHERE ClassID = '" & ClassIntl & "'"
            alterDB()
            SQLDR.Dispose()
            SQLCONN.Close()

            Dim lv As ListViewItem
            For Each lv In ListView1.Items
                Dim Quiz As Double = lv.SubItems(3).Text * C1 / 100
                Dim Attend As Double = lv.SubItems(4).Text * C2 / 100
                Dim Recite As Double = lv.SubItems(5).Text * C3 / 100
                Dim Project As Double = lv.SubItems(6).Text * C4 / 100
                Dim Homework As Double = lv.SubItems(7).Text * C5 / 100
                Dim Others As Double = lv.SubItems(8).Text * C6 / 100
                Dim Exam As Double = lv.SubItems(9).Text * PmExam / 100

                Dim TotalCS As Double = Quiz + Attend + Recite + Project + Homework + Others
                Dim TotalCSWeighted As Double = TotalCS * PmTotalCS / 100
                lv.SubItems(10).Text = TotalCSWeighted + Exam

                DBConn()
                SQLSTR = "UPDATE '" & ClassIntl & "' SET pGrade = '" & lv.SubItems(10).Text & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
                alterDB()
            Next
            SQLDR.Dispose()
            SQLCONN.Close()
        End If

    End Sub

    Private Sub Prelim_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.importdbasepressed

    End Sub

    Private Sub Prelim_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.importdbase
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
        AddGrades.AddGrades()
        AddGrades.Show()
    End Sub
End Class