using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Papeleria.LogicaAplicacion.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;

namespace Papeleria.LogicaAplicacion.CasosDeUso
{
    public class ManejadorJWT
    {
        private IEncontrarUsuarioPorEmailCU _getUsuarioByMail;

        public ManejadorJWT(IEncontrarUsuarioPorEmailCU encontrarUsuarioPorEmailCU)
        {
            _getUsuarioByMail = encontrarUsuarioPorEmailCU;

        }


        public static string GenerarToken(UsuarioDTO usuarioDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var clave = Encoding.ASCII.GetBytes("+5/68cZ8hG3J1FJ0HgJQ0zZhxh9eNufp0uF2+R5Fnqw=\r\n");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioDTO.nombre)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        public DTOs.UsuarioDTO ObtenerUsuario(string email)
        {
            {
                var usuario = this._getUsuarioByMail.EncontrarUsuarioPorEmail(email);
                return usuario;

            }
        }

    }
}
