using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeightI.Core.Models;
using HeightI.Infraestructure; 



namespace HeightI.WebAPI.Controllers
{

    //
    [ApiController]
    [Route("[controller]")]


    public class EmpresaController: ControllerBase
    {

         public HeightIServices _heiservice;

        public EmpresaController (HeightIServices heiserv)
        {
            _heiservice = heiserv;
        }
        
          [HttpPost]
        public ActionResult<Empresas> CrearEmpresa(Empresas us)
        {
            return _heiservice.CrearEmpresa(us);
        }


           [HttpPost("{user}&{pass}")]
        public ActionResult<Empresas> LoginUser(string user, string pass)
        {
            return _heiservice.LoginEmpresa(user, pass);
        }







    }
}