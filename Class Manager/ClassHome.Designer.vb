<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClassHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClassHome))
        Me.Create = New System.Windows.Forms.Button()
        Me.Update = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Create
        '
        Me.Create.FlatAppearance.BorderSize = 0
        Me.Create.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Create.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Create.Image = CType(resources.GetObject("Create.Image"), System.Drawing.Image)
        Me.Create.Location = New System.Drawing.Point(41, 113)
        Me.Create.Name = "Create"
        Me.Create.Size = New System.Drawing.Size(201, 66)
        Me.Create.TabIndex = 0
        Me.Create.Text = "Create a Class"
        Me.Create.UseVisualStyleBackColor = True
        '
        'Update
        '
        Me.Update.FlatAppearance.BorderSize = 0
        Me.Update.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Update.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Update.Image = CType(resources.GetObject("Update.Image"), System.Drawing.Image)
        Me.Update.Location = New System.Drawing.Point(41, 175)
        Me.Update.Name = "Update"
        Me.Update.Size = New System.Drawing.Size(201, 66)
        Me.Update.TabIndex = 1
        Me.Update.Text = "Update a Class"
        Me.Update.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Firebrick
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(283, 53)
        Me.MenuStrip1.TabIndex = 13
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
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(94, 49)
        Me.StudentToolStripMenuItem.Text = "Classes"
        '
        'Close
        '
        Me.Close.BackColor = System.Drawing.Color.Firebrick
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(228, 0)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(55, 53)
        Me.Close.TabIndex = 24
        Me.Close.UseVisualStyleBackColor = False
        '
        'ClassHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(283, 315)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Update)
        Me.Controls.Add(Me.Create)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ClassHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClassHome"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Create As System.Windows.Forms.Button
    Friend WithEvents Update As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Close As System.Windows.Forms.Button
End Class
