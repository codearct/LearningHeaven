# Abstract Factory
## Ne Zaman?
- Ürünlerin nasıl yaratıldığından,nasıl birleştirildiğinden ve nasıl sunulduğundan sistem bağımsız olunsun isteniyorsa
- Sistem ürün ailelerinden biriyle konfigüre edilecekse
- Birbiriyle ilişkili ürün nesneleri ailesi beraber çalışacaksa
- Sadece arayüzleri kullanarak ürün ailelerinden oluşan bir sınıf kütüphanesi oluşturacaksan
## Bileşenler
- **Abstract Factory**
  - Soyut ürünlerin yaratılmasında görevli operasyonların deklere edildiği soyut sınıftır.(IOrderFactory)
- **Concrete Factory**
  - Somut ürünleri yaratmakla görevli operasyonların implemente edildiği somut sınıftır.(RestaurantPassOrderFactory)
- **Abstract Product**
  - Ürün tipinin deklere edildiği bir arayüzdür.(IPhysicalCardOrder)
- **Concrete Product**
  - Sorumlu somut fabrika sınıfı tarafından yaratılan ürün nesnesini tanımlar
  - Soyut ürün sınıfının implementasyonudur.(RestaurantPassPhysicalCardOrder)
- **Client**
  - Sadece soyut ürün ve soyut fabrika sınıflarını kullanır(OrderService)
## Artıları
- Kullanıcıdan somut sınıfları izole eder.Ürünlerin yaratılma sürecini fabrika enkapsüle etmiş olur.
- Ürün ailelerinin değişimi kolay olur.Abstract factory bütün ürün ailelerinin yaratılma operasyonlarını barındırır.Sadece somut fabrikayı değiştirmekle ürün ailesini değiştirebilirsin.Çünkü concrete factory bütün uygulama boyunca bir yerde ortaya çıkar.
- Bir ürün ailesinin objeleri beraber çalışacak şekilde tasarlanmışsa zaman içinde sadece bir ürün ailesinin yaratılmasını enforse eder.
## Eksileri
- Yeni tip ürünü sisteme dahil etmek zordur.Çünkü soyut sınıfta yaptığın değişikliği bütün somut alt fabrikalara uygulaman gerekir.
## Teknikler
- Her ürün ailesi için bir tane(singleton) somut fabrika olmalı.
- Abstract Factory ürünün sadece interface ini deklare eder.Somut ürünü yaratmak Concrete Factorynin görevidir.İmplemantasyonu kolay olsada her ürün cinsi için bir Concrete Factory sınıfı oluşturulmalıdır.Ürün cinsinin fazla olacağını düşünürsen Prototype Patternini kullanabilirsin.Prototype pattern her bir ürün cinsi için Concrete Factory sınıfı ihtiyacını ortadan kaldırır.
- Her çeşit ürün için Abstract Factory de method olmalıdır.Method imzasında ürünün çeşidini anlayabiliriz.Yeni çeşit bir ürün ilave etmek istediğimizde Abstract Factory i değiştirmek gerekir.Daha esnek ama daha az güvenli ürün yaratan method yazmak için parametre ekleyebiliriz.Bu parametre ürünün çeşidini belli ederse Abstract Factory sadece **Make** adlı methodu her ürün için kullanabiliriz.