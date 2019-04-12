<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConTAG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConTAG))
        Me.lstArtista = New System.Windows.Forms.ListBox()
        Me.lstAlbum = New System.Windows.Forms.ListBox()
        Me.lstCanzone = New System.Windows.Forms.ListBox()
        Me.lblDirFile = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlStelle = New System.Windows.Forms.Panel()
        Me.picStelle7 = New System.Windows.Forms.PictureBox()
        Me.picStelle6 = New System.Windows.Forms.PictureBox()
        Me.picStelle1 = New System.Windows.Forms.PictureBox()
        Me.picStelle2 = New System.Windows.Forms.PictureBox()
        Me.picStelle3 = New System.Windows.Forms.PictureBox()
        Me.picStelle4 = New System.Windows.Forms.PictureBox()
        Me.picStelle5 = New System.Windows.Forms.PictureBox()
        Me.pnlImms = New System.Windows.Forms.Panel()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.picImmagineMP3 = New System.Windows.Forms.PictureBox()
        Me.cmdDownloadImmArtista = New System.Windows.Forms.Button()
        Me.cmdImposta = New System.Windows.Forms.Button()
        Me.lblNomeFile = New System.Windows.Forms.Label()
        Me.txtTitolo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTraccia = New System.Windows.Forms.TextBox()
        Me.txtAnno = New System.Windows.Forms.TextBox()
        Me.txtArtista = New System.Windows.Forms.TextBox()
        Me.txtAlbum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlScelta = New System.Windows.Forms.Panel()
        Me.chkArtista = New System.Windows.Forms.CheckBox()
        Me.chkNomeAlbum = New System.Windows.Forms.CheckBox()
        Me.cmdDownload = New System.Windows.Forms.Button()
        Me.cmdChiudePannello = New System.Windows.Forms.Button()
        Me.cmdImpostaAlbum = New System.Windows.Forms.Button()
        Me.cmdImpostaImmagine = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pnlImmagini = New System.Windows.Forms.Panel()
        Me.cmdChiudePnlImmagini = New System.Windows.Forms.Button()
        Me.lstTesto = New System.Windows.Forms.ListBox()
        Me.cmdEliminaTesto = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlImmagine = New System.Windows.Forms.Panel()
        Me.cmdSalva = New System.Windows.Forms.Button()
        Me.lblNomeImmNascosto = New System.Windows.Forms.Label()
        Me.cmdEliminaPic = New System.Windows.Forms.Button()
        Me.lblInfoPIC = New System.Windows.Forms.Label()
        Me.cmdChiudPImm = New System.Windows.Forms.Button()
        Me.picImmagine = New System.Windows.Forms.PictureBox()
        Me.pnlAzioni = New System.Windows.Forms.Panel()
        Me.cmdChiudeAzioni = New System.Windows.Forms.Button()
        Me.lblTipologia = New System.Windows.Forms.Label()
        Me.lblSelezione = New System.Windows.Forms.Label()
        Me.cmdRinomina = New System.Windows.Forms.Button()
        Me.cmdCancella = New System.Windows.Forms.Button()
        Me.cmdConverteMP3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.pnlStelle.SuspendLayout()
        CType(Me.picStelle7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStelle6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStelle1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStelle2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStelle3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStelle4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picStelle5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImmagineMP3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlScelta.SuspendLayout()
        Me.pnlImmagini.SuspendLayout()
        Me.pnlImmagine.SuspendLayout()
        CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAzioni.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstArtista
        '
        Me.lstArtista.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstArtista.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstArtista.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstArtista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lstArtista.FormattingEnabled = True
        Me.lstArtista.HorizontalScrollbar = True
        Me.lstArtista.ItemHeight = 20
        Me.lstArtista.Location = New System.Drawing.Point(1, 22)
        Me.lstArtista.Name = "lstArtista"
        Me.lstArtista.Size = New System.Drawing.Size(175, 400)
        Me.lstArtista.TabIndex = 0
        '
        'lstAlbum
        '
        Me.lstAlbum.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstAlbum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstAlbum.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAlbum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lstAlbum.FormattingEnabled = True
        Me.lstAlbum.HorizontalScrollbar = True
        Me.lstAlbum.ItemHeight = 20
        Me.lstAlbum.Location = New System.Drawing.Point(182, 22)
        Me.lstAlbum.Name = "lstAlbum"
        Me.lstAlbum.Size = New System.Drawing.Size(190, 400)
        Me.lstAlbum.TabIndex = 1
        '
        'lstCanzone
        '
        Me.lstCanzone.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstCanzone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstCanzone.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCanzone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lstCanzone.FormattingEnabled = True
        Me.lstCanzone.HorizontalScrollbar = True
        Me.lstCanzone.ItemHeight = 20
        Me.lstCanzone.Location = New System.Drawing.Point(378, 22)
        Me.lstCanzone.Name = "lstCanzone"
        Me.lstCanzone.Size = New System.Drawing.Size(184, 400)
        Me.lstCanzone.TabIndex = 2
        '
        'lblDirFile
        '
        Me.lblDirFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirFile.Location = New System.Drawing.Point(237, 10)
        Me.lblDirFile.Name = "lblDirFile"
        Me.lblDirFile.Size = New System.Drawing.Size(183, 20)
        Me.lblDirFile.TabIndex = 6
        Me.lblDirFile.Text = "Artista"
        Me.lblDirFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDirFile.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(182, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(190, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Album"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(374, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Traccia"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pnlStelle)
        Me.Panel1.Controls.Add(Me.pnlImms)
        Me.Panel1.Controls.Add(Me.cmdElimina)
        Me.Panel1.Controls.Add(Me.picImmagineMP3)
        Me.Panel1.Controls.Add(Me.cmdDownloadImmArtista)
        Me.Panel1.Controls.Add(Me.cmdImposta)
        Me.Panel1.Controls.Add(Me.lblNomeFile)
        Me.Panel1.Controls.Add(Me.txtTitolo)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtTraccia)
        Me.Panel1.Controls.Add(Me.lblDirFile)
        Me.Panel1.Controls.Add(Me.txtAnno)
        Me.Panel1.Controls.Add(Me.txtArtista)
        Me.Panel1.Controls.Add(Me.txtAlbum)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(568, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 418)
        Me.Panel1.TabIndex = 9
        '
        'pnlStelle
        '
        Me.pnlStelle.BackColor = System.Drawing.Color.Transparent
        Me.pnlStelle.Controls.Add(Me.picStelle7)
        Me.pnlStelle.Controls.Add(Me.picStelle6)
        Me.pnlStelle.Controls.Add(Me.picStelle1)
        Me.pnlStelle.Controls.Add(Me.picStelle2)
        Me.pnlStelle.Controls.Add(Me.picStelle3)
        Me.pnlStelle.Controls.Add(Me.picStelle4)
        Me.pnlStelle.Controls.Add(Me.picStelle5)
        Me.pnlStelle.Location = New System.Drawing.Point(5, 3)
        Me.pnlStelle.Name = "pnlStelle"
        Me.pnlStelle.Size = New System.Drawing.Size(226, 30)
        Me.pnlStelle.TabIndex = 41
        '
        'picStelle7
        '
        Me.picStelle7.Location = New System.Drawing.Point(2, 3)
        Me.picStelle7.Name = "picStelle7"
        Me.picStelle7.Size = New System.Drawing.Size(32, 29)
        Me.picStelle7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle7.TabIndex = 6
        Me.picStelle7.TabStop = False
        '
        'picStelle6
        '
        Me.picStelle6.Location = New System.Drawing.Point(34, 3)
        Me.picStelle6.Name = "picStelle6"
        Me.picStelle6.Size = New System.Drawing.Size(32, 29)
        Me.picStelle6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle6.TabIndex = 5
        Me.picStelle6.TabStop = False
        '
        'picStelle1
        '
        Me.picStelle1.Location = New System.Drawing.Point(194, 3)
        Me.picStelle1.Name = "picStelle1"
        Me.picStelle1.Size = New System.Drawing.Size(32, 29)
        Me.picStelle1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle1.TabIndex = 4
        Me.picStelle1.TabStop = False
        '
        'picStelle2
        '
        Me.picStelle2.Location = New System.Drawing.Point(162, 3)
        Me.picStelle2.Name = "picStelle2"
        Me.picStelle2.Size = New System.Drawing.Size(32, 29)
        Me.picStelle2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle2.TabIndex = 3
        Me.picStelle2.TabStop = False
        '
        'picStelle3
        '
        Me.picStelle3.Location = New System.Drawing.Point(130, 3)
        Me.picStelle3.Name = "picStelle3"
        Me.picStelle3.Size = New System.Drawing.Size(32, 29)
        Me.picStelle3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle3.TabIndex = 2
        Me.picStelle3.TabStop = False
        '
        'picStelle4
        '
        Me.picStelle4.Location = New System.Drawing.Point(98, 3)
        Me.picStelle4.Name = "picStelle4"
        Me.picStelle4.Size = New System.Drawing.Size(32, 29)
        Me.picStelle4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle4.TabIndex = 1
        Me.picStelle4.TabStop = False
        '
        'picStelle5
        '
        Me.picStelle5.Location = New System.Drawing.Point(66, 3)
        Me.picStelle5.Name = "picStelle5"
        Me.picStelle5.Size = New System.Drawing.Size(32, 29)
        Me.picStelle5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picStelle5.TabIndex = 0
        Me.picStelle5.TabStop = False
        '
        'pnlImms
        '
        Me.pnlImms.AutoScroll = True
        Me.pnlImms.Location = New System.Drawing.Point(5, 33)
        Me.pnlImms.Name = "pnlImms"
        Me.pnlImms.Size = New System.Drawing.Size(415, 190)
        Me.pnlImms.TabIndex = 40
        '
        'cmdElimina
        '
        Me.cmdElimina.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdElimina.Location = New System.Drawing.Point(397, 1)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.Size = New System.Drawing.Size(23, 23)
        Me.cmdElimina.TabIndex = 38
        Me.cmdElimina.Text = "D"
        Me.cmdElimina.UseVisualStyleBackColor = True
        '
        'picImmagineMP3
        '
        Me.picImmagineMP3.BackColor = System.Drawing.Color.Transparent
        Me.picImmagineMP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImmagineMP3.Location = New System.Drawing.Point(5, 262)
        Me.picImmagineMP3.Name = "picImmagineMP3"
        Me.picImmagineMP3.Size = New System.Drawing.Size(152, 151)
        Me.picImmagineMP3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImmagineMP3.TabIndex = 37
        Me.picImmagineMP3.TabStop = False
        '
        'cmdDownloadImmArtista
        '
        Me.cmdDownloadImmArtista.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownloadImmArtista.Location = New System.Drawing.Point(292, 1)
        Me.cmdDownloadImmArtista.Name = "cmdDownloadImmArtista"
        Me.cmdDownloadImmArtista.Size = New System.Drawing.Size(99, 23)
        Me.cmdDownloadImmArtista.TabIndex = 6
        Me.cmdDownloadImmArtista.Text = "Immagini artista"
        Me.cmdDownloadImmArtista.UseVisualStyleBackColor = True
        '
        'cmdImposta
        '
        Me.cmdImposta.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImposta.Location = New System.Drawing.Point(251, 390)
        Me.cmdImposta.Name = "cmdImposta"
        Me.cmdImposta.Size = New System.Drawing.Size(170, 23)
        Me.cmdImposta.TabIndex = 34
        Me.cmdImposta.Text = "Imposta"
        Me.cmdImposta.UseVisualStyleBackColor = True
        '
        'lblNomeFile
        '
        Me.lblNomeFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeFile.Location = New System.Drawing.Point(4, 231)
        Me.lblNomeFile.Name = "lblNomeFile"
        Me.lblNomeFile.Size = New System.Drawing.Size(417, 20)
        Me.lblNomeFile.TabIndex = 33
        Me.lblNomeFile.Text = "Destinazione"
        Me.lblNomeFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTitolo
        '
        Me.txtTitolo.Location = New System.Drawing.Point(250, 313)
        Me.txtTitolo.MaxLength = 50
        Me.txtTitolo.Name = "txtTitolo"
        Me.txtTitolo.Size = New System.Drawing.Size(171, 26)
        Me.txtTitolo.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(162, 317)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Titolo"
        '
        'txtTraccia
        '
        Me.txtTraccia.Location = New System.Drawing.Point(250, 364)
        Me.txtTraccia.Name = "txtTraccia"
        Me.txtTraccia.Size = New System.Drawing.Size(171, 26)
        Me.txtTraccia.TabIndex = 29
        '
        'txtAnno
        '
        Me.txtAnno.Location = New System.Drawing.Point(250, 339)
        Me.txtAnno.MaxLength = 4
        Me.txtAnno.Name = "txtAnno"
        Me.txtAnno.Size = New System.Drawing.Size(171, 26)
        Me.txtAnno.TabIndex = 28
        '
        'txtArtista
        '
        Me.txtArtista.Location = New System.Drawing.Point(251, 262)
        Me.txtArtista.Name = "txtArtista"
        Me.txtArtista.Size = New System.Drawing.Size(171, 26)
        Me.txtArtista.TabIndex = 27
        '
        'txtAlbum
        '
        Me.txtAlbum.Location = New System.Drawing.Point(251, 289)
        Me.txtAlbum.Name = "txtAlbum"
        Me.txtAlbum.Size = New System.Drawing.Size(171, 26)
        Me.txtAlbum.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(162, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Traccia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(163, 343)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Anno"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(161, 263)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Artista"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(162, 291)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 16)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Album"
        '
        'pnlScelta
        '
        Me.pnlScelta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlScelta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlScelta.Controls.Add(Me.chkArtista)
        Me.pnlScelta.Controls.Add(Me.chkNomeAlbum)
        Me.pnlScelta.Controls.Add(Me.cmdDownload)
        Me.pnlScelta.Controls.Add(Me.cmdChiudePannello)
        Me.pnlScelta.Controls.Add(Me.cmdImpostaAlbum)
        Me.pnlScelta.Controls.Add(Me.cmdImpostaImmagine)
        Me.pnlScelta.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlScelta.Location = New System.Drawing.Point(506, 272)
        Me.pnlScelta.Name = "pnlScelta"
        Me.pnlScelta.Size = New System.Drawing.Size(190, 151)
        Me.pnlScelta.TabIndex = 33
        Me.pnlScelta.Visible = False
        '
        'chkArtista
        '
        Me.chkArtista.AutoSize = True
        Me.chkArtista.Location = New System.Drawing.Point(27, 82)
        Me.chkArtista.Name = "chkArtista"
        Me.chkArtista.Size = New System.Drawing.Size(155, 24)
        Me.chkArtista.TabIndex = 5
        Me.chkArtista.Text = "Nome artista nell'URL"
        Me.chkArtista.UseVisualStyleBackColor = True
        '
        'chkNomeAlbum
        '
        Me.chkNomeAlbum.AutoSize = True
        Me.chkNomeAlbum.Location = New System.Drawing.Point(27, 100)
        Me.chkNomeAlbum.Name = "chkNomeAlbum"
        Me.chkNomeAlbum.Size = New System.Drawing.Size(157, 24)
        Me.chkNomeAlbum.TabIndex = 4
        Me.chkNomeAlbum.Text = "Nome album nell'URL"
        Me.chkNomeAlbum.UseVisualStyleBackColor = True
        '
        'cmdDownload
        '
        Me.cmdDownload.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownload.Location = New System.Drawing.Point(4, 60)
        Me.cmdDownload.Name = "cmdDownload"
        Me.cmdDownload.Size = New System.Drawing.Size(181, 23)
        Me.cmdDownload.TabIndex = 3
        Me.cmdDownload.Text = "Download album art"
        Me.cmdDownload.UseVisualStyleBackColor = True
        '
        'cmdChiudePannello
        '
        Me.cmdChiudePannello.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChiudePannello.Location = New System.Drawing.Point(4, 123)
        Me.cmdChiudePannello.Name = "cmdChiudePannello"
        Me.cmdChiudePannello.Size = New System.Drawing.Size(181, 23)
        Me.cmdChiudePannello.TabIndex = 2
        Me.cmdChiudePannello.Text = "Annulla"
        Me.cmdChiudePannello.UseVisualStyleBackColor = True
        '
        'cmdImpostaAlbum
        '
        Me.cmdImpostaAlbum.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImpostaAlbum.Location = New System.Drawing.Point(3, 33)
        Me.cmdImpostaAlbum.Name = "cmdImpostaAlbum"
        Me.cmdImpostaAlbum.Size = New System.Drawing.Size(181, 23)
        Me.cmdImpostaAlbum.TabIndex = 1
        Me.cmdImpostaAlbum.Text = "Imposta immagine album"
        Me.cmdImpostaAlbum.UseVisualStyleBackColor = True
        '
        'cmdImpostaImmagine
        '
        Me.cmdImpostaImmagine.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImpostaImmagine.Location = New System.Drawing.Point(4, 4)
        Me.cmdImpostaImmagine.Name = "cmdImpostaImmagine"
        Me.cmdImpostaImmagine.Size = New System.Drawing.Size(181, 23)
        Me.cmdImpostaImmagine.TabIndex = 0
        Me.cmdImpostaImmagine.Text = "Cambia immagine"
        Me.cmdImpostaImmagine.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(0, -1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 20)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Artista"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(565, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Tag"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pnlImmagini
        '
        Me.pnlImmagini.AutoScroll = True
        Me.pnlImmagini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImmagini.Controls.Add(Me.cmdChiudePnlImmagini)
        Me.pnlImmagini.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlImmagini.Location = New System.Drawing.Point(1, 458)
        Me.pnlImmagini.Name = "pnlImmagini"
        Me.pnlImmagini.Size = New System.Drawing.Size(1143, 190)
        Me.pnlImmagini.TabIndex = 34
        '
        'cmdChiudePnlImmagini
        '
        Me.cmdChiudePnlImmagini.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChiudePnlImmagini.Location = New System.Drawing.Point(3, 3)
        Me.cmdChiudePnlImmagini.Name = "cmdChiudePnlImmagini"
        Me.cmdChiudePnlImmagini.Size = New System.Drawing.Size(22, 23)
        Me.cmdChiudePnlImmagini.TabIndex = 0
        Me.cmdChiudePnlImmagini.Text = "X"
        Me.cmdChiudePnlImmagini.UseVisualStyleBackColor = True
        '
        'lstTesto
        '
        Me.lstTesto.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstTesto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstTesto.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTesto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lstTesto.FormattingEnabled = True
        Me.lstTesto.HorizontalScrollbar = True
        Me.lstTesto.ItemHeight = 16
        Me.lstTesto.Location = New System.Drawing.Point(1000, 22)
        Me.lstTesto.Name = "lstTesto"
        Me.lstTesto.Size = New System.Drawing.Size(144, 416)
        Me.lstTesto.TabIndex = 35
        '
        'cmdEliminaTesto
        '
        Me.cmdEliminaTesto.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminaTesto.Location = New System.Drawing.Point(1119, 415)
        Me.cmdEliminaTesto.Name = "cmdEliminaTesto"
        Me.cmdEliminaTesto.Size = New System.Drawing.Size(23, 23)
        Me.cmdEliminaTesto.TabIndex = 36
        Me.cmdEliminaTesto.Text = "D"
        Me.cmdEliminaTesto.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(999, -1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Testo"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlImmagine
        '
        Me.pnlImmagine.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlImmagine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImmagine.Controls.Add(Me.cmdSalva)
        Me.pnlImmagine.Controls.Add(Me.lblNomeImmNascosto)
        Me.pnlImmagine.Controls.Add(Me.cmdEliminaPic)
        Me.pnlImmagine.Controls.Add(Me.lblInfoPIC)
        Me.pnlImmagine.Controls.Add(Me.cmdChiudPImm)
        Me.pnlImmagine.Controls.Add(Me.picImmagine)
        Me.pnlImmagine.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlImmagine.Location = New System.Drawing.Point(403, 29)
        Me.pnlImmagine.Name = "pnlImmagine"
        Me.pnlImmagine.Size = New System.Drawing.Size(443, 390)
        Me.pnlImmagine.TabIndex = 39
        '
        'cmdSalva
        '
        Me.cmdSalva.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalva.Location = New System.Drawing.Point(382, 341)
        Me.cmdSalva.Name = "cmdSalva"
        Me.cmdSalva.Size = New System.Drawing.Size(27, 23)
        Me.cmdSalva.TabIndex = 43
        Me.cmdSalva.Text = "S"
        Me.cmdSalva.UseVisualStyleBackColor = True
        '
        'lblNomeImmNascosto
        '
        Me.lblNomeImmNascosto.BackColor = System.Drawing.Color.Transparent
        Me.lblNomeImmNascosto.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeImmNascosto.Location = New System.Drawing.Point(3, 0)
        Me.lblNomeImmNascosto.Name = "lblNomeImmNascosto"
        Me.lblNomeImmNascosto.Size = New System.Drawing.Size(81, 20)
        Me.lblNomeImmNascosto.TabIndex = 42
        Me.lblNomeImmNascosto.Text = "Artista"
        Me.lblNomeImmNascosto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNomeImmNascosto.Visible = False
        '
        'cmdEliminaPic
        '
        Me.cmdEliminaPic.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminaPic.Location = New System.Drawing.Point(408, 341)
        Me.cmdEliminaPic.Name = "cmdEliminaPic"
        Me.cmdEliminaPic.Size = New System.Drawing.Size(27, 23)
        Me.cmdEliminaPic.TabIndex = 41
        Me.cmdEliminaPic.Text = "D"
        Me.cmdEliminaPic.UseVisualStyleBackColor = True
        '
        'lblInfoPIC
        '
        Me.lblInfoPIC.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoPIC.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoPIC.Location = New System.Drawing.Point(-1, 347)
        Me.lblInfoPIC.Name = "lblInfoPIC"
        Me.lblInfoPIC.Size = New System.Drawing.Size(414, 20)
        Me.lblInfoPIC.TabIndex = 40
        Me.lblInfoPIC.Text = "Artista"
        Me.lblInfoPIC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdChiudPImm
        '
        Me.cmdChiudPImm.BackColor = System.Drawing.Color.Red
        Me.cmdChiudPImm.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdChiudPImm.ForeColor = System.Drawing.Color.White
        Me.cmdChiudPImm.Location = New System.Drawing.Point(412, 3)
        Me.cmdChiudPImm.Name = "cmdChiudPImm"
        Me.cmdChiudPImm.Size = New System.Drawing.Size(23, 23)
        Me.cmdChiudPImm.TabIndex = 39
        Me.cmdChiudPImm.Text = "X"
        Me.cmdChiudPImm.UseVisualStyleBackColor = False
        '
        'picImmagine
        '
        Me.picImmagine.Location = New System.Drawing.Point(15, 17)
        Me.picImmagine.Name = "picImmagine"
        Me.picImmagine.Size = New System.Drawing.Size(410, 334)
        Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImmagine.TabIndex = 0
        Me.picImmagine.TabStop = False
        '
        'pnlAzioni
        '
        Me.pnlAzioni.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlAzioni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAzioni.Controls.Add(Me.cmdChiudeAzioni)
        Me.pnlAzioni.Controls.Add(Me.lblTipologia)
        Me.pnlAzioni.Controls.Add(Me.lblSelezione)
        Me.pnlAzioni.Controls.Add(Me.cmdRinomina)
        Me.pnlAzioni.Controls.Add(Me.cmdCancella)
        Me.pnlAzioni.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAzioni.Location = New System.Drawing.Point(258, 385)
        Me.pnlAzioni.Name = "pnlAzioni"
        Me.pnlAzioni.Size = New System.Drawing.Size(190, 94)
        Me.pnlAzioni.TabIndex = 40
        Me.pnlAzioni.Visible = False
        '
        'cmdChiudeAzioni
        '
        Me.cmdChiudeAzioni.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChiudeAzioni.Location = New System.Drawing.Point(4, 64)
        Me.cmdChiudeAzioni.Name = "cmdChiudeAzioni"
        Me.cmdChiudeAzioni.Size = New System.Drawing.Size(181, 23)
        Me.cmdChiudeAzioni.TabIndex = 4
        Me.cmdChiudeAzioni.Text = "Annulla"
        Me.cmdChiudeAzioni.UseVisualStyleBackColor = True
        '
        'lblTipologia
        '
        Me.lblTipologia.AutoSize = True
        Me.lblTipologia.Location = New System.Drawing.Point(128, 49)
        Me.lblTipologia.Name = "lblTipologia"
        Me.lblTipologia.Size = New System.Drawing.Size(56, 20)
        Me.lblTipologia.TabIndex = 3
        Me.lblTipologia.Text = "Label11"
        Me.lblTipologia.Visible = False
        '
        'lblSelezione
        '
        Me.lblSelezione.AutoSize = True
        Me.lblSelezione.Location = New System.Drawing.Point(3, 49)
        Me.lblSelezione.Name = "lblSelezione"
        Me.lblSelezione.Size = New System.Drawing.Size(56, 20)
        Me.lblSelezione.TabIndex = 2
        Me.lblSelezione.Text = "Label11"
        Me.lblSelezione.Visible = False
        '
        'cmdRinomina
        '
        Me.cmdRinomina.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRinomina.Location = New System.Drawing.Point(3, 31)
        Me.cmdRinomina.Name = "cmdRinomina"
        Me.cmdRinomina.Size = New System.Drawing.Size(181, 23)
        Me.cmdRinomina.TabIndex = 1
        Me.cmdRinomina.Text = "Rinomina"
        Me.cmdRinomina.UseVisualStyleBackColor = True
        '
        'cmdCancella
        '
        Me.cmdCancella.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancella.Location = New System.Drawing.Point(4, 4)
        Me.cmdCancella.Name = "cmdCancella"
        Me.cmdCancella.Size = New System.Drawing.Size(181, 23)
        Me.cmdCancella.TabIndex = 0
        Me.cmdCancella.Text = "Elimina"
        Me.cmdCancella.UseVisualStyleBackColor = True
        '
        'cmdConverteMP3
        '
        Me.cmdConverteMP3.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConverteMP3.Location = New System.Drawing.Point(463, 0)
        Me.cmdConverteMP3.Name = "cmdConverteMP3"
        Me.cmdConverteMP3.Size = New System.Drawing.Size(99, 23)
        Me.cmdConverteMP3.TabIndex = 41
        Me.cmdConverteMP3.Text = "Converte MP3"
        Me.cmdConverteMP3.UseVisualStyleBackColor = True
        '
        'frmConTAG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1145, 649)
        Me.Controls.Add(Me.cmdConverteMP3)
        Me.Controls.Add(Me.pnlImmagine)
        Me.Controls.Add(Me.pnlAzioni)
        Me.Controls.Add(Me.pnlScelta)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdEliminaTesto)
        Me.Controls.Add(Me.lstTesto)
        Me.Controls.Add(Me.pnlImmagini)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstCanzone)
        Me.Controls.Add(Me.lstAlbum)
        Me.Controls.Add(Me.lstArtista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConTAG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MP3 Con TAG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlStelle.ResumeLayout(False)
        CType(Me.picStelle7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStelle6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStelle1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStelle2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStelle3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStelle4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picStelle5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImmagineMP3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScelta.ResumeLayout(False)
        Me.pnlScelta.PerformLayout()
        Me.pnlImmagini.ResumeLayout(False)
        Me.pnlImmagine.ResumeLayout(False)
        CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAzioni.ResumeLayout(False)
        Me.pnlAzioni.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstArtista As System.Windows.Forms.ListBox
    Friend WithEvents lstAlbum As System.Windows.Forms.ListBox
    Friend WithEvents lstCanzone As System.Windows.Forms.ListBox
    Friend WithEvents lblDirFile As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTitolo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTraccia As System.Windows.Forms.TextBox
    Friend WithEvents txtAnno As System.Windows.Forms.TextBox
    Friend WithEvents txtArtista As System.Windows.Forms.TextBox
    Friend WithEvents txtAlbum As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNomeFile As System.Windows.Forms.Label
    Friend WithEvents cmdImposta As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents picImmagineMP3 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlScelta As System.Windows.Forms.Panel
    Friend WithEvents cmdImpostaAlbum As System.Windows.Forms.Button
    Friend WithEvents cmdImpostaImmagine As System.Windows.Forms.Button
    Friend WithEvents cmdChiudePannello As System.Windows.Forms.Button
    Friend WithEvents cmdElimina As System.Windows.Forms.Button
    Friend WithEvents cmdDownload As System.Windows.Forms.Button
    Friend WithEvents pnlImmagini As System.Windows.Forms.Panel
    Friend WithEvents cmdChiudePnlImmagini As System.Windows.Forms.Button
    Friend WithEvents chkNomeAlbum As System.Windows.Forms.CheckBox
    Friend WithEvents chkArtista As System.Windows.Forms.CheckBox
    Friend WithEvents lstTesto As System.Windows.Forms.ListBox
    Friend WithEvents cmdEliminaTesto As System.Windows.Forms.Button
    Friend WithEvents cmdDownloadImmArtista As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlImms As System.Windows.Forms.Panel
    Friend WithEvents pnlImmagine As System.Windows.Forms.Panel
    Friend WithEvents picImmagine As System.Windows.Forms.PictureBox
    Friend WithEvents cmdChiudPImm As System.Windows.Forms.Button
    Friend WithEvents lblInfoPIC As System.Windows.Forms.Label
    Friend WithEvents cmdEliminaPic As System.Windows.Forms.Button
    Friend WithEvents lblNomeImmNascosto As System.Windows.Forms.Label
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents pnlAzioni As System.Windows.Forms.Panel
    Friend WithEvents cmdRinomina As System.Windows.Forms.Button
    Friend WithEvents cmdCancella As System.Windows.Forms.Button
    Friend WithEvents lblSelezione As System.Windows.Forms.Label
    Friend WithEvents lblTipologia As System.Windows.Forms.Label
    Friend WithEvents cmdChiudeAzioni As System.Windows.Forms.Button
    Friend WithEvents pnlStelle As System.Windows.Forms.Panel
    Friend WithEvents picStelle7 As System.Windows.Forms.PictureBox
    Friend WithEvents picStelle6 As System.Windows.Forms.PictureBox
    Friend WithEvents picStelle1 As System.Windows.Forms.PictureBox
    Friend WithEvents picStelle2 As System.Windows.Forms.PictureBox
    Friend WithEvents picStelle3 As System.Windows.Forms.PictureBox
    Friend WithEvents picStelle4 As System.Windows.Forms.PictureBox
    Friend WithEvents picStelle5 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdConverteMP3 As System.Windows.Forms.Button
End Class
