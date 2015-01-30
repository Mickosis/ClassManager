Imports System.Data.SQLite

Public Class UpdateClass

    Private Sub UpdateClass_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        DBConn()
        SQLSTR = "SELECT * FROM MasterClasslist"
        readDB()
        ListView1.GridLines = True
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.Clear()
        ListView1.MultiSelect = False
        ListView1.Columns.Add("ClassID", 80)
        ListView1.Columns.Add("Name", 80)
        ListView1.Columns.Add("Desc", 320)
        While (SQLDR.Read())
            With ListView1.Items.Add(SQLDR("ClassID"))
                .subitems.add(SQLDR("Name"))
                .subitems.add(SQLDR("Desc"))
            End With
        End While
        SQLDR.Dispose()
        SQLCONN.Close()
        Button2.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not ListView1.SelectedItems.Count = 0 Then
            With ListView1.SelectedItems.Item(0)
                UpdateClassInitialList.TextBox1.Text = .SubItems(0).Text
            End With
            Me.Hide()
            UpdateClassInitialList.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim confirm As DialogResult = MsgBox("Are you sure you want to delete this class?", MsgBoxStyle.YesNo, msgboxtitle)
        If confirm = Windows.Forms.DialogResult.Yes Then
            DBConn()
            With ListView1.SelectedItems.Item(0)
                SQLSTR = "DELETE FROM MasterClasslist WHERE ClassID = '" & .SubItems(0).Text & "'"
            End With
            alterDB()
            MsgBox("Class deleted succesfully!", , msgboxtitle)
            Me.Close()
            ClassHome.Show()

        End If

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            Button2.Enabled = True
        ElseIf ListView1.SelectedItems.Count = 0 Then
            Button2.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        ClassHome.Show()

    End Sub
End Class