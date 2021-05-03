using Datos;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class LCliente
    {
        private readonly IConfiguration _configuration;
        private readonly ClienteRepo _clienteRepo;
        public LCliente(IConfiguration configuration)
        {
            _configuration = configuration;
            _clienteRepo = new ClienteRepo(_configuration);
        }
        public List<Cliente> Listar(string busqueda = "")
        {
            var retorno = _clienteRepo.Listar(busqueda);
            return retorno;
        }
        public int Agregar(Cliente cliente)
        {
            var existe = _clienteRepo.ExisteCorreo(cliente.Correo);
            if (existe)
            { throw new ExcepcionLogica($"El correo: {cliente.Correo}, ya se encuentra registrado"); }
            var retorno = _clienteRepo.Agrega(cliente);
            return retorno;
        }
    }
}
