using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace BLFacturacionSB
{
    public class ClientesBL
    {
        Contexto _contexto;
        public BindingList<Cliente> ListaCliente { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListaCliente = new BindingList<Cliente>();

      
        }

        public BindingList<Cliente> ObtenerClientes()
        {

            _contexto.Clientes.Load();
            ListaCliente = _contexto.Clientes.Local.ToBindingList();

            return ListaCliente;
        }

        public Resultado GuardarCliente(Cliente cliente)
        {
            var resultado = Validar(cliente);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }
           
                _contexto.SaveChanges();

                resultado.Exitoso = true;
                return resultado;
                                        
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaCliente.Add(nuevoCliente);

        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaCliente)
            {
                if (cliente.Id == id)
                {
                    ListaCliente.Remove(cliente);
                    _contexto.SaveChanges();
                    return true;
                   }
                }
                
                    return false;
            }

        private Resultado Validar(Cliente cliente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (cliente.RazonSocial == "")
        {
                resultado.Mensaje = "Ingrese una Descripcion";
                resultado.Exitoso = false;
            }
            if (cliente.RtnCliente=="")
            {
                resultado.Mensaje = "Ingrese RTN";
                resultado.Exitoso = false;
            }

            if (cliente.RtnCliente == "")
            {
                resultado.Mensaje = "Ingrese RTN";
                resultado.Exitoso = false;
            }

            if (cliente.Nombrecont == "")
            {
                resultado.Mensaje = "Ingrese Contacto";
                resultado.Exitoso = false;
            }

            if (cliente.Telefono == "")
            {
                resultado.Mensaje = "Ingrese Contacto";
                resultado.Exitoso = false;
            }

            if (cliente.TipoCliente == "")
            {
                resultado.Mensaje = "Defina tipo de Cliente";
                resultado.Exitoso = false;
            }

            return resultado;

        }
    }


 

    public class Cliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string RtnCliente  { get; set; }
        public string TipoCliente { get; set; }
        public string TermPago { get; set; }
        public string Nombrecont { get; set; }
        public string Puesto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }

    }

}

