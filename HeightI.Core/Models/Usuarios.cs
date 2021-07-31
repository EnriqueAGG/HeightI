using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeightI.Core.Models
{
    public class Usuarios
    {
        //MOdelos---->
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get;set;}
                        //llave para http
        [BsonElement("nompersona")]
        public string NomPersona {get;set;}

        [BsonElement("altura")]
        public string Altura {get;set;}

        //FKY emrpesa
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdEmpresa {get;set;}

    }
}