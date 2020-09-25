24 Sept 2020
============

Getting Familiar with using Antlr in C#

The Hello, World !
	1. Visual Studio 2019 -> .NET Core Console Program
	2. Add Nuget "StringTemplate4"
	3. Use Antlr.StringTemplate.Template class to write the Hello, World of Antlr
--------------------
Reading Template from a file
	Here I'm reading a template file just as a string, so essentially this is similar to the previous example

--------------------
Code Generation - HBM file
	Create a template for HBM - the example shows a list of properties and bags inside the template
	TODO : Right now, I've populated the template using dummy data - this data should be read from the schema and fed to teh template
	And then we have a working JSON to HBM converter
