Public Structure EmpressaDades


    ' Inicialitzem les variables del objecte
    Private nomE As String
    Private cifE As String
    Private poblacioE As String
    Private drepartimentE As String

    ' retorna el nom
    Public Function getNomE()
        Return Me.nomE
    End Function

    ' assigna el nom
    Public Function setNomE(nomE As String)
        Me.nomE = nomE

        Return True
    End Function

    Public Function getCifE()
        Return Me.cifE
    End Function

    Public Function setCifE(cifE As String)
        Me.cifE = cifE

        Return True
    End Function

    Public Function getPoblacioE()
        Return Me.poblacioE
    End Function

    Public Function setPoblacioE(poblacioE As String)
        Me.poblacioE = poblacioE

        Return True
    End Function

    Public Function getDrepartimentE()
        Return Me.drepartimentE
    End Function

    Public Function setDrepartimentE(drepartimentE As String)
        Me.drepartimentE = drepartimentE

        Return True
    End Function
End Structure
