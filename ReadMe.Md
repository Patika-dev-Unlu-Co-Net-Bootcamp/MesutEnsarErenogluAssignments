### Hafta 1 [Ödev](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/tree/main/UnluCo.Bootcamp.Hafta1.Odev.WebApi)
- Projede veriler inmemory database tarafından sağlanmaktadır. /Context klasörü altında
- Her bir sorgu için ayrı ayrı oluşturulan View Modelleri (/ViewModels klasörü altında) ile entitylerle maplemek için AutoMapper kullanılmıştır. /Common/Mapping klasörü altında
- Validasyonlar için fluent validation kullanılmıştır. Her view model için ayrı ayrı validasyon düzenlenmiştir. /Validators klasörü altında
- Operasyonlar command ve query olmak üzere ikiye ayrılmış, her bir işlem için ayrı ayrı yazılmıştır. 

### Hafta 2 [Ödev](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/tree/main/UnluCo.Bootcamp.Hafta2.Odev)
- Projede CustomException Middleware kullanılmaktadır. /Middleware/CustomGlobalException.cs
- Request,Response ve Global hatalar loglanarak db'de kaydedilmektedir. /Services/DbLogger
- Extension method örnekleri /Common/Extensions altında yer almaktadır.
- Kullanıcı tarafından kayıt sırasında girilen mail adresinin örnek senaryoda gmail, hotmail yada outlook olması talep edilmektedir. Bu kurala uygunluğu kontrol eden custom attribute /Utilities klasörü altında yer almaktadır.
    
