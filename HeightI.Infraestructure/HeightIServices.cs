using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver; 
using System.Security.Cryptography;
using System.Text;
using HeightI.Core.Models;
using System.IO.Ports;

namespace HeightI.Infraestructure
{
    public class HeightIServices
    {
         private IMongoCollection<Usuarios> _usu;
         private IMongoCollection<Empresas> _emp;

        SerialPort puerto = new SerialPort(); 

          public HeightIServices(IHeightISettings settings)
        {   //conexiones
                var cliente = new MongoClient(settings.Server);
                var database = cliente.GetDatabase(settings.Database);
                _usu = database.GetCollection<Usuarios>("Usuarios");
                 _emp = database.GetCollection<Empresas>("Empresa");
        }

        //metodos - filtrar usuarios por idempresa
        public List<Usuarios> Tusu(string IdEmp)
        {
            //controlador por cosa
            return _usu.Find(d=> d.IdEmpresa==IdEmp).ToList();
        }

        public string TraerAltura(){
            puerto.PortName = "COM4";
            puerto.BaudRate = 9600;
            puerto.DataBits = 8;
            puerto.Parity = Parity.None;
            puerto.StopBits = StopBits.One;
            puerto.Handshake = Handshake.None;
            puerto.Open();

            string altura = puerto.ReadLine();

            string altura_final = altura.Substring(0, altura.Length - 1);
           

            puerto.Close();  
            return altura_final;
        }

        //metodo de insertar altura con usuario
        public Usuarios CrearUsuario(Usuarios persona)
        {
           
        
            _usu.InsertOne(persona);
             return persona;

        }
        
        //eliminar usuario
        public void BorrarUsu(string id)
        {
            _usu.DeleteOne(u => u.Id == id);
        }


        //extrar usu por id
        public Usuarios ExusUsuario(string IdEmp)
        {
            
            return _usu.Find(d=> d.Id==IdEmp).SingleOrDefault();
        }

        //actualizar usu
         public Usuarios MoodUsuario(Usuarios Ausu)
        {

         _usu.ReplaceOne(u => u.Id == Ausu.Id, Ausu);
            
            return Ausu;
        }

        //metodo2 crear usario para empresa
        public Empresas CrearEmpresa(Empresas persona)
        {
            //controlador por cosa
           persona.Password = EnPass(persona.Password);
            _emp.InsertOne(persona);
             return persona;

        }

          //metodo2 crear login para empresa
        public Empresas LoginEmpresa(string Nombre, string password)
        {
            //controlador por cosa

           string enpass = EnPass(password);
            return _emp.Find(d=> d.NomEmpresa==Nombre && d.Password== enpass).SingleOrDefault();
           

        }








            //encriptar password

        public string EnPass(string pass)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(pass));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}