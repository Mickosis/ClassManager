Imports System.Data.SQLite
Public Class GradeMe
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, TextBox7.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            MessageBox.Show("Please enter whole numbers only")
            e.Handled = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
            If TextBox1.Text > Convert.ToDouble(Label21.Text) Then
                MsgBox("Raw Quiz is greater than its total")
                TextBox1.Clear()
            ElseIf TextBox2.Text > Convert.ToDouble(Label22.Text) Then
                MsgBox("Raw Attendance is greater than its total")
                TextBox2.Clear()
            ElseIf TextBox3.Text > Convert.ToDouble(Label23.Text) Then
                MsgBox("Raw Recitation is greater than its total")
                TextBox3.Clear()
            ElseIf TextBox4.Text > Convert.ToDouble(Label24.Text) Then
                MsgBox("Raw Project is greater than its total")
                TextBox4.Clear()
            ElseIf TextBox5.Text > Convert.ToDouble(Label25.Text) Then
                MsgBox("Raw Homework is greater than its total")
                TextBox5.Clear()
            ElseIf TextBox6.Text > Convert.ToDouble(Label26.Text) Then
                MsgBox("Raw Activities is greater than its total")
                TextBox6.Clear()
            ElseIf TextBox7.Text > Convert.ToDouble(Label27.Text) Then
                MsgBox("Raw Exam is greater than its total")
                TextBox7.Clear()
            Else
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
                'Start the computation
                Dim QuizTotal As Double = Label21.Text
                Dim AttendTotal As Double = Label22.Text
                Dim RecitationTotal As Double = Label23.Text
                Dim ProjectTotal As Double = Label24.Text
                Dim HomeworkTotal As Double = Label25.Text
                Dim ActivitiesTotal As Double = Label26.Text
                Dim ExamTotal As Double = Label27.Text

                For Each form In My.Application.OpenForms
                    If (AddPrelimGrades.Visible) Then
                        Dim ClassIntl = AddPrelimGrades.TextBox1.Text
                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET pQuizRaw= '" & TextBox1.Text & "', pAttendRaw= '" & TextBox2.Text & "', pReciteRaw= '" & TextBox3.Text & "', pProjectRaw= '" & TextBox4.Text & "', pHomeworkRaw= '" & TextBox5.Text & "', pOthersRaw= '" & TextBox6.Text & "', pExamRaw= '" & TextBox7.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                        alterDB()
                        SQLDR.Dispose()
                        SQLCONN.Close()

                        'Get Raw Score
                        Dim QuizRaw As Double = TextBox1.Text / QuizTotal
                        Dim AttnRaw As Double = TextBox2.Text / AttendTotal
                        Dim ReciRaw As Double = TextBox3.Text / RecitationTotal
                        Dim ProjRaw As Double = TextBox4.Text / ProjectTotal
                        Dim HomeRaw As Double = TextBox5.Text / HomeworkTotal
                        Dim OthrRaw As Double = TextBox6.Text / ActivitiesTotal
                        Dim ExamRaw As Double = TextBox7.Text / ExamTotal

                        'Get values of each transmuted grade
                        Dim QuizGrade As Double = QuizRaw * 100
                        Dim AttnGrade As Double = AttnRaw * 100
                        Dim ReciGrade As Double = ReciRaw * 100
                        Dim ProjGrade As Double = ProjRaw * 100
                        Dim HomeGrade As Double = HomeRaw * 100
                        Dim OthrGrade As Double = OthrRaw * 100
                        Dim ExamGrade As Double = ExamRaw * 100
                        'Get the weights of Class Standing from first forms, divide by 100 for % value
                        Dim QuizWeight As Double = AddPrelimGrades.Label7.Text / 100
                        Dim AttnWeight As Double = AddPrelimGrades.Label8.Text / 100
                        Dim ReciWeight As Double = AddPrelimGrades.Label9.Text / 100
                        Dim ProjWeight As Double = AddPrelimGrades.Label10.Text / 100
                        Dim HomeWeight As Double = AddPrelimGrades.Label11.Text / 100
                        Dim OthrWeight As Double = AddPrelimGrades.Label12.Text / 100
                        Dim TotalCSWeight As Double = PmTotalCS / 100
                        Dim ExamWeight As Double = PmExam / 100


                        'Round Class Standing and Exam
                        Dim pQuiz As Double = Math.Round(QuizGrade, MidpointRounding.AwayFromZero)
                        Dim pAttend As Double = Math.Round(AttnGrade, MidpointRounding.AwayFromZero)
                        Dim pRecite As Double = Math.Round(ReciGrade, MidpointRounding.AwayFromZero)
                        Dim pProject As Double = Math.Round(ProjGrade, MidpointRounding.AwayFromZero)
                        Dim pHomework As Double = Math.Round(HomeGrade, MidpointRounding.AwayFromZero)
                        Dim pOthers As Double = Math.Round(OthrGrade, MidpointRounding.AwayFromZero)
                        Dim pExam As Double = Math.Round(ExamGrade, MidpointRounding.AwayFromZero)

                        'Compute
                        Dim QuizFinal As Double = pQuiz * QuizWeight
                        Dim AttnFinal As Double = pAttend * AttnWeight
                        Dim ReciFinal As Double = pRecite * ReciWeight
                        Dim ProjFinal As Double = pProject * ProjWeight
                        Dim HomeFinal As Double = pHomework * HomeWeight
                        Dim OthrFinal As Double = pOthers * OthrWeight
                        Dim ExamFinal As Double = pExam * ExamWeight

                        'Display grades per weight
                        'Label12.Text = QuizFinal
                        'Label13.Text = AttnFinal
                        'Label14.Text = ReciFinal
                        'Label15.Text = ProjFinal
                        'Label16.Text = HomeFinal
                        'Label17.Text = OthrFinal
                        'Label20.Text = ExamFinal


                        'Compute final grade
                        Dim FinalFinalGrade As Double = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                        Dim CSFinal As Double = FinalFinalGrade * TotalCSWeight
                        Dim PeriodGrade As Double = CSFinal + ExamFinal
                        Label4.Text = Math.Round(PeriodGrade, MidpointRounding.AwayFromZero)
                        'Display pass or fail
                        If PeriodGrade >= PassMark Then
                            Label5.Text = "Passed!"
                        Else
                            Label5.Text = "Failed!"
                        End If
                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET pQuiz= '" & pQuiz & "', pAttend= '" & pAttend & "', pRecite= '" & pRecite & "', pProject= '" & pProject & "', pHomework= '" & pHomework & "', pOthers= '" & pOthers & "', pExam= '" & pExam & "', pGrade= '" & Label4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                        alterDB()
                        SQLDR.Dispose()
                        SQLCONN.Close()
                        If Not AddPrelimGrades.ListView1.SelectedItems.Count = 0 Then
                            With AddPrelimGrades.ListView1.SelectedItems.Item(0)
                                .SubItems(3).Text = pQuiz
                                .SubItems(4).Text = pAttend
                                .SubItems(5).Text = pRecite
                                .SubItems(6).Text = pProject
                                .SubItems(7).Text = pHomework
                                .SubItems(8).Text = pOthers
                                .SubItems(9).Text = pExam
                                .SubItems(10).Text = Label4.Text
                            End With
                        End If
                    ElseIf (AddMidtermGrades.Visible) Then
                        Dim ClassIntl = AddMidtermGrades.TextBox1.Text
                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET mQuizRaw= '" & TextBox1.Text & "', mAttendRaw= '" & TextBox2.Text & "', mReciteRaw= '" & TextBox3.Text & "', mProjectRaw= '" & TextBox4.Text & "', mHomeworkRaw= '" & TextBox5.Text & "', mOthersRaw= '" & TextBox6.Text & "', mExamRaw= '" & TextBox7.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                        alterDB()
                        SQLDR.Dispose()
                        SQLCONN.Close()

                        'Get Raw Score
                        Dim QuizRaw As Double = TextBox1.Text / QuizTotal
                        Dim AttnRaw As Double = TextBox2.Text / AttendTotal
                        Dim ReciRaw As Double = TextBox3.Text / RecitationTotal
                        Dim ProjRaw As Double = TextBox4.Text / ProjectTotal
                        Dim HomeRaw As Double = TextBox5.Text / HomeworkTotal
                        Dim OthrRaw As Double = TextBox6.Text / ActivitiesTotal
                        Dim ExamRaw As Double = TextBox7.Text / ExamTotal

                        'Get values of each transmuted grade
                        Dim QuizGrade As Double = QuizRaw * 100
                        Dim AttnGrade As Double = AttnRaw * 100
                        Dim ReciGrade As Double = ReciRaw * 100
                        Dim ProjGrade As Double = ProjRaw * 100
                        Dim HomeGrade As Double = HomeRaw * 100
                        Dim OthrGrade As Double = OthrRaw * 100
                        Dim ExamGrade As Double = ExamRaw * 100
                        'Get the weights of Class Standing from first forms, divide by 100 for % value
                        Dim QuizWeight As Double = AddMidtermGrades.Label7.Text / 100
                        Dim AttnWeight As Double = AddMidtermGrades.Label8.Text / 100
                        Dim ReciWeight As Double = AddMidtermGrades.Label9.Text / 100
                        Dim ProjWeight As Double = AddMidtermGrades.Label10.Text / 100
                        Dim HomeWeight As Double = AddMidtermGrades.Label11.Text / 100
                        Dim OthrWeight As Double = AddMidtermGrades.Label12.Text / 100
                        Dim TotalCSWeight As Double = PmTotalCS / 100
                        Dim ExamWeight As Double = PmExam / 100

                        'Round Class Standing and Exam
                        Dim mQuiz As Double = Math.Round(QuizGrade, MidpointRounding.AwayFromZero)
                        Dim mAttend As Double = Math.Round(AttnGrade, MidpointRounding.AwayFromZero)
                        Dim mRecite As Double = Math.Round(ReciGrade, MidpointRounding.AwayFromZero)
                        Dim mProject As Double = Math.Round(ProjGrade, MidpointRounding.AwayFromZero)
                        Dim mHomework As Double = Math.Round(HomeGrade, MidpointRounding.AwayFromZero)
                        Dim mOthers As Double = Math.Round(OthrGrade, MidpointRounding.AwayFromZero)
                        Dim mExam As Double = Math.Round(ExamGrade, MidpointRounding.AwayFromZero)

                        'Compute
                        Dim QuizFinal As Double = mQuiz * QuizWeight
                        Dim AttnFinal As Double = mAttend * AttnWeight
                        Dim ReciFinal As Double = mRecite * ReciWeight
                        Dim ProjFinal As Double = mProject * ProjWeight
                        Dim HomeFinal As Double = mHomework * HomeWeight
                        Dim OthrFinal As Double = mOthers * OthrWeight
                        Dim ExamFinal As Double = mExam * ExamWeight

                        'Display grades per weight
                        'Label12.Text = QuizFinal
                        'Label13.Text = AttnFinal
                        'Label14.Text = ReciFinal
                        'Label15.Text = ProjFinal
                        'Label16.Text = HomeFinal
                        'Label17.Text = OthrFinal
                        'Label20.Text = ExamFinal



                        'Compute final grade
                        Dim FinalFinalGrade As Double = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                        Dim CSFinal As Double = FinalFinalGrade * TotalCSWeight
                        Dim PeriodGrade As Double = CSFinal + ExamFinal
                        Label4.Text = Math.Round(PeriodGrade, MidpointRounding.AwayFromZero)
                        'Display pass or fail
                        If PeriodGrade >= PassMark Then
                            Label5.Text = "Passed!"
                        Else
                            Label5.Text = "Failed!"
                        End If
                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET mQuiz= '" & mQuiz & "', mAttend= '" & mAttend & "', mRecite= '" & mRecite & "', mProject= '" & mProject & "', mHomework= '" & mHomework & "', mOthers= '" & mOthers & "', mExam= '" & mExam & "', mGrade= '" & Label4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                        alterDB()
                        SQLDR.Dispose()
                        SQLCONN.Close()
                        If Not AddMidtermGrades.ListView1.SelectedItems.Count = 0 Then
                            With AddMidtermGrades.ListView1.SelectedItems.Item(0)
                                .SubItems(3).Text = mQuiz
                                .SubItems(4).Text = mAttend
                                .SubItems(5).Text = mRecite
                                .SubItems(6).Text = mProject
                                .SubItems(7).Text = mHomework
                                .SubItems(8).Text = mOthers
                                .SubItems(9).Text = mExam
                                .SubItems(10).Text = Label4.Text
                            End With
                        End If
                    ElseIf (AddFinalGrades.Visible) Then
                        Dim ClassIntl = AddFinalGrades.TextBox1.Text
                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET fQuizRaw= '" & TextBox1.Text & "', fAttendRaw= '" & TextBox2.Text & "', fReciteRaw= '" & TextBox3.Text & "', fProjectRaw= '" & TextBox4.Text & "', fHomeworkRaw= '" & TextBox5.Text & "', fOthersRaw= '" & TextBox6.Text & "', fExamRaw= '" & TextBox7.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                        alterDB()
                        SQLDR.Dispose()
                        SQLCONN.Close()

                        'Get Raw Score
                        Dim QuizRaw As Double = TextBox1.Text / QuizTotal
                        Dim AttnRaw As Double = TextBox2.Text / AttendTotal
                        Dim ReciRaw As Double = TextBox3.Text / RecitationTotal
                        Dim ProjRaw As Double = TextBox4.Text / ProjectTotal
                        Dim HomeRaw As Double = TextBox5.Text / HomeworkTotal
                        Dim OthrRaw As Double = TextBox6.Text / ActivitiesTotal
                        Dim ExamRaw As Double = TextBox7.Text / ExamTotal

                        'Get values of each transmuted grade
                        Dim QuizGrade As Double = QuizRaw * 100
                        Dim AttnGrade As Double = AttnRaw * 100
                        Dim ReciGrade As Double = ReciRaw * 100
                        Dim ProjGrade As Double = ProjRaw * 100
                        Dim HomeGrade As Double = HomeRaw * 100
                        Dim OthrGrade As Double = OthrRaw * 100
                        Dim ExamGrade As Double = ExamRaw * 100

                        'Get the weights of Class Standing from first forms, divide by 100 for % value
                        Dim QuizWeight As Double = AddFinalGrades.Label7.Text / 100
                        Dim AttnWeight As Double = AddFinalGrades.Label8.Text / 100
                        Dim ReciWeight As Double = AddFinalGrades.Label9.Text / 100
                        Dim ProjWeight As Double = AddFinalGrades.Label10.Text / 100
                        Dim HomeWeight As Double = AddFinalGrades.Label11.Text / 100
                        Dim OthrWeight As Double = AddFinalGrades.Label12.Text / 100
                        Dim TotalCSWeight As Double = FTotalCS / 100
                        Dim ExamWeight As Double = FExam / 100

                        'Round Class Standing and Exam
                        Dim fQuiz As Double = Math.Round(QuizGrade, MidpointRounding.AwayFromZero)
                        Dim fAttend As Double = Math.Round(AttnGrade, MidpointRounding.AwayFromZero)
                        Dim fRecite As Double = Math.Round(ReciGrade, MidpointRounding.AwayFromZero)
                        Dim fProject As Double = Math.Round(ProjGrade, MidpointRounding.AwayFromZero)
                        Dim fHomework As Double = Math.Round(HomeGrade, MidpointRounding.AwayFromZero)
                        Dim fOthers As Double = Math.Round(OthrGrade, MidpointRounding.AwayFromZero)
                        Dim fExamRound As Double = Math.Round(ExamGrade, MidpointRounding.AwayFromZero)

                        'Compute
                        Dim QuizFinal As Double = fQuiz * QuizWeight
                        Dim AttnFinal As Double = fAttend * AttnWeight
                        Dim ReciFinal As Double = fRecite * ReciWeight
                        Dim ProjFinal As Double = fProject * ProjWeight
                        Dim HomeFinal As Double = fHomework * HomeWeight
                        Dim OthrFinal As Double = fOthers * OthrWeight
                        Dim ExamFinal As Double = fExamRound * ExamWeight
                        'Display grades per weight
                        'Label12.Text = QuizFinal
                        'Label13.Text = AttnFinal
                        'Label14.Text = ReciFinal
                        'Label15.Text = ProjFinal
                        'Label16.Text = HomeFinal
                        'Label17.Text = OthrFinal
                        'Label20.Text = ExamFinal

                        'Compute final grade
                        Dim FinalFinalGrade As Double = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                        Dim CSFinal As Double = FinalFinalGrade * TotalCSWeight
                        Dim PeriodGrade As Double = CSFinal + ExamFinal
                        Label4.Text = Math.Round(PeriodGrade, MidpointRounding.AwayFromZero)
                        'Display pass or fail
                        If PeriodGrade >= PassMark Then
                            Label5.Text = "Passed!"
                        Else
                            Label5.Text = "Failed!"
                        End If
                        DBConn()
                        SQLSTR = "UPDATE '" & ClassIntl & "' SET fQuiz= '" & fQuiz & "', fAttend= '" & fAttend & "', fRecite= '" & fRecite & "', fProject= '" & fProject & "', fHomework= '" & fHomework & "', fOthers= '" & fOthers & "', fExam= '" & fExamRound & "', fGrade= '" & Label4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
                        alterDB()
                        SQLDR.Dispose()
                        SQLCONN.Close()
                        If Not AddFinalGrades.ListView1.SelectedItems.Count = 0 Then
                            With AddFinalGrades.ListView1.SelectedItems.Item(0)
                                .SubItems(3).Text = fQuiz
                                .SubItems(4).Text = fAttend
                                .SubItems(5).Text = fRecite
                                .SubItems(6).Text = fProject
                                .SubItems(7).Text = fHomework
                                .SubItems(8).Text = fOthers
                                .SubItems(9).Text = fExamRound
                                .SubItems(10).Text = Label4.Text
                            End With
                        End If
                    End If
                Next
                Me.Close()
            End If
        End If

    End Sub
    Private Sub Grade_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        Button1.Image = My.Resources.importdbasepressed
    End Sub
    Private Sub Grade_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.Image = My.Resources.importdbase
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

    Private Sub GradeMe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class