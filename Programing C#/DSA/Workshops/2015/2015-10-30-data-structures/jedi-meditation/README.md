#  Jedi Meditation

##  Description

A long time age, in a galaxy far, far away...

All jedi must mediate. Yet, when the Jedi are at their temple, they cannot mediate at the same time, because the Force will become too much at one place and implosion will occur. There is a strict order for meditations: Jedi Masters mediate first, then Jedi Knights, and last are the padawans.

Given the sequence of Jedi: 
```cs
P, K, M, M, K, P
```
they will mediate in the following order:
```cs
M, M, K, K, P, P
```

given that `M` means a Jedi Master, `K` is a Jedi Knight, and `P` is a padawan.

Joro and Gosho are padawans. They want to have as much time with the Force as they can. Given that, they do not want to wait meaninglessly for mediation. That is why, you you help them solve in which order all Jedi will mediate.

##  Input

*  Use the standard input (i.e. the console)
*  On the first line you will find the number **N** - the number of jedi, waiting for meditation
*  On the second line you will fin exactly **N** jedi, waiting for meditation:
   *  **M** means jedi master
   *  **K** means jedi knight
   *  **P** means jedi padawan

##  Output 

*  Use the standard output (i.e. the console)
*  On the only line, print the correct sequence of jedi, ready for meditation
   *  Print each jedi's name
   *  Different jedi's are separated by a single space

##  Constraints

*  `0 < N < 100 000`
*  Time: 0.1 seconds
*  Memory: 16MB 

##  Examples

###  Example 1

####  Input

```
3
m1 k1 p1
```

####  Output

```
m1 k1 p1
```

####  Description

The sequence does not change, because they are already in the correct order


###  Example 2

####  Input

```
7
p4 p2 p3 m1 k2 p1 k1
```

####  Output

```
m1 k2 k1 p4 p2 p3 p1
```

####  Description 

*  **m1** meditates before all padawans and jedi knights
*  **k2** meditates before all padawans and after **m1**
*  **k1** meditates before all padawans and after **k2**
*  The **padawans** mediate in the order they appear
