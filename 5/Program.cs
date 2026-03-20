using System.Security.Claims;
using System.Threading.Channels;

Dictionary<int, Producto> productos = new Dictionary<int, Producto>();
int opcion=0;
do
{
    Console.Clear();
    Console.WriteLine("1. Agregue productos");
    Console.WriteLine("2. Mostrar producto");
    Console.WriteLine("3. Eliminar producto");
    Console.WriteLine("4. Buscar producto");
    Console.WriteLine("5. Mostrar todos los productos");
    Console.WriteLine("6. Registrar ventas");
    Console.WriteLine("7. Registrar compra o ingreso de inventario");
    Console.WriteLine("8. Mostrar el producto más caro");
    Console.WriteLine("9. Mostrar el producto con menor existencia");
    Console.WriteLine("10. Mostrar el valor total del inventario");
    Console.WriteLine("11. Salir");
    Console.Write("Seleccione una opcion; ");
    opcion= int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.Write("¿Cuántos productos desea registrar?: ");
            int cantidad = int.Parse(Console.ReadLine());
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
                        if (p.Precio >= 0)
                        {
                            Console.Write("Ingrese la cantidad del producto: ");
                            p.Cantidad = int.Parse(Console.ReadLine());
                            if (p.Cantidad >= 0)
                            {
                                productos.Add(codigo, p);
                            }
                            else
                            {
                                Console.WriteLine("La cantidad debe ser mayor o igual que 0");
                                i--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El precio debe ser mayor o igual que 0");
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
            if (productos.Count > 0)
            {
                Console.Write("Ingrese el codigo del producto que desea modificar: ");
                int buscar = int.Parse(Console.ReadLine());
                if (productos.ContainsKey(buscar))
                {
                    Producto p = new Producto();
                    Console.Write("Ingrese nuevo nombre del producto: ");
                    productos[buscar].Nombre = Console.ReadLine();
                    Console.Write("Ingrese el nuevo precio: ");
                    productos[buscar].Precio = double.Parse(Console.ReadLine());
                    if (productos[buscar].Precio >= 0)
                    {
                        Console.WriteLine("Ingrese la cantidad: ");
                        productos[buscar].Cantidad = int.Parse(Console.ReadLine());
                        if (productos[buscar].Cantidad >= 0)
                        {
                            productos.Add(buscar, p);
                        }
                        else
                        {
                            Console.WriteLine("La cantidad debe ser mayor o igual que 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La cantidad debe ser mayor o igaul que 0");
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados");
            }
            break;
        case 3:
            if (productos.Count > 0)
            {
                Console.Write("Ingrese el codigo del producto que desea eliminar: ");
                int buscar = int.Parse(Console.ReadLine());
                if (productos.ContainsKey(buscar))
                {
                    Producto p = new Producto();
                    productos.Remove(buscar);
                    Console.WriteLine("Se ha elilminda conrrectamente");
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados");
            }
            break;
        case 4:
            if (productos.Count > 0)
            {
                Console.Write("Ingrese el codigo del producto que desea modificar: ");
                int buscar = int.Parse(Console.ReadLine());
                if (productos.ContainsKey(buscar))
                {
                    Console.WriteLine("Este producto si existe");
                }
                else
                {
                    Console.WriteLine("Este producto no existe");
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados");
            }
            break;
        case 5:
            if (productos.Count > 0)
            {
                foreach (KeyValuePair<int, Producto> k in productos)
                {
                    Console.Write($"Codigo: {k.Key} | ");
                    k.Value.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("No hay productos guardados");
            }
            break;
        case 6:
            if (productos.Count > 0)
            {
                Producto p = new Producto();
                Console.Write("Ingrese el código delproducto: ");
                int buscar = int.Parse(Console.ReadLine());
                if (productos.ContainsKey(buscar))
                {
                    Console.Write("Ingrese la cantidad a vender: ");
                    int c = int.Parse(Console.ReadLine());
                    if (c > 0)
                    {
                        if (c > p.Cantidad)
                        {
                            Console.WriteLine("No hay cantidad suficiente");
                        }
                        else
                        {
                            double descueto = p.CalculoSub() * 0.05;
                            Console.WriteLine($"Decuento: {descueto}");
                            Console.WriteLine($"Subtotal: {p.CalculoSub()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La cantidad debe ser mayor que 0");
                    }
                }
                else
                {
                    Console.WriteLine("El producto no fue encontrado");
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el diccionario");
            }
            break;
        case 7:
            if (productos.Count > 0)
            {
                Producto p = new Producto();
                Console.Write("Ingrese el código delproducto: ");
                int buscar = int.Parse(Console.ReadLine());
                if (productos.ContainsKey(buscar))
                {
                    Console.WriteLine("Ingrese la cantidad: ");
                    productos[buscar].Cantidad = int.Parse(Console.ReadLine());
                    if (productos[buscar].Cantidad >= 0)
                    {
                        productos.Add(buscar, p);
                    }
                    else
                    {
                        Console.WriteLine("La cantidad debe ser mayor o igual que 0");
                    }
                }
                else
                {
                    Console.WriteLine("Este producto no existe");
                }
            }
            else
            {
                Console.WriteLine("No hgay productos en el diccionario");
            }
            break;
        case 8:
            if (productos.Count > 0)
            {
                Producto mayor=productos[0];
                foreach(KeyValuePair<int,Producto> i in productos)
                {
                    if (i.Value.Precio > mayor.Precio)
                    {
                        mayor = i.Value;
                    }
                }
                Console.WriteLine("El producto con mayor precio es:");
                mayor.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("No hgay productos en el diccionario");
            }
            break;
        case 9:
            if (productos.Count > 0)
            {
                Producto menor = productos[0];
                foreach (KeyValuePair<int, Producto> i in productos)
                {
                    if (i.Value.CalculoSub()<menor.CalculoSub())
                    {
                        menor = i.Value;
                    }
                }
                Console.WriteLine("El producto con mayor precio es:");
                menor.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("No hgay productos en el diccionario");
            }
            break;
        case 10:
            if (productos.Count > 0)
            {
                double sumaTotal = 0;
                foreach (KeyValuePair<int, Producto> i in productos)
                {
                    sumaTotal += i.Value.CalculoSub();
                }
                Console.WriteLine($"El valor total es: {sumaTotal}");
            }
            else
            {
                Console.WriteLine("No hgay productos en el diccionario");
            }
            break;
        case 11:
            Console.WriteLine("SALIR--GRACIAS POR UTILIZAR EL PROGRAMA");
            break;
        default:
            Console.WriteLine("Esta opcion no existe");
            break;
    }
    Console.ReadKey();
} while (opcion != 11) ;
class Producto
{
    public string Nombre;
    public double Precio;
    public int Cantidad;
    public double CalculoSub()
    {
        return Precio*Cantidad;
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre} | Precio: {Precio} | Cantidad: {Cantidad}");
    }
}