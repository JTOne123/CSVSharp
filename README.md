
# CSVSharp 
 A cross-platform CSV Writer for C#
 
| Latest Build | Nuget |
| --- | --- | 
| [![Build Status](https://img.shields.io/travis/com/JeremyRuffell/CSVSharp.svg?style=flat-square)](https://img.shields.io/travis/com/JeremyRuffell/CSVSharp.svg?style=flat-square) | [![Nuget Status](https://img.shields.io/nuget/v/CSVSharp.svg?style=flat-square)](https://img.shields.io/nuget/v/CSVSharp.svg?style=flat-square) |


# Using CSVSharp 
## Getting Started
```csharp
CSV csv = new CSV
{
    Path = "/path/to/file.csv",
    Data = new Person { First_Name = "Jeremy", Last_Name = "Ruffell", Age = 18 }    
}
csv.write();
```
| First_Name | First_Name | Age |
| --- | --- | --- |
| Jeremy | Ruffell | 18 |



## Writing a List of Objects to a csv
```csharp
List<Person> people = new List<Person>
{
    new Person { First_Name = "Jeremy", Last_Name = "Ruffell", Age = 18 },
    new Person { First_Name = "Fred ", Last_Name = "Freddington", Age = 30 }
};
CSV csv = new CSV
{
    Path = "/path/to/file.csv",
    Data = people  
}
csv.write();
```
| First_Name | First_Name | Age |
| --- | --- | --- |
| Jeremy | Ruffell | 18 |
| Fred | Freddington | 30 |



## Append to an existing csv.
```csharp
CSV csv = new CSV
{
    Path = "/path/to/file.csv",
    Append = true,
    Data = new Person { First_Name = "Shane", Last_Name = "Batey", Age = 35 }    
}
csv.write();
```
| First_Name | First_Name | Age |
| --- | --- | --- |
| Jeremy | Ruffell | 18 |
| Fred | Freddington | 30 |
| Shane | Batey | 35 |


## Write to CSV without Column Headers
```csharp
CSV csv = new CSV
{
    Path = "/path/to/file.csv",
    ColumnHeaders = false,
    Data = new Person { First_Name = "Jeremy", Last_Name = "Ruffell", Age = 18 }    
}
csv.write();
```
|  |  |  |
| --- | --- | --- |
| Jeremy | Ruffell | 18 |
| Fred | Freddington | 30 |
