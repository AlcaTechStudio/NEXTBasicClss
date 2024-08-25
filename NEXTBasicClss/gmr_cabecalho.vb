Module gmr_cabecalho

    Public Enum SymbolIndex
        [Eof] = 0                                 ' (EOF)
        [Error] = 1                               ' (Error)
        [Comment_line] = 2                        ' 'Comment_Line'
        [Whitespace] = 3                          ' Whitespace
        [Minus] = 4                               ' '-'
        [Amp] = 5                                 ' '&'
        [Ampeq] = 6                               ' '&='
        [Lparen] = 7                              ' '('
        [Rparen] = 8                              ' ')'
        [Times] = 9                               ' '*'
        [Timeseq] = 10                            ' '*='
        [Comma] = 11                              ' ','
        [Div] = 12                                ' '/'
        [Diveq] = 13                              ' '/='
        [Coloneq] = 14                            ' ':='
        [Backslash] = 15                          ' '\'
        [Backslasheq] = 16                        ' '\='
        [Caret] = 17                              ' '^'
        [Careteq] = 18                            ' '^='
        [Lbrace] = 19                             ' '{'
        [Rbrace] = 20                             ' '}'
        [Plus] = 21                               ' '+'
        [Pluseq] = 22                             ' '+='
        [Lt] = 23                                 ' '<'
        [Ltlt] = 24                               ' '<<'
        [Ltlteq] = 25                             ' '<<='
        [Lteq] = 26                               ' '<='
        [Ltgt] = 27                               ' '<>'
        [Eq] = 28                                 ' '='
        [Minuseq] = 29                            ' '-='
        [Gt] = 30                                 ' '>'
        [Gteq] = 31                               ' '>='
        [Gtgt] = 32                               ' '>>'
        [Gtgteq] = 33                             ' '>>='
        [Addhandler] = 34                         ' AddHandler
        [Addressof] = 35                          ' AddressOf
        [Alias] = 36                              ' Alias
        [And] = 37                                ' And
        [Andalso] = 38                            ' AndAlso
        [Ansi] = 39                               ' Ansi
        [As] = 40                                 ' As
        [Assembly] = 41                           ' Assembly
        [Auto] = 42                               ' Auto
        [Byref] = 43                              ' ByRef
        [Byval] = 44                              ' ByVal
        [Call] = 45                               ' Call
        [Case] = 46                               ' Case
        [Catch] = 47                              ' Catch
        [Charliteral] = 48                        ' CharLiteral
        [Class] = 49                              ' Class
        [Const] = 50                              ' Const
        [Dateliteral] = 51                        ' DateLiteral
        [Declare] = 52                            ' Declare
        [Default] = 53                            ' Default
        [Delegate] = 54                           ' Delegate
        [Dim] = 55                                ' Dim
        [Do] = 56                                 ' Do
        [Each] = 57                               ' Each
        [Else] = 58                               ' Else
        [Elseif] = 59                             ' ElseIf
        [End] = 60                                ' End
        [Endif] = 61                              ' EndIf
        [Enum] = 62                               ' Enum
        [Erase] = 63                              ' Erase
        [Error2] = 64                             ' Error
        [Event] = 65                              ' Event
        [Exit] = 66                               ' Exit
        [False] = 67                              ' False
        [For] = 68                                ' For
        [Friend] = 69                             ' Friend
        [Function] = 70                           ' Function
        [Get] = 71                                ' Get
        [Goto] = 72                               ' GoTo
        [Handles] = 73                            ' Handles
        [Hexliteral] = 74                         ' HexLiteral
        [Id] = 75                                 ' ID
        [If] = 76                                 ' If
        [Implements] = 77                         ' Implements
        [Imports] = 78                            ' Imports
        [In] = 79                                 ' In
        [Inherits] = 80                           ' Inherits
        [Interface] = 81                          ' Interface
        [Intliteral] = 82                         ' IntLiteral
        [Is] = 83                                 ' Is
        [Isnot] = 84                              ' isNot
        [Label] = 85                              ' LABEL
        [Lib] = 86                                ' Lib
        [Like] = 87                               ' Like
        [List] = 88                               ' List
        [Loop] = 89                               ' Loop
        [Me] = 90                                 ' Me
        [Memberid] = 91                           ' MemberID
        [Mod] = 92                                ' Mod
        [Module] = 93                             ' Module
        [Mustinherit] = 94                        ' MustInherit
        [Mustoverride] = 95                       ' MustOverride
        [Mybase] = 96                             ' MyBase
        [Myclass] = 97                            ' MyClass
        [Namespace] = 98                          ' NameSpace
        [New] = 99                                ' New
        [Newline] = 100                           ' NewLine
        [Next] = 101                              ' Next
        [Not] = 102                               ' NOT
        [Nothing] = 103                           ' Nothing
        [Notinheritable] = 104                    ' NotInheritable
        [Notoverridable] = 105                    ' NotOverridable
        [Octliteral] = 106                        ' OctLiteral
        [Of] = 107                                ' of
        [Off] = 108                               ' Off
        [On] = 109                                ' On
        [Option] = 110                            ' Option
        [Optional] = 111                          ' Optional
        [Or] = 112                                ' Or
        [Orelse] = 113                            ' OrElse
        [Overloads] = 114                         ' Overloads
        [Overridable] = 115                       ' Overridable
        [Overrides] = 116                         ' Overrides
        [Paramarray] = 117                        ' ParamArray
        [Preserve] = 118                          ' Preserve
        [Private] = 119                           ' Private
        [Property] = 120                          ' Property
        [Protected] = 121                         ' Protected
        [Public] = 122                            ' Public
        [Qualifiedid] = 123                       ' QualifiedID
        [Raiseevent] = 124                        ' RaiseEvent
        [Readonly] = 125                          ' ReadOnly
        [Realliteral] = 126                       ' RealLiteral
        [Redim] = 127                             ' ReDim
        [Removehandler] = 128                     ' RemoveHandler
        [Resume] = 129                            ' Resume
        [Return] = 130                            ' Return
        [Select] = 131                            ' Select
        [Set] = 132                               ' Set
        [Shadows] = 133                           ' Shadows
        [Shared] = 134                            ' Shared
        [Static] = 135                            ' Static
        [Step] = 136                              ' Step
        [Stringliteral] = 137                     ' StringLiteral
        [Structure] = 138                         ' Structure
        [Sub] = 139                               ' Sub
        [Synclock] = 140                          ' SyncLock
        [Then] = 141                              ' Then
        [Throw] = 142                             ' Throw
        [To] = 143                                ' To
        [True] = 144                              ' True
        [Try] = 145                               ' Try
        [Typeof] = 146                            ' TypeOf
        [Unicode] = 147                           ' Unicode
        [Until] = 148                             ' Until
        [While] = 149                             ' While
        [With] = 150                              ' With
        [Writeonly] = 151                         ' WriteOnly
        [Xor] = 152                               ' XOr
        [Access] = 153                            ' <Access>
        [Addexp] = 154                            ' <Add Exp>
        [Alias2] = 155                            ' <Alias>
        [Andexp] = 156                            ' <And Exp>
        [Argument] = 157                          ' <Argument>
        [Argumentitems] = 158                     ' <Argument Items>
        [Argumentlist] = 159                      ' <Argument List>
        [Argumentlistopt] = 160                   ' <Argument List Opt>
        [Assignop] = 161                          ' <Assign Op>
        [Attribute] = 162                         ' <Attribute>
        [Attributelist] = 163                     ' <Attribute List>
        [Attributemod] = 164                      ' <Attribute Mod>
        [Attributes] = 165                        ' <Attributes>
        [Caseclause] = 166                        ' <Case Clause>
        [Caseclauses] = 167                       ' <Case Clauses>
        [Caseopt] = 168                           ' <Case Opt>
        [Catchblock] = 169                        ' <Catch Block>
        [Catchblocks] = 170                       ' <Catch Blocks>
        [Charset] = 171                           ' <Charset>
        [Class2] = 172                            ' <Class>
        [Classimplements] = 173                   ' <Class Implements>
        [Classitem] = 174                         ' <Class Item>
        [Classitems] = 175                        ' <Class Items>
        [Compareexp] = 176                        ' <Compare Exp>
        [Compareop] = 177                         ' <Compare Op>
        [Concatexp] = 178                         ' <Concat Exp>
        [Constarray] = 179                        ' <const array>
        [Constitem] = 180                         ' <Const Item>
        [Constparams] = 181                       ' <Const Params>
        [Declare2] = 182                          ' <Declare>
        [Delegate2] = 183                         ' <Delegate>
        [Dimopt] = 184                            ' <dim opt>
        [Elseif2] = 185                           ' <else if>
        [Endif2] = 186                            ' <end if>
        [Enumitem] = 187                          ' <Enum Item>
        [Enumlist] = 188                          ' <Enum List>
        [Enummember] = 189                        ' <Enum Member>
        [Enumeration] = 190                       ' <Enumeration>
        [Eventmember] = 191                       ' <Event Member>
        [Expression] = 192                        ' <Expression>
        [Forstm] = 193                            ' <For Stm>
        [Handles2] = 194                          ' <Handles>
        [Handlesorimplements] = 195               ' <Handles Or Implements>
        [Idlist] = 196                            ' <ID List>
        [Identifier] = 197                        ' <Identifier>
        [Ids] = 198                               ' <IDs>
        [Ifblocks] = 199                          ' <If Blocks>
        [Ifstm] = 200                             ' <If Stm>
        [Implements2] = 201                       ' <Implements>
        [Implementsopt] = 202                     ' <Implements Opt>
        [Imports2] = 203                          ' <Imports>
        [Inherits2] = 204                         ' <Inherits>
        [Intdivexp] = 205                         ' <Int Div Exp>
        [Interface2] = 206                        ' <Interface>
        [Interfaceitem] = 207                     ' <Interface Item>
        [Interfaceitems] = 208                    ' <Interface Items>
        [Isopt] = 209                             ' <Is Opt>
        [Localdecl] = 210                         ' <Local Decl>
        [Loopstm] = 211                           ' <Loop Stm>
        [Method] = 212                            ' <Method>
        [Methodcall] = 213                        ' <Method Call>
        [Methodcalls] = 214                       ' <Method Calls>
        [Methodmember] = 215                      ' <Method Member>
        [Modifier] = 216                          ' <Modifier>
        [Modifiers] = 217                         ' <Modifiers>
        [Module2] = 218                           ' <Module>
        [Moduleitem] = 219                        ' <Module Item>
        [Moduleitems] = 220                       ' <Module Items>
        [Modulusexp] = 221                        ' <Modulus Exp>
        [Multexp] = 222                           ' <Mult Exp>
        [Namespace2] = 223                        ' <NameSpace>
        [Namespaceitem] = 224                     ' <NameSpace Item>
        [Namespaceitems] = 225                    ' <NameSpace Items>
        [Negateexp] = 226                         ' <Negate Exp>
        [Newopt] = 227                            ' <New opt>
        [Nl] = 228                                ' <NL>
        [Nlopt] = 229                             ' <NL Opt>
        [Nonminusblockstm] = 230                  ' <Non-Block Stm>
        [Notexp] = 231                            ' <Not Exp>
        [Object] = 232                            ' <Object>
        [Optiondecl] = 233                        ' <Option Decl>
        [Paramitem] = 234                         ' <Param Item>
        [Paramitems] = 235                        ' <Param Items>
        [Paramlist] = 236                         ' <Param List>
        [Paramlistopt] = 237                      ' <Param List Opt>
        [Parampassing] = 238                      ' <Param Passing>
        [Parametersortype] = 239                  ' <Parameters Or Type>
        [Powerexp] = 240                          ' <Power Exp>
        [Program] = 241                           ' <Program>
        [Programstruct] = 242                     ' <Program Struct>
        [Property2] = 243                         ' <Property>
        [Propertyitem] = 244                      ' <Property Item>
        [Propertyitems] = 245                     ' <Property Items>
        [Propertymember] = 246                    ' <Property Member>
        [Selectblocks] = 247                      ' <Select Blocks>
        [Selectstm] = 248                         ' <Select Stm>
        [Shiftexp] = 249                          ' <Shift Exp>
        [Statement] = 250                         ' <Statement>
        [Statements] = 251                        ' <Statements>
        [Stepopt] = 252                           ' <Step Opt>
        [Structure2] = 253                        ' <Structure>
        [Structureitem] = 254                     ' <Structure Item>
        [Structurelist] = 255                     ' <Structure List>
        [Subid] = 256                             ' <Sub ID>
        [Synclockstm] = 257                       ' <SyncLock Stm>
        [Testtype] = 258                          ' <Test Type>
        [Thenopt] = 259                           ' <Then Opt>
        [Trystm] = 260                            ' <Try Stm>
        [Type] = 261                              ' <Type>
        [Value] = 262                             ' <Value>
        [Vardecl] = 263                           ' <Var Decl>
        [Vardeclid] = 264                         ' <Var Decl ID>
        [Vardeclitem] = 265                       ' <Var Decl Item>
        [Varmember] = 266                         ' <Var Member>
        [Variable] = 267                          ' <Variable>
        [Withstm] = 268                           ' <With Stm>
    End Enum

    Public Enum ProductionIndex
        [Nl_Newline] = 0                          ' <NL> ::= NewLine <NL>
        [Nl_Newline2] = 1                         ' <NL> ::= NewLine
        [Nlopt] = 2                               ' <NL Opt> ::= <NL>
        [Nlopt2] = 3                              ' <NL Opt> ::= 
        [Program] = 4                             ' <Program> ::= <NL Opt> <Program Struct>
        [Programstruct] = 5                       ' <Program Struct> ::= <NameSpace Item> <Program Struct>
        [Programstruct2] = 6                      ' <Program Struct> ::= <Imports> <Program Struct>
        [Programstruct3] = 7                      ' <Program Struct> ::= <Option Decl> <Program Struct>
        [Programstruct4] = 8                      ' <Program Struct> ::= 
        [Modifiers] = 9                           ' <Modifiers> ::= <Modifier> <Modifiers>
        [Modifiers2] = 10                         ' <Modifiers> ::= 
        [Modifier_Shadows] = 11                   ' <Modifier> ::= Shadows
        [Modifier_Shared] = 12                    ' <Modifier> ::= Shared
        [Modifier_Mustinherit] = 13               ' <Modifier> ::= MustInherit
        [Modifier_Notinheritable] = 14            ' <Modifier> ::= NotInheritable
        [Modifier_Overridable] = 15               ' <Modifier> ::= Overridable
        [Modifier_Notoverridable] = 16            ' <Modifier> ::= NotOverridable
        [Modifier_Mustoverride] = 17              ' <Modifier> ::= MustOverride
        [Modifier_Overrides] = 18                 ' <Modifier> ::= Overrides
        [Modifier_Overloads] = 19                 ' <Modifier> ::= Overloads
        [Modifier_Default] = 20                   ' <Modifier> ::= Default
        [Modifier_Readonly] = 21                  ' <Modifier> ::= ReadOnly
        [Modifier_Writeonly] = 22                 ' <Modifier> ::= WriteOnly
        [Modifier] = 23                           ' <Modifier> ::= <Access>
        [Access_Public] = 24                      ' <Access> ::= Public
        [Access_Private] = 25                     ' <Access> ::= Private
        [Access_Friend] = 26                      ' <Access> ::= Friend
        [Access_Protected] = 27                   ' <Access> ::= Protected
        [Varmember] = 28                          ' <Var Member> ::= <Attributes> <Modifiers> <dim opt> <Var Decl> <NL>
        [Varmember_Const] = 29                    ' <Var Member> ::= <Attributes> <Modifiers> <dim opt> Const <Var Decl> <NL>
        [Varmember_Static] = 30                   ' <Var Member> ::= <Attributes> <Modifiers> <dim opt> Static <Var Decl> <NL>
        [Dimopt_Dim] = 31                         ' <dim opt> ::= Dim
        [Dimopt] = 32                             ' <dim opt> ::= 
        [Implements_Implements] = 33              ' <Implements> ::= Implements <ID List>
        [Idlist_Comma] = 34                       ' <ID List> ::= <Identifier> ',' <ID List>
        [Idlist] = 35                             ' <ID List> ::= <Identifier>
        [Optiondecl_Option] = 36                  ' <Option Decl> ::= Option <IDs> <NL>
        [Ids_Id] = 37                             ' <IDs> ::= ID <IDs>
        [Ids_Id2] = 38                            ' <IDs> ::= ID
        [Ids_On] = 39                             ' <IDs> ::= On
        [Ids_Off] = 40                            ' <IDs> ::= Off
        [Type_As] = 41                            ' <Type> ::= As <Attributes> <Identifier>
        [Type] = 42                               ' <Type> ::= 
        [Compareop_Eq] = 43                       ' <Compare Op> ::= '='
        [Compareop_Ltgt] = 44                     ' <Compare Op> ::= '<>'
        [Compareop_Lt] = 45                       ' <Compare Op> ::= '<'
        [Compareop_Gt] = 46                       ' <Compare Op> ::= '>'
        [Compareop_Gteq] = 47                     ' <Compare Op> ::= '>='
        [Compareop_Lteq] = 48                     ' <Compare Op> ::= '<='
        [Compareop_Isnot] = 49                    ' <Compare Op> ::= isNot
        [Namespace_Namespace_Id_End_Namespace] = 50 ' <NameSpace> ::= NameSpace ID <NL> <NameSpace Items> End NameSpace <NL>
        [Namespaceitems] = 51                     ' <NameSpace Items> ::= <NameSpace Item> <NameSpace Items>
        [Namespaceitems2] = 52                    ' <NameSpace Items> ::= 
        [Namespaceitem] = 53                      ' <NameSpace Item> ::= <Class>
        [Namespaceitem2] = 54                     ' <NameSpace Item> ::= <Declare>
        [Namespaceitem3] = 55                     ' <NameSpace Item> ::= <Delegate>
        [Namespaceitem4] = 56                     ' <NameSpace Item> ::= <Enumeration>
        [Namespaceitem5] = 57                     ' <NameSpace Item> ::= <Interface>
        [Namespaceitem6] = 58                     ' <NameSpace Item> ::= <Structure>
        [Namespaceitem7] = 59                     ' <NameSpace Item> ::= <Module>
        [Namespaceitem8] = 60                     ' <NameSpace Item> ::= <NameSpace>
        [Attributes_Lt_Gt] = 61                   ' <Attributes> ::= '<' <Attribute List> '>'
        [Attributes] = 62                         ' <Attributes> ::= 
        [Attributelist_Comma] = 63                ' <Attribute List> ::= <Attribute> ',' <Attribute List>
        [Attributelist] = 64                      ' <Attribute List> ::= <Attribute>
        [Attribute_Id] = 65                       ' <Attribute> ::= <Attribute Mod> ID <Argument List Opt>
        [Attributemod_Assembly] = 66              ' <Attribute Mod> ::= Assembly
        [Attributemod_Module] = 67                ' <Attribute Mod> ::= Module
        [Attributemod] = 68                       ' <Attribute Mod> ::= 
        [Delegate_Delegate] = 69                  ' <Delegate> ::= <Attributes> <Modifiers> Delegate <Method>
        [Delegate_Delegate2] = 70                 ' <Delegate> ::= <Attributes> <Modifiers> Delegate <Declare>
        [Imports_Imports] = 71                    ' <Imports> ::= Imports <Identifier> <NL>
        [Imports_Imports_Id_Eq] = 72              ' <Imports> ::= Imports ID '=' <Identifier> <NL>
        [Eventmember_Event_Id] = 73               ' <Event Member> ::= <Attributes> <Modifiers> Event ID <Parameters Or Type> <Implements Opt> <NL>
        [Parametersortype] = 74                   ' <Parameters Or Type> ::= <Param List>
        [Parametersortype_As] = 75                ' <Parameters Or Type> ::= As <Identifier>
        [Implementsopt] = 76                      ' <Implements Opt> ::= <Implements>
        [Implementsopt2] = 77                     ' <Implements Opt> ::= 
        [Class_Class_Id_End_Class] = 78           ' <Class> ::= <Attributes> <Modifiers> Class ID <NL> <Class Items> End Class <NL>
        [Classitems] = 79                         ' <Class Items> ::= <Class Item> <Class Items>
        [Classitems2] = 80                        ' <Class Items> ::= 
        [Classitem] = 81                          ' <Class Item> ::= <Declare>
        [Classitem2] = 82                         ' <Class Item> ::= <Method>
        [Classitem3] = 83                         ' <Class Item> ::= <Property>
        [Classitem4] = 84                         ' <Class Item> ::= <Var Member>
        [Classitem5] = 85                         ' <Class Item> ::= <Enumeration>
        [Classitem6] = 86                         ' <Class Item> ::= <Inherits>
        [Classitem7] = 87                         ' <Class Item> ::= <Class Implements>
        [Inherits_Inherits] = 88                  ' <Inherits> ::= Inherits <Identifier> <NL>
        [Classimplements_Implements] = 89         ' <Class Implements> ::= Implements <ID List> <NL>
        [Structure_Structure_Id_End_Structure] = 90 ' <Structure> ::= <Attributes> <Modifiers> Structure ID <NL> <Structure List> End Structure <NL>
        [Structurelist] = 91                      ' <Structure List> ::= <Structure Item> <Structure List>
        [Structurelist2] = 92                     ' <Structure List> ::= 
        [Structureitem] = 93                      ' <Structure Item> ::= <Implements>
        [Structureitem2] = 94                     ' <Structure Item> ::= <Enumeration>
        [Structureitem3] = 95                     ' <Structure Item> ::= <Structure>
        [Structureitem4] = 96                     ' <Structure Item> ::= <Class>
        [Structureitem5] = 97                     ' <Structure Item> ::= <Delegate>
        [Structureitem6] = 98                     ' <Structure Item> ::= <Var Member>
        [Structureitem7] = 99                     ' <Structure Item> ::= <Event Member>
        [Structureitem8] = 100                    ' <Structure Item> ::= <Declare>
        [Structureitem9] = 101                    ' <Structure Item> ::= <Method>
        [Structureitem10] = 102                   ' <Structure Item> ::= <Property>
        [Module_Module_Id_End_Module] = 103       ' <Module> ::= <Attributes> <Modifiers> Module ID <NL> <Module Items> End Module <NL>
        [Moduleitems] = 104                       ' <Module Items> ::= <Module Item> <Module Items>
        [Moduleitems2] = 105                      ' <Module Items> ::= 
        [Moduleitem] = 106                        ' <Module Item> ::= <Declare>
        [Moduleitem2] = 107                       ' <Module Item> ::= <Method>
        [Moduleitem3] = 108                       ' <Module Item> ::= <Property>
        [Moduleitem4] = 109                       ' <Module Item> ::= <Var Member>
        [Moduleitem5] = 110                       ' <Module Item> ::= <Enumeration>
        [Moduleitem6] = 111                       ' <Module Item> ::= <Option Decl>
        [Moduleitem7] = 112                       ' <Module Item> ::= <Class>
        [Moduleitem8] = 113                       ' <Module Item> ::= <Structure>
        [Interface_Interface_Id_End_Interface] = 114 ' <Interface> ::= <Attributes> <Modifiers> Interface ID <NL> <Interface Items> End Interface <NL>
        [Interfaceitems] = 115                    ' <Interface Items> ::= <Interface Item> <Interface Items>
        [Interfaceitems2] = 116                   ' <Interface Items> ::= 
        [Interfaceitem] = 117                     ' <Interface Item> ::= <Implements>
        [Interfaceitem2] = 118                    ' <Interface Item> ::= <Event Member>
        [Interfaceitem3] = 119                    ' <Interface Item> ::= <Enum Member>
        [Interfaceitem4] = 120                    ' <Interface Item> ::= <Method Member>
        [Interfaceitem5] = 121                    ' <Interface Item> ::= <Property Member>
        [Enummember_Enum_Id] = 122                ' <Enum Member> ::= <Attributes> <Modifiers> Enum ID <NL>
        [Methodmember_Sub] = 123                  ' <Method Member> ::= <Attributes> <Modifiers> Sub <Sub ID> <Param List> <Handles Or Implements> <NL>
        [Methodmember_Function_Id] = 124          ' <Method Member> ::= <Attributes> <Modifiers> Function ID <Param List> <Type> <Handles Or Implements> <NL>
        [Propertymember_Property_Id] = 125        ' <Property Member> ::= <Attributes> <Modifiers> Property ID <Param List> <Type> <Handles Or Implements> <NL>
        [Paramlistopt] = 126                      ' <Param List Opt> ::= <Param List>
        [Paramlistopt2] = 127                     ' <Param List Opt> ::= 
        [Paramlist_Lparen_Rparen] = 128           ' <Param List> ::= '(' <Param Items> ')'
        [Paramlist_Lparen_Rparen2] = 129          ' <Param List> ::= '(' ')'
        [Paramitems_Comma] = 130                  ' <Param Items> ::= <Param Item> ',' <Param Items>
        [Paramitems] = 131                        ' <Param Items> ::= <Param Item>
        [Paramitem_Id] = 132                      ' <Param Item> ::= <Param Passing> ID <Type>
        [Parampassing_Byval] = 133                ' <Param Passing> ::= ByVal
        [Parampassing_Byref] = 134                ' <Param Passing> ::= ByRef
        [Parampassing_Optional] = 135             ' <Param Passing> ::= Optional
        [Parampassing_Paramarray] = 136           ' <Param Passing> ::= ParamArray
        [Parampassing] = 137                      ' <Param Passing> ::= 
        [Argumentlistopt] = 138                   ' <Argument List Opt> ::= <Argument List>
        [Argumentlistopt2] = 139                  ' <Argument List Opt> ::= <Argument List> <Argument List>
        [Argumentlistopt3] = 140                  ' <Argument List Opt> ::= 
        [Argumentlist_Lparen_Rparen] = 141        ' <Argument List> ::= '(' <Argument Items> ')'
        [Argumentlist] = 142                      ' <Argument List> ::= <const array>
        [Argumentitems_Comma] = 143               ' <Argument Items> ::= <Argument> ',' <Argument Items>
        [Argumentitems] = 144                     ' <Argument Items> ::= <Argument>
        [Argument] = 145                          ' <Argument> ::= <Expression>
        [Argument_Id_Coloneq] = 146               ' <Argument> ::= ID ':=' <Expression>
        [Argument2] = 147                         ' <Argument> ::= 
        [Declare_Declare_Sub_Id_Lib_Stringliteral] = 148 ' <Declare> ::= <Attributes> <Modifiers> Declare <Charset> Sub ID Lib StringLiteral <Alias> <Param List Opt> <NL>
        [Declare_Declare_Function_Id_Lib_Stringliteral] = 149 ' <Declare> ::= <Attributes> <Modifiers> Declare <Charset> Function ID Lib StringLiteral <Alias> <Param List Opt> <Type> <NL>
        [Charset_Ansi] = 150                      ' <Charset> ::= Ansi
        [Charset_Unicode] = 151                   ' <Charset> ::= Unicode
        [Charset_Auto] = 152                      ' <Charset> ::= Auto
        [Charset] = 153                           ' <Charset> ::= 
        [Alias_Alias_Stringliteral] = 154         ' <Alias> ::= Alias StringLiteral
        [Alias] = 155                             ' <Alias> ::= 
        [Method_Sub_End_Sub] = 156                ' <Method> ::= <Attributes> <Modifiers> Sub <Sub ID> <Param List> <Handles Or Implements> <NL> <Statements> End Sub <NL>
        [Method_Function_Id_End_Function] = 157   ' <Method> ::= <Attributes> <Modifiers> Function ID <Param List> <Type> <Handles Or Implements> <NL> <Statements> End Function <NL>
        [Subid_Id] = 158                          ' <Sub ID> ::= ID
        [Subid_New] = 159                         ' <Sub ID> ::= New
        [Handlesorimplements] = 160               ' <Handles Or Implements> ::= <Implements>
        [Handlesorimplements2] = 161              ' <Handles Or Implements> ::= <Handles>
        [Handlesorimplements3] = 162              ' <Handles Or Implements> ::= 
        [Handles_Handles] = 163                   ' <Handles> ::= Handles <ID List>
        [Property_Property_Id_End_Property] = 164 ' <Property> ::= <Attributes> <Modifiers> Property ID <Param List> <Type> <NL> <Property Items> End Property <NL>
        [Propertyitems] = 165                     ' <Property Items> ::= <Property Item> <Property Items>
        [Propertyitems2] = 166                    ' <Property Items> ::= 
        [Propertyitem_Get_End_Get] = 167          ' <Property Item> ::= Get <NL> <Statements> End Get <NL>
        [Propertyitem_Set_End_Set] = 168          ' <Property Item> ::= Set <Param List> <NL> <Statements> End Set <NL>
        [Enumeration_Enum_Id_End_Enum] = 169      ' <Enumeration> ::= <Attributes> <Modifiers> Enum ID <NL> <Enum List> End Enum <NL>
        [Enumlist] = 170                          ' <Enum List> ::= <Enum Item> <Enum List>
        [Enumlist2] = 171                         ' <Enum List> ::= 
        [Enumitem_Id_Eq] = 172                    ' <Enum Item> ::= ID '=' <Expression> <NL>
        [Enumitem_Id] = 173                       ' <Enum Item> ::= ID <NL>
        [Vardecl_Comma] = 174                     ' <Var Decl> ::= <Var Decl Item> ',' <Var Decl>
        [Vardecl] = 175                           ' <Var Decl> ::= <Var Decl Item>
        [Vardeclitem_As] = 176                    ' <Var Decl Item> ::= <Var Decl ID> As <Identifier> <Argument List Opt>
        [Vardeclitem_As_Eq] = 177                 ' <Var Decl Item> ::= <Var Decl ID> As <Identifier> '=' <Expression>
        [Vardeclitem_As_New] = 178                ' <Var Decl Item> ::= <Var Decl ID> As New <Identifier> <Argument List Opt>
        [Vardeclitem_As_List_Lparen_Of_Id_Rparen] = 179 ' <Var Decl Item> ::= <Var Decl ID> As <New opt> List '(' of ID ')'
        [Vardeclitem] = 180                       ' <Var Decl Item> ::= <Var Decl ID>
        [Vardeclitem_Eq] = 181                    ' <Var Decl Item> ::= <Var Decl ID> '=' <Expression>
        [Newopt_New] = 182                        ' <New opt> ::= New
        [Newopt] = 183                            ' <New opt> ::= 
        [Vardeclid_Id] = 184                      ' <Var Decl ID> ::= ID <Argument List Opt>
        [Statements] = 185                        ' <Statements> ::= <Statement> <Statements>
        [Statements2] = 186                       ' <Statements> ::= 
        [Statement] = 187                         ' <Statement> ::= <Loop Stm>
        [Statement2] = 188                        ' <Statement> ::= <For Stm>
        [Statement3] = 189                        ' <Statement> ::= <If Stm>
        [Statement4] = 190                        ' <Statement> ::= <Select Stm>
        [Statement5] = 191                        ' <Statement> ::= <SyncLock Stm>
        [Statement6] = 192                        ' <Statement> ::= <Try Stm>
        [Statement7] = 193                        ' <Statement> ::= <With Stm>
        [Statement8] = 194                        ' <Statement> ::= <Option Decl>
        [Statement9] = 195                        ' <Statement> ::= <Local Decl>
        [Statement10] = 196                       ' <Statement> ::= <Non-Block Stm> <NL>
        [Statement_Label] = 197                   ' <Statement> ::= LABEL <NL>
        [Nonblockstm_Call] = 198                  ' <Non-Block Stm> ::= Call <Variable>
        [Nonblockstm_Redim] = 199                 ' <Non-Block Stm> ::= ReDim <Var Decl>
        [Nonblockstm_Redim_Preserve] = 200        ' <Non-Block Stm> ::= ReDim Preserve <Var Decl>
        [Nonblockstm_Erase_Id] = 201              ' <Non-Block Stm> ::= Erase ID
        [Nonblockstm_Throw] = 202                 ' <Non-Block Stm> ::= Throw <Expression>
        [Nonblockstm_Raiseevent] = 203            ' <Non-Block Stm> ::= RaiseEvent <Identifier> <Argument List Opt>
        [Nonblockstm_Addhandler_Comma] = 204      ' <Non-Block Stm> ::= AddHandler <Expression> ',' <Expression>
        [Nonblockstm_Removehandler_Comma] = 205   ' <Non-Block Stm> ::= RemoveHandler <Expression> ',' <Expression>
        [Nonblockstm_Exit_Do] = 206               ' <Non-Block Stm> ::= Exit Do
        [Nonblockstm_Exit_For] = 207              ' <Non-Block Stm> ::= Exit For
        [Nonblockstm_Exit_Function] = 208         ' <Non-Block Stm> ::= Exit Function
        [Nonblockstm_Exit_Property] = 209         ' <Non-Block Stm> ::= Exit Property
        [Nonblockstm_Exit_Select] = 210           ' <Non-Block Stm> ::= Exit Select
        [Nonblockstm_Exit_Sub] = 211              ' <Non-Block Stm> ::= Exit Sub
        [Nonblockstm_Exit_Try] = 212              ' <Non-Block Stm> ::= Exit Try
        [Nonblockstm_Exit_While] = 213            ' <Non-Block Stm> ::= Exit While
        [Nonblockstm_Goto_Id] = 214               ' <Non-Block Stm> ::= GoTo ID
        [Nonblockstm_Return] = 215                ' <Non-Block Stm> ::= Return <Expression>
        [Nonblockstm_Error] = 216                 ' <Non-Block Stm> ::= Error <Expression>
        [Nonblockstm_On_Error_Goto_Intliteral] = 217 ' <Non-Block Stm> ::= On Error GoTo IntLiteral
        [Nonblockstm_On_Error_Goto_Minus_Intliteral] = 218 ' <Non-Block Stm> ::= On Error GoTo '-' IntLiteral
        [Nonblockstm_On_Error_Goto_Id] = 219      ' <Non-Block Stm> ::= On Error GoTo ID
        [Nonblockstm_On_Error_Resume_Next] = 220  ' <Non-Block Stm> ::= On Error Resume Next
        [Nonblockstm_Resume_Id] = 221             ' <Non-Block Stm> ::= Resume ID
        [Nonblockstm_Resume_Next] = 222           ' <Non-Block Stm> ::= Resume Next
        [Nonblockstm] = 223                       ' <Non-Block Stm> ::= <Variable> <Assign Op> <Expression>
        [Nonblockstm2] = 224                      ' <Non-Block Stm> ::= <Variable>
        [Nonblockstm3] = 225                      ' <Non-Block Stm> ::= <Method Call>
        [Assignop_Eq] = 226                       ' <Assign Op> ::= '='
        [Assignop_Careteq] = 227                  ' <Assign Op> ::= '^='
        [Assignop_Timeseq] = 228                  ' <Assign Op> ::= '*='
        [Assignop_Diveq] = 229                    ' <Assign Op> ::= '/='
        [Assignop_Backslasheq] = 230              ' <Assign Op> ::= '\='
        [Assignop_Pluseq] = 231                   ' <Assign Op> ::= '+='
        [Assignop_Minuseq] = 232                  ' <Assign Op> ::= '-='
        [Assignop_Ampeq] = 233                    ' <Assign Op> ::= '&='
        [Assignop_Ltlteq] = 234                   ' <Assign Op> ::= '<<='
        [Assignop_Gtgteq] = 235                   ' <Assign Op> ::= '>>='
        [Localdecl_Dim] = 236                     ' <Local Decl> ::= Dim <Var Decl> <NL>
        [Localdecl_Const] = 237                   ' <Local Decl> ::= Const <Var Decl> <NL>
        [Localdecl_Static] = 238                  ' <Local Decl> ::= Static <Var Decl> <NL>
        [Loopstm_Do_Loop] = 239                   ' <Loop Stm> ::= Do <Test Type> <Expression> <NL> <Statements> Loop <NL>
        [Loopstm_Do_Loop2] = 240                  ' <Loop Stm> ::= Do <NL> <Statements> Loop <Test Type> <Expression> <NL>
        [Loopstm_While_End_While] = 241           ' <Loop Stm> ::= While <Expression> <NL> <Statements> End While <NL>
        [Testtype_While] = 242                    ' <Test Type> ::= While
        [Testtype_Until] = 243                    ' <Test Type> ::= Until
        [Forstm_For_To_Next] = 244                ' <For Stm> ::= For <Var Decl Item> To <Expression> <Step Opt> <NL> <Statements> Next <NL>
        [Forstm_For_Each_In_Next] = 245           ' <For Stm> ::= For Each <Variable> <Type> In <Variable> <NL> <Statements> Next <NL>
        [Stepopt_Step] = 246                      ' <Step Opt> ::= Step <Expression>
        [Stepopt] = 247                           ' <Step Opt> ::= 
        [Ifstm_If] = 248                          ' <If Stm> ::= If <Expression> <Then Opt> <NL> <Statements> <If Blocks> <end if> <NL>
        [Ifstm_If_Then] = 249                     ' <If Stm> ::= If <Expression> Then <Non-Block Stm> <NL>
        [Ifstm_If_Then_Else] = 250                ' <If Stm> ::= If <Expression> Then <Non-Block Stm> Else <Non-Block Stm> <NL>
        [Thenopt_Then] = 251                      ' <Then Opt> ::= Then
        [Thenopt] = 252                           ' <Then Opt> ::= 
        [Ifblocks] = 253                          ' <If Blocks> ::= <else if> <Expression> <Then Opt> <NL> <Statements> <If Blocks>
        [Ifblocks_Else] = 254                     ' <If Blocks> ::= Else <NL> <Statements>
        [Ifblocks2] = 255                         ' <If Blocks> ::= 
        [Elseif_Elseif] = 256                     ' <else if> ::= ElseIf
        [Elseif_Else_If] = 257                    ' <else if> ::= Else If
        [Endif_End_If] = 258                      ' <end if> ::= End If
        [Endif_Endif] = 259                       ' <end if> ::= EndIf
        [Selectstm_Select_End_Select] = 260       ' <Select Stm> ::= Select <Case Opt> <Expression> <NL> <Select Blocks> End Select <NL>
        [Caseopt_Case] = 261                      ' <Case Opt> ::= Case
        [Caseopt] = 262                           ' <Case Opt> ::= 
        [Selectblocks_Case] = 263                 ' <Select Blocks> ::= Case <Case Clauses> <NL> <Statements> <Select Blocks>
        [Selectblocks_Case_Else] = 264            ' <Select Blocks> ::= Case Else <NL> <Statements>
        [Selectblocks] = 265                      ' <Select Blocks> ::= 
        [Caseclauses_Comma] = 266                 ' <Case Clauses> ::= <Case Clause> ',' <Case Clauses>
        [Caseclauses] = 267                       ' <Case Clauses> ::= <Case Clause>
        [Caseclause] = 268                        ' <Case Clause> ::= <Is Opt> <Compare Op> <Expression>
        [Caseclause2] = 269                       ' <Case Clause> ::= <Expression>
        [Caseclause_To] = 270                     ' <Case Clause> ::= <Expression> To <Expression>
        [Isopt_Is] = 271                          ' <Is Opt> ::= Is
        [Isopt] = 272                             ' <Is Opt> ::= 
        [Synclockstm_Synclock_End_Synclock] = 273 ' <SyncLock Stm> ::= SyncLock <NL> <Statements> End SyncLock <NL>
        [Trystm_Try_End_Try] = 274                ' <Try Stm> ::= Try <NL> <Statements> <Catch Blocks> End Try <NL>
        [Catchblocks] = 275                       ' <Catch Blocks> ::= <Catch Block> <Catch Blocks>
        [Catchblocks2] = 276                      ' <Catch Blocks> ::= <Catch Block>
        [Catchblock_Catch_As_Id] = 277            ' <Catch Block> ::= Catch <Identifier> As ID <NL> <Statements>
        [Catchblock_Catch] = 278                  ' <Catch Block> ::= Catch <NL> <Statements>
        [Withstm_With_End_With] = 279             ' <With Stm> ::= With <Value> <NL> <Statements> End With <NL>
        [Expression_Or] = 280                     ' <Expression> ::= <And Exp> Or <Expression>
        [Expression_Orelse] = 281                 ' <Expression> ::= <And Exp> OrElse <Expression>
        [Expression_Xor] = 282                    ' <Expression> ::= <And Exp> XOr <Expression>
        [Expression] = 283                        ' <Expression> ::= <And Exp>
        [Andexp_And] = 284                        ' <And Exp> ::= <Not Exp> And <And Exp>
        [Andexp_Andalso] = 285                    ' <And Exp> ::= <Not Exp> AndAlso <And Exp>
        [Andexp] = 286                            ' <And Exp> ::= <Not Exp>
        [Notexp_Not] = 287                        ' <Not Exp> ::= NOT <Compare Exp>
        [Notexp] = 288                            ' <Not Exp> ::= <Compare Exp>
        [Compareexp] = 289                        ' <Compare Exp> ::= <Shift Exp> <Compare Op> <Compare Exp>
        [Compareexp_Typeof_Is] = 290              ' <Compare Exp> ::= TypeOf <Add Exp> Is <Object>
        [Compareexp_Is] = 291                     ' <Compare Exp> ::= <Shift Exp> Is <Object>
        [Compareexp_Like] = 292                   ' <Compare Exp> ::= <Shift Exp> Like <Value>
        [Compareexp2] = 293                       ' <Compare Exp> ::= <Shift Exp>
        [Shiftexp_Ltlt] = 294                     ' <Shift Exp> ::= <Concat Exp> '<<' <Shift Exp>
        [Shiftexp_Gtgt] = 295                     ' <Shift Exp> ::= <Concat Exp> '>>' <Shift Exp>
        [Shiftexp] = 296                          ' <Shift Exp> ::= <Concat Exp>
        [Concatexp_Amp] = 297                     ' <Concat Exp> ::= <Add Exp> '&' <Concat Exp>
        [Concatexp] = 298                         ' <Concat Exp> ::= <Add Exp>
        [Addexp_Plus] = 299                       ' <Add Exp> ::= <Modulus Exp> '+' <Add Exp>
        [Addexp_Minus] = 300                      ' <Add Exp> ::= <Modulus Exp> '-' <Add Exp>
        [Addexp] = 301                            ' <Add Exp> ::= <Modulus Exp>
        [Modulusexp_Mod] = 302                    ' <Modulus Exp> ::= <Int Div Exp> Mod <Modulus Exp>
        [Modulusexp] = 303                        ' <Modulus Exp> ::= <Int Div Exp>
        [Intdivexp_Backslash] = 304               ' <Int Div Exp> ::= <Mult Exp> '\' <Int Div Exp>
        [Intdivexp] = 305                         ' <Int Div Exp> ::= <Mult Exp>
        [Multexp_Times] = 306                     ' <Mult Exp> ::= <Negate Exp> '*' <Mult Exp>
        [Multexp_Div] = 307                       ' <Mult Exp> ::= <Negate Exp> '/' <Mult Exp>
        [Multexp] = 308                           ' <Mult Exp> ::= <Negate Exp>
        [Negateexp_Minus] = 309                   ' <Negate Exp> ::= '-' <Power Exp>
        [Negateexp] = 310                         ' <Negate Exp> ::= <Power Exp>
        [Powerexp_Caret] = 311                    ' <Power Exp> ::= <Power Exp> '^' <Value>
        [Powerexp] = 312                          ' <Power Exp> ::= <Value>
        [Value_Lparen_Rparen] = 313               ' <Value> ::= '(' <Expression> ')'
        [Value_New] = 314                         ' <Value> ::= New <Identifier> <Argument List Opt>
        [Value_Me] = 315                          ' <Value> ::= Me
        [Value_Myclass] = 316                     ' <Value> ::= MyClass
        [Value_Mybase] = 317                      ' <Value> ::= MyBase
        [Value] = 318                             ' <Value> ::= <Const Item>
        [Value2] = 319                            ' <Value> ::= <Variable>
        [Value_If_Lparen_Comma_Comma_Rparen] = 320 ' <Value> ::= If '(' <Expression> ',' <Expression> ',' <Expression> ')'
        [Value3] = 321                            ' <Value> ::= <const array>
        [Constarray_Lbrace_Rbrace] = 322          ' <const array> ::= '{' <Const Params> '}'
        [Constarray_Lbrace_Rbrace2] = 323         ' <const array> ::= '{' '}'
        [Constparams_Comma] = 324                 ' <Const Params> ::= <Const Item> ',' <Const Params>
        [Constparams] = 325                       ' <Const Params> ::= <Const Item>
        [Constitem_Intliteral] = 326              ' <Const Item> ::= IntLiteral
        [Constitem_Hexliteral] = 327              ' <Const Item> ::= HexLiteral
        [Constitem_Octliteral] = 328              ' <Const Item> ::= OctLiteral
        [Constitem_Stringliteral] = 329           ' <Const Item> ::= StringLiteral
        [Constitem_Charliteral] = 330             ' <Const Item> ::= CharLiteral
        [Constitem_Realliteral] = 331             ' <Const Item> ::= RealLiteral
        [Constitem_Dateliteral] = 332             ' <Const Item> ::= DateLiteral
        [Constitem_True] = 333                    ' <Const Item> ::= True
        [Constitem_False] = 334                   ' <Const Item> ::= False
        [Constitem_Nothing] = 335                 ' <Const Item> ::= Nothing
        [Constitem_Addressof] = 336               ' <Const Item> ::= AddressOf <Variable>
        [Object] = 337                            ' <Object> ::= <Identifier>
        [Object_Me] = 338                         ' <Object> ::= Me
        [Object_Myclass] = 339                    ' <Object> ::= MyClass
        [Object_Mybase] = 340                     ' <Object> ::= MyBase
        [Object_Nothing] = 341                    ' <Object> ::= Nothing
        [Variable] = 342                          ' <Variable> ::= <Identifier> <Argument List Opt> <Method Calls>
        [Methodcalls] = 343                       ' <Method Calls> ::= <Method Call> <Method Calls>
        [Methodcalls2] = 344                      ' <Method Calls> ::= 
        [Methodcall_Memberid] = 345               ' <Method Call> ::= MemberID <Argument List Opt>
        [Identifier_Id] = 346                     ' <Identifier> ::= ID
        [Identifier_Qualifiedid] = 347            ' <Identifier> ::= QualifiedID
    End Enum

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'valore Data Type
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public tipo_de_Dados_em_bytes() As Integer = {1, 1, 2, 2, 4, 4, 2, 2, 4, 4}
    Public tipo_de_Dados_String() As String = New String() {"ubyte", "sbyte", "uword", "sword", "ulong", "slong", "ufixed", "sfixed", "usingle", "ssingle"}
    Public Tipo_Identificador_String() As String = New String() {"Equal", "Variavel Global", "Variavel Local", "Funcao", "Subrotina", "Structure", "Structure", "Label"}

    Public Const Tipo_Identificador_Equal As Integer = 0
    Public Const Tipo_Identificador_Var_G As Integer = 1
    Public Const Tipo_Identificador_Var_L As Integer = 2
    Public Const Tipo_Identificador_Funct As Integer = 3
    Public Const Tipo_Identificador_Subrt As Integer = 4
    Public Const Tipo_Identificador_Def_Struct As Integer = 5
    Public Const Tipo_Identificador_Struct As Integer = 6
    Public Const Tipo_Identificador_Label As Integer = 7



    Public Const Data_type_ubyte As Integer = 0
    Public Const Data_type_sbyte As Integer = 1
    Public Const Data_type_uword As Integer = 2
    Public Const Data_type_sword As Integer = 3
    Public Const Data_type_ulong As Integer = 4
    Public Const Data_type_slong As Integer = 5
    Public Const Data_type_ufixed As Integer = 6
    Public Const Data_type_sfixed As Integer = 7
    Public Const Data_type_usingle As Integer = 8
    Public Const Data_type_ssingle As Integer = 9
End Module
