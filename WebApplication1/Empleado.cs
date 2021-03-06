using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1 {
    public class Empleado {
        string nombre, apellido;
        int edad, antiguedad;
        float salario;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public float Salario { get => salario; set => salario = value; }

        public static Empleado CrearEmpleado(string nombre, string apellido, int edad, int antiguedad) {
            var nuevoEmpleado = new Empleado();
            var rand = new Random();
            int sueldoBasico = rand.Next(17000, 80000);
            double adicional = CalcularAdicional(antiguedad, sueldoBasico);
            nuevoEmpleado.Nombre = nombre;
            nuevoEmpleado.Apellido = apellido;
            nuevoEmpleado.Edad = edad;
            nuevoEmpleado.Antiguedad = antiguedad;
            nuevoEmpleado.Salario = (float)CalcularSalario(adicional, sueldoBasico);
            return nuevoEmpleado;
        }

        private static double CalcularAdicional(int antiguedad, int sueldoBasico) {
            // Adicional = 1% del sueldo básico por cada año, es 25% a partir de 20 años.
            double PorcentajeAdicional;
            if (antiguedad < 20) {
                PorcentajeAdicional = antiguedad * 0.01;
            } else { // Si el empleado tiene más de 20 años de antiguedad, tendrá un adicional del 25%.
                PorcentajeAdicional = 0.25;
            }
            return sueldoBasico * PorcentajeAdicional;
        }

       private static double CalcularSalario(double adicional, int sueldoBasico) {
            double sueldo = sueldoBasico + adicional - (sueldoBasico * 0.15);
            return sueldo;
        }
    }
}
