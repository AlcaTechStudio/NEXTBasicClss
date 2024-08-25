Imports System.Drawing
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.CompilerServices
Imports System.Text

Module System_Commons

    Public Class Buffer_Entrada_codigo_fonte_S
        Public nome As String   'Nome do Arquivo
        Public caminho As String ' File path do arquivo a ser compilado
        Public cd_lido As Boolean '
        Public codigo As StringBuilder 'String contendo o codigo a ser compilado
        Public modificadores As List(Of String) 'Modificações a aplicar no codigo
    End Class

    Public Class Identificadores_NextBasic
        ' Variaveis simples/Matrizes
        Public Variaveis_Globais As New List(Of identificador_S)
        Public Variaveis_Locais As New List(Of identificador_S)
        'Structure
        Public Definicao_Estruturas As New List(Of identificador_S)
        Public Estruturas As New List(Of identificador_S)
        ' Codigo
        Public Funcoes As New List(Of identificador_S)
        Public Subrotinas As New List(Of identificador_S)
        'Labels
        Public Labels_Globais As New List(Of identificador_S)
        Public Alias_Equal As New List(Of identificador_S)

    End Class



    'TODO -> Terminar essa estrutura
    Public Class identificador_S
        Public ReadOnly id As String            'ID/Nome do Identificador
        Public ReadOnly usado As Boolean        'Se foi referenciado no codigo (remover identificadores não usados?)
        Public ReadOnly endereco As String      'Constante Contendo o Endereço do Identificador
        Public ReadOnly valor_inicial As String 'Valor inicializado?
        Public ReadOnly tipo_dados As Integer   'Tamanho do Data Type (inteiro referencia no array tipo_de_Dados_String())
        Public ReadOnly tamanho_em_bytes As Integer ' Util para matriz/matriz indexada???
        Public ReadOnly Tipo_Identificador As Integer 'Tipo do identificador (inteiro referencia no array Tipo_Identificador_String() )
        Public ReadOnly Diretiva_Compilacao As String 'Diretiva de compilacao
        'Matrix
        Public ReadOnly N_elementos As UInt32
        ' Funções e Estruturas
        Public ReadOnly parametros_id As List(Of String)
        Public ReadOnly parametros_data_type As List(Of String)
        Public ReadOnly is_pointer As List(Of Boolean)
        Public ReadOnly Valor_Retorno As Integer

        Public Sub New(ByVal id As String, ByVal data_type As Integer, ByVal nelementos As Integer, ByVal inicializador As String, ByVal inicializador_tm_bytes As Integer, ByVal addr As String) 'Variavel x Matriz
            Me.id = id
            Me.tipo_dados = data_type
            Me.N_elementos = nelementos
            Me.tamanho_em_bytes = tipo_de_Dados_em_bytes(data_type) * nelementos
            Me.endereco = If(String.IsNullOrEmpty(addr), id, addr)
            Me.valor_inicial = inicializador
            Me.usado = False
        End Sub
        Public Function get_id() As UInt32
            Return Me.id
        End Function
        Public Function get_tipo_Dados() As UInt32
            Return Me.tipo_dados
        End Function

    End Class
    Public Function Pega_linha_source_file(ByVal linha As Int32, ByRef caminho As String) As String

        Dim src_l As String = System.IO.File.ReadAllLines(caminho)(linha)
        Return "Linha ..::" & src_l & " ::.. no arquivo  """ & caminho & ":" & Convert.ToString(linha) & """" & System.Environment.NewLine

    End Function

    Public Function e_indentificador_declarado(ByRef n_ind As String) As identificador_S

        For Each item As identificador_S In Identificadores_Construcao.Variaveis_Globais
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Variaveis_Locais
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Funcoes
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Subrotinas
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Estruturas
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Definicao_Estruturas
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Labels_Globais
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next
        For Each item As identificador_S In Identificadores_Construcao.Alias_Equal
            If String.Compare(item.id, n_ind, True) = 0 Then Return item
        Next

        Return Nothing

    End Function

    Public Function declarar_variavel(ByRef id As String, ByVal tipo As Integer, ByVal tamanho_array As Integer, ByVal E_global As Boolean, ByRef inicializador As String, ByVal tam_inicializador As Integer, ByRef addr As String) As String

        Dim Nova_var As identificador_S = e_indentificador_declarado(id)

        If Not (IsNothing(Nova_var)) Then
            Return "Erro: Redefinição de Identificador """ & id & """ como variavel " & If(E_global, "Global", "Local") & ", identificador declarado originalmente como " & Tipo_Identificador_String(Nova_var.Tipo_Identificador)
        End If

        If E_global Then
            Identificadores_Construcao.Variaveis_Globais.Add(New identificador_S(id, tipo, tamanho_array, inicializador, tam_inicializador, addr))
            adc_meta(_dec_var, tipo, "_global_" & id, tamanho_array, addr)
            Debug_Write_Line("Var Globa = " & id & " como " & tipo_de_Dados_String(tipo))
        Else
            Identificadores_Construcao.Variaveis_Locais.Add(New identificador_S(id, tipo, tamanho_array, inicializador, tam_inicializador, addr))
            adc_meta(_dec_var, tipo, "_local_" & id, tamanho_array, addr)
            Debug_Write_Line("Var Local = :" & id & " como " & tipo_de_Dados_String(tipo))
        End If

        Return ""
    End Function

    Public Function declarar_label(ByRef id As String) As String

        Dim Nova_Label As identificador_S = e_indentificador_declarado(id)

        If Not (IsNothing(Nova_Label)) Then
            Return "Erro: Redefinição de Identificador """ & id & """ como Label" & ", identificador declarado originalmente como " & Tipo_Identificador_String(Nova_Label.Tipo_Identificador)
        End If

        Identificadores_Construcao.Labels_Globais.Add(New identificador_S(id, Data_type_ulong, 1, "", 0, ""))
        Debug_Write_Line("Label = :" & id)
        Return ""
    End Function


End Module
