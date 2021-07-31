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

    [ApiController]
    [Route("[controller]")]

    public class UsuarioController: ControllerBase
    {
        public HeightIServices _heiservice;

        public UsuarioController (HeightIServices heiserv)
        {
            _heiservice = heiserv;
        }

        //empresa
       [HttpGet("Empresa/{id}")]
        public ActionResult<List<Usuarios>> Tusuario(string Id)
        {
            return _heiservice.Tusu(Id);
        }
        
        [HttpPost]
        public ActionResult<Usuarios> PostAccion(Usuarios us)
        {
            return _heiservice.CrearUsuario(us);
        }


        [HttpDelete("{id}")]
        public  ActionResult BorrarUsuario(string Id)
        {
             _heiservice.BorrarUsu(Id);

             return Ok("Dato Borrado");
        }

       
        //id usuario
        [HttpGet("{id}")]
        public ActionResult<Usuarios> IdSuario(string Id)
        {
            return _heiservice.ExusUsuario(Id);
        }


        [HttpPut]
        public ActionResult<Usuarios> ActualizarUsuario(Usuarios us)
        {
            return _heiservice.MoodUsuario(us);
        }

        [HttpGet("altura")]
        public ActionResult ObtenerAltura()
        {
            return Ok(_heiservice.TraerAltura());
        }
        



    }
}