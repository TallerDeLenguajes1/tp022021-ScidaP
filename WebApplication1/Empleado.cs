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

        static Empleado crearEmpleado(string nombre, string apellido, int edad, int antiguedad, float salario) {
            var nuevoEmpleado = new Empleado();
            var rand = new Random();
            int sueldoBasico = rand.Next(17000, 80000);
            double adicional = calcularAdicional(antiguedad, sueldoBasico);
            nuevoEmpleado.Nombre = nombre;
            nuevoEmpleado.Apellido = apellido;
            nuevoEmpleado.Edad = edad;
            nuevoEmpleado.Antiguedad = antiguedad;
            nuevoEmpleado.Salario = salario;
            return nuevoEmpleado;
        }

        public static double calcularAdicional(int antiguedad, int sueldoBasico) {
            // Adicional = 1% del sueldo básico por cada año, es 25% a partir de 20 años.
            double porcentaje;
            if (antiguedad < 20) {
                porcentaje = antiguedad * 0.01;
            } else {
                porcentaje = antiguedad * 0.25;
            }
            return sueldoBasico * porcentaje;
        }

        public static double calcularSueldo(double adicional, int sueldoBasico, double descuento) {
            double sueldo = sueldoBasico + adicional - (sueldoBasico * 0.15);
            return sueldo;
        }
    }
}
