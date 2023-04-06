.686P
.model	FLAT, STDCALL
.stack	4096

.data
MB_OK	EQU	0
STR1	DB	"Lab 5.2", 0
STR2 	DB	256 DUP (0)
STR3 	DB 	"a=%d; b=%d", 0
HW		DD	?
a 		DD 	11
b 		DD 	265

EXTERN	MessageBoxA@16:NEAR
EXTERN 	wsprintfA:NEAR

.code
START:
	mov eax, a
	mov ebx, b
	xchg eax, ebx
	mov a, eax
	mov b, ebx

	push b
	push a
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
