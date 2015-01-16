Public Class ClassHome

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        ClassCreateHome.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClassCreateHomeAddStudents.Show()
        Me.Close()

    End Sub
End Class