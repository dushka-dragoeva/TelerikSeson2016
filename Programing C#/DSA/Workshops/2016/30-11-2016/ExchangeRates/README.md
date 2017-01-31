# Exchange rates

## Description

Information about the exchange rates for the next **N** days between two currencies has leaked. You have **C** amount of **Currency1** and none of **Currency2**. Write a program which find the maximum amount of **Currency1** you could have after **N** days.

## Input
- **C** is read from the first line
- **N** is read from the second line
- Each of the next **N** lines contains two numbers, separated by a space
  - Exchange rate from **Currency1** to **Currency2**
  - Exchange rate from **Currency2** to **Currency1**

## Output
- Output a number on a single line - the maximum amount of **Currency1** you could have in the end
  - Output with **two decimal digits** of precision

## Constraints
- **1** <= **N** <= **128**
- Time limit: **0.05 seconds**
- Memory limit: **16 MB**

## Sample test

### Sample test 1

#### Input
```
10
3
3 1
2 0.8
10 0.1
```

#### Output
```
24.00
```

### Sample test 2

#### Input
```
0.685586
5
0.43236 2.10926
0.717617 1.17427
0.941989 1.30136
0.190283 2.36942
0.786466 1.7112
```

#### Output
```
1.53
```
