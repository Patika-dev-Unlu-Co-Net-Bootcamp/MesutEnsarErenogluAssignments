- Projede veriler inmemory database tarafından sağlanmaktadır. /Context klasörü altında
- Her bir sorgu için ayrı ayrı oluşturulan View Modelleri (/ViewModels klasörü altında) ile entitylerle maplemek için AutoMapper kullanılmıştır. /Common/Mapping klasörü altında
- Validasyonlar için fluent validation kullanılmıştır. Her view model için ayrı ayrı validasyon düzenlenmiştir. /Validators klasörü altında
- Operasyonlar command ve query olmak üzere ikiye ayrılmış, her bir işlem için ayrı ayrı yazılmıştır. 