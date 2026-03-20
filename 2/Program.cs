Dictionary<int, Producto> productos = new Dictionary<int, Producto>();
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
    Console.WriteLine();
    Console.Write("Ingrese el codigo del producto que desea modificar: ");
    int buscar=int.Parse(Console.ReadLine());
    if(productos.ContainsKey(buscar))
    {
        Producto p=new Producto();
        Console.Write("Ingrese nuevo nombre del producto: ");
        productos[buscar].Nombre = Console.ReadLine();
        Console.Write("Ingrese el nuevo precio: ");
        productos[buscar].Precio= double.Parse(Console.ReadLine());
        if(productos[buscar].Precio > 0)
        {
            Console.WriteLine("Ingrese la cantidad: ");
            productos[buscar].Cantidad= int.Parse(Console.ReadLine()); 
            if (productos[buscar].Cantidad > 0)
            {
                productos.Add(buscar, p);
            }
            else
            {
                Console.WriteLine("La cantidad debe ser mayor que 0");
            }
        }
        else
        {
            Console.WriteLine("La cantidad debe ser mayor que 0");
        }
        foreach (KeyValuePair<int, Producto> k in productos)
        {
            Console.WriteLine($"Código: {k.Key} | ");
            k.Value.MostrarInformacion();
        }
    }
    else
    {
        Console.WriteLine("El producto no existe");
        foreach (KeyValuePair<int, Producto> k in productos)
        {
            Console.WriteLine($"Código: {k.Key} | ");
            k.Value.MostrarInformacion();    
        }
    }
}
else
{
    Console.WriteLine("La cantidad debe ser mayor que 0");
}
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
