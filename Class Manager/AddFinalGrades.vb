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
        ListView1.Columns.Add("Quizzes", 80)
        ListView1.Columns.Add("Attendance", 80)
        ListView1.Columns.Add("Recitation", 80)
        ListView1.Columns.Add("Projects", 80)
        ListView1.Columns.Add("Homework", 80)
        ListView1.Columns.Add("Others", 80)
        ListView1.Columns.Add("Final", 80)
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

End Class