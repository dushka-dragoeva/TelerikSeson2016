# Online store

## Description

The online store „112“ has a large amount of products in stock. Each product has a **name**, a **price** and a **producer**. The task is to make a model of the online store in which to select the best data structures, which will hold the products.
Write a program that performs **N** commands given as input. Each command is on a seperate line:

* **AddProduct name;price;producer** - adds a product with the given name, price and producer. If there exists a product with the same name, price or producer the new one does not change the previous (repeating products are allowed).
* **DeleteProducts name;producer** - deletes a product (or several products) that have the given name and producer
  * As a result the command outputs **"X products deleted"**, where **X** is the number of deleted products or **"No products found"** if no products were deleted.
* **DeleteProducts producer** - deletes all products made by the given producer
  * As a result the command outputs **"X products deleted"**, where **X** is the number of deleted products or **"No products found"** if no products were deleted.
* **FindProductsByName name** - finds all products by given name
  * As a result the command outputs a list of products in **{name;producer;price}** format. The list has to be sorted lexicographically and each product must be on a seperate line. If there are no products with the given name output **"No products found"**.
* **FindProductsByPriceRange fromPrice;toPrice** - finds all products with price in the interval [**fromPrice**, **toPrice**]
  * As a result the command outputs a list of products in **{name;producer;price}** format. The list has to be sorted lexicographically and each product must be on a seperate line. If there are no products with the given name output **"No products found"**.
* **FindProductsByProducer producer** - finds all products made from the given producer
  * As a result the command outputs a list of products in **{name;producer;price}** format. The list has to be sorted lexicographically and each product must be on a seperate line. If there are no products with the given name output **"No products found"**.

## Input

* Input data is read from the console.
* On the first line is a number **N** - the number of commands
* On each of the next **N** lines there will be a single valid command

## Output

Output data should be printed on the console.
* The output is consisted of all the outputs of the commands given on input

## Constraints

* **N** is in the interval **[1, 100050]**
* Each command is consisted of letters, numbers and spaces
* Prices are given as real numbers with **atmost two digits of decimal precision** (eg. 133.58 or 320)
* The `'.'` symbol is used as a decimal seperator
* Prices must be outputed with **exactly two digits of decimal precision** (eg. 320.30, 100.00, 42.42; ~~320.3~~ is wrong)
* Time limit: **2 seconds**
* Memory limit: **256 MB**

## Examples

### Example 1

#### Input

```
14
AddProduct IdeaPad Z560;1536.50;Lenovo
AddProduct ThinkPad T410;3000;Lenovo
AddProduct VAIO Z13;4099.99;Sony
AddProduct CLS 63 AMG;200000;Mercedes
FindProductsByName CLS 63 AMG
FindProductsByName CLS 63
FindProductsByName cls 63 amg
AddProduct 320i;10000;BMW
FindProductsByName 320i
AddProduct G560;999;Lenovo
FindProductsByProducer Lenovo
DeleteProducts Lenovo
FindProductsByProducer Lenovo
FindProductsByPriceRange 100000;200000
```

#### Output

```
Product added
Product added
Product added
Product added
{CLS 63 AMG;Mercedes;200000.00}
No products found
No products found
Product added
{320i;BMW;10000.00}
Product added
{G560;Lenovo;999.00}
{IdeaPad Z560;Lenovo;1536.50}
{ThinkPad T410;Lenovo;3000.00}
3 products deleted
No products found
{CLS 63 AMG;Mercedes;200000.00}
```
