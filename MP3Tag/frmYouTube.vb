Imports System.Threading

Public Class frmYouTube
	Private staDentroLista As Boolean = False
	Private tmrChiusura As System.Timers.Timer = Nothing
	Private PartitoTimer As Boolean = False
	Private trdYT As Thread
	Private trdYTC As Thread
	Private videos As String = ""

	Private Delegate Sub DelegateAddText(ByVal str As String)
	Private MethodDelegateAddVideoToList As New DelegateAddText(AddressOf AddVideoToList)
	Private MethodDelegateAddVideoToListHidden As New DelegateAddText(AddressOf AddVideoToListHidden)
	Private MethodDelegateImpostaVisibilitaPannello As New DelegateAddText(AddressOf ImpostaVisibilitaPannello)
	Private MethodDelegatePlayVideo As New DelegateAddText(AddressOf PlayVideo)
	Private MethodDelegateImpostaVideo As New DelegateAddText(AddressOf ImpostaVideo)

	Private refreshVideo As String = "N"
	Private videoEsistente As String = ""
	Private staSuonando As Boolean = False
	Private videoDaCaricare As String = ""

	Private dimeX As Integer = 0
	Private dimeY As Integer = 0
	Private codiceVideo As String = ""

	Private Sub AddVideoToList(ByVal str As String)
		lstVideo.Items.Add(str)
	End Sub

	Private Sub AddVideoToListHidden(ByVal str As String)
		lstVideoCompleto.Items.Add(str)
	End Sub

	Private Sub PlayVideo(ByVal str As String)
		videoDaCaricare = str
		CaricaFisicamenteVideo()
	End Sub

	Public Sub ImpostaVideo(ByVal str As String)
		codiceVideo = str

		If str = "" Then
			'AxWindowsMediaPlayer1.Ctlcontrols.stop()
			'AxWindowsMediaPlayer1.currentPlaylist.clear()
		Else
			'AxWindowsMediaPlayer1.URL = str
			'AxWindowsMediaPlayer1.settings.mute = True
			If staSuonando Then
				'AxWindowsMediaPlayer1.Ctlcontrols.play()
				CreaVideoEGestiscilo("S")
			Else
				'AxWindowsMediaPlayer1.Ctlcontrols.stop()
				CreaVideoEGestiscilo("N")
			End If
		End If

		'Dim html As String = "<html><head>"
		'html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>"
		'html &= "<iframe id='video' src= '" & str & "' width='100%' height='100%' frameborder='0' allowfullscreen></iframe>"
		'html &= "</body></html>"
	End Sub

	Private Sub CreaVideoEGestiscilo(play As String)
		dimeX = Me.Size.Width - 40
		dimeY = Me.Size.Height - 60

		Dim html As String = "<html><head>"
		If codiceVideo = "" Then
			html &= "</head><body style='width: 90%; height: 90%;'>"
			html &= "</body></html>"
		Else
			Dim autoPlay As String = IIf(play = "S", "1", "0")
			html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>"
			html &= "</head><body style='width: 900%; height: 90%;'>"
			html &= "<iframe id='video' src= 'https://www.youtube.com/embed/{0}?rel=0&autoplay=" & autoPlay & "' width='" & dimeX & "px' height='" & dimeY & "px' frameborder='0' allowfullscreen volume='0'></iframe>"
			html &= "</body></html>"
		End If
		WebBrowser1.DocumentText = String.Format(html, codiceVideo)
	End Sub

	Public Sub ImpostaStaSuonando(Suona As Boolean)
		staSuonando = Suona

		If staSuonando Then
			'If AxWindowsMediaPlayer1.URL <> "" Then
			' AxWindowsMediaPlayer1.Ctlcontrols.play()
			If lstVideoCompleto.Items.Count > 0 Then
				Dim videoCompleto() As String = lstVideoCompleto.Items(0).Split("§")
				videoCompleto(0) = Mid(videoCompleto(0), videoCompleto(0).IndexOf("=") + 2, videoCompleto(0).Length)
				codiceVideo = videoCompleto(0)
			Else
				codiceVideo = ""
			End If

			CreaVideoEGestiscilo("S")
			'End If
		Else
			'If AxWindowsMediaPlayer1.URL <> "" Then
			' AxWindowsMediaPlayer1.Ctlcontrols.pause()
			CreaVideoEGestiscilo("N")
			'End If
		End If
	End Sub

	Private Sub ImpostaVisibilitaPannello(ByVal str As String)
		Dim s As Boolean = False

		If str = "true" Then
			s = True
		End If

		pnlCaricamento.Visible = s

		If s Then
			'AxWindowsMediaPlayer1.Ctlcontrols.stop()
			'AxWindowsMediaPlayer1.close()
			'AxWindowsMediaPlayer1.URL = ""
			codiceVideo = ""
			CreaVideoEGestiscilo("")

			pnlGestione.Enabled = False
		Else
			pnlGestione.Enabled = True
		End If
	End Sub

	Private Sub frmYouTube_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		pnlGestione.Width = 8
	End Sub

	Private Sub SalvaPosizioni()
		SaveSetting("MP3Tag", "Impostazioni", "PosXYouTube", Me.Left)
		SaveSetting("MP3Tag", "Impostazioni", "PosYYouTube", Me.Top)
		SaveSetting("MP3Tag", "Impostazioni", "WidthXYouTube", Me.Width)
		SaveSetting("MP3Tag", "Impostazioni", "WidthYYouTube", Me.Height)
	End Sub

	Private Sub frmYouTube_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
		SalvaPosizioni()
	End Sub

	Private Sub frmYouTube_Move(sender As Object, e As EventArgs) Handles Me.Move
		SalvaPosizioni()
	End Sub

	Private Sub frmYouTube_Closed(sender As Object, e As EventArgs) Handles Me.Closed
		frmPlayer.ImpostaYouTubeVisibile(False)
	End Sub

	Public Sub RitornaVideo()
		lstVideo.Items.Clear()
		lstVideoCompleto.Items.Clear()
		pnlCaricamento.Visible = True

		'AxWindowsMediaPlayer1.Ctlcontrols.stop()
		'AxWindowsMediaPlayer1.close()
		'AxWindowsMediaPlayer1.URL = ""
		codiceVideo = ""
		CreaVideoEGestiscilo("")

		If Not trdYT Is Nothing Then
			trdYT.Abort()
			trdYT = Nothing
		End If

		videos = ""

		trdYT = New Thread(New ThreadStart(AddressOf CaricaVideoYouTubeThread))
		trdYT.IsBackground = True
		trdYT.Start()

		'trdYT.Join()
		'While trdYT.IsAlive

		'End While
		'RiempieListaVideo(videos)
	End Sub

	Private Sub CaricaVideoYouTubeThread()
		Dim ws As New wsLooWebPlayerII.wsLWPSoapClient

		'Try
		Dim nome As StrutturaCanzone.StrutturaBrano = StrutturaDati.DettaglioBrani(StrutturaDati.QualeCanzoneStaSuonando)
		'MsgBox(nome.Artista & ": " & nome.Canzone)
		If nome.Artista <> "" And Not nome.Artista.ToUpper.Contains("3MICA") And Not nome.Artista.ToUpper.Contains("3ANGELICA") Then
			Try
				If nome.Canzone.Contains("(") Then
					nome.Canzone = Mid(nome.Canzone, 1, nome.Canzone.IndexOf("(")).Trim
				End If

				videos = ws.RitornaYouTube(nome.Artista, nome.Canzone, refreshVideo)
			Catch ex As Exception

			End Try
		End If
		'Catch ex As Exception

		'End Try

		refreshVideo = "N"

		RiempieListaVideo(videos)

		'If videoEsistente <> "" Then
		Dim v() As String = videos.Split("§")
		If v.Length > 0 Then
			videoEsistente = v(0)
			If Me.InvokeRequired Then
				Me.Invoke(MethodDelegatePlayVideo, videoEsistente)
			Else
				PlayVideo(videoEsistente)
			End If
		End If
		'End If

		If Me.InvokeRequired Then
			Me.Invoke(MethodDelegateImpostaVisibilitaPannello, "False")
		Else
			Me.pnlCaricamento.Visible = False
		End If
	End Sub

	Private Sub RiempieListaVideo(Lista As String)
		Try
			If Lista <> "" And Not Lista.Contains("ERROR:") Then
				Dim Video() As String = Lista.Split("§")
				videoEsistente = ""

				For Each v As String In Video
					If v <> "" Then
						Dim vvv() As String = v.Split(";")
						Dim vv As String = vvv(1)
						Dim prefisso As String = vvv(3)
						Dim esiste As String = vvv(4)
						Dim sEsiste As String = ""

						If esiste = "S" Then
							sEsiste = "* "
						End If

						If Me.InvokeRequired Then
							Me.Invoke(MethodDelegateAddVideoToList, sEsiste & vv)
						Else
							Me.lstVideo.Items.Add(sEsiste & vv)
						End If

						If Me.InvokeRequired Then
							Me.Invoke(MethodDelegateAddVideoToListHidden, vvv(0) & "§" & vv & "§" & vvv(2) & "§" & prefisso)
						Else
							Me.lstVideoCompleto.Items.Add(vvv(0) & "§" & vv & "§" & vvv(2) & "§" & prefisso)
						End If

						If esiste = "S" And videoEsistente = "" Then
							videoEsistente = vvv(0) & "§" & vv & "§" & vvv(2) & "§" & prefisso
						End If
					End If
				Next
			End If
		Catch ex As Exception

		End Try
	End Sub

	Private Sub CaricaFisicamenteVideo()
		If videoDaCaricare = "" Then
			Return
		End If

		If Not trdYTC Is Nothing Then
			trdYTC.Abort()
			trdYTC = Nothing
		End If

		trdYTC = New Thread(New ThreadStart(AddressOf CaricaFisicamenteVideo2))
		trdYTC.IsBackground = True
		trdYTC.Start()
	End Sub

	Private Sub CaricaFisicamenteVideo2()
		Dim videoCompleto() As String = videoDaCaricare.Split("§")
		'Dim ws As New wsLooWebPlayerII.wsLWPSoapClient
		videoCompleto(0) = Mid(videoCompleto(0), videoCompleto(0).IndexOf("=") + 2, videoCompleto(0).Length)
		'Dim ritorno As String = ws.ScaricaVideoYouTube(videoCompleto(3), videoCompleto(0), videoCompleto(2))
		'If ritorno = "*" Then
		'Dim primaLettera As String = Mid(videoCompleto(0).Trim, 1, 1).ToUpper
		' Dim pathUrl As String = "http://192.168.0.227:97/YouTube/" & primaLettera & "/" & videoCompleto(0) & videoCompleto(2)
		Dim pathUrl As String = videoCompleto(0)

		If Me.InvokeRequired Then
				Me.Invoke(MethodDelegateImpostaVideo, pathUrl)
			Else
				ImpostaVideo(pathUrl)
			End If
		'Else
		'	MsgBox(ritorno)
		'End If
	End Sub

	Private Sub btnApriChiudi_Click(sender As Object, e As EventArgs) Handles btnApriChiudi.Click
		pnlGestione.Width = 8
	End Sub

	Private Sub pnlGestione_MouseEnter(sender As Object, e As EventArgs) Handles pnlGestione.MouseEnter
		If pnlGestione.Width = 8 Then
			pnlGestione.Width = 200
		End If
	End Sub

	Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
		If pnlCaricamento.Visible Then
			Exit Sub
		End If

		If lstVideo.Text = "" Then
			MsgBox("Selezionare un video")
			Exit Sub
		End If

		Dim video As String = lstVideo.Text.Replace("* ", "")
		For Each v As String In lstVideoCompleto.Items
			If v.Contains(video) Then
				Dim videoCompleto() As String = v.Split("§")
				videoCompleto(0) = Mid(videoCompleto(0), videoCompleto(0).IndexOf("=") + 2, videoCompleto(0).Length)

				'AxWindowsMediaPlayer1.Ctlcontrols.stop()
				'AxWindowsMediaPlayer1.close()
				'AxWindowsMediaPlayer1.URL = ""
				codiceVideo = ""
				CreaVideoEGestiscilo("")

				pnlCaricamento.Visible = True
				Application.DoEvents()

				Dim ws As New wsLooWebPlayerII.wsLWPSoapClient
				ws.EliminaVideoYouTube(videoCompleto(0), videoCompleto(2))

				pnlCaricamento.Visible = False

				lstVideo.Items.Remove(video)
				lstVideoCompleto.Items.Remove(v)
				Exit For
			End If
		Next

	End Sub

	Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
		refreshVideo = "S"
		RitornaVideo()
	End Sub

	Private Sub lstVideo_DoubleClick(sender As Object, e As EventArgs) Handles lstVideo.DoubleClick
		If pnlCaricamento.Visible Then
			Exit Sub
		End If
		'4MF3miZCFBQ .mp4

		pnlGestione.Width = 8
		Dim video As String = lstVideo.Text.Replace("* ", "")
		For Each v As String In lstVideoCompleto.Items
			If v.Contains(video) Then
				pnlCaricamento.Visible = True
				Application.DoEvents()

				videoDaCaricare = v
				' https://www.youtube.com/watch?v=-5-CwpSfyRE§Moonsun The lake 1§.mp4§v
				CaricaFisicamenteVideo()

				pnlCaricamento.Visible = False
				Exit For
			End If
		Next
	End Sub

End Class