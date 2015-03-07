Imports System.Data.SQLite
Imports System.IO

Public Class GradingSettings
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter whole numbers only")
            e.Handled = True
        End If
    End Sub

    Private Sub Import_Click(sender As Object, e As EventArgs) Handles Update.Click, Update.Click
        If TextBox1.Text = "" Then
            TextBox1.Text = 0
        ElseIf TextBox2.Text = "" Then
            TextBox2.Text = 0
        ElseIf TextBox3.Text = "" Then
            TextBox3.Text = 0
        ElseIf TextBox4.Text = "" Then
            TextBox4.Text = 0
        ElseIf TextBox5.Text = "" Then
            TextBox5.Text = 0
        ElseIf TextBox6.Text = "" Then
            TextBox6.Text = 0
        ElseIf TextBox7.Text = "" Then
            TextBox7.Text = 0
        Else
            If (AddPrelimGrades.Visible) Then
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

                Dim querystring2 As String = "SELECT pQuiz, pAttend, pRecite, pProject, pHomework, pOthers FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    AddPrelimGrades.Label7.Text = reader2.GetValue(0)
                    AddPrelimGrades.Label8.Text = reader2.GetValue(1)
                    AddPrelimGrades.Label9.Text = reader2.GetValue(2)
                    AddPrelimGrades.Label10.Text = reader2.GetValue(3)
                    AddPrelimGrades.Label11.Text = reader2.GetValue(4)
                    AddPrelimGrades.Label12.Text = reader2.GetValue(5)
                End While
                reader2.Close()

                If ComputeCheck > 100 Then
                    MsgBox("Criteria must not exceed 100, current is " & ComputeCheck)
                ElseIf ComputeCheck < 100 Then
                    MsgBox("Criteria must be equal to 100, current is " & ComputeCheck)
                Else
                    DBConn()
                    SQLSTR = "UPDATE MasterClasslist SET mQuiz = '" & TextBox2.Text & "', mAttend = '" & TextBox3.Text & "', mRecite = '" & TextBox4.Text & "', mProject = '" & TextBox5.Text & "', mHomework = '" & TextBox6.Text & "', mOthers = '" & TextBox7.Text & "' WHERE ClassID = '" & ClassIntl & "'"
                    alterDB()
                    SQLDR.Dispose()
                    SQLCONN.Close()

                    Dim lv As ListViewItem
                    For Each lv In AddPrelimGrades.ListView1.Items
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
                    Me.Hide()
                End If

            ElseIf (AddMidtermGrades.Visible) Then

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

                Dim querystring2 As String = "SELECT mQuiz, mAttend, mRecite, mProject, mHomework, mOthers FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    AddMidtermGrades.Label7.Text = reader2.GetValue(0)
                    AddMidtermGrades.Label8.Text = reader2.GetValue(1)
                    AddMidtermGrades.Label9.Text = reader2.GetValue(2)
                    AddMidtermGrades.Label10.Text = reader2.GetValue(3)
                    AddMidtermGrades.Label11.Text = reader2.GetValue(4)
                    AddMidtermGrades.Label12.Text = reader2.GetValue(5)
                End While
                reader2.Close()


                If ComputeCheck > 100 Then
                    MsgBox("Criteria must not exceed 100, current is " & ComputeCheck)
                ElseIf ComputeCheck < 100 Then
                    MsgBox("Criteria must be equal to 100, current is " & ComputeCheck)
                Else
                    DBConn()
                    SQLSTR = "UPDATE MasterClasslist SET mQuiz = '" & TextBox2.Text & "', mAttend = '" & TextBox3.Text & "', mRecite = '" & TextBox4.Text & "', mProject = '" & TextBox5.Text & "', mHomework = '" & TextBox6.Text & "', mOthers = '" & TextBox7.Text & "' WHERE ClassID = '" & ClassIntl & "'"
                    alterDB()
                    SQLDR.Dispose()
                    SQLCONN.Close()

                    Dim lv As ListViewItem
                    For Each lv In AddMidtermGrades.ListView1.Items
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
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET mGrade = '" & lv.SubItems(10).Text & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
                        alterDB()
                    Next
                    SQLDR.Dispose()
                    SQLCONN.Close()
                    Me.Hide()
                End If

            ElseIf (AddFinalGrades.Visible) Then
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

                Dim querystring2 As String = "SELECT fQuiz, fAttend, fRecite, fProject, fHomework, fOthers FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    AddFinalGrades.Label7.Text = reader2.GetValue(0)
                    AddFinalGrades.Label8.Text = reader2.GetValue(1)
                    AddFinalGrades.Label9.Text = reader2.GetValue(2)
                    AddFinalGrades.Label10.Text = reader2.GetValue(3)
                    AddFinalGrades.Label11.Text = reader2.GetValue(4)
                    AddFinalGrades.Label12.Text = reader2.GetValue(5)
                End While
                reader2.Close()


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
                    For Each lv In AddFinalGrades.ListView1.Items
                        Dim Quiz As Double = lv.SubItems(3).Text * C1 / 100
                        Dim Attend As Double = lv.SubItems(4).Text * C2 / 100
                        Dim Recite As Double = lv.SubItems(5).Text * C3 / 100
                        Dim Project As Double = lv.SubItems(6).Text * C4 / 100
                        Dim Homework As Double = lv.SubItems(7).Text * C5 / 100
                        Dim Others As Double = lv.SubItems(8).Text * C6 / 100
                        Dim Exam As Double = lv.SubItems(9).Text * FExam / 100

                        Dim TotalCS As Double = Quiz + Attend + Recite + Project + Homework + Others
                        Dim TotalCSWeighted As Double = TotalCS * FTotalCS / 100
                        lv.SubItems(10).Text = TotalCSWeighted + Exam

                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET fGrade = '" & lv.SubItems(10).Text & "' WHERE StudentID = '" & lv.SubItems(0).Text & "'"
                        alterDB()
                    Next
                    SQLDR.Dispose()
                    SQLCONN.Close()
                    Me.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub Prelim_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseHover

        Update.Image = My.Resources.addbrowsepressed

    End Sub

    Private Sub Prelim_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Update.MouseLeave

        Update.Image = My.Resources.addbrowse
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MessageBox.Show("Do you want to exit?", "Class Manager", _
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) _
       = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        Me.Hide()
    End Sub
End Class