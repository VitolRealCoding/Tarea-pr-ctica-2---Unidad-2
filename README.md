# Tarea-pr-ctica-2---Unidad-2

# App de Operaciones Matemáticas

## Propósito
Esta aplicación de consola en C# permite a los usuarios manejar una lista de números de un tipo elegido (int, double, float, decimal) y realizar operaciones matemáticas (suma, resta, multiplicación, division) sobre ellos usando genéricos, delegados y manejo de excepciones.

## Como Ejecutar
1. Compila y ejecuta el programa en un entorno de C# (por ejemplo, Visual Studio o dotnet CLI).
2. Elige el tipo de número al inicio.
3. Usa el menú para agregar números, realizar operaciones o salir.

## Manejo de Excepciones
- **FormatException**: Manejada cuando se proporciona una entrada inválida al ingresar números.
- **InvalidOperationException**: Lanzada y manejada si se intenta una operación con menos de 2 números.
- **DivideByZeroException**: Manejada durante la división si algún denominador es cero.

## Uso de Genéricos y Delegados
- La clase `ListaNumeros<T>` usa genéricos para manejar diferentes tipos numéricos.
- Delegados (`Func<T, T, T>`) representan operaciones binarias pasadas al método `Calcular` para cómputos flexibles.

## Métodos
- `Agregar(T numero)`: Agrega un numero a la lista.
- `Calcular(Func<T, T, T> operacion)`: Aplica la operación secuencialmente a los elementos de la lista.
