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
- Projede örnek senaryoya göre Movie işlemlerine ulaşabilmek için kayıt olunması gerekir. MovieController altına yapılacak her sorgu başlığında kayıt sırasında girilen email ve şifre basic olarak giriş yapılmalıdır. Bunu kontrol eden attribute Utilities/CustomAuthAttribute olarak yer almaktadır. 
## Hafta 3 [Ödev](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/tree/main/UnluCo.Bootcamp.Hafta3.Odev)

Patikadev yapısını düşünerek bir db oluşturuldu
- eğitimler, öğrenciler,katılımcılar,eğitmenler,asistanlar, eğitimde öğrencilerin yoklamalarının ve başarı durumlarının tutulduğu tablolar içeriyor.
veritipleri ve ilişkiler belirtilmelidi.
![Diagram](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/blob/main/UnluCo.Bootcamp.Hafta3.Odev/Diagram.PNG)

- öğrenci yoklaması girildiğinde. yoklama durumuna göre başarı durumunu hafta bazlı olarak güncelleyin.(Örn: eğitim 7 hafta olsun. ilk iki hafta derslere katıldı ise başarı oranı 2/7 nin % olarak karşılığı yazılacak trigger hazırlandı.)
![Trigger](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/blob/main/UnluCo.Bootcamp.Hafta3.Odev/Trigger.PNG)

- öğrencileri eğitimlere ekleyen bir procedure yazıldı. öğrenci belirtilen eğitim tarihinde herhangi başka bir eğitime kayıtlı olamaz.
![Stored Procedure](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/blob/main/UnluCo.Bootcamp.Hafta3.Odev/StoredProc.PNG)

- eğitim bazlı öğrencileri listeleyen view yazıldı.
![View](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/blob/main/UnluCo.Bootcamp.Hafta3.Odev/View.PNG)

## Hafta 4 [Ödev](https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/MesutEnsarErenogluAssignments/tree/main/UnluCo.Bootcamp.Hafta4.Odev)

- Kullanıcı işlemleri için Asp.NET Core Identity altyapısı kullanıldı.
- Api de yetkilendirme işlemleri için JWT kullanıldı. Movie Controller içerisindeki actionlara erişmek için token kullanılmalıdır. 
- Movie Controller içerisinde her response da header a verinin oluşturulma/getirilme tarihi saati yazan result filter oluşturuldu.
- Rol bazlı yapı tanımlandı. Create,Delete,Update işlemleri yalnızca admin tarafından gerçekleştirilebilir.    
