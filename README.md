[TR] Dapper ORM'ine ait metotları barındıran unit test projesidir. .NET 5 alt yapısına sahiptir. Northwind veritabanı kullanılmıştır.

![image](https://user-images.githubusercontent.com/37337606/140230965-3ea47932-bd0a-45bf-86b4-0e20d24462cc.png)

DapperUnitTest.cs'de örnek testleri bulabilirsiniz. DataAccess projesinde ise QueryMethods ve ExecuteMethods dosyaları bulunur. Bu dosyalar sırasıyla Dapper'a ait Query ve Execute methodları barındırdığı için isimler bu şekilde ayrılmıştır. Ayrıca Asenkron işlemleri de desteklediği için DapperAsyncMethods dosyası da bulunur. Models projesinde ise Northwind'e uyumlu entityler mevcuttur.(Products, Categories tabloları vs.)

[EN] This project is Unit Test Project that runs DapperORM methods. It creates with .NET 5  Northwind used as example database.

DapperUnitTest.cs has sample tests for some Dapper methods from data access project. DataAccess project has QueryMethods ve ExecuteMethods class files which have Dapper's built-in Query ve Execute methods respectively. Also, the project includes DapperAsyncMethods file which has async built in functions to support asynchronous operations. Models project has entities of Northwind database.(Products, Categories tables etc.)
