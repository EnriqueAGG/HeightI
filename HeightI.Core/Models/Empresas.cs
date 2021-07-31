using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeightI.Core.Models
{
    public class Empresas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
                        //llave para http
        [BsonElement("nomEmpresa")]
        public string NomEmpresa {get;set;}

        [BsonElement("password")]
        public string Password {get;set;}
    }
}