Imports System.Data.SQLite

Public Class GradeMe

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter numbers only")
            e.Handled = True
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox1.Clear()
        ElseIf TextBox2.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox2.Clear()
        ElseIf TextBox3.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox3.Clear()
        ElseIf TextBox4.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox4.Clear()
        ElseIf TextBox5.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox5.Clear()
        ElseIf TextBox5.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox5.Clear()
        ElseIf TextBox6.Text > 100 Then
            MsgBox("Grades cannot exceed 100")
            TextBox6.Clear()
        Else
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

            'Start the computation
            For Each form In My.Application.OpenForms
                If (AddPrelimGrades.Visible) Then

                    Dim ClassIntl = AddPrelimGrades.TextBox1.Text

                    'Get values of each transmuted grade
                    Dim QuizGrade As Double = TextBox1.Text
                    Dim AttnGrade As Double = TextBox2.Text
                    Dim ReciGrade As Double = TextBox3.Text
                    Dim ProjGrade As Double = TextBox4.Text
                    Dim HomeGrade As Double = TextBox5.Text
                    Dim OthrGrade As Double = TextBox6.Text
                    Dim ExamGrade As Double = TextBox7.Text

                    'Get the weights of Class Standing from first forms, divide by 100 for % value
                    Dim QuizWeight As Double = AddPrelimGrades.TextBox2.Text / 100
                    Dim AttnWeight As Double = AddPrelimGrades.TextBox3.Text / 100
                    Dim ReciWeight As Double = AddPrelimGrades.TextBox4.Text / 100
                    Dim ProjWeight As Double = AddPrelimGrades.TextBox5.Text / 100
                    Dim HomeWeight As Double = AddPrelimGrades.TextBox6.Text / 100
                    Dim OthrWeight As Double = AddPrelimGrades.TextBox7.Text / 100
                    Dim TotalCSWeight As Double = PmTotalCS / 100
                    Dim ExamWeight As Double = PmExam / 100

                    'Compute
                    Dim QuizFinal As Double = QuizGrade * QuizWeight
                    Dim AttnFinal As Double = AttnGrade * AttnWeight
                    Dim ReciFinal As Double = ReciGrade * ReciWeight
                    Dim ProjFinal As Double = ProjGrade * ProjWeight
                    Dim HomeFinal As Double = HomeGrade * HomeWeight
                    Dim OthrFinal As Double = OthrGrade * OthrWeight
                    Dim ExamFinal As Double = ExamGrade * ExamWeight

                    'Display grades per weight
                    Label12.Text = QuizFinal
                    Label13.Text = AttnFinal
                    Label14.Text = ReciFinal
                    Label15.Text = ProjFinal
                    Label16.Text = HomeFinal
                    Label17.Text = OthrFinal
                    Label20.Text = ExamFinal

                    'Compute final grade
                    Dim FinalFinalGrade As Integer = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                    Dim CSFinal As Integer = FinalFinalGrade * TotalCSWeight
                    Dim PeriodGrade As Integer = CSFinal + ExamFinal
                    Label4.Text = PeriodGrade

                    'Display pass or fail
                    If PeriodGrade >= PassMark Then
                        Label5.Text = "Passed!"
                    Else
                        Label5.Text = "Failed!"
                    End If

                    DBConn()
                    SQLSTR = "UPDATE '" & ClassIntl & "' SET pQuiz= '" & TextBox1.Text & "', pAttend= '" & TextBox2.Text & "', pRecite= '" & TextBox3.Text & "', pProject= '" & TextBox4.Text & "', pHomework= '" & TextBox5.Text & "', pOthers= '" & TextBox6.Text & "', pExam= '" & TextBox7.Text & "', pGrade= '" & Label4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                    alterDB()
                    SQLDR.Dispose()
                    SQLCONN.Close()

                    If Not AddPrelimGrades.ListView1.SelectedItems.Count = 0 Then
                        With AddPrelimGrades.ListView1.SelectedItems.Item(0)
                            .SubItems(3).Text = TextBox1.Text
                            .SubItems(4).Text = TextBox2.Text
                            .SubItems(5).Text = TextBox3.Text
                            .SubItems(6).Text = TextBox4.Text
                            .SubItems(7).Text = TextBox5.Text
                            .SubItems(8).Text = TextBox6.Text
                            .SubItems(9).Text = TextBox7.Text
                            .SubItems(10).Text = Label4.Text
                        End With
                    End If

                ElseIf (AddMidtermGrades.Visible) Then

                    Dim ClassIntl = AddMidtermGrades.TextBox1.Text

                    'Get values of each transmuted grade
                    Dim QuizGrade As Double = TextBox1.Text
                    Dim AttnGrade As Double = TextBox2.Text
                    Dim ReciGrade As Double = TextBox3.Text
                    Dim ProjGrade As Double = TextBox4.Text
                    Dim HomeGrade As Double = TextBox5.Text
                    Dim OthrGrade As Double = TextBox6.Text
                    Dim ExamGrade As Double = TextBox7.Text

                    'Get the weights of Class Standing from first forms, divide by 100 for % value
                    Dim QuizWeight As Double = AddMidtermGrades.TextBox2.Text / 100
                    Dim AttnWeight As Double = AddMidtermGrades.TextBox3.Text / 100
                    Dim ReciWeight As Double = AddMidtermGrades.TextBox4.Text / 100
                    Dim ProjWeight As Double = AddMidtermGrades.TextBox5.Text / 100
                    Dim HomeWeight As Double = AddMidtermGrades.TextBox6.Text / 100
                    Dim OthrWeight As Double = AddMidtermGrades.TextBox7.Text / 100
                    Dim TotalCSWeight As Double = PmTotalCS / 100
                    Dim ExamWeight As Double = PmExam / 100

                    'Compute
                    Dim QuizFinal As Double = QuizGrade * QuizWeight
                    Dim AttnFinal As Double = AttnGrade * AttnWeight
                    Dim ReciFinal As Double = ReciGrade * ReciWeight
                    Dim ProjFinal As Double = ProjGrade * ProjWeight
                    Dim HomeFinal As Double = HomeGrade * HomeWeight
                    Dim OthrFinal As Double = OthrGrade * OthrWeight
                    Dim ExamFinal As Double = ExamGrade * ExamWeight

                    'Display grades per weight
                    Label12.Text = QuizFinal
                    Label13.Text = AttnFinal
                    Label14.Text = ReciFinal
                    Label15.Text = ProjFinal
                    Label16.Text = HomeFinal
                    Label17.Text = OthrFinal
                    Label20.Text = ExamFinal

                    'Compute final grade
                    Dim FinalFinalGrade As Integer = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                    Dim CSFinal As Integer = FinalFinalGrade * TotalCSWeight
                    Dim PeriodGrade As Integer = CSFinal + ExamFinal
                    Label4.Text = PeriodGrade

                    'Display pass or fail
                    If PeriodGrade >= PassMark Then
                        Label5.Text = "Passed!"
                    Else
                        Label5.Text = "Failed!"
                    End If

                    DBConn()
                    SQLSTR = "UPDATE '" & ClassIntl & "' SET mQuiz= '" & TextBox1.Text & "', mAttend= '" & TextBox2.Text & "', mRecite= '" & TextBox3.Text & "', mProject= '" & TextBox4.Text & "', mHomework= '" & TextBox5.Text & "', mOthers= '" & TextBox6.Text & "', mExam= '" & TextBox7.Text & "', mGrade= '" & Label4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                    alterDB()
                    SQLDR.Dispose()
                    SQLCONN.Close()

                    If Not AddMidtermGrades.ListView1.SelectedItems.Count = 0 Then
                        With AddMidtermGrades.ListView1.SelectedItems.Item(0)
                            .SubItems(3).Text = TextBox1.Text
                            .SubItems(4).Text = TextBox2.Text
                            .SubItems(5).Text = TextBox3.Text
                            .SubItems(6).Text = TextBox4.Text
                            .SubItems(7).Text = TextBox5.Text
                            .SubItems(8).Text = TextBox6.Text
                            .SubItems(9).Text = TextBox7.Text
                            .SubItems(10).Text = Label4.Text
                        End With
                    End If

                ElseIf (AddFinalGrades.Visible) Then

                    Dim ClassIntl = AddFinalGrades.TextBox1.Text

                    'Get values of each transmuted grade
                    Dim QuizGrade As Double = TextBox1.Text
                    Dim AttnGrade As Double = TextBox2.Text
                    Dim ReciGrade As Double = TextBox3.Text
                    Dim ProjGrade As Double = TextBox4.Text
                    Dim HomeGrade As Double = TextBox5.Text
                    Dim OthrGrade As Double = TextBox6.Text
                    Dim ExamGrade As Double = TextBox7.Text

                    'Get the weights of Class Standing from first forms, divide by 100 for % value
                    Dim QuizWeight As Double = AddFinalGrades.TextBox2.Text / 100
                    Dim AttnWeight As Double = AddFinalGrades.TextBox3.Text / 100
                    Dim ReciWeight As Double = AddFinalGrades.TextBox4.Text / 100
                    Dim ProjWeight As Double = AddFinalGrades.TextBox5.Text / 100
                    Dim HomeWeight As Double = AddFinalGrades.TextBox6.Text / 100
                    Dim OthrWeight As Double = AddFinalGrades.TextBox7.Text / 100
                    Dim TotalCSWeight As Double = FTotalCS / 100
                    Dim ExamWeight As Double = FExam / 100

                    'Compute
                    Dim QuizFinal As Double = QuizGrade * QuizWeight
                    Dim AttnFinal As Double = AttnGrade * AttnWeight
                    Dim ReciFinal As Double = ReciGrade * ReciWeight
                    Dim ProjFinal As Double = ProjGrade * ProjWeight
                    Dim HomeFinal As Double = HomeGrade * HomeWeight
                    Dim OthrFinal As Double = OthrGrade * OthrWeight
                    Dim ExamFinal As Double = ExamGrade * ExamWeight

                    'Display grades per weight
                    Label12.Text = QuizFinal
                    Label13.Text = AttnFinal
                    Label14.Text = ReciFinal
                    Label15.Text = ProjFinal
                    Label16.Text = HomeFinal
                    Label17.Text = OthrFinal
                    Label20.Text = ExamFinal

                    'Compute final grade
                    Dim FinalFinalGrade As Integer = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                    Dim CSFinal As Integer = FinalFinalGrade * TotalCSWeight
                    Dim PeriodGrade As Integer = CSFinal + ExamFinal
                    Label4.Text = PeriodGrade

                    'Display pass or fail
                    If PeriodGrade >= PassMark Then
                        Label5.Text = "Passed!"
                    Else
                        Label5.Text = "Failed!"
                    End If

                    DBConn()
                    SQLSTR = "UPDATE '" & ClassIntl & "' SET fQuiz= '" & TextBox1.Text & "', fAttend= '" & TextBox2.Text & "', fRecite= '" & TextBox3.Text & "', fProject= '" & TextBox4.Text & "', fHomework= '" & TextBox5.Text & "', fOthers= '" & TextBox6.Text & "', fExam= '" & TextBox7.Text & "', fGrade= '" & Label4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                    alterDB()
                    SQLDR.Dispose()
                    SQLCONN.Close()

                    If Not AddFinalGrades.ListView1.SelectedItems.Count = 0 Then
                        With AddFinalGrades.ListView1.SelectedItems.Item(0)
                            .SubItems(3).Text = TextBox1.Text
                            .SubItems(4).Text = TextBox2.Text
                            .SubItems(5).Text = TextBox3.Text
                            .SubItems(6).Text = TextBox4.Text
                            .SubItems(7).Text = TextBox5.Text
                            .SubItems(8).Text = TextBox6.Text
                            .SubItems(9).Text = TextBox7.Text
                            .SubItems(10).Text = Label4.Text
                        End With
                    End If
                End If
            Next
            Me.Close()
        End If

    End Sub


End Class