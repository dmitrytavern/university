.686P
.model FLAT, STDCALL
.stack 4096
 
.data
MB_OK	EQU	0
STR1	DB	"Lab 6", 0
STR2 	DB	256 DUP (0)
STR3 DB "a = %d", 13, 10, \
        "b = %d", 13, 10, \
        "z = a + b = %d", 13, 10, \
        "y = a - b = %d", 13, 10, \
        "x = a * b = %d", 13, 10, \
        "w = a / b = %d", 13, 10, \
        "v = a %% b = %d", 13, 10, \
        "u = z + 1 = %d", 13, 10, \
        "t = y + 1 = %d", 13, 10, \
        "s = x - 1 = %d", 0
HW	DD	?
a DD -235
b DD 50
z DD ?
y DD ?
x DD ?
w DD ?
v DD ?
u DD ?
t DD ?
s DD ?

EXTERN MessageBoxA@16:NEAR
EXTERN wsprintfA:NEAR

.code
START:
  ; z = a + b
  mov eax, a
  mov ebx, b
  add eax, ebx
  mov z, eax

  ; y = a - b
  mov eax, a
  mov ebx, b
  sub eax, ebx
  mov y, eax

  ; x = a * b
  mov eax, a
  mov ebx, b
  imul ebx
  mov x, eax

  ; w = a / b
  mov eax, a
  mov ebx, b
  idiv ebx
  mov w, eax

  ; v = a % b
  mov eax, a
  mov ebx, b
  idiv ebx
  mov v, edx

  ; u = z + 1
  mov eax, z
  inc eax
  mov u, eax

  ; t = y + 1
  mov eax, y
  inc eax
  mov t, eax

  ; s = x - 1
  mov eax, x
  dec eax
  mov s, eax

  push s
  push t
  push u
  push v
  push w
  push x
  push y
  push z
  push b
  push a
  push OFFSET STR3
  push OFFSET STR2
  call wsprintfA
 
  add esp, 44
 
  push MB_OK
  push OFFSET STR1
  push OFFSET STR2
  push HW
  call MessageBoxA@16
  ret
END START