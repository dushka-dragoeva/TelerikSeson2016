# Doge++

## Description
Remember **Doge** the dog? He needs your help again. He is in the top left corner of a field that has some enemies in it.
As you might remember, **Doge** cannot step on these cells. He can move only **down** or **right**. But he can also make at most **K** moves **up** and **left**.

![doge labyrinth](https://raw.githubusercontent.com/TelerikAcademy/Data-Structures-and-Algorithms/master/Topics/08.%20Dynamic-Programming/imgs/labirynth.png)

Your task is, by given size of the field, locations of the enemies and **K**, to find out in how many unique ways can **Doge** get from the top left cell to the bottom right cell.

## Input
- On the first line, you will receive the numbers **R**, **C** and **K**
  - **R** is the number of rows
  - **C** is the number of columns
  - **K** is **K**
- On the second line you will receive pairs of enemy coordinates, separated by `;`

## Output
- On a single line, output the number of unique ways for **Doge** to reach the bottom right cell

## Constraints
- 5 <= **R** <= 30
- 5 <= **C** <= 30
- 0 <= **K** <= 5
- **K** will be **0** in 50% of the tests
- **Time limit**: **0.03 seconds**
- **Memory limit**: **16 MB**

## Sample test

### Sample test 1

#### Input
```
5 5 0
1 1
```

#### Output
```
30
```

### Sample test 2

#### Input
```
5 5 0
3 4
```

#### Output
```
35
```

### Sample test 3

#### Input
```
5 5 1
2 3
```

#### Output
```
4692
```

### Sample test 4

#### Input
```
5 5 1
2 3;1 1
```

#### Output
```
923
```
