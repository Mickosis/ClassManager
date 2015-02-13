Imports System.Data.SQLite

Public Class GradeMe



    Private Sub TextBox_TextChanged(sender As Object,
                   e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged, TextBox3.TextChanged, TextBox4.TextChanged, TextBox5.TextChanged, TextBox6.TextChanged


        For Each form In My.Application.OpenForms
            If (AddPrelimGrades.Visible) Then
                Dim ClassIntl = AddPrelimGrades.TextBox1.Text

                'Get values of each transmuted grades
                Dim QuizGrade As Double = TextBox1.Text
                Dim AttnGrade As Double = TextBox2.Text
                Dim ReciGrade As Double = TextBox3.Text
                Dim ProjGrade As Double = TextBox4.Text
                Dim HomeGrade As Double = TextBox5.Text
                Dim OthrGrade As Double = TextBox6.Text

                'Get the weights of Class Standing from first forms, divide by 100 for % value
                Dim QuizWeight As Double = AddPrelimGrades.TextBox2.Text / 100
                Dim AttnWeight As Double = AddPrelimGrades.TextBox3.Text / 100
                Dim ReciWeight As Double = AddPrelimGrades.TextBox4.Text / 100
                Dim ProjWeight As Double = AddPrelimGrades.TextBox5.Text / 100
                Dim HomeWeight As Double = AddPrelimGrades.TextBox6.Text / 100
                Dim OthrWeight As Double = AddPrelimGrades.TextBox7.Text / 100

                'Compute
                Dim QuizFinal As Double = QuizGrade * QuizWeight
                Dim AttnFinal As Double = AttnGrade * AttnWeight
                Dim ReciFinal As Double = ReciGrade * ReciWeight
                Dim ProjFinal As Double = ProjGrade * ProjWeight
                Dim HomeFinal As Double = HomeGrade * HomeWeight
                Dim OthrFinal As Double = OthrGrade * OthrWeight
                'Display grades per weight
                Label12.Text = QuizFinal
                Label13.Text = AttnFinal
                Label14.Text = ReciFinal
                Label15.Text = ProjFinal
                Label16.Text = HomeFinal
                Label17.Text = OthrFinal

                'Compute final grade
                Dim FinalFinalGrade = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                Label4.Text = FinalFinalGrade

                Dim PassMark As Double
                'Get Global Grades Values
                DBConn()
                DBConn()
                Dim querystring As String = "SELECT PassingMark FROM GlobalGrades"
                Dim command As New SQLiteCommand(querystring, SQLCONN)
                Dim reader As SQLiteDataReader = command.ExecuteReader
                While reader.Read
                    PassMark = reader.GetValue(0)
                End While
                reader.Close()

                'Display pass or fail
                If FinalFinalGrade >= PassMark Then
                    Label5.Text = "Passed!"
                Else
                    Label5.Text = "Failed!"
                End If
            End If
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each form In My.Application.OpenForms
            If (AddPrelimGrades.Visible) Then

                Dim ClassIntl = AddPrelimGrades.TextBox1.Text

                'Get values of each transmuted grades
                Dim QuizGrade As Double = TextBox1.Text
                Dim AttnGrade As Double = TextBox2.Text
                Dim ReciGrade As Double = TextBox3.Text
                Dim ProjGrade As Double = TextBox4.Text
                Dim HomeGrade As Double = TextBox5.Text
                Dim OthrGrade As Double = TextBox6.Text

                'Get the weights of Class Standing from first forms, divide by 100 for % value
                Dim QuizWeight As Double = AddPrelimGrades.TextBox2.Text / 100
                Dim AttnWeight As Double = AddPrelimGrades.TextBox3.Text / 100
                Dim ReciWeight As Double = AddPrelimGrades.TextBox4.Text / 100
                Dim ProjWeight As Double = AddPrelimGrades.TextBox5.Text / 100
                Dim HomeWeight As Double = AddPrelimGrades.TextBox6.Text / 100
                Dim OthrWeight As Double = AddPrelimGrades.TextBox7.Text / 100

                'Compute
                Dim QuizFinal As Double = QuizGrade * QuizWeight
                Dim AttnFinal As Double = AttnGrade * AttnWeight
                Dim ReciFinal As Double = ReciGrade * ReciWeight
                Dim ProjFinal As Double = ProjGrade * ProjWeight
                Dim HomeFinal As Double = HomeGrade * HomeWeight
                Dim OthrFinal As Double = OthrGrade * OthrWeight
                'Display grades per weight
                Label12.Text = QuizFinal
                Label13.Text = AttnFinal
                Label14.Text = ReciFinal
                Label15.Text = ProjFinal
                Label16.Text = HomeFinal
                Label17.Text = OthrFinal

                'Compute final grade
                Dim FinalFinalGrade = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                Label4.Text = FinalFinalGrade

                Dim PassMark As Double
                'Get Global Grades Values
                DBConn()
                DBConn()
                Dim querystring As String = "SELECT PassingMark FROM GlobalGrades"
                Dim command As New SQLiteCommand(querystring, SQLCONN)
                Dim reader As SQLiteDataReader = command.ExecuteReader
                While reader.Read
                    PassMark = reader.GetValue(0)
                End While
                reader.Close()

                'Display pass or fail
                If FinalFinalGrade >= PassMark Then
                    Label5.Text = "Passed!"
                Else
                    Label5.Text = "Failed!"
                End If

                DBConn()
                SQLSTR = "UPDATE '" & ClassIntl & "' SET pQuiz= '" & TextBox2.Text & "', pAttend= '" & TextBox3.Text & "', pRecite= '" & TextBox4.Text & "', pProject= '" & TextBox5.Text & "', pHomework= '" & TextBox4.Text & "', pRecite= '" & TextBox4.Text & "', pOthers= '" & TextBox4.Text & "', pGrade= '" & TextBox4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
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
                        .SubItems(9).Text = Label4.Text
                    End With
                End If

            ElseIf (AddMidtermGrades.Visible) Then

                Dim ClassIntl = AddMidtermGrades.TextBox1.Text

                'Get values of each transmuted grades
                Dim QuizGrade As Double = TextBox1.Text
                Dim AttnGrade As Double = TextBox2.Text
                Dim ReciGrade As Double = TextBox3.Text
                Dim ProjGrade As Double = TextBox4.Text
                Dim HomeGrade As Double = TextBox5.Text
                Dim OthrGrade As Double = TextBox6.Text

                'Get the weights of Class Standing from first forms, divide by 100 for % value
                Dim QuizWeight As Double = AddMidtermGrades.TextBox2.Text / 100
                Dim AttnWeight As Double = AddMidtermGrades.TextBox3.Text / 100
                Dim ReciWeight As Double = AddMidtermGrades.TextBox4.Text / 100
                Dim ProjWeight As Double = AddMidtermGrades.TextBox5.Text / 100
                Dim HomeWeight As Double = AddMidtermGrades.TextBox6.Text / 100
                Dim OthrWeight As Double = AddMidtermGrades.TextBox7.Text / 100

                'Compute
                Dim QuizFinal As Double = QuizGrade * QuizWeight
                Dim AttnFinal As Double = AttnGrade * AttnWeight
                Dim ReciFinal As Double = ReciGrade * ReciWeight
                Dim ProjFinal As Double = ProjGrade * ProjWeight
                Dim HomeFinal As Double = HomeGrade * HomeWeight
                Dim OthrFinal As Double = OthrGrade * OthrWeight
                'Display grades per weight
                Label12.Text = QuizFinal
                Label13.Text = AttnFinal
                Label14.Text = ReciFinal
                Label15.Text = ProjFinal
                Label16.Text = HomeFinal
                Label17.Text = OthrFinal

                'Compute final grade
                Dim FinalFinalGrade = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                Label4.Text = FinalFinalGrade

                Dim PassMark As Double
                'Get Global Grades Values
                DBConn()
                DBConn()
                Dim querystring As String = "SELECT PassingMark FROM GlobalGrades"
                Dim command As New SQLiteCommand(querystring, SQLCONN)
                Dim reader As SQLiteDataReader = command.ExecuteReader
                While reader.Read
                    PassMark = reader.GetValue(0)
                End While
                reader.Close()

                'Display pass or fail
                If FinalFinalGrade >= PassMark Then
                    Label5.Text = "Passed!"
                Else
                    Label5.Text = "Failed!"
                End If

                DBConn()
                SQLSTR = "UPDATE '" & ClassIntl & "' SET mQuiz= '" & TextBox2.Text & "', mAttend= '" & TextBox3.Text & "', mRecite= '" & TextBox4.Text & "', mProject= '" & TextBox5.Text & "', mHomework= '" & TextBox4.Text & "', mRecite= '" & TextBox4.Text & "', mOthers= '" & TextBox4.Text & "', mGrade= '" & TextBox4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
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
                        .SubItems(9).Text = Label4.Text
                    End With
                End If

            ElseIf (AddFinalGrades.Visible) Then

                Dim ClassIntl = AddFinalGrades.TextBox1.Text

                'Get values of each transmuted grades
                Dim QuizGrade As Double = TextBox1.Text
                Dim AttnGrade As Double = TextBox2.Text
                Dim ReciGrade As Double = TextBox3.Text
                Dim ProjGrade As Double = TextBox4.Text
                Dim HomeGrade As Double = TextBox5.Text
                Dim OthrGrade As Double = TextBox6.Text

                'Get the weights of Class Standing from first forms, divide by 100 for % value
                Dim QuizWeight As Double = AddFinalGrades.TextBox2.Text / 100
                Dim AttnWeight As Double = AddFinalGrades.TextBox3.Text / 100
                Dim ReciWeight As Double = AddFinalGrades.TextBox4.Text / 100
                Dim ProjWeight As Double = AddFinalGrades.TextBox5.Text / 100
                Dim HomeWeight As Double = AddFinalGrades.TextBox6.Text / 100
                Dim OthrWeight As Double = AddFinalGrades.TextBox7.Text / 100

                'Compute
                Dim QuizFinal As Double = QuizGrade * QuizWeight
                Dim AttnFinal As Double = AttnGrade * AttnWeight
                Dim ReciFinal As Double = ReciGrade * ReciWeight
                Dim ProjFinal As Double = ProjGrade * ProjWeight
                Dim HomeFinal As Double = HomeGrade * HomeWeight
                Dim OthrFinal As Double = OthrGrade * OthrWeight

                'Display grades per weight
                Label12.Text = QuizFinal
                Label13.Text = AttnFinal
                Label14.Text = ReciFinal
                Label15.Text = ProjFinal
                Label16.Text = HomeFinal
                Label17.Text = OthrFinal

                'Compute final grade
                Dim FinalFinalGrade = QuizFinal + AttnFinal + ReciFinal + ProjFinal + HomeFinal + OthrFinal
                Label4.Text = FinalFinalGrade

                Dim PassMark As Double
                'Get Global Grades Values
                DBConn()
                DBConn()
                Dim querystring As String = "SELECT PassingMark FROM GlobalGrades"
                Dim command As New SQLiteCommand(querystring, SQLCONN)
                Dim reader As SQLiteDataReader = command.ExecuteReader
                While reader.Read
                    PassMark = reader.GetValue(0)
                End While
                reader.Close()

                'Display pass or fail
                If FinalFinalGrade >= PassMark Then
                    Label5.Text = "Passed!"
                Else
                    Label5.Text = "Failed!"
                End If

                DBConn()
                SQLSTR = "UPDATE '" & ClassIntl & "' SET fQuiz= '" & TextBox2.Text & "', fAttend= '" & TextBox3.Text & "', fRecite= '" & TextBox4.Text & "', fProject= '" & TextBox5.Text & "', fHomework= '" & TextBox4.Text & "', fRecite= '" & TextBox4.Text & "', fOthers= '" & TextBox4.Text & "', fGrade= '" & TextBox4.Text & "' WHERE StudentID = '" & Label18.Text & "'"
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
                        .SubItems(9).Text = Label4.Text
                    End With
                End If
            End If
        Next
        Me.Close()
    End Sub


End Class