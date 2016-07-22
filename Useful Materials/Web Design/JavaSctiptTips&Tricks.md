nodemon - live refresh on terminal

Ctr+Shft+P => open extentions
install extentions javascript
codesnipet
linter
codemetrics
jshint
===========================================================================
StringFormat
==========================================================================

String.prototype.format = function() {
    var formatted = this;
    for( var arg in arguments ) {
        formatted = formatted.replace("{" + arg + "}", arguments[arg]);
    }
    return formatted;
}
=================================================================================
area.toFixed(2) + " " +  perimeter.toFixed(2));
zakragliava do vtoria znak

 console.log.apply(console, output);
 
 =========================================================
Масив от поредни числа
var N = 10;
var arr = Array.apply(null, { length: N }).map(Number.call, Number);
console.log(arr);

###Function

var print = new Function("console.log('Hello')"); // constructor
function print() { console.log("Hello") };  // declaration
var print = function() { console.log("Hello") };    // expression
var print = function printFunc() { console.log("Hello") }; / expression

**ES6**
console.log(`The number ${number} is positive.`);

Argument object is better to be parsed to Array
 args = [].slice.apply(arguments);
 
 Object types act as templates from which an instance of an object is created at run 
 time. Types define the properties of the object and the methods used to control the 
 object's behavior.
 
 let person = {
  firstName: 'Doncho',
  lastName: 'Minkov',
  toString: function () {
    return this.firstName + ' ' + this.lastName;
  }
};

JS Object = Dictionary

var numbers = [5, 1, 2, 4, 6];
numbers.sort(function(x, y) {
  return y - x;
});
var people = [createPerson('Peter', 13), createPerson('John', 18), ..];
people.sort(function(p1, p2) {
  return p1.name > p2.name;
});
console.log(people);

function getRandomDigit() { return (Math.random() * 10) | 0; }

**for-in loop** iterates over the properties of an object
for (property in object) {...
}
for(index in collection){
}
**for-of loop** iterates over the elements in an array

Can be used only on arrays, or array-like objects

##String Methods

.length
[index]
.charAt(index);
.concat => не се използва
.replace (str1, str2)
.search(REGEX)
.indexOf(substring[,index])  index is 0 by default
.lastIndexOf(substring[,index]) index is string.length by default
.split(separator) sepaator is string or REGEX
.trim, .trimLeft, .trimRight  => only whitespace
.substr(startIndex, length)
.substring(startIndex, endIndex) => без елемента на последния индекс
.valueOf - returns the primitive value of the object string

#####String Escapes

String.prototype.htmlEscape = function () {
  let escapedStr = String(this)
      .replace(/&/g, '&amp;');
      .replace(/</g, '&lt;');
      .replace(/>/g, '&gt;');
      .replace(/"/g, '&quot;');
      .replace(/'/g, '&#39');
  return escapedStr;
}

##String Extentions

.string.trimChars(chars), 
.string.trimLeftChars(chars), 
.string.trimRightChars(chars)
.padLeft(count, char)
.padRiht(count, char)
String.prototype.padLeft = function (count, char) {
  char = char || ' ';
  if(char.length > 1) return String(this);
  if(str.length >= count) return String(this);
  var s = String(this);
  for (var i = 0, len = this.len; i < count - len; i++) {
    s = char + s;
  }
  return s;
}
String Extensions
Demo
Strings
Questions?
Free Trainings @ Telerik Academy
"Web Design with HTML 5, CSS 3 and JavaScript" course @ Telerik Academy
javascript course
Telerik Software Academy
academy.telerik.com
Telerik Academy @ Facebook
facebook.com/TelerikAcademy
Telerik Software Academy Forums
forums.academy.telerik.com
 
Follow us 
Our website Follow us Subscribe Add us to circles Follow Follow Subscribe

#REGEX

var re = /ab+c/
var re = new RegExp("ab+c");

 'bar foo'.replace( /(...) (...)/, '$2 $1' )
 
 
**RegExp.test** – searches for a match in a given string. Returns true or false
**RegExp.exec** - searches for the next match in a given string
			Returns an array of all captured groups for the found match or null.
**String.match** – searches for a match in a string
			Returns an array of information or null on a mismatch
			
**String.replace** – replaces the matched substring with a replacement substring
			Returns the new string
**String.split**– breaks a string into an array of substrings, using a regex or a string search for matches
			Returns an array
**String.search** – tests for a match in a string
		It returns the index of the match, or -1 if the search fail
			
 
 
####FLAGS
g
i
m - multy line search

* – The preceding character/group is matched 0 or more times
+ – Almost the same behaviour as * - the preceding character/
group is matched 1 or more times
? – The preceding character/group is matched 0 or 1 times
.(dot) – matches any single character except the newline character
| – Matches one pattern or the other
[xyz] – Character set - Matches any of the characters
[x-z] – Character set - Matches any one between the characters range
[^xyz] – Inverted characters set - Matches all other characters
{N} – matches exactly N occurrences of the preceding character/group
{N, M} – matches at least N and at most M occurrences of the preceding character/group
^ - matches the start of the string
$ matches the end of the string
\s – matches a single white space character, including space, tab, form feed, line feed
\S – matches a single character other than white space
\d – matches a digit character
Equivalent to [0-9]
\D – matches any non-digit character
Equivalent to [^0-9]
\w – matches any alphanumeric character including the underscore
\W – matches any non-alphanumeric or underscore characte

*? – нула или повече срещания, но най-малкият възможен брой
+? – едно или повече срещания, но най-малкият възможен брой
{n,}? – поне n срещания, но най-малкият възможен брой

\b – указание за търсене само в началото или края на дума – 
	на границата между символите \w и \W, но в рамките на \w
	Пример: \b\w*бир\w*\b обозначава всички думи, съдържащи като подниз "бир", 
	например "бира", "обирам" но не и "налей ми биричка"
	Пример: .*?ра\b обозначава всички най-къси поднизове, завършващи на "ра", 
	например "кака Мара" и "дай бира", но не и "бира няма" и "подай ми бирата"
\B – указание за търсене само в средата на думата (без началото и края)
	Пример: \w*бира\B ще намери "бира" в текста "Къде ми е бирата?", но няма да 
	намери нищо в текста "Налей ми бира, моме ле!"
\A – указание за търсене само в началото на подадения текст (задава се преди низа)
	Пример: \Aбира ще намери "бира" в текста "бирата е хладна", но няма да намери 
	нищо в текста "Живот без бира не е живот!"
\z – указание за търсене само в края на текста (задава се след низа)
П	ример: бира\Z ще намери "бира" в текста "налей бира", но няма да намери нищо в 
	текста "бирата е хладна"
^ –  търсене само в началото на текста (в режим multi-line и в началото на всеки ред)
$ –  търсене само в края на текста (в режим multi-line и в края на всеки ред)

A|B – задава алтернативен избор между регулярните изрази A и B
	Пример: бира|скара ще намери "бира" в текста "Студена ли е бирата?", 
	а в текста "Къде е скарата?" ще намери "скара"
**Метасимволи за задаване на групи:**
	(група), (?<име>група) – задава група в регулярния израз (без име или с име)
	Пример: \s*(?<name>\w+)\s*=\s*(\d+)
	Групите се използват за логическо отделяне на части от регулярния израз и 
	могат да имат имена







