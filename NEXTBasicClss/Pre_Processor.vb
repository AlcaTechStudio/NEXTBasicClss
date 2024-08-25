Imports System.Diagnostics.Eventing
Imports System.IO
Imports GOLD

Module Pre_Processor

    Private buffer_modificadores As New List(Of String)
    Private Global_preprocessor_fail As Boolean
    Private Global_current_reader As Buffer_Entrada_codigo_fonte_S

    Private Structure Preprocessor_Contexto
        Dim Adiciona_Modificadores As Boolean
        Dim Registrar_Statements As Boolean
        Dim Remover_Statemnts_nao_utilizados As Boolean

    End Structure

    Private Preprocessor_ctx As Preprocessor_Contexto


    Public Function preprocessor_Apply(ByRef Reader As Buffer_Entrada_codigo_fonte_S) As Boolean
        Dim apply_ok As Boolean = False







        Return apply_ok
    End Function

    Public Function Preprocessor_Scan(ByRef Reader As Buffer_Entrada_codigo_fonte_S) As Boolean
        'This procedure starts the GOLD Parser Engine and handles each of the
        'messages it returns. Each time a reduction is made, you can create new
        'custom object and reassign the .CurrentReduction property. Otherwise, 
        'the system will use the Reduction object that was returned.
        '
        'The resulting tree will be a pure representation of the language 
        'and will be ready to implement.

        Dim Response As GOLD.ParseMessage
        Dim Done As Boolean                  'Controls when we leave the loop
        Dim Accepted As Boolean = False      'Was the parse successful?


        Parser.Open(Reader.codigo.ToString())
        Parser.TrimReductions = False  'Please read about this feature before enabling  
        buffer_modificadores.Clear()

        Done = False
        Global_preprocessor_fail = False
        Global_current_reader = Reader

        Do Until Done
            Response = Parser.Parse()
            If Global_preprocessor_fail Then Exit Do
            Select Case Response
                Case GOLD.ParseMessage.LexicalError
                    'Cannot recognize token
                    Console.WriteLine("Erro: identificador nao reconhecido: " & Parser.CurrentToken.Data.ToString() & " linha: '" & Parser.CurrentToken.Position.Line & "' Coluna: '" & Parser.CurrentToken.Position.Column & Parser.CurrentToken.Data.ToString() & System.Environment.NewLine)
                    Console.WriteLine(Pega_linha_source_file(Parser.CurrentToken.Position.Line, Reader.caminho))
                    Done = True

                Case GOLD.ParseMessage.SyntaxError
                    'Expecting a different token
                    Console.WriteLine("Erro: Esperando identificador diferente '" & Parser.CurrentToken.Data.ToString() & "' Coluna: ' " & Parser.CurrentToken.Position.Column & " ' " & Parser.CurrentToken.Data.ToString() & System.Environment.NewLine)
                    Console.WriteLine(Pega_linha_source_file(Parser.CurrentToken.Position.Line, Reader.caminho)) '"Linha: " & basic_source_lines(Parser.CurrentToken.Position.Line))
                    Done = True

                Case GOLD.ParseMessage.Reduction
                    'Create a customized object to store the reduction
                    'Dim CurrentReduction As Object = Preprocessor_reduce(Parser.CurrentReduction)

                Case GOLD.ParseMessage.Accept
                    'Accepted!
                    'Program = Parser.CurrentReduction  'The root node!                 
                    Done = True
                    Accepted = True
                    If Parser.CurrentReduction IsNot Nothing Then
                        Try
                            Preprocessor_reduce(Parser.CurrentReduction)
                        Catch ex As Exception
                            Console.WriteLine(ex.ToString())
                        End Try
                    End If
                Case GOLD.ParseMessage.TokenRead
                    'You don't have to do anything here.

                Case GOLD.ParseMessage.InternalError
                    'INTERNAL ERROR! Something is horribly wrong.
                    Console.WriteLine("INTERNAL ERROR! Something is horribly wrong.")
                    Done = True

                Case GOLD.ParseMessage.NotLoadedError
                    'This error occurs if the CGT was not loaded.
                    Console.WriteLine("This error occurs if the CGT was not loaded.")
                    Done = True

                Case GOLD.ParseMessage.GroupError
                    'COMMENT ERROR! Unexpected end of file
                    Console.WriteLine("COMMENT ERROR! Unexpected end of file")
                    Done = True
            End Select
        Loop

        If Accepted Then
            Reader.modificadores = buffer_modificadores
        End If

        Return Accepted
    End Function


    Private Function Preprocessor_reduce(Reduction As GOLD.Reduction) As Object
        Dim Result As Object = Nothing

        With Reduction
            Select Case .Parent.TableIndex
                Case ProductionIndex.Nl_Newline
                    ' <NL> ::= NewLine <NL> 

                Case ProductionIndex.Nl_Newline2
                    ' <NL> ::= NewLine 

                Case ProductionIndex.Nlopt
                    ' <NL Opt> ::= <NL> 

                Case ProductionIndex.Nlopt2
                    ' <NL Opt> ::=  

                Case ProductionIndex.Program
                    ' <Program> ::= <NL Opt> <Program Struct> 

                Case ProductionIndex.Programstruct
                    ' <Program Struct> ::= <NameSpace Item> <Program Struct> 

                Case ProductionIndex.Programstruct2
                    ' <Program Struct> ::= <Imports> <Program Struct> 

                Case ProductionIndex.Programstruct3
                    ' <Program Struct> ::= <Option Decl> <Program Struct> 

                Case ProductionIndex.Programstruct4
                    ' <Program Struct> ::=  

                Case ProductionIndex.Modifiers
                    ' <Modifiers> ::= <Modifier> <Modifiers> 

                Case ProductionIndex.Modifiers2
                    ' <Modifiers> ::=  

                Case ProductionIndex.Modifier_Shadows
                    ' <Modifier> ::= Shadows 

                Case ProductionIndex.Modifier_Shared
                    ' <Modifier> ::= Shared 

                Case ProductionIndex.Modifier_Mustinherit
                    ' <Modifier> ::= MustInherit 

                Case ProductionIndex.Modifier_Notinheritable
                    ' <Modifier> ::= NotInheritable 

                Case ProductionIndex.Modifier_Overridable
                    ' <Modifier> ::= Overridable 

                Case ProductionIndex.Modifier_Notoverridable
                    ' <Modifier> ::= NotOverridable 

                Case ProductionIndex.Modifier_Mustoverride
                    ' <Modifier> ::= MustOverride 

                Case ProductionIndex.Modifier_Overrides
                    ' <Modifier> ::= Overrides 

                Case ProductionIndex.Modifier_Overloads
                    ' <Modifier> ::= Overloads 

                Case ProductionIndex.Modifier_Default
                    ' <Modifier> ::= Default 

                Case ProductionIndex.Modifier_Readonly
                    ' <Modifier> ::= ReadOnly 

                Case ProductionIndex.Modifier_Writeonly
                    ' <Modifier> ::= WriteOnly 

                Case ProductionIndex.Modifier
                    ' <Modifier> ::= <Access> 

                Case ProductionIndex.Access_Public
                    ' <Access> ::= Public 

                Case ProductionIndex.Access_Private
                    ' <Access> ::= Private 

                Case ProductionIndex.Access_Friend
                    ' <Access> ::= Friend 

                Case ProductionIndex.Access_Protected
                    ' <Access> ::= Protected 

                Case ProductionIndex.Varmember
                    ' <Var Member> ::= <Attributes> <Modifiers> <dim opt> <Var Decl> <NL> 

                Case ProductionIndex.Varmember_Const
                    ' <Var Member> ::= <Attributes> <Modifiers> <dim opt> Const <Var Decl> <NL> 

                Case ProductionIndex.Varmember_Static
                    ' <Var Member> ::= <Attributes> <Modifiers> <dim opt> Static <Var Decl> <NL> 

                Case ProductionIndex.Dimopt_Dim
                    ' <dim opt> ::= Dim 

                Case ProductionIndex.Dimopt
                    ' <dim opt> ::=  

                Case ProductionIndex.Implements_Implements
                    ' <Implements> ::= Implements <ID List> 

                Case ProductionIndex.Idlist_Comma
                    ' <ID List> ::= <Identifier> ',' <ID List> 

                Case ProductionIndex.Idlist
                    ' <ID List> ::= <Identifier> 

                Case ProductionIndex.Optiondecl_Option
                    ' <Option Decl> ::= Option <IDs> <NL> 

                Case ProductionIndex.Ids_Id
                    ' <IDs> ::= ID <IDs> 

                Case ProductionIndex.Ids_Id2
                    ' <IDs> ::= ID 

                Case ProductionIndex.Ids_On
                    ' <IDs> ::= On 

                Case ProductionIndex.Ids_Off
                    ' <IDs> ::= Off 

                Case ProductionIndex.Type_As
                    ' <Type> ::= As <Attributes> <Identifier> 

                Case ProductionIndex.Type
                    ' <Type> ::=  

                Case ProductionIndex.Compareop_Eq
                    ' <Compare Op> ::= '=' 

                Case ProductionIndex.Compareop_Ltgt
                    ' <Compare Op> ::= '<>' 

                Case ProductionIndex.Compareop_Lt
                    ' <Compare Op> ::= '<' 

                Case ProductionIndex.Compareop_Gt
                    ' <Compare Op> ::= '>' 

                Case ProductionIndex.Compareop_Gteq
                    ' <Compare Op> ::= '>=' 

                Case ProductionIndex.Compareop_Lteq
                    ' <Compare Op> ::= '<=' 

                Case ProductionIndex.Compareop_Isnot
                    ' <Compare Op> ::= isNot 

                Case ProductionIndex.Namespace_Namespace_Id_End_Namespace
                    ' <NameSpace> ::= NameSpace ID <NL> <NameSpace Items> End NameSpace <NL> 

                Case ProductionIndex.Namespaceitems
                    ' <NameSpace Items> ::= <NameSpace Item> <NameSpace Items> 

                Case ProductionIndex.Namespaceitems2
                    ' <NameSpace Items> ::=  

                Case ProductionIndex.Namespaceitem
                    ' <NameSpace Item> ::= <Class> 

                Case ProductionIndex.Namespaceitem2
                    ' <NameSpace Item> ::= <Declare> 

                Case ProductionIndex.Namespaceitem3
                    ' <NameSpace Item> ::= <Delegate> 

                Case ProductionIndex.Namespaceitem4
                    ' <NameSpace Item> ::= <Enumeration> 

                Case ProductionIndex.Namespaceitem5
                    ' <NameSpace Item> ::= <Interface> 

                Case ProductionIndex.Namespaceitem6
                    ' <NameSpace Item> ::= <Structure> 

                Case ProductionIndex.Namespaceitem7
                    ' <NameSpace Item> ::= <Module> 

                Case ProductionIndex.Namespaceitem8
                    ' <NameSpace Item> ::= <NameSpace> 

                Case ProductionIndex.Attributes_Lt_Gt
                    ' <Attributes> ::= '<' <Attribute List> '>' 

                Case ProductionIndex.Attributes
                    ' <Attributes> ::=  

                Case ProductionIndex.Attributelist_Comma
                    ' <Attribute List> ::= <Attribute> ',' <Attribute List> 

                Case ProductionIndex.Attributelist
                    ' <Attribute List> ::= <Attribute> 

                Case ProductionIndex.Attribute_Id
                    ' <Attribute> ::= <Attribute Mod> ID <Argument List Opt> 

                Case ProductionIndex.Attributemod_Assembly
                    ' <Attribute Mod> ::= Assembly 

                Case ProductionIndex.Attributemod_Module
                    ' <Attribute Mod> ::= Module 

                Case ProductionIndex.Attributemod
                    ' <Attribute Mod> ::=  

                Case ProductionIndex.Delegate_Delegate
                    ' <Delegate> ::= <Attributes> <Modifiers> Delegate <Method> 

                Case ProductionIndex.Delegate_Delegate2
                    ' <Delegate> ::= <Attributes> <Modifiers> Delegate <Declare> 

                Case ProductionIndex.Imports_Imports
                    ' <Imports> ::= Imports <Identifier> <NL> 

                Case ProductionIndex.Imports_Imports_Id_Eq
                    ' <Imports> ::= Imports ID '=' <Identifier> <NL> 

                Case ProductionIndex.Eventmember_Event_Id
                    ' <Event Member> ::= <Attributes> <Modifiers> Event ID <Parameters Or Type> <Implements Opt> <NL> 

                Case ProductionIndex.Parametersortype
                    ' <Parameters Or Type> ::= <Param List> 

                Case ProductionIndex.Parametersortype_As
                    ' <Parameters Or Type> ::= As <Identifier> 

                Case ProductionIndex.Implementsopt
                    ' <Implements Opt> ::= <Implements> 

                Case ProductionIndex.Implementsopt2
                    ' <Implements Opt> ::=  

                Case ProductionIndex.Class_Class_Id_End_Class
                    ' <Class> ::= <Attributes> <Modifiers> Class ID <NL> <Class Items> End Class <NL> 

                Case ProductionIndex.Classitems
                    ' <Class Items> ::= <Class Item> <Class Items> 

                Case ProductionIndex.Classitems2
                    ' <Class Items> ::=  

                Case ProductionIndex.Classitem
                    ' <Class Item> ::= <Declare> 

                Case ProductionIndex.Classitem2
                    ' <Class Item> ::= <Method> 

                Case ProductionIndex.Classitem3
                    ' <Class Item> ::= <Property> 

                Case ProductionIndex.Classitem4
                    ' <Class Item> ::= <Var Member> 

                Case ProductionIndex.Classitem5
                    ' <Class Item> ::= <Enumeration> 

                Case ProductionIndex.Classitem6
                    ' <Class Item> ::= <Inherits> 

                Case ProductionIndex.Classitem7
                    ' <Class Item> ::= <Class Implements> 

                Case ProductionIndex.Inherits_Inherits
                    ' <Inherits> ::= Inherits <Identifier> <NL> 

                Case ProductionIndex.Classimplements_Implements
                    ' <Class Implements> ::= Implements <ID List> <NL> 

                Case ProductionIndex.Structure_Structure_Id_End_Structure
                    ' <Structure> ::= <Attributes> <Modifiers> Structure ID <NL> <Structure List> End Structure <NL> 

                Case ProductionIndex.Structurelist
                    ' <Structure List> ::= <Structure Item> <Structure List> 

                Case ProductionIndex.Structurelist2
                    ' <Structure List> ::=  

                Case ProductionIndex.Structureitem
                    ' <Structure Item> ::= <Implements> 

                Case ProductionIndex.Structureitem2
                    ' <Structure Item> ::= <Enumeration> 

                Case ProductionIndex.Structureitem3
                    ' <Structure Item> ::= <Structure> 

                Case ProductionIndex.Structureitem4
                    ' <Structure Item> ::= <Class> 

                Case ProductionIndex.Structureitem5
                    ' <Structure Item> ::= <Delegate> 

                Case ProductionIndex.Structureitem6
                    ' <Structure Item> ::= <Var Member> 

                Case ProductionIndex.Structureitem7
                    ' <Structure Item> ::= <Event Member> 

                Case ProductionIndex.Structureitem8
                    ' <Structure Item> ::= <Declare> 

                Case ProductionIndex.Structureitem9
                    ' <Structure Item> ::= <Method> 

                Case ProductionIndex.Structureitem10
                    ' <Structure Item> ::= <Property> 

                Case ProductionIndex.Module_Module_Id_End_Module
                    ' <Module> ::= <Attributes> <Modifiers> Module ID <NL> <Module Items> End Module <NL> 

                Case ProductionIndex.Moduleitems
                    ' <Module Items> ::= <Module Item> <Module Items> 

                Case ProductionIndex.Moduleitems2
                    ' <Module Items> ::=  

                Case ProductionIndex.Moduleitem
                    ' <Module Item> ::= <Declare> 

                Case ProductionIndex.Moduleitem2
                    ' <Module Item> ::= <Method> 

                Case ProductionIndex.Moduleitem3
                    ' <Module Item> ::= <Property> 

                Case ProductionIndex.Moduleitem4
                    ' <Module Item> ::= <Var Member> 

                Case ProductionIndex.Moduleitem5
                    ' <Module Item> ::= <Enumeration> 

                Case ProductionIndex.Moduleitem6
                    ' <Module Item> ::= <Option Decl> 

                Case ProductionIndex.Moduleitem7
                    ' <Module Item> ::= <Class> 

                Case ProductionIndex.Moduleitem8
                    ' <Module Item> ::= <Structure> 

                Case ProductionIndex.Interface_Interface_Id_End_Interface
                    ' <Interface> ::= <Attributes> <Modifiers> Interface ID <NL> <Interface Items> End Interface <NL> 

                Case ProductionIndex.Interfaceitems
                    ' <Interface Items> ::= <Interface Item> <Interface Items> 

                Case ProductionIndex.Interfaceitems2
                    ' <Interface Items> ::=  

                Case ProductionIndex.Interfaceitem
                    ' <Interface Item> ::= <Implements> 

                Case ProductionIndex.Interfaceitem2
                    ' <Interface Item> ::= <Event Member> 

                Case ProductionIndex.Interfaceitem3
                    ' <Interface Item> ::= <Enum Member> 

                Case ProductionIndex.Interfaceitem4
                    ' <Interface Item> ::= <Method Member> 

                Case ProductionIndex.Interfaceitem5
                    ' <Interface Item> ::= <Property Member> 

                Case ProductionIndex.Enummember_Enum_Id
                    ' <Enum Member> ::= <Attributes> <Modifiers> Enum ID <NL> 

                Case ProductionIndex.Methodmember_Sub
                    ' <Method Member> ::= <Attributes> <Modifiers> Sub <Sub ID> <Param List> <Handles Or Implements> <NL> 

                Case ProductionIndex.Methodmember_Function_Id
                    ' <Method Member> ::= <Attributes> <Modifiers> Function ID <Param List> <Type> <Handles Or Implements> <NL> 

                Case ProductionIndex.Propertymember_Property_Id
                    ' <Property Member> ::= <Attributes> <Modifiers> Property ID <Param List> <Type> <Handles Or Implements> <NL> 

                Case ProductionIndex.Paramlistopt
                    ' <Param List Opt> ::= <Param List> 

                Case ProductionIndex.Paramlistopt2
                    ' <Param List Opt> ::=  

                Case ProductionIndex.Paramlist_Lparen_Rparen
                    ' <Param List> ::= '(' <Param Items> ')' 

                Case ProductionIndex.Paramlist_Lparen_Rparen2
                    ' <Param List> ::= '(' ')' 

                Case ProductionIndex.Paramitems_Comma
                    ' <Param Items> ::= <Param Item> ',' <Param Items> 

                Case ProductionIndex.Paramitems
                    ' <Param Items> ::= <Param Item> 

                Case ProductionIndex.Paramitem_Id
                    ' <Param Item> ::= <Param Passing> ID <Type> 

                Case ProductionIndex.Parampassing_Byval
                    ' <Param Passing> ::= ByVal 

                Case ProductionIndex.Parampassing_Byref
                    ' <Param Passing> ::= ByRef 

                Case ProductionIndex.Parampassing_Optional
                    ' <Param Passing> ::= Optional 

                Case ProductionIndex.Parampassing_Paramarray
                    ' <Param Passing> ::= ParamArray 

                Case ProductionIndex.Parampassing
                    ' <Param Passing> ::=  

                Case ProductionIndex.Argumentlistopt
                    ' <Argument List Opt> ::= <Argument List> 

                Case ProductionIndex.Argumentlistopt2
                    ' <Argument List Opt> ::= <Argument List> <Argument List> 

                Case ProductionIndex.Argumentlistopt3
                    ' <Argument List Opt> ::=  

                Case ProductionIndex.Argumentlist_Lparen_Rparen
                    ' <Argument List> ::= '(' <Argument Items> ')' 

                Case ProductionIndex.Argumentlist
                    ' <Argument List> ::= <const array> 

                Case ProductionIndex.Argumentitems_Comma
                    ' <Argument Items> ::= <Argument> ',' <Argument Items> 

                Case ProductionIndex.Argumentitems
                    ' <Argument Items> ::= <Argument> 

                Case ProductionIndex.Argument
                    ' <Argument> ::= <Expression> 

                Case ProductionIndex.Argument_Id_Coloneq
                    ' <Argument> ::= ID ':=' <Expression> 

                Case ProductionIndex.Argument2
                    ' <Argument> ::=  

                Case ProductionIndex.Declare_Declare_Sub_Id_Lib_Stringliteral
                    ' <Declare> ::= <Attributes> <Modifiers> Declare <Charset> Sub ID Lib StringLiteral <Alias> <Param List Opt> <NL> 

                Case ProductionIndex.Declare_Declare_Function_Id_Lib_Stringliteral
                    ' <Declare> ::= <Attributes> <Modifiers> Declare <Charset> Function ID Lib StringLiteral <Alias> <Param List Opt> <Type> <NL> 

                Case ProductionIndex.Charset_Ansi
                    ' <Charset> ::= Ansi 

                Case ProductionIndex.Charset_Unicode
                    ' <Charset> ::= Unicode 

                Case ProductionIndex.Charset_Auto
                    ' <Charset> ::= Auto 

                Case ProductionIndex.Charset
                    ' <Charset> ::=  

                Case ProductionIndex.Alias_Alias_Stringliteral
                    ' <Alias> ::= Alias StringLiteral 

                Case ProductionIndex.Alias
                    ' <Alias> ::=  

                Case ProductionIndex.Method_Sub_End_Sub
                    ' <Method> ::= <Attributes> <Modifiers> Sub <Sub ID> <Param List> <Handles Or Implements> <NL> <Statements> End Sub <NL> 

                Case ProductionIndex.Method_Function_Id_End_Function
                    ' <Method> ::= <Attributes> <Modifiers> Function ID <Param List> <Type> <Handles Or Implements> <NL> <Statements> End Function <NL> 

                Case ProductionIndex.Subid_Id
                    ' <Sub ID> ::= ID 

                Case ProductionIndex.Subid_New
                    ' <Sub ID> ::= New 

                Case ProductionIndex.Handlesorimplements
                    ' <Handles Or Implements> ::= <Implements> 

                Case ProductionIndex.Handlesorimplements2
                    ' <Handles Or Implements> ::= <Handles> 

                Case ProductionIndex.Handlesorimplements3
                    ' <Handles Or Implements> ::=  

                Case ProductionIndex.Handles_Handles
                    ' <Handles> ::= Handles <ID List> 

                Case ProductionIndex.Property_Property_Id_End_Property
                    ' <Property> ::= <Attributes> <Modifiers> Property ID <Param List> <Type> <NL> <Property Items> End Property <NL> 

                Case ProductionIndex.Propertyitems
                    ' <Property Items> ::= <Property Item> <Property Items> 

                Case ProductionIndex.Propertyitems2
                    ' <Property Items> ::=  

                Case ProductionIndex.Propertyitem_Get_End_Get
                    ' <Property Item> ::= Get <NL> <Statements> End Get <NL> 

                Case ProductionIndex.Propertyitem_Set_End_Set
                    ' <Property Item> ::= Set <Param List> <NL> <Statements> End Set <NL> 

                Case ProductionIndex.Enumeration_Enum_Id_End_Enum
                    ' <Enumeration> ::= <Attributes> <Modifiers> Enum ID <NL> <Enum List> End Enum <NL> 

                Case ProductionIndex.Enumlist
                    ' <Enum List> ::= <Enum Item> <Enum List> 

                Case ProductionIndex.Enumlist2
                    ' <Enum List> ::=  

                Case ProductionIndex.Enumitem_Id_Eq
                    ' <Enum Item> ::= ID '=' <Expression> <NL> 

                Case ProductionIndex.Enumitem_Id
                    ' <Enum Item> ::= ID <NL> 

                Case ProductionIndex.Vardecl_Comma
                    ' <Var Decl> ::= <Var Decl Item> ',' <Var Decl> 

                Case ProductionIndex.Vardecl
                    ' <Var Decl> ::= <Var Decl Item> 

                Case ProductionIndex.Vardeclitem_As
                    ' <Var Decl Item> ::= <Var Decl ID> As <Identifier> <Argument List Opt> 

                Case ProductionIndex.Vardeclitem_As_Eq
                    ' <Var Decl Item> ::= <Var Decl ID> As <Identifier> '=' <Expression> 

                Case ProductionIndex.Vardeclitem_As_New
                    ' <Var Decl Item> ::= <Var Decl ID> As New <Identifier> <Argument List Opt> 

                Case ProductionIndex.Vardeclitem_As_List_Lparen_Of_Id_Rparen
                    ' <Var Decl Item> ::= <Var Decl ID> As <New opt> List '(' of ID ')' 

                Case ProductionIndex.Vardeclitem
                    ' <Var Decl Item> ::= <Var Decl ID> 

                Case ProductionIndex.Vardeclitem_Eq
                    ' <Var Decl Item> ::= <Var Decl ID> '=' <Expression> 

                Case ProductionIndex.Newopt_New
                    ' <New opt> ::= New 

                Case ProductionIndex.Newopt
                    ' <New opt> ::=  

                Case ProductionIndex.Vardeclid_Id
                    ' <Var Decl ID> ::= ID <Argument List Opt> 

                Case ProductionIndex.Statements
                    ' <Statements> ::= <Statement> <Statements> 

                Case ProductionIndex.Statements2
                    ' <Statements> ::=  

                Case ProductionIndex.Statement
                    ' <Statement> ::= <Loop Stm> 

                Case ProductionIndex.Statement2
                    ' <Statement> ::= <For Stm> 

                Case ProductionIndex.Statement3
                    ' <Statement> ::= <If Stm> 

                Case ProductionIndex.Statement4
                    ' <Statement> ::= <Select Stm> 

                Case ProductionIndex.Statement5
                    ' <Statement> ::= <SyncLock Stm> 

                Case ProductionIndex.Statement6
                    ' <Statement> ::= <Try Stm> 

                Case ProductionIndex.Statement7
                    ' <Statement> ::= <With Stm> 

                Case ProductionIndex.Statement8
                    ' <Statement> ::= <Option Decl> 

                Case ProductionIndex.Statement9
                    ' <Statement> ::= <Local Decl> 

                Case ProductionIndex.Statement10
                    ' <Statement> ::= <Non-Block Stm> <NL> 

                Case ProductionIndex.Statement_Label
                    ' <Statement> ::= LABEL <NL> 

                Case ProductionIndex.Nonblockstm_Call
                    ' <Non-Block Stm> ::= Call <Variable> 

                Case ProductionIndex.Nonblockstm_Redim
                    ' <Non-Block Stm> ::= ReDim <Var Decl> 

                Case ProductionIndex.Nonblockstm_Redim_Preserve
                    ' <Non-Block Stm> ::= ReDim Preserve <Var Decl> 

                Case ProductionIndex.Nonblockstm_Erase_Id
                    ' <Non-Block Stm> ::= Erase ID 

                Case ProductionIndex.Nonblockstm_Throw
                    ' <Non-Block Stm> ::= Throw <Expression> 

                Case ProductionIndex.Nonblockstm_Raiseevent
                    ' <Non-Block Stm> ::= RaiseEvent <Identifier> <Argument List Opt> 

                Case ProductionIndex.Nonblockstm_Addhandler_Comma
                    ' <Non-Block Stm> ::= AddHandler <Expression> ',' <Expression> 

                Case ProductionIndex.Nonblockstm_Removehandler_Comma
                    ' <Non-Block Stm> ::= RemoveHandler <Expression> ',' <Expression> 

                Case ProductionIndex.Nonblockstm_Exit_Do
                    ' <Non-Block Stm> ::= Exit Do 

                Case ProductionIndex.Nonblockstm_Exit_For
                    ' <Non-Block Stm> ::= Exit For 

                Case ProductionIndex.Nonblockstm_Exit_Function
                    ' <Non-Block Stm> ::= Exit Function 

                Case ProductionIndex.Nonblockstm_Exit_Property
                    ' <Non-Block Stm> ::= Exit Property 

                Case ProductionIndex.Nonblockstm_Exit_Select
                    ' <Non-Block Stm> ::= Exit Select 

                Case ProductionIndex.Nonblockstm_Exit_Sub
                    ' <Non-Block Stm> ::= Exit Sub 

                Case ProductionIndex.Nonblockstm_Exit_Try
                    ' <Non-Block Stm> ::= Exit Try 

                Case ProductionIndex.Nonblockstm_Exit_While
                    ' <Non-Block Stm> ::= Exit While 

                Case ProductionIndex.Nonblockstm_Goto_Id
                    ' <Non-Block Stm> ::= GoTo ID 

                Case ProductionIndex.Nonblockstm_Return
                    ' <Non-Block Stm> ::= Return <Expression> 

                Case ProductionIndex.Nonblockstm_Error
                    ' <Non-Block Stm> ::= Error <Expression> 

                Case ProductionIndex.Nonblockstm_On_Error_Goto_Intliteral
                    ' <Non-Block Stm> ::= On Error GoTo IntLiteral 

                Case ProductionIndex.Nonblockstm_On_Error_Goto_Minus_Intliteral
                    ' <Non-Block Stm> ::= On Error GoTo '-' IntLiteral 

                Case ProductionIndex.Nonblockstm_On_Error_Goto_Id
                    ' <Non-Block Stm> ::= On Error GoTo ID 

                Case ProductionIndex.Nonblockstm_On_Error_Resume_Next
                    ' <Non-Block Stm> ::= On Error Resume Next 

                Case ProductionIndex.Nonblockstm_Resume_Id
                    ' <Non-Block Stm> ::= Resume ID 

                Case ProductionIndex.Nonblockstm_Resume_Next
                    ' <Non-Block Stm> ::= Resume Next 

                Case ProductionIndex.Nonblockstm
                    ' <Non-Block Stm> ::= <Variable> <Assign Op> <Expression> 

                Case ProductionIndex.Nonblockstm2
                    ' <Non-Block Stm> ::= <Variable> 

                Case ProductionIndex.Nonblockstm3
                    ' <Non-Block Stm> ::= <Method Call> 

                Case ProductionIndex.Assignop_Eq
                    ' <Assign Op> ::= '=' 

                Case ProductionIndex.Assignop_Careteq
                    ' <Assign Op> ::= '^=' 

                Case ProductionIndex.Assignop_Timeseq
                    ' <Assign Op> ::= '*=' 

                Case ProductionIndex.Assignop_Diveq
                    ' <Assign Op> ::= '/=' 

                Case ProductionIndex.Assignop_Backslasheq
                    ' <Assign Op> ::= '\=' 

                Case ProductionIndex.Assignop_Pluseq
                    ' <Assign Op> ::= '+=' 

                Case ProductionIndex.Assignop_Minuseq
                    ' <Assign Op> ::= '-=' 

                Case ProductionIndex.Assignop_Ampeq
                    ' <Assign Op> ::= '&=' 

                Case ProductionIndex.Assignop_Ltlteq
                    ' <Assign Op> ::= '<<=' 

                Case ProductionIndex.Assignop_Gtgteq
                    ' <Assign Op> ::= '>>=' 

                Case ProductionIndex.Localdecl_Dim
                    ' <Local Decl> ::= Dim <Var Decl> <NL> 

                Case ProductionIndex.Localdecl_Const
                    ' <Local Decl> ::= Const <Var Decl> <NL> 

                Case ProductionIndex.Localdecl_Static
                    ' <Local Decl> ::= Static <Var Decl> <NL> 

                Case ProductionIndex.Loopstm_Do_Loop
                    ' <Loop Stm> ::= Do <Test Type> <Expression> <NL> <Statements> Loop <NL> 

                Case ProductionIndex.Loopstm_Do_Loop2
                    ' <Loop Stm> ::= Do <NL> <Statements> Loop <Test Type> <Expression> <NL> 

                Case ProductionIndex.Loopstm_While_End_While
                    ' <Loop Stm> ::= While <Expression> <NL> <Statements> End While <NL> 

                Case ProductionIndex.Testtype_While
                    ' <Test Type> ::= While 

                Case ProductionIndex.Testtype_Until
                    ' <Test Type> ::= Until 

                Case ProductionIndex.Forstm_For_To_Next
                    ' <For Stm> ::= For <Var Decl Item> To <Expression> <Step Opt> <NL> <Statements> Next <NL> 

                Case ProductionIndex.Forstm_For_Each_In_Next
                    ' <For Stm> ::= For Each <Variable> <Type> In <Variable> <NL> <Statements> Next <NL> 

                Case ProductionIndex.Stepopt_Step
                    ' <Step Opt> ::= Step <Expression> 

                Case ProductionIndex.Stepopt
                    ' <Step Opt> ::=  

                Case ProductionIndex.Ifstm_If
                    ' <If Stm> ::= If <Expression> <Then Opt> <NL> <Statements> <If Blocks> <end if> <NL> 

                Case ProductionIndex.Ifstm_If_Then
                    ' <If Stm> ::= If <Expression> Then <Non-Block Stm> <NL> 

                Case ProductionIndex.Ifstm_If_Then_Else
                    ' <If Stm> ::= If <Expression> Then <Non-Block Stm> Else <Non-Block Stm> <NL> 

                Case ProductionIndex.Thenopt_Then
                    ' <Then Opt> ::= Then 

                Case ProductionIndex.Thenopt
                    ' <Then Opt> ::=  

                Case ProductionIndex.Ifblocks
                    ' <If Blocks> ::= <else if> <Expression> <Then Opt> <NL> <Statements> <If Blocks> 

                Case ProductionIndex.Ifblocks_Else
                    ' <If Blocks> ::= Else <NL> <Statements> 

                Case ProductionIndex.Ifblocks2
                    ' <If Blocks> ::=  

                Case ProductionIndex.Elseif_Elseif
                    ' <else if> ::= ElseIf 

                Case ProductionIndex.Elseif_Else_If
                    ' <else if> ::= Else If 

                Case ProductionIndex.Endif_End_If
                    ' <end if> ::= End If 

                Case ProductionIndex.Endif_Endif
                    ' <end if> ::= EndIf 

                Case ProductionIndex.Selectstm_Select_End_Select
                    ' <Select Stm> ::= Select <Case Opt> <Expression> <NL> <Select Blocks> End Select <NL> 

                Case ProductionIndex.Caseopt_Case
                    ' <Case Opt> ::= Case 

                Case ProductionIndex.Caseopt
                    ' <Case Opt> ::=  

                Case ProductionIndex.Selectblocks_Case
                    ' <Select Blocks> ::= Case <Case Clauses> <NL> <Statements> <Select Blocks> 

                Case ProductionIndex.Selectblocks_Case_Else
                    ' <Select Blocks> ::= Case Else <NL> <Statements> 

                Case ProductionIndex.Selectblocks
                    ' <Select Blocks> ::=  

                Case ProductionIndex.Caseclauses_Comma
                    ' <Case Clauses> ::= <Case Clause> ',' <Case Clauses> 

                Case ProductionIndex.Caseclauses
                    ' <Case Clauses> ::= <Case Clause> 

                Case ProductionIndex.Caseclause
                    ' <Case Clause> ::= <Is Opt> <Compare Op> <Expression> 

                Case ProductionIndex.Caseclause2
                    ' <Case Clause> ::= <Expression> 

                Case ProductionIndex.Caseclause_To
                    ' <Case Clause> ::= <Expression> To <Expression> 

                Case ProductionIndex.Isopt_Is
                    ' <Is Opt> ::= Is 

                Case ProductionIndex.Isopt
                    ' <Is Opt> ::=  

                Case ProductionIndex.Synclockstm_Synclock_End_Synclock
                    ' <SyncLock Stm> ::= SyncLock <NL> <Statements> End SyncLock <NL> 

                Case ProductionIndex.Trystm_Try_End_Try
                    ' <Try Stm> ::= Try <NL> <Statements> <Catch Blocks> End Try <NL> 

                Case ProductionIndex.Catchblocks
                    ' <Catch Blocks> ::= <Catch Block> <Catch Blocks> 

                Case ProductionIndex.Catchblocks2
                    ' <Catch Blocks> ::= <Catch Block> 

                Case ProductionIndex.Catchblock_Catch_As_Id
                    ' <Catch Block> ::= Catch <Identifier> As ID <NL> <Statements> 

                Case ProductionIndex.Catchblock_Catch
                    ' <Catch Block> ::= Catch <NL> <Statements> 

                Case ProductionIndex.Withstm_With_End_With
                    ' <With Stm> ::= With <Value> <NL> <Statements> End With <NL> 

                Case ProductionIndex.Expression_Or
                    ' <Expression> ::= <And Exp> Or <Expression> 

                Case ProductionIndex.Expression_Orelse
                    ' <Expression> ::= <And Exp> OrElse <Expression> 

                Case ProductionIndex.Expression_Xor
                    ' <Expression> ::= <And Exp> XOr <Expression> 

                Case ProductionIndex.Expression
                    ' <Expression> ::= <And Exp> 

                Case ProductionIndex.Andexp_And
                    ' <And Exp> ::= <Not Exp> And <And Exp> 

                Case ProductionIndex.Andexp_Andalso
                    ' <And Exp> ::= <Not Exp> AndAlso <And Exp> 

                Case ProductionIndex.Andexp
                    ' <And Exp> ::= <Not Exp> 

                Case ProductionIndex.Notexp_Not
                    ' <Not Exp> ::= NOT <Compare Exp> 

                Case ProductionIndex.Notexp
                    ' <Not Exp> ::= <Compare Exp> 

                Case ProductionIndex.Compareexp
                    ' <Compare Exp> ::= <Shift Exp> <Compare Op> <Compare Exp> 

                Case ProductionIndex.Compareexp_Typeof_Is
                    ' <Compare Exp> ::= TypeOf <Add Exp> Is <Object> 

                Case ProductionIndex.Compareexp_Is
                    ' <Compare Exp> ::= <Shift Exp> Is <Object> 

                Case ProductionIndex.Compareexp_Like
                    ' <Compare Exp> ::= <Shift Exp> Like <Value> 

                Case ProductionIndex.Compareexp2
                    ' <Compare Exp> ::= <Shift Exp> 

                Case ProductionIndex.Shiftexp_Ltlt
                    ' <Shift Exp> ::= <Concat Exp> '<<' <Shift Exp> 

                Case ProductionIndex.Shiftexp_Gtgt
                    ' <Shift Exp> ::= <Concat Exp> '>>' <Shift Exp> 

                Case ProductionIndex.Shiftexp
                    ' <Shift Exp> ::= <Concat Exp> 

                Case ProductionIndex.Concatexp_Amp
                    ' <Concat Exp> ::= <Add Exp> '&' <Concat Exp> 

                Case ProductionIndex.Concatexp
                    ' <Concat Exp> ::= <Add Exp> 

                Case ProductionIndex.Addexp_Plus
                    ' <Add Exp> ::= <Modulus Exp> '+' <Add Exp> 

                Case ProductionIndex.Addexp_Minus
                    ' <Add Exp> ::= <Modulus Exp> '-' <Add Exp> 

                Case ProductionIndex.Addexp
                    ' <Add Exp> ::= <Modulus Exp> 

                Case ProductionIndex.Modulusexp_Mod
                    ' <Modulus Exp> ::= <Int Div Exp> Mod <Modulus Exp> 

                Case ProductionIndex.Modulusexp
                    ' <Modulus Exp> ::= <Int Div Exp> 

                Case ProductionIndex.Intdivexp_Backslash
                    ' <Int Div Exp> ::= <Mult Exp> '\' <Int Div Exp> 

                Case ProductionIndex.Intdivexp
                    ' <Int Div Exp> ::= <Mult Exp> 

                Case ProductionIndex.Multexp_Times
                    ' <Mult Exp> ::= <Negate Exp> '*' <Mult Exp> 

                Case ProductionIndex.Multexp_Div
                    ' <Mult Exp> ::= <Negate Exp> '/' <Mult Exp> 

                Case ProductionIndex.Multexp
                    ' <Mult Exp> ::= <Negate Exp> 

                Case ProductionIndex.Negateexp_Minus
                    ' <Negate Exp> ::= '-' <Power Exp> 

                Case ProductionIndex.Negateexp
                    ' <Negate Exp> ::= <Power Exp> 

                Case ProductionIndex.Powerexp_Caret
                    ' <Power Exp> ::= <Power Exp> '^' <Value> 

                Case ProductionIndex.Powerexp
                    ' <Power Exp> ::= <Value> 

                Case ProductionIndex.Value_Lparen_Rparen
                    ' <Value> ::= '(' <Expression> ')' 

                Case ProductionIndex.Value_New
                    ' <Value> ::= New <Identifier> <Argument List Opt> 

                Case ProductionIndex.Value_Me
                    ' <Value> ::= Me 

                Case ProductionIndex.Value_Myclass
                    ' <Value> ::= MyClass 

                Case ProductionIndex.Value_Mybase
                    ' <Value> ::= MyBase 

                Case ProductionIndex.Value
                    ' <Value> ::= <Const Item> 

                Case ProductionIndex.Value2
                    ' <Value> ::= <Variable> 

                Case ProductionIndex.Value_If_Lparen_Comma_Comma_Rparen
                    ' <Value> ::= If '(' <Expression> ',' <Expression> ',' <Expression> ')' 

                Case ProductionIndex.Value3
                    ' <Value> ::= <const array> 

                Case ProductionIndex.Constarray_Lbrace_Rbrace
                    ' <const array> ::= '{' <Const Params> '}' 

                Case ProductionIndex.Constarray_Lbrace_Rbrace2
                    ' <const array> ::= '{' '}' 

                Case ProductionIndex.Constparams_Comma
                    ' <Const Params> ::= <Const Item> ',' <Const Params> 

                Case ProductionIndex.Constparams
                    ' <Const Params> ::= <Const Item> 

                Case ProductionIndex.Constitem_Intliteral
                    ' <Const Item> ::= IntLiteral 

                Case ProductionIndex.Constitem_Hexliteral
                    ' <Const Item> ::= HexLiteral 

                Case ProductionIndex.Constitem_Octliteral
                    ' <Const Item> ::= OctLiteral 

                Case ProductionIndex.Constitem_Stringliteral
                    ' <Const Item> ::= StringLiteral 

                Case ProductionIndex.Constitem_Charliteral
                    ' <Const Item> ::= CharLiteral 

                Case ProductionIndex.Constitem_Realliteral
                    ' <Const Item> ::= RealLiteral 

                Case ProductionIndex.Constitem_Dateliteral
                    ' <Const Item> ::= DateLiteral 

                Case ProductionIndex.Constitem_True
                    ' <Const Item> ::= True 

                Case ProductionIndex.Constitem_False
                    ' <Const Item> ::= False 

                Case ProductionIndex.Constitem_Nothing
                    ' <Const Item> ::= Nothing 

                Case ProductionIndex.Constitem_Addressof
                    ' <Const Item> ::= AddressOf <Variable> 

                Case ProductionIndex.Object
                    ' <Object> ::= <Identifier> 

                Case ProductionIndex.Object_Me
                    ' <Object> ::= Me 

                Case ProductionIndex.Object_Myclass
                    ' <Object> ::= MyClass 

                Case ProductionIndex.Object_Mybase
                    ' <Object> ::= MyBase 

                Case ProductionIndex.Object_Nothing
                    ' <Object> ::= Nothing 

                Case ProductionIndex.Variable
                    ' <Variable> ::= <Identifier> <Argument List Opt> <Method Calls> 

                Case ProductionIndex.Methodcalls
                    ' <Method Calls> ::= <Method Call> <Method Calls> 

                Case ProductionIndex.Methodcalls2
                    ' <Method Calls> ::=  

                Case ProductionIndex.Methodcall_Memberid
                    ' <Method Call> ::= MemberID <Argument List Opt> 

                Case ProductionIndex.Identifier_Id
                    ' <Identifier> ::= ID 

                Case ProductionIndex.Identifier_Qualifiedid
                    ' <Identifier> ::= QualifiedID 

            End Select
        End With

        Return Result
    End Function
End Module
