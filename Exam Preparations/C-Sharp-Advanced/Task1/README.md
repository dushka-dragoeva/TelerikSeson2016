<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 31 May 2016_

# Task 1: Messages

## Description

Joro and Gosho are very good friends. They love to talk and devise master plans for world domination.

Yet, **John the Evil** wants to steal their ideas. So, they have built an encryption system for communication.

The encryption system consists of **adding** or **subtracting** numbers in their GeorgeTheGreat numeral system.

The GeorgeTheGreat numeral system has **exactly 10 different digits** and **each digit consists of 3 chacters** as follows:

| Digit | Value |
| ----- | ----- |
| cad   | 0     |
| xoz   | 1     |
| nop   | 2     |
| cyk   | 3     |
| min   | 4     |
| mar   | 5     |
| kon   | 6     |
| iva   | 7     |
| ogi   | 8     |
| yan   | 9     |

Your task is to calculate the result of the operatoration, by given two numbers in GeorgeTheGreat numeral system and an operator (subtraction or addition)

## Example


```bash
markoncykyanogi - cykyan = markoncykmaryan
```

```cmd
markoncykyanogi (56398)
-
         cykyan (39)
=
markoncykmaryan (56359)

```

## Input
- On the first line you will receive the first number in GeorgeTheGreat numeral system
- On the second line you will receive the operation (subtraction or addition)
- On the third line you will receive the second number in GeorgeTheGreat numeral system

## Output
-   Print the result of the operation with the provided numbers

## Constraints

- The input will always be valid and in the described format. There is no need to validate it explicitly.
- The number of digits in any number will always be less or equal to 8192 (2^13)
- The second number will always be smaller or equal than the first
- **Time limit: 0.3 s**
- **Memory limit: 32 MB**

## Sample tests

### Input

```bash
markoncykyanogi
-
cykyan
```

### Output

```bash
markoncykmaryan
```
