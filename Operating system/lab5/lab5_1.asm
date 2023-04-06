.686P
.model	FLAT, STDCALL
.stack	4096

.data
MB_OK	EQU	0
STR1	DB	"Lab 5.1", 0
STR2 	DB	256 DUP (0)
STR3 	DB 	"x=%d; y=%d", 0
HW		DD	?
x 		DD 	30
y 		DD 	240

EXTERN	MessageBoxA@16:NEAR
EXTERN 	wsprintfA:NEAR

.code
START:
	push x
	push y
	pop x
	pop y

	push y
	push x
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
