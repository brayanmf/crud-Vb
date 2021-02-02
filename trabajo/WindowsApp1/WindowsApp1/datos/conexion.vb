Imports System.Data.SqlClient
Public Class conexion
    Protected cm As New SqlConnection
    Public idusuario As Integer
    Protected Function conectado()
        Try
            cm = New SqlConnection("Data Source=DESKTOP-N9ECH2V\SQLEXPRESS;Initial Catalog=personal;Integrated Security=True")

            cm.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try


    End Function
    Protected Function desconectado()
        Try
            If cm.State = ConnectionState.Open Then
                cm.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class
