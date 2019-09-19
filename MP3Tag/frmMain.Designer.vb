<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
		Me.lblPathOrigine = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblPathDestinazione = New System.Windows.Forms.Label()
		Me.cmdSceglieOrigine = New System.Windows.Forms.Button()
		Me.cmdSceglieDest = New System.Windows.Forms.Button()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.lblAggiornamento = New System.Windows.Forms.Label()
		Me.lblCopiati = New System.Windows.Forms.Label()
		Me.chkUguali = New System.Windows.Forms.CheckBox()
		Me.chkSposta = New System.Windows.Forms.CheckBox()
		Me.picEsegue = New System.Windows.Forms.PictureBox()
		Me.picPlayer = New System.Windows.Forms.PictureBox()
		Me.picSettings = New System.Windows.Forms.PictureBox()
		Me.picConTAG = New System.Windows.Forms.PictureBox()
		Me.picSenzaTag = New System.Windows.Forms.PictureBox()
		Me.picUguali = New System.Windows.Forms.PictureBox()
		Me.pnlOperazioni = New System.Windows.Forms.Panel()
		Me.picUscita = New System.Windows.Forms.PictureBox()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
		Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
		Me.Button1 = New System.Windows.Forms.Button()
		CType(Me.picEsegue, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picSettings, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picConTAG, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picSenzaTag, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.picUguali, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnlOperazioni.SuspendLayout()
		CType(Me.picUscita, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'lblPathOrigine
		'
		Me.lblPathOrigine.BackColor = System.Drawing.Color.White
		Me.lblPathOrigine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblPathOrigine.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPathOrigine.Location = New System.Drawing.Point(95, 0)
		Me.lblPathOrigine.Name = "lblPathOrigine"
		Me.lblPathOrigine.Size = New System.Drawing.Size(343, 19)
		Me.lblPathOrigine.TabIndex = 1
		Me.lblPathOrigine.Text = "Label1"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label1.Location = New System.Drawing.Point(0, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(55, 16)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Origine"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label2.Location = New System.Drawing.Point(0, 30)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(90, 16)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Destinazione"
		'
		'lblPathDestinazione
		'
		Me.lblPathDestinazione.BackColor = System.Drawing.Color.White
		Me.lblPathDestinazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lblPathDestinazione.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPathDestinazione.Location = New System.Drawing.Point(95, 30)
		Me.lblPathDestinazione.Name = "lblPathDestinazione"
		Me.lblPathDestinazione.Size = New System.Drawing.Size(343, 19)
		Me.lblPathDestinazione.TabIndex = 3
		Me.lblPathDestinazione.Text = "Label1"
		'
		'cmdSceglieOrigine
		'
		Me.cmdSceglieOrigine.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSceglieOrigine.Location = New System.Drawing.Point(444, 0)
		Me.cmdSceglieOrigine.Name = "cmdSceglieOrigine"
		Me.cmdSceglieOrigine.Size = New System.Drawing.Size(31, 19)
		Me.cmdSceglieOrigine.TabIndex = 5
		Me.cmdSceglieOrigine.Text = "..."
		Me.cmdSceglieOrigine.UseVisualStyleBackColor = True
		'
		'cmdSceglieDest
		'
		Me.cmdSceglieDest.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSceglieDest.Location = New System.Drawing.Point(444, 30)
		Me.cmdSceglieDest.Name = "cmdSceglieDest"
		Me.cmdSceglieDest.Size = New System.Drawing.Size(31, 19)
		Me.cmdSceglieDest.TabIndex = 6
		Me.cmdSceglieDest.Text = "..."
		Me.cmdSceglieDest.UseVisualStyleBackColor = True
		'
		'lblAggiornamento
		'
		Me.lblAggiornamento.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblAggiornamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblAggiornamento.Location = New System.Drawing.Point(20, 16)
		Me.lblAggiornamento.Name = "lblAggiornamento"
		Me.lblAggiornamento.Size = New System.Drawing.Size(269, 18)
		Me.lblAggiornamento.TabIndex = 7
		Me.lblAggiornamento.Text = "Label3"
		Me.lblAggiornamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblCopiati
		'
		Me.lblCopiati.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCopiati.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.lblCopiati.Location = New System.Drawing.Point(20, 43)
		Me.lblCopiati.Name = "lblCopiati"
		Me.lblCopiati.Size = New System.Drawing.Size(269, 18)
		Me.lblCopiati.TabIndex = 8
		Me.lblCopiati.Text = "Label3"
		Me.lblCopiati.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'chkUguali
		'
		Me.chkUguali.AutoSize = True
		Me.chkUguali.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkUguali.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.chkUguali.Location = New System.Drawing.Point(238, 51)
		Me.chkUguali.Name = "chkUguali"
		Me.chkUguali.Size = New System.Drawing.Size(129, 20)
		Me.chkUguali.TabIndex = 9
		Me.chkUguali.Text = "Controlla uguali"
		Me.chkUguali.UseVisualStyleBackColor = True
		'
		'chkSposta
		'
		Me.chkSposta.AutoSize = True
		Me.chkSposta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkSposta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.chkSposta.Location = New System.Drawing.Point(128, 51)
		Me.chkSposta.Name = "chkSposta"
		Me.chkSposta.Size = New System.Drawing.Size(101, 20)
		Me.chkSposta.TabIndex = 10
		Me.chkSposta.Text = "Smista MP3"
		Me.chkSposta.UseVisualStyleBackColor = True
		'
		'picEsegue
		'
		Me.picEsegue.BackColor = System.Drawing.Color.Transparent
		Me.picEsegue.BackgroundImage = CType(resources.GetObject("picEsegue.BackgroundImage"), System.Drawing.Image)
		Me.picEsegue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picEsegue.Location = New System.Drawing.Point(3, 71)
		Me.picEsegue.Name = "picEsegue"
		Me.picEsegue.Size = New System.Drawing.Size(37, 37)
		Me.picEsegue.TabIndex = 16
		Me.picEsegue.TabStop = False
		'
		'picPlayer
		'
		Me.picPlayer.BackColor = System.Drawing.Color.Transparent
		Me.picPlayer.BackgroundImage = CType(resources.GetObject("picPlayer.BackgroundImage"), System.Drawing.Image)
		Me.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picPlayer.Location = New System.Drawing.Point(49, 71)
		Me.picPlayer.Name = "picPlayer"
		Me.picPlayer.Size = New System.Drawing.Size(41, 37)
		Me.picPlayer.TabIndex = 17
		Me.picPlayer.TabStop = False
		'
		'picSettings
		'
		Me.picSettings.BackColor = System.Drawing.Color.Transparent
		Me.picSettings.BackgroundImage = CType(resources.GetObject("picSettings.BackgroundImage"), System.Drawing.Image)
		Me.picSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picSettings.Location = New System.Drawing.Point(385, 71)
		Me.picSettings.Name = "picSettings"
		Me.picSettings.Size = New System.Drawing.Size(42, 37)
		Me.picSettings.TabIndex = 18
		Me.picSettings.TabStop = False
		'
		'picConTAG
		'
		Me.picConTAG.BackColor = System.Drawing.Color.Transparent
		Me.picConTAG.BackgroundImage = CType(resources.GetObject("picConTAG.BackgroundImage"), System.Drawing.Image)
		Me.picConTAG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picConTAG.Location = New System.Drawing.Point(99, 71)
		Me.picConTAG.Name = "picConTAG"
		Me.picConTAG.Size = New System.Drawing.Size(40, 37)
		Me.picConTAG.TabIndex = 19
		Me.picConTAG.TabStop = False
		'
		'picSenzaTag
		'
		Me.picSenzaTag.BackColor = System.Drawing.Color.Transparent
		Me.picSenzaTag.BackgroundImage = CType(resources.GetObject("picSenzaTag.BackgroundImage"), System.Drawing.Image)
		Me.picSenzaTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picSenzaTag.Location = New System.Drawing.Point(145, 71)
		Me.picSenzaTag.Name = "picSenzaTag"
		Me.picSenzaTag.Size = New System.Drawing.Size(38, 37)
		Me.picSenzaTag.TabIndex = 20
		Me.picSenzaTag.TabStop = False
		'
		'picUguali
		'
		Me.picUguali.BackColor = System.Drawing.Color.Transparent
		Me.picUguali.BackgroundImage = CType(resources.GetObject("picUguali.BackgroundImage"), System.Drawing.Image)
		Me.picUguali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picUguali.Location = New System.Drawing.Point(189, 71)
		Me.picUguali.Name = "picUguali"
		Me.picUguali.Size = New System.Drawing.Size(40, 37)
		Me.picUguali.TabIndex = 21
		Me.picUguali.TabStop = False
		'
		'pnlOperazioni
		'
		Me.pnlOperazioni.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.pnlOperazioni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlOperazioni.Controls.Add(Me.lblAggiornamento)
		Me.pnlOperazioni.Controls.Add(Me.lblCopiati)
		Me.pnlOperazioni.Location = New System.Drawing.Point(95, 12)
		Me.pnlOperazioni.Name = "pnlOperazioni"
		Me.pnlOperazioni.Size = New System.Drawing.Size(307, 76)
		Me.pnlOperazioni.TabIndex = 22
		Me.pnlOperazioni.Visible = False
		'
		'picUscita
		'
		Me.picUscita.BackColor = System.Drawing.Color.Transparent
		Me.picUscita.BackgroundImage = CType(resources.GetObject("picUscita.BackgroundImage"), System.Drawing.Image)
		Me.picUscita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.picUscita.Location = New System.Drawing.Point(433, 71)
		Me.picUscita.Name = "picUscita"
		Me.picUscita.Size = New System.Drawing.Size(42, 37)
		Me.picUscita.TabIndex = 23
		Me.picUscita.TabStop = False
		'
		'Timer1
		'
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(257, 85)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(98, 23)
		Me.Button1.TabIndex = 24
		Me.Button1.Text = "Sistema Immagini"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'frmMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Green
		Me.ClientSize = New System.Drawing.Size(478, 111)
		Me.ControlBox = False
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.picUscita)
		Me.Controls.Add(Me.pnlOperazioni)
		Me.Controls.Add(Me.picSenzaTag)
		Me.Controls.Add(Me.picUguali)
		Me.Controls.Add(Me.picConTAG)
		Me.Controls.Add(Me.picSettings)
		Me.Controls.Add(Me.picPlayer)
		Me.Controls.Add(Me.picEsegue)
		Me.Controls.Add(Me.chkSposta)
		Me.Controls.Add(Me.chkUguali)
		Me.Controls.Add(Me.cmdSceglieDest)
		Me.Controls.Add(Me.cmdSceglieOrigine)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.lblPathDestinazione)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.lblPathOrigine)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frmMain"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		CType(Me.picEsegue, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picPlayer, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picSettings, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picConTAG, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picSenzaTag, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.picUguali, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnlOperazioni.ResumeLayout(False)
		CType(Me.picUscita, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents lblPathOrigine As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPathDestinazione As System.Windows.Forms.Label
    Friend WithEvents cmdSceglieOrigine As System.Windows.Forms.Button
    Friend WithEvents cmdSceglieDest As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblAggiornamento As System.Windows.Forms.Label
    Friend WithEvents lblCopiati As System.Windows.Forms.Label
    Friend WithEvents chkUguali As System.Windows.Forms.CheckBox
    Friend WithEvents chkSposta As System.Windows.Forms.CheckBox
    Friend WithEvents picEsegue As System.Windows.Forms.PictureBox
    Friend WithEvents picPlayer As System.Windows.Forms.PictureBox
    Friend WithEvents picSettings As System.Windows.Forms.PictureBox
    Friend WithEvents picConTAG As System.Windows.Forms.PictureBox
    Friend WithEvents picSenzaTag As System.Windows.Forms.PictureBox
    Friend WithEvents picUguali As System.Windows.Forms.PictureBox
    Friend WithEvents pnlOperazioni As Panel
    Friend WithEvents picUscita As PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
