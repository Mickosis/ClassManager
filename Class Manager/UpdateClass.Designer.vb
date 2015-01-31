<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateClass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateClass))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Selected = New System.Windows.Forms.Button()
        Me.DelClass = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(24, 104)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(328, 252)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select a class"
        '
        'Selected
        '
        Me.Selected.FlatAppearance.BorderSize = 0
        Me.Selected.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Selected.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Selected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Selected.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Selected.Image = CType(resources.GetObject("Selected.Image"), System.Drawing.Image)
        Me.Selected.Location = New System.Drawing.Point(254, 381)
        Me.Selected.Name = "Selected"
        Me.Selected.Size = New System.Drawing.Size(98, 42)
        Me.Selected.TabIndex = 2
        Me.Selected.Text = "Select"
        Me.Selected.UseVisualStyleBackColor = True
        '
        'DelClass
        '
        Me.DelClass.FlatAppearance.BorderSize = 0
        Me.DelClass.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.DelClass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.DelClass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.DelClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DelClass.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DelClass.Image = CType(resources.GetObject("DelClass.Image"), System.Drawing.Image)
        Me.DelClass.Location = New System.Drawing.Point(24, 381)
        Me.DelClass.Name = "DelClass"
        Me.DelClass.Size = New System.Drawing.Size(98, 42)
        Me.DelClass.TabIndex = 3
        Me.DelClass.Text = "Delete Class"
        Me.DelClass.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Firebrick
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(380, 53)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "Student"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Image = Global.Class_Manager.My.Resources.Resources.arrow
        Me.HomeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(112, 49)
        Me.HomeToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.HomeToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(150, 49)
        Me.StudentToolStripMenuItem.Text = "Update Class"
        '
        'Close
        '
        Me.Close.BackColor = System.Drawing.Color.Firebrick
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(325, 0)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(55, 53)
        Me.Close.TabIndex = 32
        Me.Close.UseVisualStyleBackColor = False
        '
        'UpdateClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(380, 445)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DelClass)
        Me.Controls.Add(Me.Selected)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UpdateClass"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UpdateClass"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Selected As System.Windows.Forms.Button
    Friend WithEvents DelClass As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Close As System.Windows.Forms.Button
End Class
