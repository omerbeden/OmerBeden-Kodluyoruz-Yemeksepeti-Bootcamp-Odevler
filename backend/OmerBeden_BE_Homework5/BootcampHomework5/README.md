# BootcampHomework5

Selam Arkadaşlar, Ödeviniz aşağıdadır. 
Dapper üzerinde aşağıdaki işlemleri içeren bir proje istiyorum.Tek bir proje olabilir
Her Madde bir method olacak.
Generic bir yapı istemiyorum. Direk method üzerinde Controller'da using ile kullanabilirsiniz.

Controller : DapperSample
Action        : DapperInsert
Action        : DapperUpdate
Action        : DapperSpInsert gibi

Direk method üzerinde ( kod bloğunda ) açıklama yapmanızı istiyorum. 
Açıklamanızın uzunluğu size kalmış.  

bkz : Dapper'ın Query methodunu kullandım. Bu method dbden dönen result set'i model'ime map ediyor.

bkz : Dbde çalışan bir delete cümleciğim var. Belirli Idleri silmek istiyorum bu nedenle @Id parametresine Id Listesi gönderdim.
Dapper benim gönderdiğim Id listesine göre sql tarafına query'lerimi çoklayıp gönderecek
IdList = 1,2,3 
Queries : delete from table where Id = 1;
                  delete from table where ıd = 2; gibi 


SqlServer üzerinde işlem yapmanız gerekiyor ( SqlServer + SqlManagementStudio indirebilirsiniz )

AdventureWorks2019 db yi kullanabilirsiniz.

Maddeler aşağıdaki gibidir.
( Not : Geçen hafta verdiğim ödevi bitirmeyenlerin ödevi tamamlamasını şiddetle tavsiye ediyorum )

* Select IN Query
* Insert
* Update
* Delete
* Delete IN Query
* SP Kullanımı
* Transactional Insert min 2 tablo
* ResultMapping (Select)
* One-to-one Mapping
* One-To-Many mapping,
* MultipleQueryMapping
