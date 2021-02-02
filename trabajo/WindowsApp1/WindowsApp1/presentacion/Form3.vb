Public Class Form3
    Private dt As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("desea exportar los datos mostrados", vbYesNo, "exportar a excel") = vbYes Then
            Dim save As New SaveFileDialog
            save.Filter = "archivos Excel | *.xlsx"
            If save.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Exportar_excel(Me.DataGridView1, save.FileName)
            End If
            MsgBox(" los datos han sido exportado a excel al archivo" & save.FileName)
        End If
    End Sub
    Public Sub Exportar_excel(ByVal dgv As DataGridView, ByVal pth As String)
        Dim xlapp As Object = CreateObject("Excel.Application")

        Dim xlwb As Object = xlapp.WorkBooks.add
        Dim xlws As Object = xlwb.WorkSheets(1)
        For c As Integer = 0 To Me.DataGridView1.Columns.Count - 1
            xlws.cells(1, c + 1).value = DataGridView1.Columns(c).HeaderText
        Next
        For r As Integer = 0 To DataGridView1.RowCount - 1
            For c As Integer = 0 To DataGridView1.Columns.Count - 1
                xlws.cells(r + 2, c + 1).value = DataGridView1.Item(c, r).Value
            Next
        Next
        xlwb.saveas(pth)
        xlws = Nothing
        xlwb = Nothing
        xlapp.quit()
        xlapp = Nothing


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        buscar1()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
    Private Sub buscar1()

        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt.Copy)
            Dim dv As New DataView(ds.Tables(0))

            dv.RowFilter = ComboBox1.Text & " like  '" & TextBox1.Text & "%' "

            If dv.Count <> 0 Then
                DataGridView1.DataSource = dv




            Else
                DataGridView1.DataSource = Nothing
            End If

            'Label.Text = "total registro: " & dv.Count
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

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

End Class