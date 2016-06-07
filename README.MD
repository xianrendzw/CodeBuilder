CodeBuilder
===========
CodeBuilder([中文版][]) is a lightweight base Database Physical Data Model's code (C#/java/ruby/php/xml etc.) generation tool.
# Contents
* [Features](#features)  
* [User Guide](#user-guide)  
	* [Requirements](#requirements)  
	* [Quick Start](#quick-start)  
	* [Make Template](#make-template)  
	* [Configuration](#configuration) 
* [For Developers](#for-developers)  
	* [Environment](#environment)  
	* [Architecture](#architecture)  
* [FAQ](#faq)  

## Features
  a.support from Powerdesinger 12+ PDM file import to Data Model  
  b.support from MySql5/SQLserver2000/2005/2008/Oralce Database import to Data Model   
  c.support [velocity][] template engine for code template
## User Guide
### Requirements  
a.windows7 or later  
b.[net framework4.0][] or later(Optional)  
### Quick Start  
1. Installation   
       Download the [Binary only distribution][] then extract it  
2. Config DataSource   
       Open CodeBuilder folder then double click codebuilder.exe file run Appliction  
       click (**tools->datasource configuration**) add new datasource item  
       ![qs-img1][]
3. Import Database Tables & Views  
       click (**files->export from datasource->selected database**) and watting until list all tables and views of current database  
       ![qs-img2][]
4. Generate Codes    
       a.checked some(or all) tables and views  
       b.select programming language(c#/java/ruby/php/xml etc.)  
       c.fill root package or namespaces (eg:com.easytoolsoft.codebuilder)  
       d.fill prefix of table& view name,code author and version (Optional)
       e.select one or more code template for generation,if you want to customize template please ref [Make Template](#make-template)     
       f.**if want remove table&views prefix(eg:cb_table1,cb_table2's cb is prefix,also you need fill prefix of table& view name by step d) 
       and Camel-Case class or field name (eg:easy_tools_soft will transfer to EasyToolsSoft) when you generation code,
       you should check "is omit table prefix" or "is Camel-Case name"**  
       ![qs-img3][]  
       g.click "generate" button start execute code build then click file bar open genenrated code file directory  
       ![qs-img4][]  
       
### Make Template
1.Create code template by apache velocity   
  create a text file(eg:example.txt) with **UTF-8** encoding,use TDO by [velocity][]  
  ![qs-img5][]  
2.Template Data Object(TDO)  
**a.TDO Properties**  
      
Name | Type | Comment
-----  | ---- | --------
Name|string| template data name  
Language|string|programming language (eg:csharp/java/ruby/php/xml etc.)
Database|string|database (eg:mysql5/sqlserver2000/2005/2008/oralce etc.)
Package|string|namespaces or package name (eg:com.easytoolsoft)
TablePrefix|string| table name prefix(eg:cb_table's prefix is "cb")
Author|string|code author name
Version|string|code version 
TemplateEngine|string|template engine name default is nvelocity
TemplateName|string|template display name(eg:example.java.nv file displayname is "example")
Prefix|string|template prefix
Suffix|string|template suffix 
Encoding|string|code file encoding (eg:utf8/utf7/ascii etc.)
TemplateFileName|string|template file name(eg:example.java.nv)
CodeFileName|string|generated code file name(eg:Example.java)
IsOmitTablePrefix|bool|is omit table prefix (eg:cb_table will remove "cb")
IsCamelCaseName|bool|is Camel-Case tables ,views,columns,fields name(eg:cb_table -> Cb_Table)
ModelObject|object| in the corresponding database tables and views.please ref:**b.ModelObject Properties**

**b.ModelObject Properties**  
     
Name | Type | Comment
-----  | ---- | --------
Id|string|table or view name(eg:cb_table)
DisplayName|string|table or view display name, default is Name property
Name|string|table or view Upper Camel-Case name(eg:cb_table -> CbTable)
OriginalName|string|talbe or view name(eg:cb_table)
Comment|string|table or view's comment
MetaTypeName|string|meta data type is:(table|view)
Columns|Dictionary[string,Column]|table or view's column collection,please ref:**c.Column Properties**
PrimaryKeys|Dictionary[string,Column]|table's Primary key column collection
Keys|Dictionary[string,Column]|table's Non-Primary key column collection  

**c.Column Properties**  
      
Name | Type | Comment
-----  | ---- | --------
Id|string| column name (eg:first_name)
DisplayName|string|column display name, default is Name
Name|string|column Upper Camel-Case name(eg:first_name -> FirstName)
LowerCamelName|string|column Lower Camel-Case name(eg:first_name -> firstName)
OriginalName|string|column name (eg:first_name)
Comment|string|column's comment
DataType|string|column data type of database (eg: mysql int/bigint/varchar etc.)
DefaultValue|string|column default value of database
LanguageType|string|column mapping to programming language (eg:c#/java/ruby etc.) data type (eg: C# int/long/string etc.)
LanguageDefaultValue|string|column default value of programming language (eg:c#/java/ruby etc.)
Length|int|column data type length of database
Ordinal|int|column sequence of table or view
IsAutoIncremented|bool|column whether auto incremented field 
IsNullable|bool|column whether is null field 
IsComputed|bool|column whether is computed field 
HasDefault|bool|column whether default value
MetaTypeName|string|meta data type is "column"

3.Add Template
  when templates completed,you should add it to codebuilder  
  ![qs-img6][] 
### Configuration
#### DataSource
#### Template
#### Language
#### TypeMapping
#### Others
## For Developers
### Environment
  a.[VS2010][]+ or [sharpdevelop][]4.1+  
  b.[ms.net][]4.0+  
  c.[nunit][]2.5 or later  
  d.[moq3][] or later   
  e.[velocity][]  
### Architecture
   ![architecture][]
## FAQ

[Binary only distribution]: https://github.com/xianrendzw/CodeBuilder/releases/download/v1.1.16.0602_Beta/CodeBuilder_1.1.16.0602.zip  
[中文版]: https://github.com/xianrendzw/CodeBuilder/blob/master/README_ZH-CN.MD 
[VS2010]: https://www.visualstudio.com/  
[sharpdevelop]: http://www.icsharpcode.net/opensource/sd/
[mono.net]: http://www.mono-project.com/download/  
[ms.net]: https://www.microsoft.com/en-US/download/details.aspx?id=17718  
[net framework4.0]: https://www.microsoft.com/en-US/download/details.aspx?id=17718 
[moq3]: https://github.com/Moq  
[nunit]: http://nunit.org
[velocity]: http://velocity.apache.org/engine/1.7/user-guide.html
[architecture]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/architecture/architecture-general.jpg 
[qs-img1]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img1.png
[qs-img2]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img2.png
[qs-img3]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img3.png
[qs-img4]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img4.png
[qs-img5]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img5.png
[qs-img6]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img6.png
