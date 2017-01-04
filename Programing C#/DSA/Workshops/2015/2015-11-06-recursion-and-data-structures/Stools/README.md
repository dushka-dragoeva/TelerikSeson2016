# Stools

## Description
Little Timmy loves to invent stupid games and you as a friend should always help him. This time Timmy decided to make a tower of stools.

There are finite number of stools. Each one of them is in the form of **cuboid**. Timmy builds his tower by taking a stool that is not already installed and places it on top of the current tower. However the stools are of different sizes and for the tower to be stable the bottom of each stool must be within the boundaries of the one below it.

Timmy can rotate stools as he wishes. Each stool can be the basis of the tower. The edges of each stool in the tower should be parallel to the relevant edges of the main stool.

Help Timmy to calculate what is **the maximum height of a tower** that can be build with available stools.

## Input
Input data is read from the console.
* On the first line there will be a natural number **N** - the number of Timmy's stools.
* On the next **N** lines there will be 3 natural numbers on each line - the dimensions of each stool.

## Output
Output data should be printed on the console.
* On the only line of the output print the maximum height of a tower that can be build.

## Constraints
* 1 <= **N** <= 15
* 1 <= **X**, **Y**, **Z** <= 10 000 000
* Time limit: **0.2 seconds**
* Memory limit: **64 MB**

## Examples

### Example 1

#### Input
```
5
10 10 10
50 50 50
40 40 40
20 20 20
30 30 30
```

#### Output
```
150
```

#### Description
All stools are cubes of different sizes. All of them can be used together.

### Example 2

#### Input
```
2
20 20 20
30 30 10

```

#### Output
```
30
```

#### Description
The best solution here can be achieved in two ways:
* put the second stool on the 30x30 side and the other one on top of it
* use only the second stool to make a tower of height 30
