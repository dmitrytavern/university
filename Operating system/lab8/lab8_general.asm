.686P
.model FLAT, STDCALL
.stack 4096
 
.data
MB_OK	EQU	0
STR1	DB  "Lab 8 (General)",  0
STR2  DB  "Yes",    0
STR3  DB  "No",     0
HW	  DD  ?
a     DW  123
b     DW  23
_c    DW  123

EXTERN MessageBoxA@16:NEAR

.code
START:
  xor eax, eax
  mov ax, a
  lea ebx, STR3
  cmp ax, b
  jne m
  cmp ax, _c
  jne m
  lea ebx, STR2

m:  
  push MB_OK
  push OFFSET STR1
  push ebx
  push HW
  call MessageBoxA@16
  ret
END START
