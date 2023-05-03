.686P
.model FLAT, STDCALL
.stack 4096
 
.data
MB_OK	EQU	0
STR1	DB	"Lab 6", 0
STR2 	DB	256 DUP (0)
STR3 DB "a = %d", 13, 10, \
        "b = %d", 13, 10, \
        "c = %d", 13, 10, \
        "d = %d", 13, 10, \
        "eq1 = %d", 13, 10, \
        "eq2 = %d", 13, 10, \
        "x = %d", 0
HW	DD	?
a   DD 4
b   DD 8
_c  DD 2
d   DD -10
x   DD ?
eq1 DD ?
eq2 DD ?

EXTERN MessageBoxA@16:NEAR
EXTERN wsprintfA:NEAR

.code
START:
  ; Solve: a * b / 10
  mov eax, a      ; move the value a to the eax register
  mov ebx, 10     ; move the number 10 to the ebx register
  imul d          ; multiply eax by b and save the result to edx:eax
  idiv ebx        ; divide edx:eax by ebx and store the result in eax
  mov eq1, eax    ; move the value of eax to the variable eq1

  ; Solve: b^2 + d^2 + 28
  mov eax, b      ; move the value of b to the eax register
  imul b          ; multiply eax by b and save the result to edx:eax
  xchg eax, ebx   ; exchange the values of eax and ebx
  mov eax, d      ; move the value of d to the eax register
  imul d          ; multiply eax by d and store the result in edx:eax
  add eax, ebx    ; add ebx to eax and store the result in eax
  add eax, 28     ; add 28 to eax and store the result in eax

  ; Save the result of the numerator to edx  
  xchg eax, ebx   ; Store the result of the numerator in edx

  ; Solve the problem: a * c^3
  mov eax, a      ; move the value of a to the eax register
  imul _c         ; multiply eax by the variable _c and store the result in edx:eax
  imul _c         ; multiply eax by the variable _c and store the result in edx:eax
  imul _c         ; multiply eax by variable _c and store the result in edx:eax

  ; Divide the numerator by the denominator
  xchg eax, ebx   ; exchange the values of eax and ebx
  idiv ebx        ; divide edx:eax by ebx and store the result in eax
  mov eq2, eax    ; move the value of eax to the variable eq2

  ; Solve the problem: eq1 + eq2
  mov eax, eq1    ; move the value of the variable eq1 to the eax register
  mov ebx, eq2    ; move the value of the variable eq2 to the ebx register
  add eax, ebx    ; add ebx to eax and store the result in eax
  mov x, eax      ; move the value of eax to the variable x

  push x
  push eq2
  push eq1
  push d
  push _c
  push b
  push a
  push OFFSET STR3
  push OFFSET STR2
  call wsprintfA
 
  add esp, 32
 
  push MB_OK
  push OFFSET STR1
  push OFFSET STR2
  push HW
  call MessageBoxA@16
  ret
END START