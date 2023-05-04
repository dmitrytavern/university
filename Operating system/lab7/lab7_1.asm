.686P
.model FLAT, STDCALL
.stack 4096
 
.data
MB_OK	EQU	0
STR1	DB	"Lab 7", 0
STR2 	DB	256 DUP (0)
STR3 DB "a = %d", 13, 10, \
        "b = %d", 13, 10, \
        "c = %d", 13, 10, \
        "d = %d", 13, 10, \
        "x = %d", 0
HW	DD	?
a   DD 4
b   DD 8
_c  DD 2
d   DD -10

EXTERN MessageBoxA@16:NEAR
EXTERN wsprintfA:NEAR

.code
START:
  ; Solve: a * d / 10
  mov eax, a      ; move the value a to the eax register
  mov ebx, 10     ; move the number 10 to the ebx register
  imul d          ; multiply eax by b and save the result to edx:eax
  idiv ebx        ; divide edx:eax by ebx and store the result in eax
  mov ecx, eax    ; move the value of eax to the ecx register

  ; Solve: a * c^3
  mov eax, a      ; move the value of a to the eax register
  imul _c         ; multiply eax by the variable _c and store the result in edx:eax
  imul _c         ; multiply eax by the variable _c and store the result in edx:eax
  imul _c         ; multiply eax by the variable _c and store the result in edx:eax
  push eax

  ; Solve: b^2 + d^2 + 28
  mov eax, b      ; move the value of b to the eax register
  imul b          ; multiply eax by b and save the result to edx:eax
  mov ebx, eax    ; exchange the values of eax and ebx
  mov eax, d      ; move the value of d to the eax register
  imul d          ; multiply eax by d and store the result in edx:eax
  add eax, ebx    ; add ebx to eax and store the result in eax
  add eax, 28     ; add 28 to eax and store the result in eax

  ; Divide the numerator by the denominator
  pop ebx
  idiv ebx        ; divide edx:eax by ebx and store the result in eax

  ; Solve: eq1 + eq2
  add eax, ecx    ; add ebx to eax and store the result in eax
  push eax        ; move the value of eax to the stack

  push d
  push _c
  push b
  push a
  push OFFSET STR3
  push OFFSET STR2
  call wsprintfA
 
  add esp, 28
 
  push MB_OK
  push OFFSET STR1
  push OFFSET STR2
  push HW
  call MessageBoxA@16
  ret
END START