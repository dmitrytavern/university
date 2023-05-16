.686P
.model FLAT, STDCALL
.stack 4096
 
.data
MB_OK	EQU	0
STR1	DB  "Lab 8.1",          0
STR2 	DB	256                 DUP (0)
STR3  DB  "Min: %d Max: %d",  0
HW	  DD  ?
a     DD  3
b     DD  1
_c    DD  2

EXTERN MessageBoxA@16:NEAR
EXTERN wsprintfA:NEAR

.code
START:
  mov eax, a		; max
  mov ebx, b		; min
  mov ecx, _c

  ; if a >= b
  cmp eax, ebx
  jge check_c_max
  xchg eax, ebx

check_c_max:
  ; if max >= c
  cmp eax, ecx
  jge check_c_min
  mov eax, ecx

check_c_min:
  ; if min <= c
  cmp ebx, ecx
  jle check_end
  mov ebx, ecx

check_end:
  push eax
  push ebx
  push OFFSET STR3
  push OFFSET STR2
  call wsprintfA
 
  add esp, 16

  push MB_OK
  push OFFSET STR1
  push OFFSET STR2
  push HW
  call MessageBoxA@16
  ret  
END START