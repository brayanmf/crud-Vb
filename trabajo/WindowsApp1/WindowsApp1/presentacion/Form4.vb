Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Public Class Form4
    Dim emisor, password, mensaje, asunto, destinatario, ruta As String
    Private correos As New MailMessage
    Private envios As New SmtpClient
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'mensaje =                 "' & TextBox1.Text & "cliente:" & TextBox2.Text & " fecha: " & TextBox3.Text & " hora: " & TextBox4.Text & " direccion: " & TextBox5.Text & " contacto: " & TextBox6.Text & " telefono " & TextBox7.Text
            mensaje = TextBox3.Text
            asunto = TextBox2.Text
            ' & TextBox16.Text
            destinatario = TextBox1.Text

            emisor =    'usar tu correo '
            password = '"usar contraseña usu" '
            correos.To.Clear()
            correos.Body = ""
            correos.Subject = ""
            correos.Body = mensaje
            correos.Subject = asunto
            correos.IsBodyHtml = True
            correos.To.Add(Trim(destinatario))
            correos.From = New MailAddress(emisor)
            envios.Credentials = New NetworkCredential(emisor, password)
            'Datos importantes no modificables para tener acceso a las cuentas
            envios.Host = "smtp.live.com"
            envios.Port = 25
            envios.EnableSsl = True
            envios.Send(correos)
            MsgBox(" se envio")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensajeria 1.0 vb.net ®", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class