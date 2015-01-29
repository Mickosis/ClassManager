Imports System.Data.SQLite

Public Class AddGrades
    Dim DS As New DataSet
    Dim CB

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        UpdateClassInitialList.Show()

    End Sub

    Private Sub AddGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.ReadOnly = True


        Dim ClassIntl = TextBox1.Text
        SQLSTR = "SELECT * FROM '" & ClassIntl & "'"
        DBConn()
        SQLDA.Fill(DS, "Grades")
        SQLCONN.Close()
        DataGridView1.DataSource = DS
        DataGridView1.DataMember = "Grades"
        With DataGridView1
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "Student ID"
            .Columns(1).HeaderCell.Value = "First Name"
            .Columns(2).HeaderCell.Value = "Last Name"
            .Columns(3).HeaderCell.Value = "Quiz 1"
            .Columns(4).HeaderCell.Value = "Quiz 2"
            .Columns(5).HeaderCell.Value = "Quiz 3"
            .Columns(6).HeaderCell.Value = "Quiz 4"
            .Columns(7).HeaderCell.Value = "Quiz 5"
            .Columns(8).HeaderCell.Value = "Quiz 6"
            .Columns(9).HeaderCell.Value = "CS Prelim"
            .Columns(10).HeaderCell.Value = "CS Midterm"
            .Columns(11).HeaderCell.Value = "CS Finals"
            .Columns(12).HeaderCell.Value = "Attend Prelim"
            .Columns(13).HeaderCell.Value = "Attend Midterm"
            .Columns(14).HeaderCell.Value = "Attend Finals"
            .Columns(15).HeaderCell.Value = "Exam Prelim"
            .Columns(16).HeaderCell.Value = "Exam Midterm"
            .Columns(17).HeaderCell.Value = "Exam Finals"
            .Columns(18).HeaderCell.Value = "Total Prelim"
            .Columns(19).HeaderCell.Value = "Total Midterm"
            .Columns(20).HeaderCell.Value = "Total Finals"
        End With

        ''Get weights from DB
        DBConn()
        Dim querystring As String = "SELECT PrelimWeight, MidtermWeight, FinalWeight, PassingMark, QuizWeight, ClassStandingWeight, AttendanceWeight, PeriodicalExamWeight FROM MasterClasslist WHERE ClassID = ('" & TextBox1.Text & "')"
        Dim command As New SQLiteCommand(querystring, SQLCONN)
        Dim reader As SQLiteDataReader = command.ExecuteReader
        While reader.Read
            TextBox2.Text = reader.GetValue(0)
            TextBox3.Text = reader.GetValue(1)
            TextBox4.Text = reader.GetValue(2)
            TextBox5.Text = reader.GetValue(3)
            TextBox14.Text = reader.GetValue(4)
            TextBox15.Text = reader.GetValue(5)
            TextBox16.Text = reader.GetValue(6)
            TextBox17.Text = reader.GetValue(7)
        End While
        reader.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CB = New SQLiteCommandBuilder(SQLDA)
        SQLDA.Update(DS, "Grades")
        MessageBox.Show("Updated Rows!")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            DBConn()
            SQLSTR = "UPDATE MasterClasslist SET PrelimWeight= '" & TextBox2.Text & "', MidtermWeight= '" & TextBox3.Text & "', FinalWeight= '" & TextBox4.Text & "', PassingMark= '" & TextBox5.Text & "', QuizWeight= '" & TextBox14.Text & "', ClassStandingWeight= '" & TextBox15.Text & "', AttendanceWeight= '" & TextBox16.Text & "', PeriodicalExamWeight= '" & TextBox17.Text & "' WHERE ClassID = '" & TextBox1.Text & "'"
            alterDB()
            MsgBox("Update successful!", , msgboxtitle)
            SQLCONN.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Label17.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        Label18.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        Label19.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
        TextBox9.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
        TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
        TextBox11.Text = DataGridView1.Rows(e.RowIndex).Cells(15).Value.ToString



    End Sub

End Class





