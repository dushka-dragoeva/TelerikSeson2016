# Source

## Description

An important problem of software maintenance is to track down duplication in a large software system. One would like to find not only exact matches between sections of code, but parameterized matches, where a parameterized match between two sections of code means that one section can be transformed into the other by replacing the parameter names (e.g., identifiers and constants) of one section by the parameter names of the other via a one-to-one (bijective) function.

Let **Σ** and **Π** be two alphabets: **Σ** is the upper case English alphabet and **Π** is the lower case English alphabet. Each symbol in **Σ** represents a token and each symbol in **Π** represents a parameter.

A string can consist of any combinations of tokens and parameters fro m **Σ** and **Π**. Two strings **A** and **B** are said to _p_-match if and only if:
* **A** and **B** have the same length (more formally: length(**A**) = length(**B**))
*  Each token in **A** matches a token in **B** and each parameter in **A** matches a parameter in **B** (more formally: ( **A** i is a token and **B** i is a token) or ( **A** i is a parameter and **B** i is a parameter) for any 1 <= i <= length(**A**))
*  The alignment of tokens in **A** and **B** is a perfect match (more formally: if **A** i is a token then **A** i = **B** i for any 1 <= i <= length(**A**))
*  The alignment of parameters in **A** and **B** defines a one-to-one correspondence between parameter names in **A** and parameter names in **B** (more formally: there exists a one-to-one (bijective) function _f_ : **Π** → **Π** such that if **A** i is a parameter _f_(**A** i) = **B** i for any 1 <= i <= length(**A**))

A token represents a part of the program that cannot be changed, whereas a parameter represents a program's variable, which can be renamed as long as all occurrences of the varia ble are renamed consistently. Thus if **A** and **B** _p_-match, then the variable names in **A** could be changed to the corresponding variable names in **B**, making the two programs identical. If these two problems were part of a larger program, then they could both be replaced by a call to a single subroutine.

Given a text **T** and a pattern **P**, each a string over **Σ** and **Π**, find all substrings of **T** that _p_-match **P**.

## Input
* Input is read from the console
  * **P** is read from the first line
  * **T** is read from the second line

## Output
* Output should be printed on the console
  * On the first line output the number of substrings of **T** that _p_-match **P**
  * On the second line output the offsets of those substrings
    * By convention prefixes have offset 1

## Constraints
* 1 <= length(**T**) <= 1 000 000
* 1 <= length(**P**) <= 10 000
* Time limit: **0.2 seconds**
* Memory limit: **32 MiB**

## Examples

### Example 1

#### Input
```
XYabCaCXZddbW
xXYdxCdCXZccxW
```

#### Output
```
1
2
```

#### Explanation
<code>
The pattern XYabCaCXZddbW <em>p</em>-matches the 2-offset text substring XYdxCdCXZccxW but does not <em>p</em>-match the 1-offset text substring xXYdxCdCXZccx.
Notice that when the <em>p</em>-match occurs, the following one-to-one (bijective) function <em>f</em> is used:
<br><em>f</em>(a) = d
<br><em>f</em>(b) = x
<br><em>f</em>(d) = c
</code>
