using System;
using System.Collections.Generic;

class Biblioteca
{
    List<Libro> productos = new List<Libro>();

    public void AgregarProducto(string nombre, decimal precio, int stock)
    {
        productos.Add(new Libro(nombre, precio, stock));
        Console.WriteLine("Producto agregado al inventario.");
    }

    public void Disponibles()
    {
        Console.Clear();
        foreach (var producto in productos)
        {
            producto.ConsultarInfo();
            Console.WriteLine();
        }
    }

    public void ConsultarInfoProducto(string nombre)
    {
        var producto = productos.Find(p => p.Nombre.ToLower() == nombre.ToLower());
        if (producto != null)
        {
            producto.ConsultarInfo();
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void VenderProducto(string nombre, int cantidad)
    {
        var producto = productos.Find(p => p.Nombre.ToLower() == nombre.ToLower());
        if (producto != null)
        {
            producto.Vender(cantidad);
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void ReabastecerProducto(string nombre, int cantidad)
    {
        var producto = productos.Find(p => p.Nombre.ToLower() == nombre.ToLower());
        if (producto != null)
        {
            producto.Reabastecer(cantidad);
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void ActualizarPrecioProducto(string nombre, decimal nuevoPrecio)
    {
        var producto = productos.Find(p => p.Nombre.ToLower() == nombre.ToLower());
        if (producto != null)
        {
            producto.ActualizarPrecio(nuevoPrecio);
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public void MostrarResumenProducto(string nombre)
    {
        var producto = productos.Find(p => p.Nombre.ToLower() == nombre.ToLower());
        if (producto != null)
        {
            producto.MostrarResumen();
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
}



class Program
{
    static void Menu()
    {
        Biblioteca biblioteca = new Biblioteca();
        do
        {
            Console.Clear();
            Console.WriteLine("Opciones");
            Console.WriteLine("1. Agregar un nuevo libro a la biblioteca");
            Console.WriteLine("2. Mostrar todos los libros disponibles");
            Console.WriteLine("3. Buscar un libro por su título");
            Console.WriteLine("4. Vender un libro");
            Console.WriteLine("5. Reabastecer un libro");
            Console.WriteLine("6. Actualizar precio de un libro");
            Console.WriteLine("7. Mostrar resumen de un libro");
            Console.WriteLine("8. Salir");

            Console.Write("Ingrese el número de la opción que desea realizar: ");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 8)
            {
                Console.WriteLine("Opción no válida. Ingrese un número del 1 al 8.");
                Console.Write("Ingrese el número de la opción que desea realizar: ");
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el precio del libro: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    Console.Write("Ingrese el stock del libro: ");
                    int stock = int.Parse(Console.ReadLine());
                    biblioteca.AgregarProducto(titulo, precio, stock);
                    break;
                case 2:
                    biblioteca.Disponibles();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro que desea buscar: ");
                    string tituloBuscar = Console.ReadLine();
                    biblioteca.ConsultarInfoProducto(tituloBuscar);
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro que desea vender: ");
                    string tituloVender = Console.ReadLine();
                    Console.Write("Ingrese la cantidad que desea vender: ");
                    int cantidadVender = int.Parse(Console.ReadLine());
                    biblioteca.VenderProducto(tituloVender, cantidadVender);
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro que desea reabastecer: ");
                    string tituloReabastecer = Console.ReadLine();
                    Console.Write("Ingrese la cantidad que desea reabastecer: ");
                    int cantidadReabastecer = int.Parse(Console.ReadLine());
                    biblioteca.ReabastecerProducto(tituloReabastecer, cantidadReabastecer);
                    break;
                case 6:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro cuyo precio desea actualizar: ");
                    string tituloActualizar = Console.ReadLine();
                    Console.Write("Ingrese el nuevo precio: ");
                    decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
                    biblioteca.ActualizarPrecioProducto(tituloActualizar, nuevoPrecio);
                    break;
                case 7:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro cuyo resumen desea mostrar: ");
                    string tituloResumen = Console.ReadLine();
                    biblioteca.MostrarResumenProducto(tituloResumen);
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Programa terminado. ¡Gracias!");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("¿Desea volver al menú principal? (s/n)");
            string volver = Console.ReadLine();
            if (volver.ToLower() == "n")
            {
                Console.WriteLine("Programa terminado. ¡Gracias!");
                Environment.Exit(0);
            }

        } while (true);
    }

    static void Main(string[] args)
    {
        Menu();
    }
}
