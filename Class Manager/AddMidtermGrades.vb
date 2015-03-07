Imports System.Data.SQLite

Public Class AddMidtermGrades
    Dim StudID As String
    Private Sub AddMidtermGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        ListView1.Columns.Add("First Name", 90)
        ListView1.Columns.Add("Last Name", 100)
        ListView1.Columns.Add("Quizzes", 70)
        ListView1.Columns.Add("Attendance", 90)
        ListView1.Columns.Add("Recitation", 80)
        ListView1.Columns.Add("Projects", 70)
        ListView1.Columns.Add("Homework", 90)
        ListView1.Columns.Add("Activities", 70)
        ListView1.Columns.Add("Exam", 50)
        ListView1.Columns.Add("Midterm", 70)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("StudentID"))
                .subitems.add(SQLDR("FirstName"))
                .subitems.add(SQLDR("LastName"))
                .subitems.add(SQLDR("mQuiz"))
                .subitems.add(SQLDR("mAttend"))
                .subitems.add(SQLDR("mRecite"))
                .subitems.add(SQLDR("mProject"))
                .subitems.add(SQLDR("mHomework"))
                .subitems.add(SQLDR("mOthers"))
                .subitems.add(SQLDR("mExam"))
                .subitems.add(SQLDR("mGrade"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()

        DBConn()
        Dim querystring As String = "SELECT mQuiz, mAttend, mRecite, mProject, mHomework, mOthers FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            Label7.Text = reader.GetValue(0)
            Label8.Text = reader.GetValue(1)
            Label9.Text = reader.GetValue(2)
            Label10.Text = reader.GetValue(3)
            Label11.Text = reader.GetValue(4)
            Label12.Text = reader.GetValue(5)

            GradingSettings.TextBox2.Text = reader.GetValue(0)
            GradingSettings.TextBox3.Text = reader.GetValue(1)
            GradingSettings.TextBox4.Text = reader.GetValue(2)
            GradingSettings.TextBox5.Text = reader.GetValue(3)
            GradingSettings.TextBox6.Text = reader.GetValue(4)
            GradingSettings.TextBox7.Text = reader.GetValue(5)
        End While
        reader.Close()
        SQLDR.Dispose()
        SQLCONN.Close()

        DBConn()
        Dim querystring2 As String = "SELECT mQuizTotal, mAttendTotal, mReciteTotal, mProjectTotal, mHomeworkTotal, mOthersTotal, mExamTotal FROM MasterClasslist WHERE ClassID = '" & ClassIntl & "'"
        Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
        Dim reader2 As SQLiteDataReader = command2.ExecuteReader
        While reader2.Read
            Label13.Text = reader2.GetValue(0)
            Label14.Text = reader2.GetValue(1)
            Label15.Text = reader2.GetValue(2)
            Label16.Text = reader2.GetValue(3)
            Label17.Text = reader2.GetValue(4)
            Label18.Text = reader2.GetValue(5)
            Label26.Text = reader2.GetValue(6)

            GradeMe.Label21.Text = reader2.GetValue(0)
            GradeMe.Label22.Text = reader2.GetValue(1)
            GradeMe.Label23.Text = reader2.GetValue(2)
            GradeMe.Label24.Text = reader2.GetValue(3)
            GradeMe.Label25.Text = reader2.GetValue(4)
            GradeMe.Label26.Text = reader2.GetValue(5)
            GradeMe.Label27.Text = reader2.GetValue(6)

            Edit_Total_Scores.TextBox2.Text = reader2.GetValue(0)
            Edit_Total_Scores.TextBox3.Text = reader2.GetValue(1)
            Edit_Total_Scores.TextBox4.Text = reader2.GetValue(2)
            Edit_Total_Scores.TextBox5.Text = reader2.GetValue(3)
            Edit_Total_Scores.TextBox6.Text = reader2.GetValue(4)
            Edit_Total_Scores.TextBox7.Text = reader2.GetValue(5)
            Edit_Total_Scores.TextBox8.Text = reader2.GetValue(6)
        End While
        reader2.Close()
        SQLDR.Dispose()
        SQLCONN.Close()


    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                Dim ClassIntl = TextBox1.Text
                GradeMe.Label18.Text = .SubItems(0).Text
                StudID = .SubItems(0).Text
                GradeMe.Label1.Text = .SubItems(1).Text
                GradeMe.Label2.Text = .SubItems(2).Text
                'GradeMe.TextBox1.Text = .SubItems(3).Text
                'GradeMe.TextBox2.Text = .SubItems(4).Text
                'GradeMe.TextBox3.Text = .SubItems(5).Text
                'GradeMe.TextBox4.Text = .SubItems(6).Text
                'GradeMe.TextBox5.Text = .SubItems(7).Text
                'GradeMe.TextBox6.Text = .SubItems(8).Text
                'GradeMe.TextBox7.Text = .SubItems(9).Text


                DBConn()
                Dim querystring3 As String = "SELECT mQuizRaw, mAttendRaw, mReciteRaw, mProjectRaw, mHomeworkRaw, mOthersRaw, mExamRaw FROM '" & ClassIntl & "' WHERE  StudentID = '" & StudID & "' "
                Dim command3 As New SQLiteCommand(querystring3, SQLCONN)
                Dim reader3 As SQLiteDataReader = command3.ExecuteReader
                While reader3.Read
                    GradeMe.TextBox1.Text = reader3.GetValue(0)
                    GradeMe.TextBox2.Text = reader3.GetValue(1)
                    GradeMe.TextBox3.Text = reader3.GetValue(2)
                    GradeMe.TextBox4.Text = reader3.GetValue(3)
                    GradeMe.TextBox5.Text = reader3.GetValue(4)
                    GradeMe.TextBox6.Text = reader3.GetValue(5)
                    GradeMe.TextBox7.Text = reader3.GetValue(6)
                End While
                reader3.Close()
                SQLDR.Dispose()
                SQLCONN.Close()

                DBConn()
                Dim querystring2 As String = "SELECT mQuizTotal, mAttendTotal, mReciteTotal, mProjectTotal, mHomeworkTotal, mOthersTotal, mExamTotal FROM MasterClasslist WHERE ClassID ='" & ClassIntl & "' "
                Dim command2 As New SQLiteCommand(querystring2, SQLCONN)
                Dim reader2 As SQLiteDataReader = command2.ExecuteReader
                While reader2.Read
                    GradeMe.Label21.Text = reader2.GetValue(0)
                    GradeMe.Label22.Text = reader2.GetValue(1)
                    GradeMe.Label23.Text = reader2.GetValue(2)
                    GradeMe.Label24.Text = reader2.GetValue(3)
                    GradeMe.Label25.Text = reader2.GetValue(4)
                    GradeMe.Label26.Text = reader2.GetValue(5)
                    GradeMe.Label27.Text = reader2.GetValue(6)
                End While
                reader2.Close()
                SQLDR.Dispose()
                SQLCONN.Close()
                GradeMe.Show()
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ClassIntl = TextBox1.Text

        GradingSettings.TextBox1.Text = ClassIntl
        GradingSettings.Show()

    End Sub

    Private Sub Midterm_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover

        Button1.Image = My.Resources.Browse_and_Update_pressed

    End Sub

    Private Sub Midterm_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Button1.Image = My.Resources.Browse_and_Update
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

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
        AddGrades.AddGrades()
        AddGrades.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ClassIntl = TextBox1.Text
        Edit_Total_Scores.TextBox1.Text = ClassIntl

        Edit_Total_Scores.Show()
    End Sub

    Private Sub Midterm2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover

        Button2.Image = My.Resources.Browse_and_Update_pressed

    End Sub

    Private Sub Midterm2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Button2.Image = My.Resources.Browse_and_Update
    End Sub
End Class