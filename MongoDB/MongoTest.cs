//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MongoDB.Driver;
//using MongoDB.Bson;

//namespace HR.MongoDB
//{
//    class MongoTest
//    {
//        public async void MakeConnection()
//        {
//            var client = new MongoClient("mongodb://localhost:27017");
//            var database = client.GetDatabase("test");
//            var collection = database.GetCollection<BsonDocument>("Timeout");

         
            

//            var currentSP = Builders<BsonDocument>.Filter.Eq("type", "Database");
//            var firstMatch = await collection.Find(currentSP).FirstAsync();
//            if (firstMatch.Count() == 0)
//            {
//                   var document = new BsonDocument
//                                {
//                                    { "name", "MongoDB" },
//                                    { "type", "Database" },
//                                    { "count", 1 },
//                                    { "info", new BsonDocument
//                                              {
//                                                  { "x", 203 },
//                                                  { "y", 102 }
//                                              }}
//                                };
//                await collection.InsertOneAsync(document); // Insert
//            }
//            else
//            {
//                var update = Builders<BsonDocument>.Update.Set("type", "DB");
//                await collection.UpdateOneAsync(currentSP, update);
//            }

//            Console.WriteLine(currentSP.ToJson());
//            //Console.Read();
//        }
//    }
//}
