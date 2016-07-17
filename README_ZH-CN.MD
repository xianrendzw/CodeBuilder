CodeBuilder
===========
CodeBuilder([English][]) 是一款简单易用且轻量级的基于数据库物理模型的代码(C#/java/ruby/php/xml等)生成工具.
# Contents
* [特点](#特点)  
* [用户指南](#用户指南)  
	* [系统要求](#系统要求)  
	* [快速入门](#快速入门)  
	* [制作代码模板](#制作代码模板)  
	* [配置](#配置) 
* [开发者](#开发者)  
	* [开发及运行环境](#开发及运行环境)  
	* [架构图](#架构图)  
* [常见问题](#常见问题)  

## 特点
  a.支持从PowderDesigner12+文件（PDM）/ SQLserver2000/2005/2008/Oralce/Mysql5 中导入数据库表结构  
  b.利用[velocity][]模板引擎生成代码  
## 用户指南
### 系统要求  
a.windows7 或 更高  
b.[net framework4.0][] 或 更高(Optional)  
### 快速入门
1. 安装   
       你可以从这里下载[二进制可执行文件包][]然后解压即可
2. 配置数据源  
       双击CodeBuilder目录下codebuilder.exe文件运行应用程序，
       然后在菜单栏中选择(**工具->数据源配置**),新增你需要的数据源，然后"确定"  
       ![qs-img1][]  
3. 导入数据源中表与视图 
       在菜单栏中选择(**文件->从数据源导出->选择指定数据库**)然后等待几秒中将列出当前数据库中所有的表及视图    
       ![qs-img2][]  
4. 生成代码    
       a.选择全部或指定几个表及视图  
       b.选择要生成代码的程序语言(如c#/java/ruby/php/xml等)    
       c.设置代码的根命名空间(如:com.easytoolsoft.codebuilder)   
       d.设置表名前缀、代码作者、版本(这三个是可选设置)  
       e.选择一个或多个代码模板,自定义模板请参考[制作代码模板](#制作代码模板)  
       f.**如果你想在生成代码时去掉表或视图名称前辍（你先必须在步聚d中设置好前辍名称)或想生成后的代码命名方式为驼峰式(Camel-Case)(如表名:easy_tools_soft 将变成 EasyToolsSoft),
         这时你应该选中"是否忽略表前辍" 或 "是否使用驼峰式命名"**  
       ![qs-img3][]  
       g.点击 "生成" 按钮执行代码生成，然后点击生成的文件可以进入的生成代码的目录  
       ![qs-img4][]  
         
### 制作代码模板
1.使用[velocity]语言创建代码模板文件  
  创建一个**UTF-8**编码格式的文本文件(如:example.txt),从TDO对象中读取模板中需要使用的内容   
  ![qs-img5][]  
2.模板数据对象(TDO)  
**a.TDO属性**  
      
名称 | 类型 | 说明
-----  | ---- | --------
Name|string| 模板数据名称 
Language|string|程序设计语言名称 (如:csharp/java/ruby/php/xml etc.)
Database|string|数据库名称 (如:mysql5/sqlserver2000/2005/2008/oralce etc.)
Package|string|命名空间或包名 (如:com.easytoolsoft)
TablePrefix|string|表名前辍(如:cb_table表的前辍为"cb")
Author|string|代码作者
Version|string|代码版本
TemplateEngine|string|模板引擎名称,默认为"nvelocity"
TemplateName|string|模板显示名称(如:example.java.nv 模板文件的显示名为"example")
Prefix|string|模板前辍
Suffix|string|模板后辍 
Encoding|string|生成的代码文件字符集编码(如:utf8/utf7/ascii etc.)
TemplateFileName|string|模板对应的文件名(如:example.java.nv)
CodeFileName|string|生成的代码文件名(如:Example.java)
IsOmitTablePrefix|bool|生成代码时是否忽略表前辍(如:cb_table表生成代码时将去掉"cb")
IsCamelCaseName|bool|是否驼峰化(Camel-Case)命名(如:cb_table -> CbTable)
ModelObject|object| 模型对象，对应一个数据库的表或视图.相关属性请参考:**b.ModelObject属性**

**b.ModelObject属性**  
     
名称 | 类型 | 说明
-----  | ---- | --------
Id|string|对应数据库中的表或视图表(如:cb_table)
DisplayName|string|显示名,默认为属性"Name"的值
Name|string|表或视图首字母大写驼峰式(Camel-Case)名.(如:cb_table -> CbTable)
OriginalName|string|表或视图在数据库中的名称(如:cb_table)
Comment|string|表或视图在数据库中的注释
MetaTypeName|string|当前ModelObject元数据类型名:table|view
Columns|Dictionary[string,Column]|表或视图中所有列集合,相关属性请参考:**c.Column Proprities**
PrimaryKeys|Dictionary[string,Column]|表中所有主键列集合
Keys|Dictionary[string,Column]|表中所有非主键列集合

**c.Column属性**  
      
名称 | 类型 | 说明
-----  | ---- | --------
Id|string| 对应数据库中表或视图的列名 (如:first_name)
DisplayName|string|列显示名,默认为属性"Name"的值
Name|string|列名，首字母大写驼峰式(Camel-Case)名(如:first_name -> FirstName)
LowerCamelName|string|列名，首字母小写驼峰式(Camel-Case)名(如:first_name -> firstName)
OriginalName|string|原始列名 (如:first_name)
Comment|string|列说明
DataType|string|列在数据库中的数据类型(如: mysql int/bigint/varchar etc.)
DefaultValue|string|列在数据库中的默认值
LanguageType|string|列在对应的程序设计语言(如:c#/java/ruby etc.)中的数据类型(如: C# int/long/string etc.)
LanguageDefaultValue|string|列在对应的程序设计语言(如:c#/java/ruby etc.)中的默认值
Length|int|列在数据库中数据类型对应的长度
Ordinal|int|列在数据库中表或视图的顺序
IsAutoIncremented|bool|列是否为自增列
IsNullable|bool|列是否可为空
IsComputed|bool|列是否为计算列
HasDefault|bool|列是否有默认值
MetaTypeName|string|元数据类型名，值为"column"

3.添加模板
  把创建好的代码模板文件加入到CodeBuilder的模板列表中
  ![qs-img6][] 
### 配置
#### 数据源管理
#### 模板管理
#### 程序语言管理
#### 数据类型映射
#### 其他
## 开发者
### 开发及运行环境
  a.[VS2010][]+ or [sharpdevelop][]4.1+  
  b.[ms.net][]4.0+ or [mono.net][]2.10+   
  c.[nunit][]2.5 or later  
  d.[moq3][] or later   
  e.[velocity][]  
### 架构图
   ![architecture][]
## 常见问题

[二进制可执行文件包]: https://github.com/xianrendzw/CodeBuilder/releases/download/v1.1.16.0602_Beta/CodeBuilder_1.1.16.0602.zip 
[English]: https://github.com/xianrendzw/CodeBuilder/blob/master/README.MD 
[VS2010]: https://www.visualstudio.com/  
[sharpdevelop]: http://www.icsharpcode.net/opensource/sd/
[mono.net]: http://www.mono-project.com/download/  
[ms.net]: https://www.microsoft.com/en-US/download/details.aspx?id=17718  
[moq3]: https://github.com/Moq  
[nunit]: http://nunit.org
[velocity]: http://velocity.apache.org/engine/1.7/user-guide.html
[architecture]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/architecture/architecture-general.jpg 
[net framework4.0]: https://www.microsoft.com/en-US/download/details.aspx?id=17718 
[qs-img1]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/cn/images/qs-img1.png
[qs-img2]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/cn/images/qs-img2.png
[qs-img3]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/cn/images/qs-img3.png
[qs-img4]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/cn/images/qs-img4.png
[qs-img5]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/cn/images/qs-img5.png
[qs-img6]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/manual/cn/images/qs-img6.png
