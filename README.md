CQS sample
==========

Sample implementation of CQS for .NET apps

Projects
---------
* **TestApp** - test application to run queries and commands.
* **DataModel** - domain objects and abstractions for queries and commands. Have no references to any data-access specific libraries.
* **EFDataAccess** - implementation of data-access layer on top of Entity Framework 5.0 and SQL Compact.
* **UnitTests** - unit-test for queries and commands.