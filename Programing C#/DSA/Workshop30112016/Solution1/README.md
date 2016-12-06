# Find number

## Description

You are given an array of **N** strings (may be unsorted). Find the number at index **K** if the array was sorted lexicographically.

## Input
- **N** and **K** are read from the first line
  - Separated with a space
- The array of strings is read from the second line
  - Strings are separated by spaces

## Output
- Output the number on a single line

## Constraints
- **1** <= **N** <= **100 000**
- Strings will be consisted of alphanumerical characters
- Strings will be of length no more than **10**
- Time limit: **0.2 seconds**
- Memory limit: **64 MB**

## Sample test

### Sample test 1

#### Input
```
5 2
2 8 4 7 8
```

#### Output
```
7
```

### Sample test 2

#### Input
```
8 3
3 2 1 3 5 5 4 3
```

#### Output
```
3
```

### Sample test 3

#### Input
```
10 8
4 8 10 8 15 11 4 9 19 -17
```

#### Output
```
8
```
