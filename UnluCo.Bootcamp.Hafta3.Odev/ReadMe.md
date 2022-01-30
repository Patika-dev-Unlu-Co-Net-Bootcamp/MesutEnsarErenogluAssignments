
Patikadev yapısını düşünerek bir db oluşturun
- eğitimler, öğrenciler,katılımcılar,eğitmenler,asistanlar, eğitimde öğrencilerin yoklamalarının ve başarı durumlarının tutulduğu tablolar olacaktır.
veritipleri ve ilişkiler belirtilmelidir.
![Diagram](/UnluCo.Bootcamp.Hafta3.Odev/Diagram.png "PatikaDev DB Diagram")
- trigger yazın
öğrenci yoklaması girildiğinde. yoklama durumuna göre başarı durumunu hafta bazlı olarak güncelleyin.(Örn: eğitim 7 hafta olsun. ilk iki hafta derslere katıldı ise başarı oranı 2/7 nin % olarak karşılı olmalı.)
![Trigger](/UnluCo.Bootcamp.Hafta3.Odev/Trigger.png "PatikaDev Trigger Example")
- stored procedure yazın
öğrencileri eğitimlere ekleyen bir procedure olacak. öğrenci belirtilen eğitim tarihinde herhangi başka bir eğitime kayıtlı olmamalıdır.
![Stored Procedure](/UnluCo.Bootcamp.Hafta3.Odev/StoredProc.png "PatikaDev Trigger Example")
- view yazın
eğitim bazlı öğrencileri listeleyin(gruplu olarak)
![View](/UnluCo.Bootcamp.Hafta3.Odev/View.png "PatikaDev Trigger Example")
- Bonus
Aynı yapıyı ef code first olarak sadece model bazında oluşturun