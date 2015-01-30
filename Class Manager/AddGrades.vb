Imports System.Data.SQLite

Public Class AddGrades

    Dim DS As New DataSet()
    Dim CB


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        UpdateClassInitialList.Show()

    End Sub

    Private Sub AddGrades_Activate(sender As Object, e As EventArgs) Handles MyBase.Activated

        Button8.PerformClick()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DBConn()
        SQLSTR = "UPDATE '" & TextBox1.Text & "' SET Q1 = '" & TextBox6.Text & "', Q2 = '" & TextBox7.Text & "', S1 = '" & TextBox9.Text & "', A1 = '" & TextBox10.Text & "', PrelimExam = '" & TextBox11.Text & "', PrelimTotal = '" & TextBox12.Text & "', Q3 = '" & TextBox19.Text & "', Q4 = '" & TextBox20.Text & "', S2 = '" & TextBox21.Text & "', A2 = '" & TextBox22.Text & "', MidtermExam = '" & TextBox24.Text & "', MidtermTotal = '" & TextBox25.Text & "', Q5 = '" & TextBox27.Text & "', Q6 = '" & TextBox28.Text & "', S3 = '" & TextBox29.Text & "', A3 = '" & TextBox30.Text & "', FinalExam = '" & TextBox32.Text & "', FinalTotal = '" & TextBox33.Text & "' WHERE StudentID = '" & Label17.Text & "'"
        alterDB()
        SQLCONN.Close()
        SQLDR.Dispose()
        MsgBox("Update successful!", , msgboxtitle)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim PrelimWeight As Integer = TextBox2.Text
        Dim MidtermWeight As Integer = TextBox3.Text
        Dim FinalWeight As Integer = TextBox4.Text
        Dim QuizWeight As Integer = TextBox14.Text
        Dim ClassStandingWeight As Integer = TextBox15.Text
        Dim AttendanceWeight As Integer = TextBox16.Text
        Dim PeriodicalExamWeight As Integer = TextBox17.Text
        If PrelimWeight + MidtermWeight + FinalWeight < 100 Then
            MsgBox("Weights must total to 100")
        ElseIf PrelimWeight + MidtermWeight + FinalWeight > 100 Then
            MsgBox("Weights must not exceed 100")
        ElseIf QuizWeight + ClassStandingWeight + AttendanceWeight + PeriodicalExamWeight < 100 Then
            MsgBox("Weights must total to 100")
        ElseIf QuizWeight + ClassStandingWeight + AttendanceWeight + PeriodicalExamWeight > 100 Then
            MsgBox("Weights must not exceed 100")
        Else
            Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
            If confirm = Windows.Forms.DialogResult.Yes Then
                DBConn()
                SQLSTR = "UPDATE MasterClasslist SET PrelimWeight= '" & TextBox2.Text & "', MidtermWeight= '" & TextBox3.Text & "', FinalWeight= '" & TextBox4.Text & "', PassingMark= '" & TextBox5.Text & "', QuizWeight= '" & TextBox14.Text & "', ClassStandingWeight= '" & TextBox15.Text & "', AttendanceWeight= '" & TextBox16.Text & "', PeriodicalExamWeight= '" & TextBox17.Text & "' WHERE ClassID = '" & TextBox1.Text & "'"
                alterDB()
                SQLCONN.Close()
                SQLDR.Dispose()
                MsgBox("Update successful!", , msgboxtitle)
                'Get weights from DB
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
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        'Update Name
        Label17.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
        Label18.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
        Label19.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString

        'Prelim
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
        TextBox9.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
        TextBox10.Text = DataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
        TextBox11.Text = DataGridView1.Rows(e.RowIndex).Cells(15).Value.ToString
        TextBox12.Text = DataGridView1.Rows(e.RowIndex).Cells(18).Value.ToString

        'Midterm
        TextBox19.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
        TextBox20.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
        TextBox21.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
        TextBox22.Text = DataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString
        TextBox24.Text = DataGridView1.Rows(e.RowIndex).Cells(16).Value.ToString
        TextBox25.Text = DataGridView1.Rows(e.RowIndex).Cells(19).Value.ToString

        'Finals
        TextBox27.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
        TextBox28.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
        TextBox29.Text = DataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString
        TextBox30.Text = DataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString
        TextBox32.Text = DataGridView1.Rows(e.RowIndex).Cells(17).Value.ToString
        TextBox33.Text = DataGridView1.Rows(e.RowIndex).Cells(20).Value.ToString

        'Compute grades on load
        'Compute theg grades
        Button5.PerformClick()
        Button6.PerformClick()
        Button7.PerformClick()
        Dim FinalWeight As Decimal = TextBox4.Text / 100
        Dim MidtermWeight As Decimal = TextBox3.Text / 100
        Dim PrelimWeight As Decimal = TextBox2.Text / 100
        Dim PassingMark = TextBox5.Text
        Dim PrelimGrade = Decimal.Parse(TextBox12.Text) * PrelimWeight
        Dim MidtermGrade = Decimal.Parse(TextBox19.Text) * MidtermWeight
        Dim FinalGrade = Decimal.Parse(TextBox27.Text) * FinalWeight

        Dim FinalSemGrade = PrelimGrade + MidtermGrade + FinalGrade

        TextBox8.Text = FinalSemGrade


        If FinalSemGrade >= PassingMark Then
            Label8.Text = "PASSED"
        Else
            Label8.Text = "FAILED"

        End If


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox6.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox7.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox9.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox10.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox11.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox12.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        Else
            Dim QuizWeight As Decimal = TextBox14.Text / 100
            Dim ClassStandingWeight As Decimal = TextBox15.Text / 100
            Dim AttendanceWeight As Decimal = TextBox16.Text / 100
            Dim PeriodicalExamWeight As Decimal = TextBox17.Text / 100
            Dim PassingMark = TextBox5.Text
            Dim Q1 = Decimal.Parse(TextBox6.Text)
            Dim Q2 = Decimal.Parse(TextBox7.Text)
            Dim QuizTotal1 As Decimal = Q1 + Q2
            Dim QuizTotal2 As Decimal = QuizTotal1 / 2
            Dim QuizTotal3 As Decimal = QuizTotal2 / 100
            Dim QuizTotal4 As Decimal = QuizTotal3 * 100
            Dim QuizAverage As Decimal = QuizTotal4 * QuizWeight
            Dim ClassStandingAverage As Decimal = TextBox9.Text * ClassStandingWeight
            Dim AttendanceAverage As Decimal = TextBox10.Text * AttendanceWeight
            Dim PeriodicalExamAverage As Decimal = TextBox11.Text * PeriodicalExamWeight
            Dim TotalPrelimGrade As Integer = QuizAverage + ClassStandingAverage + AttendanceAverage + PeriodicalExamAverage
            TextBox12.Text = TotalPrelimGrade
            If TotalPrelimGrade >= PassingMark Then
                Label24.Text = "PASSED"
            Else
                Label24.Text = "FAILED"
            End If
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox25.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox24.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox22.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox21.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox20.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox19.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        Else
            Dim QuizWeight As Decimal = TextBox14.Text / 100
            Dim ClassStandingWeight As Decimal = TextBox15.Text / 100
            Dim AttendanceWeight As Decimal = TextBox16.Text / 100
            Dim PeriodicalExamWeight As Decimal = TextBox17.Text / 100
            Dim PassingMark = TextBox5.Text
            Dim Q3 = Decimal.Parse(TextBox25.Text)
            Dim Q4 = Decimal.Parse(TextBox24.Text)
            Dim QuizTotal1 As Decimal = Q3 + Q4
            Dim QuizTotal2 As Decimal = QuizTotal1 / 2
            Dim QuizTotal3 As Decimal = QuizTotal2 / 100
            Dim QuizTotal4 As Decimal = QuizTotal3 * 100
            Dim QuizAverage As Decimal = QuizTotal4 * QuizWeight
            Dim ClassStandingAverage As Decimal = TextBox22.Text * ClassStandingWeight
            Dim AttendanceAverage As Decimal = TextBox21.Text * AttendanceWeight
            Dim PeriodicalExamAverage As Decimal = TextBox20.Text * PeriodicalExamWeight
            Dim TotalMidtermGrade As Integer = QuizAverage + ClassStandingAverage + AttendanceAverage + PeriodicalExamAverage
            TextBox19.Text = TotalMidtermGrade
            If TotalMidtermGrade >= PassingMark Then
                Label31.Text = "PASSED"
            Else
                Label31.Text = "FAILED"
            End If
        End If


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox33.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox32.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox30.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox29.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox28.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        ElseIf TextBox27.Text > 100 Then
            MsgBox("Transmuted grade must not exceed 100")
        Else
            Dim QuizWeight As Decimal = TextBox14.Text / 100
            Dim ClassStandingWeight As Decimal = TextBox15.Text / 100
            Dim AttendanceWeight As Decimal = TextBox16.Text / 100
            Dim PeriodicalExamWeight As Decimal = TextBox17.Text / 100
            Dim PassingMark = TextBox5.Text
            Dim Q5 = Decimal.Parse(TextBox33.Text)
            Dim Q6 = Decimal.Parse(TextBox32.Text)
            Dim QuizTotal1 As Decimal = Q5 + Q6
            Dim QuizTotal2 As Decimal = QuizTotal1 / 2
            Dim QuizTotal3 As Decimal = QuizTotal2 / 100
            Dim QuizTotal4 As Decimal = QuizTotal3 * 100
            Dim QuizAverage As Decimal = QuizTotal4 * QuizWeight
            Dim ClassStandingAverage As Decimal = TextBox30.Text * ClassStandingWeight
            Dim AttendanceAverage As Decimal = TextBox29.Text * AttendanceWeight
            Dim PeriodicalExamAverage As Decimal = TextBox28.Text * PeriodicalExamWeight
            Dim TotalFinalGrade As Integer = QuizAverage + ClassStandingAverage + AttendanceAverage + PeriodicalExamAverage
            TextBox27.Text = TotalFinalGrade
            If TotalFinalGrade >= PassingMark Then
                Label34.Text = "PASSED"
            Else
                Label34.Text = "FAILED"
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button5.PerformClick()
        Button6.PerformClick()
        Button7.PerformClick()
        Dim FinalWeight As Decimal = TextBox4.Text / 100
        Dim MidtermWeight As Decimal = TextBox3.Text / 100
        Dim PrelimWeight As Decimal = TextBox2.Text / 100
        Dim PassingMark = TextBox5.Text
        Dim PrelimGrade = Decimal.Parse(TextBox12.Text) * PrelimWeight
        Dim MidtermGrade = Decimal.Parse(TextBox19.Text) * MidtermWeight
        Dim FinalGrade = Decimal.Parse(TextBox27.Text) * FinalWeight
        Dim FinalSemGrade = PrelimGrade + MidtermGrade + FinalGrade
        TextBox8.Text = FinalSemGrade
        If FinalSemGrade >= PassingMark Then
            Label8.Text = "PASSED"
        Else
            Label8.Text = "FAILED"

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim ClassIntl = TextBox1.Text

        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()

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
            .Columns(21).HeaderCell.Value = "Final Grade"
        End With

        'Get weights from DB
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
End Class





