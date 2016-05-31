Imports System.IO
Imports System.Data

' Importem les 2 classes creades amb l'estructura de dades i les funcions per mostrar
Imports SubministramentDeBegudes.EmpressaDades
Imports SubministramentDeBegudes.FuncionsEmpresa

Public Class Form1
    'Marius H

    ' Declaro llista de Empresses
    Dim Empreses As New List(Of EmpressaDades)
    ' inicialitzo la classe amb les funcions per poder treballar 
    Dim FuncionsEmpresa = New FuncionsEmpresa()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Verifiquem si s'han completat tots els camps
        If (String.IsNullOrEmpty(TextBox1.Text) OrElse
            String.IsNullOrEmpty(TextBox2.Text) OrElse
            (String.IsNullOrEmpty(TextBox3.Text))) Then

            MessageBox.Show("Omple tots els camps amb les dades basiques!")
            ' Si els comps no estan complets sortim
        Else
            ' Initializezi un obiect din structura Company
            Dim EmpresaObj As New EmpressaDades

            ' Agafo les dades dels textbox i les guardo en l'objecte
            EmpresaObj.setNomE(TextBox1.Text)
            EmpresaObj.setCifE(TextBox2.Text)
            EmpresaObj.setPoblacioE(TextBox3.Text)
            EmpresaObj.setDrepartimentE(DateTimePicker1.Text)
            Console.WriteLine(FuncionsEmpresa.cercaCIF(Empreses, EmpresaObj.getCifE()))

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            DateTimePicker1.ResetText()

            ' guardo l'objecte en la llista si no forma part ja de la llista

            If (FuncionsEmpresa.cercaCIF(Empreses, EmpresaObj.getCifE()) Is Nothing) Then
                Empreses.Add(EmpresaObj)
            End If

            ' actualitzo els combobox x afegir les dades introduides
            Me.UpdateCIFComboBox(Empreses)
            Me.UpdatePoblacioComboBox(Empreses)
            Me.UpdateDataComboBox(Empreses)

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListView1.Items.Clear()
        Dim EmpresaObj = FuncionsEmpresa.cercaCIF(Empreses, ComboBox1.SelectedItem.ToString())
        If (EmpresaObj IsNot Nothing) Then
            Dim row(2) As String
            row(0) = EmpresaObj.getNomE()
            row(1) = EmpresaObj.getPoblacioE()
            row(2) = EmpresaObj.getDrepartimentE()

            Dim item = New ListViewItem(row)
            ListView1.Items.Add(item)

        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ListView2.Items.Clear()
        Dim EmpresaObj = FuncionsEmpresa.cercaPoblacio(Empreses, ComboBox2.SelectedItem.ToString())
        If (EmpresaObj IsNot Nothing) Then
            Dim row(2) As String
            row(0) = EmpresaObj.getDrepartimentE()
            row(1) = EmpresaObj.getNomE()
            row(2) = EmpresaObj.getCifE()

            Dim item = New ListViewItem(row)
            ListView2.Items.Add(item)
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ListView3.Items.Clear()
        Dim EmpresaObj = FuncionsEmpresa.cercaData(Empreses, ComboBox3.SelectedItem.ToString())
        If (EmpresaObj IsNot Nothing) Then
            Dim row(2) As String
            row(0) = EmpresaObj.getNomE()
            row(1) = EmpresaObj.getCifE()
            row(2) = EmpresaObj.getPoblacioE()

            Dim item = New ListViewItem(row)
            ListView3.Items.Add(item)
        End If
    End Sub




    Private Sub UpdateCIFComboBox(Empreses As List(Of EmpressaDades))
        ComboBox1.Items.Clear()
        For Each EmpresaObj In Empreses
            ComboBox1.Items.Add(EmpresaObj.getCifE())
        Next
    End Sub

    Private Sub UpdatePoblacioComboBox(Empreses As List(Of EmpressaDades))
        ComboBox2.Items.Clear()
        For Each EmpresaObj In Empreses
            ComboBox2.Items.Add(EmpresaObj.getPoblacioE())
        Next
    End Sub

    Private Sub UpdateDataComboBox(Empreses As List(Of EmpressaDades))
        ComboBox3.Items.Clear()
        For Each EmpresaObj In Empreses
            ComboBox3.Items.Add(EmpresaObj.getDrepartimentE())
        Next
    End Sub


    
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Text file|*.txt"
        saveFileDialog1.Title = "Save a text File"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            Dim sw As StreamWriter = New StreamWriter(saveFileDialog1.OpenFile())
            If (sw IsNot Nothing) Then
                For Each EmpressaDadesObj In Empreses
                    Dim linea As String = EmpressaDadesObj.getNomE() + ";" + EmpressaDadesObj.getCifE() + ";" + EmpressaDadesObj.getPoblacioE() + ";" + EmpressaDadesObj.getDrepartimentE()
                    sw.WriteLine(linea)
                Next
            End If
            sw.Close()
        End If
    End Sub
End Class
