using System;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Libro
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public Libro(string nombre, decimal precio, int stock)
    {
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }
}

class Biblioteca
{
    List<Producto> productos = new List<Producto>();

    public void AgregarProducto(string nombre, decimal precio, int stock)
    {
        productos.Add(new Producto(nombre, precio, stock));
        Console.WriteLine("Producto agregado al inventario.");
    }

    public void disponibles()
    {
        Console.Clear();
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Precio: {Precio:C}");
        Console.WriteLine($"Stock: {Stock}");
    }


    public void buscartitulo(string titulo)
    {
        Console.Clear();
        bool encontrado = false;
        foreach (var libro in productos)
        {
            if (libro.Título.ToLower() == titulo.ToLower())
            {
                Console.WriteLine($"Título: {libro.Título}\n Autor: {libro.Autor} \n Estado: {(libro.disponible ? "Disponible" : "Prestado")}");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    public void prestar(string titulo)
    {
        Console.Clear();
        foreach (var libro in productos)
        {
            if (libro.Título.ToLower() == titulo.ToLower() && libro.disponible)
            {
                libro.disponible = false;
                Console.WriteLine("Libro prestado correctamente.");
                return;
            }
        }
        Console.WriteLine("Libro no encontrado o ya prestado.");
    }

    public void devolver(string titulo)
    {
        Console.Clear();
        foreach (var libro in productos)
        {
            if (libro.Título.ToLower() == titulo.ToLower() && !libro.disponible)
            {
                libro.disponible = true;
                Console.WriteLine("Libro devuelto correctamente.");
                return;
            }
        }
        Console.WriteLine("Libro no encontrado o no prestado.");
    }
}

class Program
{
    static void menu()
    {
        Biblioteca biblioteca = new Biblioteca();
        do
        {
            Console.Clear();
            Console.WriteLine("Opciones");
            Console.WriteLine("1. Agregar un nuevo libro a la biblioteca");
            Console.WriteLine("2. Mostrar todos los libros disponibles");
            Console.WriteLine("3. Buscar un libro por su título");
            Console.WriteLine("4. Prestar un libro a un usuario");
            Console.WriteLine("5. Devolver un libro prestado");
            Console.WriteLine("6. Salir");

            Console.Write("Ingrese el número de la opción que desea realizar: ");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
            {
                Console.WriteLine("Opción no válida. Ingrese un número del 1 al 6.");
                Console.Write("Ingrese el número de la opción que desea realizar: ");
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string autor = Console.ReadLine();
                    biblioteca.agregar(titulo, autor);
                    break;
                case 2:
                    biblioteca.disponibles();
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro que desea buscar: ");
                    string tituloBuscar = Console.ReadLine();
                    biblioteca.buscartitulo(tituloBuscar);
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro que desea prestar: ");
                    string tituloPrestar = Console.ReadLine();
                    biblioteca.prestar(tituloPrestar);
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Ingrese el título del libro que desea devolver: ");
                    string tituloDevolver = Console.ReadLine();
                    biblioteca.devolver(tituloDevolver);
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Programa terminado.  ¡Gracias!");
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
        menu();
    }
}