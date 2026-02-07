using System;
using System.Collections.Generic;

namespace AppOperacionesMatematicas
{
    // Clase genérica para manejar la lista de números
    public class ListaNumeros<T> where T : struct
    {
        private readonly List<T> _lista = new List<T>();

        // Método para agregar un número a la lista
        public void Agregar(T numero)
        {
            _lista.Add(numero);
        }

        // Método para realizar la operación usando el delegado proporcionado
        public T Calcular(Func<T, T, T> operacion)
        {
            if (_lista.Count < 2)
            {
                throw new InvalidOperationException("La lista debe contener al menos dos elementos para realizar la operación.");
            }

            T resultado = _lista[0];
            for (int i = 1; i < _lista.Count; i++)
            {
                resultado = operacion(resultado, _lista[i]);
            }
            return resultado;
        }

        // Método para obtener la lista actual (para mostrarla)
        public List<T> ObtenerLista()
        {
            return new List<T>(_lista);
        }
    }

    class Program
    {
        // Método genérico para ejecutar la lógica del programa para un tipo T específico
        private static void EjecutarPrograma<T>(Func<string, T> analizador, Func<T, T, T> opSuma, Func<T, T, T> opResta, Func<T, T, T> opMulti, Func<T, T, T> opDiv) where T : struct
        {
            ListaNumeros<T> listaNumeros = new ListaNumeros<T>();
            while (true)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar un número");
                Console.WriteLine("2. Realizar Suma");
                Console.WriteLine("3. Realizar Resta (secuencial)");
                Console.WriteLine("4. Realizar Multiplicación");
                Console.WriteLine("5. Realizar División (secuencial)");
                Console.WriteLine("6. Mostrar lista actual");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "0")
                {
                    break;
                }
                else if (opcion == "1")
                {
                    Console.Write("Ingresa un número: ");
                    string entrada = Console.ReadLine();
                    try
                    {
                        T numero = analizador(entrada);
                        listaNumeros.Agregar(numero);
                        Console.WriteLine("Número agregado exitosamente.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Formato de entrada inválido. Por favor, ingresa un número válido.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5")
                {
                    Func<T, T, T> operacion = opcion switch
                    {
                        "2" => opSuma,
                        "3" => opResta,
                        "4" => opMulti,
                        "5" => opDiv,
                        _ => null
                    };

                    try
                    {
                        T resultado = listaNumeros.Calcular(operacion);
                        Console.WriteLine($"Resultado: {resultado}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Error de división: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inesperado: {ex.Message}");
                    }
                }
                else if (opcion == "6")
                {
                    List<T> listaActual = listaNumeros.ObtenerLista();
                    if (listaActual.Count == 0)
                    {
                        Console.WriteLine("La lista está vacía.");
                    }
                    else
                    {
                        Console.WriteLine("Lista actual: " + string.Join(", ", listaActual));
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intenta de nuevo.");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a la App de Operaciones Matemáticas.");
            Console.Write("Elige el tipo de número (int, double, float, decimal): ");
            string tipoEntrada = Console.ReadLine().ToLower();

            switch (tipoEntrada)
            {
                case "int":
                    EjecutarPrograma<int>(
                        int.Parse,
                        (x, y) => x + y,
                        (x, y) => x - y,
                        (x, y) => x * y,
                        (x, y) => { if (y == 0) throw new DivideByZeroException("No se puede dividir por cero."); return x / y; }
                    );
                    break;
                case "double":
                    EjecutarPrograma<double>(
                        double.Parse,
                        (x, y) => x + y,
                        (x, y) => x - y,
                        (x, y) => x * y,
                        (x, y) => { if (y == 0) throw new DivideByZeroException("No se puede dividir por cero."); return x / y; }
                    );
                    break;
                case "float":
                    EjecutarPrograma<float>(
                        float.Parse,
                        (x, y) => x + y,
                        (x, y) => x - y,
                        (x, y) => x * y,
                        (x, y) => { if (y == 0) throw new DivideByZeroException("No se puede dividir por cero."); return x / y; }
                    );
                    break;
                case "decimal":
                    EjecutarPrograma<decimal>(
                        decimal.Parse,
                        (x, y) => x + y,
                        (x, y) => x - y,
                        (x, y) => x * y,
                        (x, y) => { if (y == 0) throw new DivideByZeroException("No se puede dividir por cero."); return x / y; }
                    );
                    break;
                default:
                    Console.WriteLine("Tipo no soportado. Saliendo.");
                    break;
            }
        }
    }
}