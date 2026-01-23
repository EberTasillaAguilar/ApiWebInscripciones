using APIIncripccionesChota.Data;
using APIInscripcionesChota.Dtos;
using APIInscripcionesChota.Models;
using Humanizer.Localisation;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace APIInscripcionesChota.Services
{
    public class AuthService
    {
        private readonly BD_Context _db;
        private readonly JwtService _jwt;
        public AuthService(BD_Context db, JwtService jwt)
        {
            _db = db;
            _jwt = jwt;
        }


       
        public async Task<string> Register(RegisterDto dto)
        {
           
            if (_db.Usuario_Roles.Any(x => x.Username == dto.Username))
                throw new Exception("El usuario ya existe.");

            string rolIngresado = dto.Rol.ToLower().Trim();

            if (rolIngresado != "postulante" && rolIngresado != "administrativo")
            {
                throw new Exception("El rol ingresado no es válido. Solo se permiten: 'Postulante' o 'Administrativo'.");
            }



            var user = new Usuario_Rol
            {
                Username = dto.Username,


                NombreRol = dto.Rol,

                Password = PasswordHasher.Hash(dto.Password)
            };

            _db.Usuario_Roles.Add(user);
            await _db.SaveChangesAsync();

            return "Registro exitoso.";

        }
            public async Task<string> Login(LoginDto dto)
        {
            var user = _db.Usuario_Roles.FirstOrDefault(x => x.Username == dto.Username);

            if (user == null)
                throw new Exception("Usuario no encontrado.");

            if (!PasswordHasher.Verify(dto.Password, user.Password))
                throw new Exception("Contraseña incorrecta.");

            return _jwt.GenerateToken(user);
        }
    }
}
