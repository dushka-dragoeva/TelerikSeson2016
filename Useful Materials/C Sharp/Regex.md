# **Regex**

## Literal

\/<regex>/<options>

### Symbols
[0-9]+ maches non-empty sequence of digits

[A-Z][a-z]*maches a capital and  small letters

\s+ maches whitespace (non-empty)

\S+ maches non-whitespace

\d+ maches sequence digits

\D+ maches sequence non-digits

\w+ maches sequence letters

\W+ maches sequence non-letters

### Length

{1,3} - length 1-3 symbols

{5, } - length 5+ symbols

[a-z]+ maches sequence

### Special symbols

+ - for sequence else maches a single symbol

*
| - or

? - can present or no after the symbol

^ - maches start of text or line

$ - maches end of text or line

^.....$ the regex must match exactly from start to end . If there is a partitial coincidence it doesn't match

### Flags

g -  maches all, without g maches first

i - case insensetive maches small and capital letters

m -multiline


### Escaping special symbols

\ 



### Examples:

Tel. Number

\+\d{1,3}
