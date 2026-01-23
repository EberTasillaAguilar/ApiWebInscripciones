using APIIncripccionesChota.Data;
using APIInscripcionesChota.Models;

namespace APIInscripcionesChota.Data
{
    public class BD_Initializer
    {
        public static void Initialize(BD_Context context)
        {
            // Asegura que la BD exista
            context.Database.EnsureCreated();

            // ---------------------------------------------------------
            // 1. CARGA DE CARRERAS (Adaptado a columnas: Nombre, Facultad, Escuela, Sede)
            // ---------------------------------------------------------
            if (!context.Carreras.Any())
            {
                var carreras = new List<Carrera>
                {
                    // Cs. Agrarias
                    new Carrera { Nombre = "Agronomía", Facultad = "Cs. Agrarias", Escuela = "Agronomía", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Forestal", Facultad = "Cs. Agrarias", Escuela = "Ing. Forestal", Sede = "Chota" },
                    new Carrera { Nombre = "Ind. Alimentarias", Facultad = "Cs. Agrarias", Escuela = "Ind. Alimentarias", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Ambiental", Facultad = "Cs. Agrarias", Escuela = "Ing. Ambiental", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Agronegocios", Facultad = "Cs. Agrarias", Escuela = "Ing. Agronegocios", Sede = "Chota" },
                    
                    // Cs. de la Salud
                    new Carrera { Nombre = "Enfermería", Facultad = "Cs. de la Salud", Escuela = "Enfermería", Sede = "Chota" },
                    new Carrera { Nombre = "Biología y Biotecnología", Facultad = "Cs. de la Salud", Escuela = "Biología", Sede = "Chota" },
                    new Carrera { Nombre = "Obstetricia", Facultad = "Cs. de la Salud", Escuela = "Obstetricia", Sede = "Chota" },
                    new Carrera { Nombre = "Psicología", Facultad = "Cs. de la Salud", Escuela = "Psicología", Sede = "Chota" },
                    
                    // Cs. Veterinarias
                    new Carrera { Nombre = "Med. Veterinaria", Facultad = "Cs. Veterinarias", Escuela = "Med. Veterinaria", Sede = "Chota" },
                    
                    // Cs. Econ. Cont. Adm.
                    new Carrera { Nombre = "Economía", Facultad = "Cs. Econ. Cont. Adm.", Escuela = "Economía", Sede = "Chota" },
                    new Carrera { Nombre = "Contabilidad", Facultad = "Cs. Econ. Cont. Adm.", Escuela = "Contabilidad", Sede = "Chota" },
                    new Carrera { Nombre = "Administración", Facultad = "Cs. Econ. Cont. Adm.", Escuela = "Administración", Sede = "Chota" },
                    
                    // Cs. Sociales
                    new Carrera { Nombre = "Sociología", Facultad = "Cs. Sociales", Escuela = "Sociología", Sede = "Chota" },
                    new Carrera { Nombre = "Turismo y Hotelería", Facultad = "Cs. Sociales", Escuela = "Turismo", Sede = "Chota" },
                    new Carrera { Nombre = "Periodismo", Facultad = "Cs. Sociales", Escuela = "Periodismo", Sede = "Chota" },
                    new Carrera { Nombre = "Ciencias Políticas", Facultad = "Cs. Sociales", Escuela = "Ciencias Políticas", Sede = "Chota" },
                    new Carrera { Nombre = "Filosofía", Facultad = "Cs. Sociales", Escuela = "Filosofía", Sede = "Chota" },
                    new Carrera { Nombre = "Historia", Facultad = "Cs. Sociales", Escuela = "Historia", Sede = "Chota" },

                    // Educación
                    new Carrera { Nombre = "Lengua y Literatura", Facultad = "Educación", Escuela = "Educación Secundaria", Sede = "Chota" },
                    new Carrera { Nombre = "Inglés", Facultad = "Educación", Escuela = "Educación Secundaria", Sede = "Chota" },
                    new Carrera { Nombre = "Matemática y Física", Facultad = "Educación", Escuela = "Educación Secundaria", Sede = "Chota" },
                    new Carrera { Nombre = "CC. NN. Química y Biología", Facultad = "Educación", Escuela = "Educación Secundaria", Sede = "Chota" },
                    new Carrera { Nombre = "Educación Primaria", Facultad = "Educación", Escuela = "Educación Primaria", Sede = "Chota" },

                    // Ingeniería
                    new Carrera { Nombre = "Ing. Civil", Facultad = "Ingeniería", Escuela = "Ing. Civil", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Sistemas", Facultad = "Ingeniería", Escuela = "Ing. Sistemas", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Geológica", Facultad = "Ingeniería", Escuela = "Ing. Geológica", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Sanitaria", Facultad = "Ingeniería", Escuela = "Ing. Sanitaria", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. de Minas", Facultad = "Ingeniería", Escuela = "Ing. de Minas", Sede = "Chota" },
                    new Carrera { Nombre = "Ing. Hidráulica", Facultad = "Ingeniería", Escuela = "Ing. Hidráulica", Sede = "Chota" },

                    // Otros
                    new Carrera { Nombre = "Ing. Zootecnista", Facultad = "Cs. Pecuarias", Escuela = "Zootecnia", Sede = "Chota" },
                    new Carrera { Nombre = "Medicina Humana", Facultad = "Medicina", Escuela = "Medicina Humana", Sede = "Chota" },
                    new Carrera { Nombre = "Residentado Médico", Facultad = "Medicina", Escuela = "Postgrado Medicina", Sede = "Chota" },
                    new Carrera { Nombre = "Derecho", Facultad = "Derecho y Cs. Políticas", Escuela = "Derecho", Sede = "Chota" }
                };

                context.Carreras.AddRange(carreras);
                context.SaveChanges();
            }

            // ---------------------------------------------------------
            // 2. CARGA DE TARIFAS (Adaptado a columnas: Descripción, Monto)
            // ---------------------------------------------------------
            if (!context.Tarifas.Any())
            {
                var tarifas = new List<Tarifa>
                {
                    // -- Admisión --
                    new Tarifa { Descripcion = "Postulante institución educativa estatal", Monto = 350m },
                    new Tarifa { Descripcion = "Postulante institución educativa privada", Monto = 450m },
                    new Tarifa { Descripcion = "Postulante licenciado de las FF.AA", Monto = 200m },
                    new Tarifa { Descripcion = "Postulante traslado interno (UNC)", Monto = 450m },
                    new Tarifa { Descripcion = "Postulante traslado externo estatal", Monto = 600m },
                    new Tarifa { Descripcion = "Postulante traslado externo privada", Monto = 850m },
                    new Tarifa { Descripcion = "Postulante graduado y titulado", Monto = 1200m },
                    new Tarifa { Descripcion = "Postulante trabajador e hijo de trabajador UNC", Monto = 50m },
                    new Tarifa { Descripcion = "Postulante víctima de terrorismo", Monto = 50m },

                    // -- Certificados --
                    new Tarifa { Descripcion = "Certificado de estudios", Monto = 50m },
                    new Tarifa { Descripcion = "Certificado de notas", Monto = 40m },
                    new Tarifa { Descripcion = "Certificado de conducta", Monto = 30m },
                    new Tarifa { Descripcion = "Certificado de matrícula", Monto = 45m },
                    new Tarifa { Descripcion = "Certificado de salud", Monto = 35m },

                    // -- Centro de Idiomas --
                    new Tarifa { Descripcion = "Curso de inglés", Monto = 200m },
                    new Tarifa { Descripcion = "Curso de francés", Monto = 210m },
                    new Tarifa { Descripcion = "Curso de alemán", Monto = 220m },
                    new Tarifa { Descripcion = "Curso de chino", Monto = 230m },
                    new Tarifa { Descripcion = "Curso de japonés", Monto = 240m },
                    new Tarifa { Descripcion = "Curso de portugués", Monto = 250m },

                    // -- Tasas UNC --
                    new Tarifa { Descripcion = "Matrícula anual", Monto = 350m },
                    new Tarifa { Descripcion = "Cuota mensual", Monto = 150m },
                    new Tarifa { Descripcion = "Examen de admisión", Monto = 100m },
                    new Tarifa { Descripcion = "Materiales de estudio", Monto = 75m },
                    new Tarifa { Descripcion = "Transporte", Monto = 50m },
                    new Tarifa { Descripcion = "Comedor universitario", Monto = 80m },

                    // -- CEPUNC --
                    new Tarifa { Descripcion = "Inscripción a CEPUNC", Monto = 120m },
                    new Tarifa { Descripcion = "Cuota mensual CEPUNC", Monto = 100m },
                    new Tarifa { Descripcion = "Examen de certificación", Monto = 150m },
                    new Tarifa { Descripcion = "Materiales de CEPUNC", Monto = 60m },
                    new Tarifa { Descripcion = "Talleres y eventos", Monto = 90m }
                };

                context.Tarifas.AddRange(tarifas);
                context.SaveChanges();
            }

            // ---------------------------------------------------------
            // 3. CARGA DE USUARIO POR DEFECTO (Adaptado a: NombreRol, Username, Password)
            // ---------------------------------------------------------
            if (!context.Usuario_Roles.Any())
            {
                // Se crea un usuario Admin por defecto para poder loguearse al inicio
                var adminUser = new Usuario_Rol
                {
                    NombreRol = "Administrador",
                    Username = "admin",
                    Password = "123" // NOTA: En producción, esto debe estar encriptado
                };

                context.Usuario_Roles.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}

