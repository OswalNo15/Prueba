using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurasGeometricas
{

    public abstract class Geometria
    {
        public abstract double CalcularArea();

        public virtual void MostrarAreaCirculo() {
            Console.WriteLine("El área del círculo es: " + CalcularArea()+ "\n");
        }

        public virtual void MostrarAreaRectangulo()
        {
            Console.WriteLine("El área del rectángulo es: " + CalcularArea()+ "\n");
        }
    }



    public class Circulo : Geometria
    {
        public virtual double Radio { get; set; }

        public override double CalcularArea()
        {

           return Math.PI * Math.Pow(Radio, 2);

        }
    }
    public class Rectangulo : Geometria
    {
        public double Base { get; set; }
        public double Altura { get; set; }


        public override double CalcularArea()
        {
            return Base * Altura;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Elija la figura de la cual desea calcular el área:");
                    Console.WriteLine("1. Círculo");
                    Console.WriteLine("2. Rectángulo");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.WriteLine("Ingrese el radio del círculo:");
                            string Radior = Console.ReadLine();
                            double radio = 0;
                            if (!string.IsNullOrEmpty(Radior))
                            {
                                if (double.TryParse(Radior, out radio)) {
                                    radio = Convert.ToDouble(Radior);
                                    Circulo circulo = new Circulo { Radio = radio };
                                    circulo.MostrarAreaCirculo();
                                }
                                else
                                {
                                    Console.WriteLine("El valor del radio no es numérica" + "\n");
                                }
                               
                            }
                            else
                            {
                                Console.WriteLine($"Debes ingresar el radio del círculo" + "\n");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese la base del rectángulo:" );
                            string BaseString=  Console.ReadLine(); 
                            double baseRectangulo = 0;
                            double alturaRectangulo = 0;

                            if (!string.IsNullOrEmpty(BaseString))
                            {
                                if (double.TryParse(BaseString, out baseRectangulo))
                                {
                                    baseRectangulo = Convert.ToDouble(BaseString);
                                }
                                else
                                {
                                    Console.WriteLine("El valor de la base del rectangulo no es numérica" + "\n");
                                    break;
                                }
                               
                            }
                            else
                            {
                                Console.WriteLine("El valor de la base del rectangulo es obligatorio" + "\n");
                                break;
                            }

                            Console.WriteLine("Ingrese la altura del rectángulo:");
                            string AlturaString = Console.ReadLine();
                            if (!string.IsNullOrEmpty(AlturaString))
                            {
                                if (double.TryParse(AlturaString, out alturaRectangulo)) {
                                    alturaRectangulo = Convert.ToDouble(AlturaString);
                                }
                                else
                                {
                                    Console.WriteLine("El valor de la altura del rectangulo no es numérica" + "\n");
                                    break;
                                }

                        
                            }
                            else
                            {
                                Console.WriteLine("El valor de la altura del rectangulo es obligatorio" + "\n");
                                break;
                            }
                            Rectangulo rectangulo = new Rectangulo { Base = baseRectangulo, Altura = alturaRectangulo };
                            rectangulo.MostrarAreaRectangulo();
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo." + "\n");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el codigo: "+ex.Message);
                throw;
            }


        }
    }
}
