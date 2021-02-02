Imports System.Data.SqlClient
Public Class Form1
    Private dt As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try

            Dim vp As New vPersonal
            Dim fp As New fPersonal

            'vp.gcodigo = TextBox1.Text
            vp.gnombre = TextBox2.Text
            vp.gapellidos = TextBox3.Text
            vp.gdireccion = TextBox4.Text
            vp.gtelefono = TextBox5.Text
            vp.gdni = TextBox6.Text
            If fp.insertar(vp) Then
                MessageBox.Show("personal guardado correctamente", "guardando registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("error al intentar guardar personal", "guardando registro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            mostrar()
            limpiar()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MsgBox("desea eliminar el registro", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim vp As New vPersonal
            Dim fp As New fPersonal
            vp.gcodigo = CInt(TextBox1.Text)
            If fp.eliminar(vp) Then
                MsgBox("eliminado")
                mostrar()
            Else
                MessageBox.Show("cancelando eliminacion de registros", "eliminando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mostrar()
            End If
            limpiar()
        Else
            MsgBox("El registro no ha sido eliminado")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As DialogResult
        result = MessageBox.Show("Realmente desea modificar los datos del cliente?", "Modificado registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Dim vp As New vPersonal
                Dim fp As New fPersonal

                vp.gcodigo = TextBox1.Text
                vp.gnombre = TextBox2.Text
                vp.gapellidos = TextBox3.Text
                vp.gdireccion = TextBox4.Text
                vp.gtelefono = TextBox5.Text
                vp.gdni = TextBox6.Text
                If fp.editar(vp) Then
                    MessageBox.Show("personal modificado correctamente", "modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    mostrar()
                    limpiar()
                Else
                    MessageBox.Show("error al modificar ", "modificamos registro", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try
        Else
            MessageBox.Show("no se ha modificado el producto", "modificando registros", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mostrar()

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            DataGridView1.Rows(e.RowIndex).Selected = True

        Catch ex As Exception

        End Try
        TextBox1.Text = DataGridView1.SelectedCells.Item(0).Value
        TextBox2.Text = DataGridView1.SelectedCells.Item(1).Value
        TextBox3.Text = DataGridView1.SelectedCells.Item(2).Value
        TextBox4.Text = DataGridView1.SelectedCells.Item(3).Value
        TextBox5.Text = DataGridView1.SelectedCells.Item(4).Value

        TextBox6.Text = DataGridView1.SelectedCells.Item(5).Value
    End Sub



    Private Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        TextBox1.Focus()
        MessageBox.Show("limpiado")


    End Sub

    Private Sub mostrar()

        Dim fp As New fpersonal
        Try


            dt = fp.mostrar
            If dt.Rows.Count <> 0 Then
                DataGridView1.DataSource = dt

                DataGridView1.ColumnHeadersVisible = True
                DataGridView1.AutoResizeColumns()

            Else
                DataGridView1.DataSource = Nothing
                DataGridView1.ColumnHeadersVisible = True

            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'buscar()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()

    End Sub
End Class
