;#DropDB ZynEasyTest

#Application ZynWin
#Application ZynWeb
#IfDef ZynWin

*Action About...
 
*Action OK

#EndIf

#IfDef ZynWeb
!Action Navigation(My Details)
#EndIf
