Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Form2
    Dim conex As New SqlConnection("Data Source=DESKTOP-N9ECH2V\SQLEXPRESS;Initial Catalog=personal;Integrated Security=True")
    Dim veces As Integer
    Dim usuario, contraseña As String
    Dim dt As DataTable
    Dim reader As SqlDataReader
    Dim l1 As String
    Dim l2 As String

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqle As New String(CType("Select * from usuarios2 where usuario=@ui", Char()))


        Dim md As New SqlCommand(sqle, conex)
        conex.Open()
        md.Parameters.Add("@ui", SqlDbType.NVarChar).Value = TextBox1.Text
        Dim T As String = CStr(md.ExecuteScalar())
        If Len(T) = 0 Then
            MsgBox("El usuario no existe, vuelva a escribirlo")
            TextBox1.Text = ""
            TextBox2.Text = ""
            conex.Close()
            veces = veces + 1
            If veces = 3 Then
                MsgBox("Se acabo sus oportunidades")

                Form1.ActiveForm.Close()
            End If
        Else
            reader = md.ExecuteReader
            reader.Read()
            l1 = CStr(reader("usuario"))
            l2 = CStr(reader("contraseña"))

            conex.Close()
            If (l2 = TextBox2.Text) Then
                'sw_dni = l3
                ' nivel = l4
                Me.Hide()
                'xnombre_usuario = l1
                Form1.Show()
            Else
                MsgBox("La contraseña es incorrecta")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox1.Focus()
                conex.Close()
                veces = veces + 1
                If veces = 3 Then

                    MsgBox("Se acabo sus oportunidades")

                    Form1.ActiveForm.Close()
                End If
            End If
        End If


    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class