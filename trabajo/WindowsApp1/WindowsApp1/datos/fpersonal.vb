Imports System.Data.SqlClient
Public Class fpersonal

    Inherits conexion
    Dim cmd As New SqlCommand
    Public Function mostrar() As DataTable
        Try
            conectado()

            cmd = New SqlCommand("mostrar_personal")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cm
            If cmd.ExecuteNonQuery Then
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(cmd)
                da.Fill(dt)
                Return dt
            Else
                Return Nothing


            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            desconectado()
        End Try
    End Function
    Public Function insertar(ByVal vp As vpersonal) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("insertar_personal")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cm

            'cmd.Parameters.AddWithValue("@codigo", vp.gcodigo)
            cmd.Parameters.AddWithValue("@nombre", vp.gnombre)
            cmd.Parameters.AddWithValue("@apellidos", vp.gapellidos)
            cmd.Parameters.AddWithValue("@direccion", vp.gdireccion)
            cmd.Parameters.AddWithValue("@telefono", vp.gtelefono)
            cmd.Parameters.AddWithValue("@dni", vp.gdni)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try

    End Function
    Public Function eliminar(ByVal vp As vpersonal) As Boolean
        Try
            conectado()
            cmd = New SqlCommand("eliminar_personal")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cm
            cmd.Parameters.Add("@codigo", SqlDbType.VarChar, 50).Value = vp.gcodigo
            If cmd.ExecuteNonQuery Then
                Return True
            Else

                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()
        End Try
    End Function

    Public Function editar(ByVal vp As vpersonal) As Boolean
        Try

            conectado()
            cmd = New SqlCommand("Editar_personal")
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cm
            cmd.Parameters.AddWithValue("@codigo", vp.gcodigo)
            cmd.Parameters.AddWithValue("@nombre", vp.gnombre)
            cmd.Parameters.AddWithValue("@apellidos", vp.gapellidos)
            cmd.Parameters.AddWithValue("@direccion", vp.gdireccion)
            cmd.Parameters.AddWithValue("@telefono", vp.gtelefono)
            cmd.Parameters.AddWithValue("@dni", vp.gdni)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            desconectado()

        End Try




    End Function
End Class
