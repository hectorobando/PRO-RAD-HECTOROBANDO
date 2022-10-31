Imports System.Data.SqlClient
Public Class FrmLogin
    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        Dim con As New SqlClient.SqlConnection(My.Settings.ProRad)
        con.Open()
        Dim reader As SqlClient.SqlDataReader
        Dim cmd As New SqlClient.SqlCommand("select * from Usuarios where idusuario = '" & txtusuario.Text & "' and contrasena =  '" & txtcontra.Text & "' ", con)
        reader = cmd.ExecuteReader

        If reader.Read() Then
            If reader.Item("activo") = True Then
                VariablesPublicas.idusuario = reader.Item("idusuario")
                VariablesPublicas.nivelacceso = reader.Item("nivelacceso")
                VariablesPublicas.nombrecompleto = reader.Item("NombreCompleto")
                Me.Dispose()
                FrmMenuPrincipal.ShowDialog()
            Else
                MessageBox.Show("Usuario inactivo")
            End If
        Else
            MessageBox.Show("Usuario o contraseña incorrectos")
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        txtusuario.Clear()
        txtcontra.Clear()
        txtusuario.Focus()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Application.Exit()
    End Sub
End Class