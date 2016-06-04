CodeBuilder
===========
CodeBuilder([中文版][]) is a lightweight base Database Physical Data Model's code (C#/java/ruby/php/xml etc.) generation tool.
# Contents
* [Features](#fatures)  
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
2. Config Dataource   
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
       e.select one or more code template for generation(customize template please ref [Make Template](#make-template))     
       f.**if want remove table&views prefix(eg:cb_table1,cb_table2's cb is prefix,also you need fill prefix of table& view name by step d) 
       and Camel-Case class or field name (eg:easy_tools_soft will transfer to EasyToolsSoft) when you generation code,
       you should check "is omit table prefix" or "is Camel-Case name"**  
       ![qs-img3][]  
       g.click "generate" button start execute code build then click file bar open genenrated code file directory  
       ![qs-img4][]  
       
### Make Template
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
[velocity]: http://velocity.apache.org/engine/releases/velocity-1.5/user-guide.html
[architecture]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/architecture/architecture-general.jpg 
[qs-img1]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img1.png
[qs-img2]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img2.png
[qs-img3]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img3.png
[qs-img4]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/en/images/qs-img4.png