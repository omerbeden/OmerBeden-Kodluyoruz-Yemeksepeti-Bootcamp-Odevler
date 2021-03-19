using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Homework5.Models;
using Microsoft.Extensions.Configuration;

namespace Homework5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperSampleController : ControllerBase
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");

        }




        /*
         * Parametre olarak su sekilde api/DapperSample/IN?ids=10&ids=11 array seklinde aldigim idleri
         * Query metodu kullanarak sql cümlesinde IN keywordünden sonra kullaniyorum.
         * Query metodu sql cümlesini calistirip bana dönen degeri CreditCard nesnesine map edip veriyor.
         */
        [HttpGet("In")]
        public IActionResult DapperSelectInQuery([FromQuery(Name = "ids")] int[] ids)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql = @"SELECT * FROM [Sales].[CreditCard] WHERE [CreditCardID] IN @ids";
                var affected = dbConnection.Query<CreditCard>(sql, new { ids = ids });
                return Ok(affected);
            }
        }


        /*
         * Dapper'ın execute methodunu kulladim. Bu metot aldıgi parametleri sql komutundaki parametreler ile esliyerek
         * sql komutunu calistiriyor. eger parametre olarak dizi verirsek bu komutu bircok kez calistirabilir.
         * Geri donus olarak kac tane column un etkilendigıini dondurur.
         * Hicbir komut etkilenmesse -1 dondurur
         */
        [HttpPost]
        public IActionResult DapperInsert([FromBody] CreditCard creditCard)
        {

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql = @"INSERT INTO [Sales].[CreditCard] (CardType,CardNumber,ExpMonth,ExpYear,ModifiedDate) 
                                VALUES (@CardType,@CardNumber,@ExpMonth,@ExpYear,@ModifiedDate);";

                var affected = dbConnection.Execute(sql, creditCard);

                return Ok(affected);
            }
        }


        /*
         * Yine Dapperin Execute metodunu kullandım.Parametre olarak girilen id degeri ile json olarak gonderilen nesnenin
         * bilgilerini esleyerek update islemini yapiyor
         */
        [HttpPut("{CreditCardID}")]
        public IActionResult DapperUpdate([FromBody] CreditCard creditCard, int CreditCardID)
        {

            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql = @"UPDATE [Sales].[CreditCard] SET CardType =@CardType,CardNumber=@CardNumber,
                                                                        ExpMonth=@ExpMonth,
                                                                        ExpYear=@ExpYear,ModifiedDate=@ModifiedDate
                                                                        WHERE CreditCardID=@CreditCardID";

                creditCard.CreditCardID = CreditCardID;
                var affected = dbConnection.Execute(sql, creditCard);
            }
            return Ok();
        }


        /*Dapper'in execute metodunu kullanarak silme işlemi yaptım. Fakat CreditCard tablosu baska tablolarda foreign key
         * olarak var oldugundan dolayı ilk once onları sildim daha sonra CreditCard tablosundaki id ile eslesen veriyi sildim
         */
        [HttpDelete("{id}")]
        public IActionResult DapperDeleteCreditCard(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql1 = @"DELETE FROM [Sales].[SalesOrderHeader] WHERE CreditCardID=@CreditCardID";
                string sql2 = @"DELETE FROM [Sales].[PersonCreditCard] WHERE CreditCardID=@CreditCardID";
                string sql3 = @"DELETE FROM[Sales].[CreditCard] WHERE CreditCardID = @CreditCardID";


                var affected1 = dbConnection.Execute(sql1, new CreditCard { CreditCardID = id });
                var affected2 = dbConnection.Execute(sql2, new CreditCard { CreditCardID = id });
                var affected3 = dbConnection.Execute(sql3, new CreditCard { CreditCardID = id });
                return Ok(affected1 + affected2 + affected3);

            }
        }


        /*
         * Yukarida yaptigim yöntemin aynisini bu sefer query string den  şu şekilde:
         *  https://localhost:44314/api/DapperSample/multiple?ids=1&ids=3&ids=4
         * id lerden olusan bir dizi aldım ve bu dizideki id lere gore CreditCard nesneleri olusturdum
         * Exucute metotoduna bu diziyi gönderince sql komutu bu dizi elamlarının her biri icin tek tek
         * calisacak ve kac column un etkilendigini dondurcek
         */
        [HttpDelete("multiple")]
        public IActionResult DapperDeleteCreditCardMultiple([FromQuery(Name = "ids")] int[] idList)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                string sql1 = @"DELETE FROM [Sales].[SalesOrderHeader] WHERE CreditCardID=@CreditCardID";
                string sql2 = @"DELETE FROM [Sales].[PersonCreditCard] WHERE CreditCardID=@CreditCardID";
                string sql3 = @"DELETE FROM[Sales].[CreditCard] WHERE CreditCardID = @CreditCardID";


                CreditCard[] creditCards = new CreditCard[idList.Length];
                for (int i = 0; i < idList.Length; i++)
                {
                    creditCards[i] = new CreditCard { CreditCardID = idList[i] };
                }

                var affected1 = dbConnection.Execute(sql1, creditCards);
                var affected2 = dbConnection.Execute(sql2, creditCards);
                var affected3 = dbConnection.Execute(sql3, creditCards);


                return Ok(affected1 + affected2 + affected3);
            }
        }


        /* Stored Procedure kullanmak icin ilk once basit bir sekilde id ye gore veri ceken bir sp yazdim
         * DynamicParameters sınıfı sayesinde sp nin ihtiyac duydugu parametreleri burada verdim
         * Dapper in query metodunu kullanarak sp yi calistirdim ve geri donus tipi dynamic bir tip dondurdu
         * gerekirse bu donus tipi bir modele map edilip kullanılabilir fakat ben bu ornekte dynamic tip olarak
         * kullandım. Strongly Type kullansaydım sonucu kullandigim strongly type a map edecekti
         *
         * sp ayni sekilde execute metodu ile de kullanılabilirdi eger sp ile insert-update-delete gibi islemler yapilsaydi
         */
        [HttpGet("SP")]
        public IActionResult DapperSP()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                var sp = "[dbo].[getCreditCards]";
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@@CreditCardId", 5);
                var affected = dbConnection.Query(sp, queryParameters, commandType: CommandType.StoredProcedure);
                return Ok(affected);

            }
        }


        /*
         * Request Body den sadece CreditCard nesnesi aldim
         * bu nesneyi db ye eklerken id sini vermedim bu yüzden otomatik olarak sql id verdi ve ben onu bilmedigimden
         * db den eklenen son satiri ceken bir sql yazdim.
         * Daha sonra Diger bir tablo olan PersonCreditCard nesnesini bu cektigim CreditCard nesnesine göre olusturdum.
         * BusinessEntityId yi bilmedigimden ona keyfi bir deger verdim.
         * Daha sonra hazirladigim bu nesneyi db ye ekledim.
         * Bu islemlerin hepsini transaction kullanarak yaptim. burada 3 islem var aslinda ve transaction sayesinde herhangi bir islemde
         * hata olursa önceki islemler iptal oluyor.
         * Transaction u bitirmek icin commit() veya RolBack() fonksiyonu kullanabiliriz ben hatayı handle etmedigimden roolback kullanmadim
         * Commit() metodu ile transaction da bir hata olusmazsa yapilan islemler tamamlanip onaylaniyor.
          */
        [HttpPost("Transaction")]
        public IActionResult DapperTransactionalInsert([FromBody] CreditCard CreditCard)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                using (var transaction = dbConnection.BeginTransaction())
                {
                    string sql = @"INSERT INTO [Sales].[CreditCard] (CardType,CardNumber,ExpMonth,ExpYear,ModifiedDate) 
                                    VALUES (@CardType,@CardNumber,@ExpMonth,@ExpYear,@ModifiedDate);";
                    var affected = dbConnection.Execute(sql, CreditCard, transaction: transaction);


                    sql = @"SELECT TOP(1) * FROM [Sales].[CreditCard] ORDER BY [CreditCardID] DESC";
                    CreditCard selectCreditCard = dbConnection.QueryFirst<CreditCard>(sql, transaction: transaction);

                    PersonCreditCard personCreditCard = new PersonCreditCard
                    {
                        CreditCardID = selectCreditCard.CreditCardID,
                        ModifiedDate = selectCreditCard.ModifiedDate,
                        BusinessEntityID = 1001
                    };

                    sql = @"INSERT INTO [Sales].[PersonCreditCard] (BusinessEntityID,CreditCardID,ModifiedDate) VALUES(@BusinessEntityID,@CreditCardID,@ModifiedDate)";
                    var affected2 = dbConnection.Execute(sql, personCreditCard, transaction: transaction);

                    transaction.Commit();

                    return (affected + affected2 > 0 ? (IActionResult)Ok() : NotFound());
                }
            }
        }


        /*
         *Dapper'in Query Metodunu kullanarak sql cümlesini calistirdim ve geri donen sonucu PersonCreditCard nesnesine
         * map etmesini sagladim. Bu sayade elimde Bu nesnenin bir örnegi olmus oldu.
         * Query kullandigim icin IEnumerable<T> seklinde dondurdu QueryFirst kullansaydim Direk T seklinde donerdi
         */
        [HttpGet("ResultMapping")]
        public IActionResult DapperResultMapping()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql = @"SELECT * FROM [Sales].[PersonCreditCard]";
                var result = dbConnection.Query<PersonCreditCard>(sql);
                return Ok(result);
            }
        }

        /*
         * Dapper'in Query metoduna generic olarak 3 parametre gonderdim bunlar ilk 2 si map edecegi parametreler , sonuncusu ise return parametresi
         * Student tablosunu ben olusturdum ve Bir ogrencinin bir CreditCard i olur seklinde tanimladim.
         * Query metodundaki Func delegate i sayesinde Student icindeki CreditCard propertysini map edebildim.
         * gelen verilerin neye göre ayrilacagini splitOn parametresi ile belirttim
         */
        [HttpGet("OneToOne")]
        public IActionResult DapperOneToOne()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql = @"SELECT * FROM [dbo].[Student] JOIN [Sales].[CreditCard] ON
                              [dbo].[Student].[CreditCardID] =  [Sales].[CreditCard].[CreditCardID]";


                var result = dbConnection.Query<Student, CreditCard, Student>(sql, (student, creditCard) =>
                {
                    student.CreditCard = creditCard;
                    return student;
                },splitOn: "CreditCardID");

                return Ok(result);
            }
        }
        

        /* Asagidaki One-to-Many iliskisinde bir SalesTerritory inin birçok Customer 'ı olabilmektedir.
         * Customer In diğer tablolarla ayrı ayrı yine ilisikisi olsada sadece bu iki SalesTerritory tablosu ile iliskisini gosterdim
         * JOIN (inner join) islemi yaparak TerritoryID leri esit olan SalesTerritory leri listeledim
         * SalesTerritory classı icinde List<Customers> propertysi oldugundan bunlari map etmem gerekti.
         * Func delege i sayesinde bunlari Query metodunda map ettim.
         * SalesTerritoryleri bir dictionary de tuttum çünkü SalesTerritory bir tane olduğundan sabit ama onun birçok Customer ı oldugundan
         * her gelen Customer 'i dictionarydeki SalesTerritory key ine ekliyorum. Bu sayede her defasında ayni SalesTerritory 'i eklemekten ziyade
         * SalesTerritory.Customers larini ekliyorum.
         * Örnegin:
         *        "territoryID": 1,
                    "customers": [
                        {
                            "customerID": 0,
                            "personID": 0,
                            "storeID": 0,
                            "territoryID": 1,
                            "accountNumber": "AW00000001"
                        },
                        {
                            "customerID": 0,
                            "personID": 0,
                            "storeID": 0,
                            "territoryID": 1,
                            "accountNumber": "AW00000002"
                        },
         * bir sonraki satira gecmesi icin splitOn parametresine TerritoryID yi verdim çunku TerritoryID lere göre split edecek ve yeni gelen
         * datayi buna gore ayirmis olacak.
         */
        [HttpGet("OneToMany")]
        public IActionResult DapperOneToMany()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }

                string sql = @"SELECT * FROM [Sales].[SalesTerritory] JOIN [Sales].[Customer] 
                                ON [Sales].[SalesTerritory].[TerritoryID] = [Sales].[Customer].[TerritoryID]";

                var territoryDictionary = new Dictionary<int, SalesTerritory>();

                var salesTerritories = dbConnection.Query<SalesTerritory, Customer, SalesTerritory>(sql,
                    (SalesTerritory, Customer) =>
                    {
                        SalesTerritory salesTerritoryEntry;
                        
                        if (!territoryDictionary.TryGetValue(SalesTerritory.TerritoryID, out salesTerritoryEntry))
                        {
                            salesTerritoryEntry = SalesTerritory;
                            salesTerritoryEntry.Customers = salesTerritoryEntry.Customers ?? new List<Customer>();
                            territoryDictionary.Add(salesTerritoryEntry.TerritoryID, salesTerritoryEntry);
                        }
                        
                        salesTerritoryEntry.Customers.Add(Customer);
                        return salesTerritoryEntry;

                    }, splitOn: "TerritoryID")
                    .Distinct();


                return Ok(salesTerritories);
            }
        }
        
        
        /*Burada 2 farkli tabloya sorgu atan sql cümleleri olusturdum
         * Bunları Dapper'in QueryMultiple metodunu kullanarak calistirdim
         * QueryMultiple metodu aynı command daki bircok sorguyu calistirip geriye bircok ResultSet döner
         * Read metodu ile de gelen ResultSetleri map yaptim.
         * Sonucta iki tabloda gozuksun diye iki ayrı  IEnumerable nesneyi bir Object listesine yazdirip return ettim.
         */
        [HttpGet("MultiQueryMapping")]
        public IActionResult DapperMultiQueryMapping()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {

                string sql = @"SELECT TOP(3) * FROM [Sales].[PersonCreditCard];
                               SELECT TOP(3) * FROM [Sales].[SalesTerritory]";


                var multipleQuery = dbConnection.QueryMultiple(sql);
                var personCreditCard = multipleQuery.Read<PersonCreditCard>();
                var salesTerritory = multipleQuery.Read<SalesTerritory>();

                List<Object> result = new List<object>{personCreditCard,salesTerritory};
                return Ok(result);
            }
        }
        
        
        
    }
}
