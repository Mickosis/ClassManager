Public Class ImportExcelDialog

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim confirm As DialogResult = MsgBox("Are all information correct?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = ("") Then
                MsgBox("Please input a subject name", MsgBoxStyle.OkOnly, msgboxtitle)
            Else
                Try


                Catch ex As Exception

                End Try
            End If
        End If

    End Sub
End Class