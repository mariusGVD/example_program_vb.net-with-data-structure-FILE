Public Class FuncionsEmpresa

    ' Funció per buscar pel CIF
    ' Empresses es la llista d'empresses
    Public Shared Function cercaCIF(Empresses As List(Of EmpressaDades), query As String)
        ' recorem la llista d'ojectes
        For Each EmpressaDadesObj In Empresses
            ' si he trobat l'empresa buscada pel cif la guardem i la retornem
            If (query = EmpressaDadesObj.getCifE()) Then
                Return EmpressaDadesObj
            End If
        Next

        ' si no troba res no retorna res
        Return Nothing
    End Function

    ' Funció per buscar per la Població
    Public Shared Function cercaPoblacio(Empresses As List(Of EmpressaDades), query As String)
        Dim result As List(Of EmpressaDades)


        For Each EmpressaDadesObj In Empresses
            ' si trobo guardo i retorno
            If (query = EmpressaDadesObj.getPoblacioE()) Then
                Return EmpressaDadesObj
            End If
        Next

        ' si no trobo res retorno la llista buida
        Return result
    End Function


    ' Funció per buscar per la data de repartiment
    Public Shared Function cercaData(Empresses As List(Of EmpressaDades), query As String)
        Dim result As List(Of EmpressaDades)

        For Each EmpressaDadesObj In Empresses
            ' si trobo guardo i retorno
            If (query = EmpressaDadesObj.getDrepartimentE()) Then
                Return EmpressaDadesObj
            End If
        Next

        ' si no trobo retorno buit
        Return result
    End Function
End Class
