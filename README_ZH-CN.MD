CodeBuilder
===========
CodeBuilder([English][]) 是一款简单易用且轻量级的基于数据库物理模型的代码(C#/java/ruby/php/xml等)生成工具.
# Contents
* [特点](#特点)  
* [用户指南](#用户指南)  
	* [快速入门](#快速入门)  
	* [制做代码模板](#制做代码模板)  
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
       ![qs-img1][Config Dataource]  
3. 导入数据源中表与视图 
       在菜单栏中选择(**文件->从数据源导出->选择指定数据库**)然后等待几秒中将列出当前数据库中所有的表及视图    
       ![qs-img2][Import Database]  
4. 生成代码    
       a.选择全部或指定几个表及视图  
       b.选择要生成代码的程序语言(如c#/java/ruby/php/xml等)    
       c.设置代码的根命名空间(如:com.easytoolsoft.codebuilder)   
       d.设置表名前缀、代码作者、版本(这三个是可选设置)
       e.选择一个或多个代码模板(自定义模板请参考[制作代码模板](#制做代码模板))  
       f.**如果你想在生成代码时去掉表或视图名称前辍（你先必须在步聚d中设置好前辍名称)或想生成后的代码命名方式为驼峰式(Camel-Case)(如表名:easy_tools_soft 将变成 EasyToolsSoft),
         这时你应该选中"是否忽略表前辍" 或 "是否使用驼峰式命名"**  
       ![qs-img3][Generate Codes]  
       g.点击 "生成" 按钮执行代码生成，然后点击生成的文件可以进入的生成代码的目录  
       ![qs-img4][Code Build]  
### 制作代码模板
### 配置
#### 数据源管理
#### 模板管理
#### 程序语言管理
#### 数据类型映射
#### 其他
## 开发者
### 开发及运行环境
  b.[VS2010][]+ or [sharpdevelop][]4.1+  
  b.[ms.net][]4.0+ or [mono.net][]2.10+   
  c.[nunit][]2.5 or later  
  d.[moq3][] or later   
  e.[velocity][]  
### 架构图
   ![architecture][]
## 常见问题

[二进制可执行文件包]]: https://github.com/xianrendzw/CodeBuilder/releases/download/v1.1.16.0602_Beta/CodeBuilder_1.1.16.0602.zip 
[English]: https://github.com/xianrendzw/CodeBuilder/blob/master/README.MD 
[VS2010]: https://www.visualstudio.com/  
[sharpdevelop]: http://www.icsharpcode.net/opensource/sd/
[mono.net]: http://www.mono-project.com/download/  
[ms.net]: https://www.microsoft.com/en-US/download/details.aspx?id=17718  
[moq3]: https://github.com/Moq  
[nunit]: http://nunit.org
[velocity]: http://velocity.apache.org/engine/releases/velocity-1.5/user-guide.html
[architecture]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/architecture/architecture-general.jpg 
[net framework4.0]: https://www.microsoft.com/en-US/download/details.aspx?id=17718 
[qs-img1]: 
[qs-img2]: 
[qs-img3]: 
[qs-img4]: 