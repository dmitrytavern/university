.686P
.model	FLAT, STDCALL
.stack	4096

.data
MB_OK	EQU	0
STR1	DB	"Window Title", 0
STR2	DB	"Hello World", 0
HW		DD	?

EXTERN	MessageBoxA@16:NEAR

.code
START:
	push MB_OK
	push OFFSET STR1
	push OFFSET STR2
	push HW
	call MessageBoxA@16
	ret
END START
