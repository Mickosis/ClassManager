Imports System.Data.SQLite

Public Class AddFinalGrades

    Private Sub AddFinalGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ListView1.Columns.Add("Quizzes", 50)
        ListView1.Columns.Add("Attendance", 50)
        ListView1.Columns.Add("Recitation", 50)
        ListView1.Columns.Add("Projects", 50)
        ListView1.Columns.Add("Homework", 50)
        ListView1.Columns.Add("Others", 50)
        ListView1.Columns.Add("Exam", 50)
        ListView1.Columns.Add("Finals", 50)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("fQuiz"))
                .subitems.add(SQLDR("fAttend"))
                .subitems.add(SQLDR("fRecite"))
                .subitems.add(SQLDR("fProject"))
                .subitems.add(SQLDR("fHomework"))
                .subitems.add(SQLDR("fOthers"))
                .subitems.add(SQLDR("fExam"))
                .subitems.add(SQLDR("fGrade"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

        DBConn()
        Dim querystring As String = "SELECT fQuiz, fAttend, fRecite, fProject, fHomework, fOthers FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
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
                GradeMe.Show()
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim C1 As Integer = TextBox2.Text
        Dim C2 As Integer = TextBox3.Text
        Dim C3 As Integer = TextBox4.Text
        Dim C4 As Integer = TextBox5.Text
        Dim C5 As Integer = TextBox6.Text
        Dim C6 As Integer = TextBox7.Text
        Dim ComputeCheck = C1 + C2 + C3 + C4 + C5 + C6
        Dim ClassIntl = TextBox1.Text

        'Get Admin weights first!!
        Dim PmTotalCS As Integer
        Dim PmExam As Integer
        Dim FTotalCS As Integer
        Dim FExam As Integer
        Dim PassMark As Integer
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
            SQLSTR = "UPDATE MasterClasslist SET fQuiz = '" & TextBox2.Text & "', fAttend = '" & TextBox3.Text & "', fRecite = '" & TextBox4.Text & "', fProject = '" & TextBox5.Text & "', fHomework = '" & TextBox6.Text & "', fOthers = '" & TextBox7.Text & "' WHERE ClassID = '" & ClassIntl & "'"
            alterDB()
            SQLDR.Dispose()
            SQLCONN.Close()

            Dim lv As ListViewItem
            For Each lv In ListView1.Items
                Dim Quiz As Integer = lv.SubItems(3).Text * C1 / 100
                Dim Attend As Integer = lv.SubItems(4).Text * C2 / 100
                Dim Recite As Integer = lv.SubItems(5).Text * C3 / 100
                Dim Project As Integer = lv.SubItems(6).Text * C4 / 100
                Dim Homework As Integer = lv.SubItems(7).Text * C5 / 100
                Dim Others As Integer = lv.SubItems(8).Text * C6 / 100
                Dim Exam As Integer = lv.SubItems(9).Text * FExam / 100

                Dim TotalCS As Integer = Quiz + Attend + Recite + Project + Homework + Others
                Dim TotalCSWeighted As Integer = TotalCS * PmTotalCS / 100
                Dim TotalGrade As Integer = TotalCSWeighted + Exam
                lv.SubItems(10).Text = TotalGrade

                DBConn()
                SQLSTR = "UPDATE '" & ClassIntl & "' SET fGrade = '" & TotalCSWeighted & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
                alterDB()
            Next
            SQLDR.Dispose()
            SQLCONN.Close()
        End If
    End Sub
End Class