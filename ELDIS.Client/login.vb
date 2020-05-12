Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel
Imports ComputerInfo



Public Class login
    Dim conn As MySqlConnection

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            MessageBox.Show("Bitte fülle die Felder aus!")
        Else
            Dim cmd As New MySqlCommand
            conn = New MySqlConnection
            conn.ConnectionString = ("server=" & My.Settings.mysqlserver & " ;userid=" & My.Settings.mysqluser & ";password=" & My.Settings.mysqlpassword & ";database=" & My.Settings.mysqldatabase & "")
            Dim Reader As MySqlDataReader
            Try
                conn.Open()
                Dim query As String
                query = "SELECT * from sis_users where username= '" & UsernameTextBox.Text & "' and password = '" & PasswordTextBox.Text & "'"
                My.Settings.benutzername = UsernameTextBox.Text
                cmd = New MySqlCommand(query, conn)
                Reader = cmd.ExecuteReader

                Dim count As Integer
                count = 0
                While Reader.Read
                    count = count + 1
                End While

                If count = 1 Then

                    Dim usertype = Reader.GetString(4)
                    Dim username = Reader.GetString(1)
                    Dim id = Reader.GetString(0)
                    Dim fraction = Reader.GetString(6)
                    My.Settings.id = id
                    My.Settings.benutzername = username
                    My.Settings.usertype = usertype




                    If usertype = "admin" Then
                        For j = 0 To 500
                        Next
                        My.Settings.usertype = usertype
                        If fraction = "police" Then
                            MsgBox("Du bist Polizist! Kein Feuerwehr'ler.", MsgBoxStyle.Critical)
                        ElseIf fraction = "ambulance" Then
                            MsgBox("Du bist Sanit�ter! Kein Feuerwehr'ler.", MsgBoxStyle.Critical)
                        ElseIf fraction = "fire" Then
                            hauptmenu.Show()
                            Me.Hide()
                        End If
                    ElseIf usertype = "disponent" Then
                        For j = 0 To 500
                        Next
                        My.Settings.usertype = usertype
                        If fraction = "police" Then
                            MsgBox("Du bist Polizist! Kein Feuerwehr'ler.", MsgBoxStyle.Critical)
                        ElseIf fraction = "ambulance" Then
                            MsgBox("Du bist Sanitäter! Kein Feuerwehr'ler.", MsgBoxStyle.Critical)
                        ElseIf fraction = "fire" Then
                            hauptmenu.Show()
                            Me.Hide()
                        End If
                    ElseIf usertype = "user" Then
                        For j = 0 To 500
                        Next
                        My.Settings.usertype = usertype
                        If fraction = "police" Then
                            MsgBox("Du bist Polizist! Kein Feuerwehr'ler.", MsgBoxStyle.Critical)
                        ElseIf fraction = "ambulance" Then
                            MsgBox("Du bist Sanitäter! Kein Feuerwehr'ler.", MsgBoxStyle.Critical)
                        ElseIf fraction = "fire" Then
                            hauptmenu.Show()
                            Me.Hide()
                        End If
                    End If

                    conn.Close()

                Else
                    MsgBox("Dein Passwort ODER Benutzername ist falsch.", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
            End Try
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        version.Text = "Version " & Me.GetType.Assembly.GetName.Version.ToString
    End Sub
End Class
