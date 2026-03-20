Dictionary<int, Producto> productos = new Dictionary<int, Producto>();
Console.Write("¿Cuántos productos desea registrar?: ");
int cantidad = int.Parse(Console.ReadLine());
int opcion;
do
{
    Console.WriteLine("1. Agregue productos");
    Console.WriteLine("2. Mostrar producto");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opcion; ");
    opcion= int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            if (cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Producto p = new Producto();
                    Console.WriteLine($"\tProducto {i + 1}");
                    Console.Write("Ingrese el código: ");
                    int codigo = int.Parse(Console.ReadLine());
                    if (productos.ContainsKey(codigo))
                    {
                        Console.WriteLine("Ya existe este código, ingrese otro");
                        i--;
                    }
                    else
                    {
                        Console.Write("Ingrese el nombre del producto: ");
                        p.Nombre = Console.ReadLine();
                        Console.Write("Ingrese el precio: ");
                        p.Precio = double.Parse(Console.ReadLine());
                        if (p.Precio > 0)
                        {
                            Console.Write("Ingrese la cantidad del producto: ");
                            p.Cantidad = int.Parse(Console.ReadLine());
                            if (p.Cantidad > 0)
                            {
                                productos.Add(codigo, p);
                            }
                            else
                            {
                                Console.WriteLine("La cantidad debe ser mayor que 0");
                                i--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El precio debe ser mayor que 0");
                            i--;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("La cantidad debe ser mayor que 0");
            }
            break;
        case 2:
            Console.WriteLine();
            Console.WriteLine("Productos en el diccionario");
            foreach (KeyValuePair<int, Producto> k in productos)
            {
                Console.WriteLine($"Código: {k.Key} | ");
                k.Value.MostrarInformacion();
            }
            break;
        case 3:
            Console.WriteLine("GRACIAS POR UTILIZAR EL PROGRAMA");
            default:
            Console.WriteLine("");
    }
} while (opcion != 3);
class Producto
{
    public string Nombre;
    public double Precio;
    public int Cantidad;
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre} | Precio: {Precio} | Cantidad: {Cantidad}");
    }
}