# Reverse Polish notation

## Description
Your task is to calculate an expression. The expression is given in Reverse Polish notation.

Reverse Polish notation (RPN) is a mathematical notation in which every operator follows all of its operands.

- _Examples:_

| Infix notation | Reverse Polish (postfix notation) |
|:---------------|:----------------------------------|
| `5 + 3`        | `5 3 +`                           |
| `3 * 4 + 5`    | `3 4 * 5 +`                       |
| `3 * (4 + 5)`  | `3 4 5 + *`                       |
| `3 + 4 * 5`    | `3 4 5 * +`                       |
| `(3 + 4) * 5`  | `3 4 + 5 *`                       |

- _Notice there are no brackets in RPN_

- [Read more](https://en.wikipedia.org/wiki/Reverse_Polish_notation)

## Input
- A single line is given as input
  - The RPN expression

## Output
- Output a single number on a single line
  - The result of the expression

## Constraints
- **3** <= **length of expression** <= **300 000**
- All numbers will be integer and in the interval `[0; 1000]`
- All operations will be arithmetic (`+`, `-`, `*`, `/`) and bitwise (`&`, `|`, `^`)
  - `/` means integer division
  - No divisions by `0` will occur
- Time limit: **0.2 seconds**
- Memory limit: **16 MB**

## Sample test

### Sample test 1

#### Input
```
7 8 +
```

#### Output
```
15
```

### Sample test 2

#### Input
```
3 4 5 * +
```

#### Output
```
23
```

### Sample test 3

#### Input
```
254 488 & 61 / 771 24 | * 394 3 428 | 141 171 & + | / 654 *
```

#### Output
```
1308
```
