.686P
.model FLAT, STDCALL
.stack 4096
 
.data
MB_OK	EQU	0
STR1	DB  "Lab 8.2",                0
STR2  DB  "Is an even number",      0
STR3  DB  "Is not an even number",  0
HW	  DD  ?
TWO   DD  2
ZERO  DD  0
a     DD  120

EXTERN MessageBoxA@16:NEAR

.code
START:
  xor eax, eax
  xor ebx, ebx
  xor edx, edx

  mov eax, a
  mov ebx, TWO
  idiv ebx
  mov eax, edx

  lea ebx, STR3

  cmp eax, ZERO
  jne print_end
  lea ebx, STR2

print_end:
  push MB_OK
  push OFFSET STR1
  push ebx
  push HW
  call MessageBoxA@16
  ret
END START
