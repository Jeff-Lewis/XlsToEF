#XlsToEF#

[![Build Status](https://ci.appveyor.com/api/projects/status/github/ajepst/XlstoEf?branch=master&svg=true)](https://ci.appveyor.com/project/ajepst/xlstoef)

### What is XlsToEf? ###

XlsToEf is a library you can use to help you import rows from excel files and then save right to the database with Entity Framework.  It includes components to take care of most of the mechanical work of an import, and also includes several helper functions that you can use in your UI.

###How Do I Get Started?###

The core of doing the import happens through calling ImportColumnData. You mist pass it at least three things:

* Information that specifies the spreadsheet file location and the sheet you want to import
* a Func that lets ImportColumnData know how to match a particular row against the database.

Take a look at the Example project- You will probably make something very similar to *IdDefaultImporter* if your entity Ids and/or spreadsheet identifier column names are very consistent. In that case, *ImportOrderMatchesFromXlsx* is how you would use it for each entity type you want to import into. If you don't have that kind of consistency, you will probably build fully one-off configurations like *ImportAddressesFromXlsx*, which is kind of a combination between the two.

Optionally, you can pass a few more things:

* The name of the Xlsx column to check against the identifier of existing objects (Only optional in CreateOnly mode)
* An overrider if you want to handle the mapping yourself
* A switch to select Update Only, Create only, or Upsert behavior. Upsert behavior is the default.

###Additional Tools:###

The IExcelIoWrapper interface has several useful functions that are useful in implementing a column-matching UI:

*GetSheets* - returns the list of sheet names in the uploaded spreadsheet

*GetImportColumnData* - This returns a collection of the column names in a spreadsheet. This could be useful for implementing a matching UI, as in the example project.

### Notable Dependencies ###

Like most of these Excel integration tools, this relies on the Microsoft Access Database Engine 2010 Redistributable, which you can get here: 
https://www.microsoft.com/en-us/download/details.aspx?id=13255
