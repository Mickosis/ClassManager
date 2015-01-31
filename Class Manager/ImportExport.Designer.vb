<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportExport))
        Me.Import = New System.Windows.Forms.Button()
        Me.Export = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Browse = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Import
        '
        Me.Import.Enabled = False
        Me.Import.FlatAppearance.BorderSize = 0
        Me.Import.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Import.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Import.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Import.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Import.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import.Image = Global.Class_Manager.My.Resources.Resources.addbrowse
        Me.Import.Location = New System.Drawing.Point(304, 66)
        Me.Import.Name = "Import"
        Me.Import.Size = New System.Drawing.Size(88, 32)
        Me.Import.TabIndex = 0
        Me.Import.Text = "Import DB"
        Me.Import.UseVisualStyleBackColor = True
        '
        'Export
        '
        Me.Export.FlatAppearance.BorderSize = 0
        Me.Export.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Export.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Export.Image = Global.Class_Manager.My.Resources.Resources.addbrowse
        Me.Export.Location = New System.Drawing.Point(292, 107)
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(123, 34)
        Me.Export.TabIndex = 1
        Me.Export.Text = "Export DB"
        Me.Export.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(103, 66)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(178, 29)
        Me.TextBox1.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(103, 112)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(178, 29)
        Me.TextBox2.TabIndex = 3
        '
        'Browse
        '
        Me.Browse.FlatAppearance.BorderSize = 0
        Me.Browse.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Browse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Browse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Browse.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse.Image = Global.Class_Manager.My.Resources.Resources.addbrowse
        Me.Browse.Location = New System.Drawing.Point(12, 66)
        Me.Browse.Name = "Browse"
        Me.Browse.Size = New System.Drawing.Size(75, 32)
        Me.Browse.TabIndex = 4
        Me.Browse.Text = "Browse"
        Me.Browse.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LimeGreen
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(427, 53)
        Me.MenuStrip1.TabIndex = 16
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
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(174, 49)
        Me.StudentToolStripMenuItem.Text = "Import / Export"
        '
        'Close
        '
        Me.Close.BackColor = System.Drawing.Color.LimeGreen
        Me.Close.FlatAppearance.BorderSize = 0
        Me.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close.Image = Global.Class_Manager.My.Resources.Resources.CloseButton
        Me.Close.Location = New System.Drawing.Point(372, 0)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(55, 53)
        Me.Close.TabIndex = 24
        Me.Close.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Class_Manager.My.Resources.Resources.addbrowse
        Me.Button1.Location = New System.Drawing.Point(120, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 34)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Create DB"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ImportExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(427, 205)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Browse)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Export)
        Me.Controls.Add(Me.Import)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImportExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImportExport"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Import As System.Windows.Forms.Button
    Friend WithEvents Export As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Browse As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HomeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Close As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
