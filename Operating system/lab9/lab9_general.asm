.686P
.model FLAT, STDCALL
.stack 4096

.data
MB_OK	EQU	0
STR1	DB  "Lab 9 (General)",    0
STR2 	DB	256 DUP (0)
STR3  DB  "%d - Is simple",     0
STR4  DB  "%d - Is not simple", 0
HW	  DD  ?
n     DW  181 ; simple
;n     DW  182 ; not simple

EXTERN wsprintfA:NEAR
EXTERN MessageBoxA@16:NEAR

.code
START:
  xor ecx, ecx
  lea ebx, STR3
  mov cl, 2

m1:
  mov ax, [n]
  xor dx, dx
  div cx
  inc cl
  cmp cx, [n]
  jae m2
  test dx, dx
  jnz m1
  lea ebx, STR4

m2:
  push DWORD PTR n
  push ebx
  push OFFSET STR2
  call wsprintfA

  add esp, 12

  push MB_OK
  push OFFSET STR1
  push OFFSET STR2
  push HW
  call MessageBoxA@16
  ret
END START