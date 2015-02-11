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
        ListView1.Columns.Add("Quiz", 50)
        ListView1.Columns.Add("Midt", 50)
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
    End Sub
End Class