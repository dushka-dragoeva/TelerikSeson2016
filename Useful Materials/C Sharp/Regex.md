# **Regex**

## Literal

/\<regex\>/\<options\>

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

\+ - for sequence else maches a single symbol
maches the preceding expression 1 or more times

* - maches the preceding expression 0 or more times

. The desimal point matches any single character exept the newline character

For example, /.n/ matches 'an' and 'on' in "nay, an apple is on the tree", but not 'nay'.

.* matches any whole string

| - or

? - can present or no after the symbol. Matches the preceding expression 0 or 1 time - equivalent to {0,1}

/\d+/ to "123abc" matches "123". But applying /\d+?/ to that same string matches only the "1".

^ - maches start of text or line

$ - maches end of text or line

^.....$ the regex must match exactly from start to end . If there is a partitial coincidence it doesn't match

[] char set
[^ae] - matches anything but not ae. A negated or complemented character set

() - for grouping

### Flags

g -  maches all, without g maches first

i - case insensetive maches small and capital letters

m -multiline


### Escaping special symbols

\ 



### Examples:

Tel. Number in input field

^\+\d{1,3}([ -]*[0-9]){6,}$ 

E-mail
RFC 822

/^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,20}$/i
