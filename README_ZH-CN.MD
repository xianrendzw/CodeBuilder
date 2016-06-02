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
### 快速入门
### 制做代码模板
### 配置
#### 数据源管理
#### 模板管理
#### 程序语言管理
#### 数据类型映射
#### 其他
## 开发者
### 开发及运行环境
  a.windows7+  
  b.[vs2010][]+ or [sharpdevelop][]4.1+  
  b.[ms.net][]4.0+ or [mono.net][]2.10+   
  c.[nunit][]2.5 or later  
  d.[moq3][] or later   
  e.[velocity][]  
### 架构图
   ![architecture][]
## 常见问题

[English]: https://github.com/xianrendzw/CodeBuilder/blob/master/README.MD 
[vs2010]: https://www.visualstudio.com/  
[sharpdevelop]: http://www.icsharpcode.net/opensource/sd/
[mono.net]: http://www.mono-project.com/download/  
[ms.net]: https://www.microsoft.com/en-US/download/details.aspx?id=17718  
[moq3]: https://github.com/Moq  
[nunit]: http://nunit.org
[velocity]: http://velocity.apache.org/engine/releases/velocity-1.5/user-guide.html
[architecture]: https://raw.githubusercontent.com/xianrendzw/CodeBuilder/master/docs/architecture/architecture-general.jpg 