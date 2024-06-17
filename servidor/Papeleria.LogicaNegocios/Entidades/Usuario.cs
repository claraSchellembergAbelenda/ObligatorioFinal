using Microsoft.EntityFrameworkCore;
using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Papeleria.LogicaNegocio.Exceptions.Usuario;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index (nameof(email), IsUnique =  true)]
    public class Usuario : IValidable<Usuario>
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string passwordSinEncriptar { get; set; }
        public NombreCompleto? nombreCompleto { get; set; }
        public bool? esAdmin { get; set; }
        public bool? esEncargado { get; set; }
        public Usuario() { }
        public Usuario(int id, string email, string password, string passwordSinEncriptar, NombreCompleto? nombreCompleto, bool? esAdmin, bool? esEncargado)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.passwordSinEncriptar = passwordSinEncriptar;
            this.nombreCompleto = nombreCompleto;
            this.esAdmin = esAdmin;
            this.esEncargado = esEncargado;
        }


        public void EsValido()
        {
            try
            {
                ValidarPosicion();
                ValidarMail();
                ValidarNombreCompleto();
               if (!ValidarPassword())
                {
                    throw new UsuarioNoValidoException
                    ("Contraseña debe tener al menos una mayuscula, una minuscula, un numero y un simbolo de puntuacion y debe tener al menos 6 caracteres");
                }

            }
            catch(UsuarioNoValidoException ex)
            {
                throw ex;
            }
            
        }
        public void ValidarPosicion()
        {
            if(this.esAdmin==true&&this.esEncargado==true)
            {
                throw new UsuarioNoValidoException("Un usuario no puede ser administrador y encargado a la misma vez");
            }
        }
        public bool ValidarMail()
        {
            if (this.email.Contains("@") && this.email.Substring((email.Length - 4), 4) == ".com") return true;
            else
            {
                throw new UsuarioNoValidoException("email incorrecto");
            }
                return false;
        }
        
        public bool ValidarNombreCompleto()
        {
            if (!ValidarNombre(this.nombreCompleto.nombre)) {
                throw new UsuarioNoValidoException
                    ("Nombre ingresado invalido, recuede que si el nombre tiene caracteres no alfabeticos(espacio, apostrofe o guion estos no pueden esta ubicados ni al principio ni al final de la cadena");
                    }
            if (!ValidarNombre(this.nombreCompleto.apellido))
            {
                throw new UsuarioNoValidoException
                    ("Apellido ingresado invalido, recuede que si el nombre tiene caracteres no alfabeticos(espacio, apostrofe o guion estos no pueden esta ubicados ni al principio ni al final de la cadena");
            }
            return true;
        }
        public bool ValidarNombre(string parteNombre)
        {
            //el nombre y el apellido solamente pueden contener caracteres
            //alfabéticos, espacio, apóstrofe o guión del medio.Los caracteres no alfabéticos no pueden estar ubicados al
            //principio ni al final de la cadena.
            for(int i= 0; i< parteNombre.Length; i++)
            {
                char c= parteNombre[i];
                if (!ValidarCaracterNombre(c)) return false;
                if (i == 0 || i== parteNombre.Length-1 )
                {
                    if(!char.IsLower(c) && !char.IsUpper(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidarCaracterNombre(char letra)
        {
            char[] caracteresPuntuacion = { ' ', '-', '\'' };
            if (char.IsUpper(letra) || char.IsLower(letra)|| char.IsDigit(letra) || caracteresPuntuacion.Contains(letra))
            {
                return true;
            }
            return false;
        }
       
        public bool ValidarPassword()
        {
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneDigito = false;
            bool tienePuntuacion = false;
            char[] caracteresPuntuacion = { '.', ';', ',', '!' };
            if (this.passwordSinEncriptar.Length < 6) throw new UsuarioNoValidoException("La contraseña debe tener al menos 6 digitos");
            foreach (char c in this.passwordSinEncriptar)
            {
                if (char.IsUpper(c))
                {
                    tieneMayuscula = true;
                }
                if (char.IsLower(c))
                {
                    tieneMinuscula = true;
                }
                if (char.IsDigit(c))
                {
                    tieneDigito = true;
                }
                if (caracteresPuntuacion.Contains(c))
                {
                    tienePuntuacion = true;
                }
                if (tieneMayuscula && tieneMinuscula && tieneDigito && tienePuntuacion)
                {
                    return true;
                }
            }
            return tieneMayuscula && tieneMinuscula && tieneDigito && tienePuntuacion;
        }


    }
}
