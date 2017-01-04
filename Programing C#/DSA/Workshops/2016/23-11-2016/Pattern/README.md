# Pattern

## Description
Your task is to draw a broken line.

The number **N** represents the size of the line
  - The line for `N = 1` looks like:<br/>
![1](SVGs/1.svg)
  - The line for `N = 2` can be build from the line `N = 1`:<br/>
![2](SVGs/2.svg)
  - The line for `N = 3` can be build from the line `N = 2`:<br/>
![3](SVGs/3.svg)
  - The line for `N = 4` can be build from the line `N = 3`:<br/>
![4](SVGs/4.svg)
  - The line for `N = 5` can be build from the line `N = 4`:<br/>
![5](SVGs/5.svg)
  - And so on...

Describe the line for a given **N** as a string of directions: `u`, `d`, `l`, `r` (up, down, left, right)
starting from the **bottom left** corner and ending in the **bottom right** one.

The `Svg.WriteToFile` method is provided for easy visualization of what you are doing. You can see how to use it [here](./Pattern/Main.cs).

## Input
- **N** is read from the input on single line

## Output
- Output a sequence of directions describing the line on single line

## Constraints
- **1** <= **N** <= **10**
- Time limit: **0.2 seconds**
- Memory limit: **32 MB**

## Sample test

### Sample test 1

#### Input
```
1
```

#### Output
```
urd
```

### Sample test 2

#### Input
```
2
```

#### Output
```
ruluurdrurddldr
```

### Sample test 3

#### Input
```
3
```

#### Output
```
urdrrulurulldluuruluurdrurddldrrruluurdrurddldrddlulldrdldrrurd
```
