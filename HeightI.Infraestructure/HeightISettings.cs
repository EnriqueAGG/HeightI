using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System.Security.Cryptography;
using System.Text;
using MongoDB.Driver; 

namespace HeightI.Infraestructure
{
    public class HeightISettings: IHeightISettings
    {   
          public string Server{get;set;}
        public string Database{get;set;}
        public string Collection{get;set;}
    }

    //interface - categorizar
    public interface IHeightISettings
    {
         string Server{get;set;}
         string Database{get;set;}
            }
}