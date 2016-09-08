<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 31 May 2016_

# Task 2: Dancing Moves (Batman returns)

## Description

Batman is a great dancer. :D Just kidding you know.

Pesho, Gosho and the others are at party after one of the exams at the Academy. We all know programmers are great dancers (for real?), so they choose to make a dance competition. But as we all already know, these people are so brainwashed, so to be even more interesting (really?) they decide to use Dancing machine in the format of an array. Your task is to calculate the points each player scores at the end of the round. Each cell in the array has a value (**an integer between 0 and 1000**).

On the input you will receive the array itself with all the values. After that you will receive multiple lines with instructions in the format **[Times Direction Step]** separated by single space until you receive **stop**.

The starting position **is always at index 0** of the array. Direction could be **right** or **left**. If you get out of the boundaries of the array you should enter from the other side.

The final result is the average of all the rounds played rounded to one digit after the comma.

### Example:

_1 2 3 5 7 10 20_<br/>
_5 right 1_<br/>
_2 left 2_<br/>
_3 right 2_<br/>
_1 left 3_<br/>
_stop_<br/>

- We start at **position 0**.
- We move **5 times** to the **right** with **step 1** - sum = 2 + 3 + 5 + 7 + 10 = 27
- We move **2 times** to the **left** with **step 2** - sum = 5 + 2 = 7
- We move **3 times** to the **right** with **step 2** - sum = 5 + 10 + 1 = 16
- We move **1 time** to the **left** with **step 3** - sum = 7
- **Result = (27 + 7 + 16 + 7) / 4 =  14.25 = 14.3**

![example](./imgs/example.png)


## Input

All input data is read from the standard input (the console)

- On the first line you will receive the array as a string (**space delimited integers**)
- On the next lines until you find **stop** you will strings in format **[times direction step]** delimited by **single space**

## Output

The output data is printed on the standard output (the console)

- On a single line you should output the result **rounded** to **one digit** after the comma.

## Constraints

- The integers in the array will be in the range [0, 10000]
- The **times** will be an integer in the range [0, 10000]
- The **direction** will be string in format **"left"** or **"right"**
- The **step** will be an integer in the range [0, 10000]
- **The input data will always be correct and there is no need to check it explicitly**
- **Time limit: 0.5 s**
- **Memory limit: 16 MB**

## Sample Tests

### Sample Input 1

```
1 2 3 5 7 10 20
5 right 1
2 left 2
3 right 2
1 left 3
stop
```

### Sample Output 1

```
14.3
```

### Sample Input 2

```
10 2 31 1000 2 15 10 10
2 right 2
2 right 1
4 right 1
2 left 1
stop
```

### Sample Output 2

```
30.8
```

### Sample Input 3

```
1 2 3 4 5 6 7 8 9 10
1 right 3
1 left 3
2 left 3
3 left 5
stop
```

### Sample Output 3

```
10.8
```
