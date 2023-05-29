.686P
.model FLAT, STDCALL
.stack 4096

.data
MB_OK	EQU	0
STR1	DB  "Lab 9.1",    0
STR2 	DB	256 DUP (0)
STR3  DB  "%d - Result of sum from %d to %d", 0
HW	  DD  ?
n1    DD  2
n2    DD  5

EXTERN wsprintfA:NEAR
EXTERN MessageBoxA@16:NEAR

.code
START:
  xor eax, eax
  xor ebx, ebx
  xor ecx, ecx
  mov eax, n1
  mov ebx, n1
  mov ecx, n2

m1:
  inc ebx
  add eax, ebx
  cmp ebx, ecx
  je m2
  jmp m1

m2:
  push n2
  push n1
  push eax
  push OFFSET STR3
  push OFFSET STR2
  call wsprintfA

  add esp, 20

  push MB_OK
  push OFFSET STR1
  push OFFSET STR2
  push HW
  call MessageBoxA@16
  ret
END START