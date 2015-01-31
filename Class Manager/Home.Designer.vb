<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.Students = New System.Windows.Forms.Button()
        Me.Classes = New System.Windows.Forms.Button()
        Me.Sync = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Students
        '
        Me.Students.FlatAppearance.BorderSize = 0
        Me.Students.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Students.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Students.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Students.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Students.Image = Global.Class_Manager.My.Resources.Resources.StudentsButton
        Me.Students.Location = New System.Drawing.Point(33, 84)
        Me.Students.Name = "Students"
        Me.Students.Size = New System.Drawing.Size(312, 294)
        Me.Students.TabIndex = 0
        Me.Students.UseVisualStyleBackColor = True
        '
        'Classes
        '
        Me.Classes.FlatAppearance.BorderSize = 0
        Me.Classes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Classes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Classes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Classes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Classes.Image = Global.Class_Manager.My.Resources.Resources.ClassesButton
        Me.Classes.Location = New System.Drawing.Point(357, 90)
        Me.Classes.Name = "Classes"
        Me.Classes.Size = New System.Drawing.Size(312, 294)
        Me.Classes.TabIndex = 1
        Me.Classes.UseVisualStyleBackColor = True
        '
        'Sync
        '
        Me.Sync.FlatAppearance.BorderSize = 0
        Me.Sync.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Sync.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Sync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Sync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Sync.Image = Global.Class_Manager.My.Resources.Resources.SyncButton
        Me.Sync.Location = New System.Drawing.Point(678, 84)
        Me.Sync.Name = "Sync"
        Me.Sync.Size = New System.Drawing.Size(312, 294)
        Me.Sync.TabIndex = 2
        Me.Sync.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 27.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(37, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 48)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Class Manager"
        '
        'Close
        '
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(980, 12)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(32, 36)
        Me.Close.TabIndex = 4
        Me.Close.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1024, 480)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Sync)
        Me.Controls.Add(Me.Classes)
        Me.Controls.Add(Me.Students)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Students As System.Windows.Forms.Button
    Friend WithEvents Classes As System.Windows.Forms.Button
    Friend WithEvents Sync As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Close As System.Windows.Forms.Button

End Class
