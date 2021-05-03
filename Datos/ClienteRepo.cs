using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class ClienteRepo
    {
        private readonly IConfiguration _configuration;
        private readonly ClienteContext _contexto;
        public ClienteRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            _contexto = new ClienteContext(_configuration.GetConnectionString("DefaultConnection"));
            _contexto.Database.EnsureCreated();
        }
        public int Agrega(Cliente cliente)
        {
            cliente.Id = 0;
            cliente.Activo = true;
            cliente.FechaRegistro = DateTime.Now;

            _contexto.Cliente.Add(cliente);
            _contexto.SaveChanges();
            return cliente.Id;
        }

        public bool ExisteCorreo(string correo)
        {
            var q = (from c in _contexto.Cliente
                     where c.Correo == correo
                     select c.Id).Any();
            return q;
        }

        public List<Cliente> Listar(string busqueda="")
        {
            var q = (from c in _contexto.Cliente
                     where  c.Nombres.Contains(busqueda) ||
                                              c.Apellidos.Contains(busqueda) ||
                                              c.Correo.Contains(busqueda)
                     select c)
                    .ToList();
            return q;
        }
    }
}
