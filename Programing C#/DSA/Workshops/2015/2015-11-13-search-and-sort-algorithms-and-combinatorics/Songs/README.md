# Songs

## Description

The jury of the "Eurovision" ranked **N** songs for the finals. Ivancho has ordered the songs according to his liking. His order may differ from the official ranking.
For example if the songs are the numbers from 1 to 5, one possible ranking would be (3, 1, 2, 5, 4). Ivancho's ranking could be (5, 3, 2, 1, 4).

Write a program that finds the number of pairs of songs for which Ivancho's ranking is different from the official one.

## Input

* Input is read from the console
* On the first line is the number **N**
* On the second line is a permutation of the numbers from **1 to N** - official ranking
  * Numbers are seperated by a single space bar
* On the third line is a permutation of the numbers from **1 to N** - Ivancho's ranking
  * Numbers are seperated by a single space bar

## Output

* Output should be printed to the console
  * The number of inversions on a single line

## Constraints
* 1 <= **N** <= 100 000
* Time limit: **0.1 seconds**
* Memory limit: **32 MiB**

## Examples

### Example 1

#### Input
```
3
1 2 3
3 2 1
```
#### Output
```
3
```

### Example 2

#### Input
```
5
3 1 2 5 4
5 3 2 1 4
```
#### Output
```
4
```

### Example 3

#### Input
```
6
6 2 3 4 5 1
1 2 3 4 5 6
```
#### Output
```
9
```
