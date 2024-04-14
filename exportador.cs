using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ExportadorDatos
{
    public class Exportador
    {

        public static void Eleccion(int formatoElegido, List<string> alumnos)
        {
            if (formatoElegido == 0 || alumnos.Count == 0)
            {
                return;
            }

            switch (formatoElegido)
            {
                case 1:
                    GenerarCSV(alumnos);
                    break;
                case 2:
                    GenerarJSON(alumnos);
                    break;
                case 3:
                    GenerarSQL(alumnos);
                    break;
                case 4:
                    GenerarXML(alumnos);
                    break;
                default:
                    Console.WriteLine("Formato inválido");
                    break;
            }
        }

        private static void GenerarCSV(List<string> alumnos)
        {
            var salida = new StringBuilder();

            foreach (var alumno in alumnos)
            {
                salida.AppendLine(alumno);
            }

            File.WriteAllText("alumnos.csv", salida.ToString());
        }

        private static void GenerarJSON(List<string> alumnos)
        {
            var salida = new List<Alumno>();

            foreach (var alumno in alumnos)
            {
                var alumnoData = alumno.Split(", ");
                salida.Add(new Alumno
                {
                    Expediente = alumnoData[0],
                    Apellido1 = alumnoData[1],
                    Apellido2 = alumnoData[2],
                    Nombre = alumnoData[3],
                    Correo = alumnoData[4],
                    FechaNacimiento = alumnoData[5]
                });
            }

            var jsonSalida = JsonSerializer.Serialize(salida, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("alumnos.json", jsonSalida);
        }

        public static void GenerarSQL(List<string> alumnos)
        {
            var salida = new StringBuilder();
            salida.AppendLine("CREATE DATABASE IF NOT EXISTS evento;");
            salida.AppendLine("USE evento;");
            salida.AppendLine("CREATE TABLE IF NOT EXISTS asistentes(expediente INT NOT NULL, apellido1 VARCHAR(255), apellido2 VARCHAR(255), nombre VARCHAR(255), correo VARCHAR(255) NOT NULL, fechaNacimiento DATE);");
            salida.AppendLine("INSERT INTO asistentes (expediente, apellido1, apellido2, nombre, correo, fechaNacimiento) VALUES");

            foreach (var alumnoLine in alumnos)
            {
                var alumno = alumnoLine.Split(", ");
                salida.AppendLine($"('{alumno[0]}', '{alumno[1]}', '{alumno[2]}', '{alumno[3]}', '{alumno[4]}', '{alumno[5]}'),");
            }

            salida.Remove(salida.Length - 3, 1); // Remove the last comma
            salida.AppendLine(";");

            File.WriteAllText("alumnos.sql", salida.ToString());
        }

        public static void GenerarXML(List<string> alumnos)
        {
            var salida = new StringBuilder();
            salida.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            salida.AppendLine("<asistentes>");

            foreach (var alumnoLine in alumnos)
            {
                var alumno = alumnoLine.Split(", ");
                salida.AppendLine("  <asistente>");
                salida.AppendLine($"    <expediente>{alumno[0]}</expediente>");
                salida.AppendLine($"    <apellido1>{alumno[1]}</apellido1>");
                salida.AppendLine($"    <apellido2>{alumno[2]}</apellido2>");
                salida.AppendLine($"    <nombre>{alumno[3]}</nombre>");
                salida.AppendLine($"    <correo>{alumno[4]}</correo>");
                salida.AppendLine($"    <fechaNacimiento>{alumno[5]}</fechaNacimiento>");
                salida.AppendLine("  </asistente>");
            }

            salida.AppendLine("</asistentes>");

            File.WriteAllText("alumnos.xml", salida.ToString());
        }

        public class Alumno
        {
            public string? Expediente { get; set; }
            public string? Apellido1 { get; set; }
            public string? Apellido2 { get; set; }
            public string? Nombre { get; set; }
            public string? Correo { get; set; }
            public string? FechaNacimiento { get; set; }
        }
    }
}
