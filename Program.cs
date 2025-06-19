using EvaluacionT3;


GrafoT3 grafo = null;

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n**********************************");
    Console.WriteLine("***************MENÚ***************");
    Console.WriteLine("**********************************");
    Console.WriteLine("1.- Agregar arista.");
    Console.WriteLine("2.- Mostrar.");
    Console.WriteLine("3.- Cantidad de grupos.");
    Console.WriteLine("4.- Es correlativo.");
    Console.WriteLine("5.- Salir.");
    Console.WriteLine("**********************************");
    Console.Write("Ingrese una opción: ");
    string opc = Console.ReadLine();

    switch (opc)
    {
        case "1":

            if (grafo == null)
            {
                Console.WriteLine();
                Console.Write("Ingrese la cantidad de nodos del grafo: ");

                int n = int.Parse(Console.ReadLine());

                grafo = new GrafoT3(n);

            }
                Console.Write("Ingrese el nodo origen: ");
                int o = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el nodo destino: ");
                int d = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el peso: ");
                int p = int.Parse(Console.ReadLine());

                grafo.AgregarArista(o, d, p);
            
            break;
        case "2":
            if (grafo != null)
            {
                grafo.MostrarMatriz();
            }
            else
            {
                Console.WriteLine("Primero agregue aristas.");
            }
                break;
        case "3":
            if(grafo != null)
            {
                Console.WriteLine($"Cantidad de grupos: {grafo.NumGrupos()}");
            }
            break;
        case "4":
            if (grafo != null)
            {
                Console.Write("Ingrese un nodo: ");
                int nodo = int.Parse(Console.ReadLine());
                bool esCorrelativo = grafo.GrupoCorrelativo(nodo);
                Console.WriteLine(esCorrelativo ? "Es correlativo." : "No es correlativo.");
            }
            else Console.WriteLine("Primero agregue aristas.");
            break;
        case "5":
            salir = true;
            break;
        default:
            Console.WriteLine("Error. Opción no válida!!.");
            break;
    }
}