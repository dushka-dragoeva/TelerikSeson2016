## XML Basics

**XML - Extendable Markup Language**

-An universal language(notation) for describing structured data using text with tags
-The data is sorted together with the metadata about it
-Used to describe other languages for data representation
-Like HTML use tags and **attributes**
- Whorldwide standard
Independent of:
1. Hardware platform,
Operating System
Programming language

```<?xml version="1.0"?>
<library **name=".NET Developer's Library"**>
  <book>
    <title>Professional C# 4.0 and .NET 4</title>
    <author>Christian Nagel</author>
    <isbn>978-0-470-50225-9</isbn>
  </book>
  <book>
    <title>Silverlight in Action</title>
    <author>Pete Brown</author>
    <isbn>978-1-935182-37-5</isbn>
  </book>
</library>```

### XML vs HTML
-Both are text based notations and use tags and attributes
-HTML is a language => XML is sintax for describing other languages
-HTML describes the formatting of information =>XML describes structured information
-XML requires the document to be well formated

### Advantages
1. Human Readable
2. Any kinfd of structured data can be sorted
3. Data come with self discrioting metadata
4. Information can be exchanged between different systems with ease
5. Unicode is fully support
6. Custom XML-based lanquages can be developed for certain application

### Disasvantages
1. XML data is bigger - more momory, network trafic, more space
2. Decrease performance - need parsing/constructing the XML data
3. Not suitable for all kinds of data - grad=fics, images, video clips

## Namespaces
Allows to use different tags with same name

```<?xml version="1.0" encoding="utf-8"?>
<sample:towns
  xmlns:sample="http://www.academy.com/towns/1.0">
  <sample:town>
    <sample:name>Sofia</sample:name>
    <sample:population>1200000</sample:population>
  </sample:town>
  <sample:town>
     <sample:name>Plovdiv</sample:name>
     <sample:population>700 000</sample:population>
  </sample:town>
</sample:towns>```

```<?xml version="1.0" encoding="UTF-8"?>
<country:towns
    xmlns:country="urn:academy-com:country"
    xmlns:town="http://www.academy.com/towns/1.0">
  <town:town>
    <town:name>Plovdiv</town:name>
    <town:population>700 000</town:population>
    <country:name>Bulgaria</country:name>
  </town:town>
</country:towns>```

It is betetr to define all namespacec in the root element.
Default namespace : not named



