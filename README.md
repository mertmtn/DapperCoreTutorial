[TR] Dapper ORM'ine ait metotları barındıran unit test projesidir. .NET 10 alt yapısına sahiptir. Northwind veritabanı kullanılmıştır.
16.02.2026 tarihinde bütün projeleri .NET 10'ya yükselttim. 

![image](https://user-images.githubusercontent.com/37337606/142294982-6bb3b34c-a549-4700-a13d-f2a77e81c2fa.png)

DapperUnitTest.cs'de örnek testleri bulabilirsiniz. DataAccess projesinde Dapper için GenericRepository tasarımı yapıldı. Her entity için Abstract interface ve Concrete sınıflar oluşturuldu. Dapper.Contrib nuget paketi kurularak metotları temel CRUD işlemleri için geliştirildi. 

![image](https://user-images.githubusercontent.com/37337606/142295329-7d1429f5-f3b8-4e67-98ac-eccc37f0800b.png)

DataAccess projesinde Abstract interfacede oluşturulan metotlar, generic repositorydeki ortak metotlara ek olarak oluşturulabilir. 

IProductDal

![image](https://user-images.githubusercontent.com/37337606/142295690-584edca1-8742-42b1-ba9e-f85cae1425f1.png)

DapperProductDal

![image](https://user-images.githubusercontent.com/37337606/142295729-0911da31-146c-407d-b61b-e03edc8e3134.png)

Business projesinde ise QueryMethods ve ExecuteMethods dosyaları bulunur. Bu dosyalar sırasıyla Dapper'a ait Query ve Execute methodları barındırdığı için isimler bu şekilde ayrılmıştır. Ayrıca Asenkron işlemleri de desteklediği için DapperAsyncMethods dosyası da bulunur. 

Generic repository metotlarını kullanacak iş metotları, her entity için Abstract interface ve Concrete sınıflarda oluşturuldu. 

Models projesinde ise Northwind'e uyumlu entityler mevcuttur.(Products, Categories tabloları vs.)

[EN] This project is Unit Test Project that runs DapperORM methods. It creates with .NET 10 Northwind used as example database.
On 16.02.2026, all class libraries migrated from .NET 6 to .NET 10

DapperUnitTest.cs has sample tests for some Dapper methods from Business project. 

DataAccess project includes GenericRepository for Dapper. Dapper.Contrib nuget package added on this project to design generic repository easily. Created Abstract interfaces and Concrete classses for each entities. This enhancement satisfies basic CRUD operations. 

Methods in Abstract interfaces on DataAccess project are additional operations to generic repository common methods.

Business project includes QueryMethods ve ExecuteMethods class files which have Dapper's built-in Query ve Execute methods respectively. Also, the project includes DapperAsyncMethods file which has async built in functions to support asynchronous operations. Created Abstract interfaces and Concrete classses for each entities which methods work for their business. 

Models project has entities of Northwind database.(Products, Categories tables etc.)
