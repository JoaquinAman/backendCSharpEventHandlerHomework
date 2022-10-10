namespace EventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SuscriptorCalculadoraVirtual suscriptorCalculadoraVirtual = new SuscriptorCalculadoraVirtual(3, 2);
            suscriptorCalculadoraVirtual.OperacionSuma();
            suscriptorCalculadoraVirtual.OperacionResta();
        }
    }

    public class EditorCalculadora
    {
        public delegate void EjemploDelegado();
        public event EjemploDelegado ejemploEvento;

        public void Sumar (int a, int b)
        {
            if(ejemploEvento != null)
            {
                ejemploEvento();
                Console.WriteLine("La suma es: " + (a + b));
            }
            else
            {
                Console.WriteLine("No estas suscrito a los eventos.");
            }
            
        }
        public void Resta(int a, int b)
        {
            if (ejemploEvento != null)
            {
                ejemploEvento();
                Console.WriteLine("La resta es: " + (a - b));
            }
            else
            {
                Console.WriteLine("No estas suscrito a los eventos.");
            }
        }
    }

    public class SuscriptorCalculadoraVirtual
    {
        private EditorCalculadora editor;
        private int A;
        private int B;

        public void EjemplEventHandler()
        {
            Console.WriteLine("La operacion va a ser ejecutada.");
        }

        public SuscriptorCalculadoraVirtual(int a, int b)
        {
            this.editor = new EditorCalculadora();
            A = a;
            B = b;
            editor.ejemploEvento += EjemplEventHandler;
        }

        public void OperacionSuma()
        {
            editor.Sumar(A, B);
        }
        public void OperacionResta()
        {
            editor.Resta(A, B);
        }
    }
}