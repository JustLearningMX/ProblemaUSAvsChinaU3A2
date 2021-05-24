using System;

namespace DS_DPRN2_U3_A2_HICL
{
    class Program//Clase principal
    {
        static void Main(string[] args)
        {
            MenuPrincipal();//Se llama al menu principal
        }

        static void MenuPrincipal()//Método que implementa al menú principal
        {
            int? anioCelular = null;//Año del teléfono
            string marcaCelular = null;//Marca del teléfono

            DibujaTitulo();
            //Menú de opciones
            Console.SetCursorPosition(33, 9);
            Console.WriteLine("|-----------------------------------------------------|");
            Console.SetCursorPosition(33, 10);
            Console.WriteLine("| Ingrese los datos del celular:                      |");
            Console.SetCursorPosition(33, 11);
            Console.WriteLine("|-----------------------------------------------------|");
            Console.SetCursorPosition(33, 12);
            Console.WriteLine("|   Año:                                              |");
            Console.SetCursorPosition(33, 13);
            Console.WriteLine("| Marca:                                              |");
            Console.SetCursorPosition(33, 14);
            Console.WriteLine("|-----------------------------------------------------|");

            try
            {   //Invocamos método que captura año del teléfono
                anioCelular = CapturarAnio();

                //Invocamos método que captura marca del teléfono
                marcaCelular = CapturarMarca();

                //Enviamos por parámetros año y marca ya validados
                TelefonoAceptado(anioCelular, marcaCelular);

                Console.ReadKey();
            }
            //EXCEPCIÓN PROPIA 1. Teléfonos 2009 o anteriores o mayor al año actual
            //o por marca china/Apple
            catch (GestionDeErroresPropiosException gdepe)
            {
                Console.SetCursorPosition(33, 22);
                Console.WriteLine(gdepe.Message);//Se agrega a pantalla el mensaje
                Console.SetCursorPosition(41, 23);
                Console.WriteLine("Error: " + gdepe.GetType());//Se coloca el tipo de excepción
                Console.ReadKey();
                MenuPrincipal();//Se retorna al menú principal
            }
        }

        public static void TelefonoAceptado(int? anio, string marca)
        {
            //Instanciamos un celular de la clase Celular
            //Pasando por parámetro el año y la marca
            Celular celular = new Celular(anio, marca);

            DibujaTitulo();
            //Mensaje indicando que el teléfono es aceptado para actualización
            Console.SetCursorPosition(29, 9);
            Console.WriteLine("|--------------------------------------------------------------|");
            Console.SetCursorPosition(29, 10);
            Console.WriteLine("|  ¡Su teléfono es elegible para una actualización de google!  |");
            Console.SetCursorPosition(29, 11);
            Console.WriteLine("|--------------------------------------------------------------|");
            Console.SetCursorPosition(29, 12);
            Console.WriteLine("|                                                              |");
            Console.SetCursorPosition(29, 13);
            Console.WriteLine("|--------------------------------------------------------------|");

            //Marca y teléfono
            Console.SetCursorPosition(32, 12);
            Console.WriteLine(celular.Marca);
            Console.SetCursorPosition(33 + marca.Length, 12);
            Console.WriteLine(celular.Anio);
        }

        public static int? CapturarAnio()
        {//Método para capturar el año
            int? anioCelular = null;

            try
            {   //Capturamos año del teléfono
                Console.SetCursorPosition(42, 12);
                anioCelular = Convert.ToInt32(Console.ReadLine());
            }
            //EXCEPCIÓN 1. FormatException por ingresar texto 
            catch (FormatException fe)
            {
                Console.SetCursorPosition(42, 22);
                Console.WriteLine("** ¡Introduzca un dato numérico! **");
                Console.SetCursorPosition(45, 23);
                Console.WriteLine("Error: " + fe.GetType());
                Console.ReadKey();
                MenuPrincipal();
            }
            //EXCEPCIÓN 2. OverflowException por número demasiado grande 
            catch (OverflowException oe)
            {
                Console.SetCursorPosition(40, 22);
                Console.WriteLine("** ¡El año introducido es exagerado! **");
                Console.SetCursorPosition(45, 23);
                Console.WriteLine("Error: " + oe.GetType());
                Console.ReadKey();
                MenuPrincipal();
            }
            finally
            {
                var hoy = DateTime.Now;

                //Se valida si si año capturado es menor a 2009
                if (anioCelular <= 2009)
                {
                    //se lanza la excepción propia
                    throw new GestionDeErroresPropiosException("** ¡Los teléfonos 2009 o anteriores quedan excluidos! **");
                }
                else if (anioCelular > hoy.Year)
                {//Se valida si el año es mayor al año actual
                    //se lanza la excepción propia
                    throw new GestionDeErroresPropiosException("       El año del teléfono debe ser menor a " + hoy.Year);
                }
            }
            return anioCelular;
        }

        public static string CapturarMarca()
        {//Método para capturar marca del celular
            string marcaCelular = null;

            try
            {   //Capturamos marca del teléfono
                Console.SetCursorPosition(42, 13);
                marcaCelular = Console.ReadLine();
            }
            finally
            {
                //Se valida si marca es china o Apple
                if (@marcaCelular.ToLower() == "huawei" || marcaCelular.ToLower() == "xiaomi" ||
                     marcaCelular.ToLower() == "oppo" || marcaCelular.ToLower() == "pocophone" ||
                     marcaCelular.ToLower() == "apple")
                {
                    //se lanza la excepción propia
                    throw new GestionDeErroresPropiosException("¡Actualización no disponible en teléfonos chinos o de Apple!");
                }
            }
            return marcaCelular;
        }

        public static void DibujaTitulo()//Método que permite agregar título a la ventana principal
        {
            //Mensajes de bienvenida al programa
            Console.Clear();
            Console.SetCursorPosition(40, 1);
            Console.WriteLine("****************************************");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("*        Programación .NET II          *");
            Console.SetCursorPosition(40, 3);
            Console.WriteLine("*               Unidad 3               *");
            Console.SetCursorPosition(40, 4);
            Console.WriteLine("*              Actividad 2             *");
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("*     Control de excepciones en C#     *");
            Console.SetCursorPosition(40, 6);
            Console.WriteLine("*      Alumno: Hiram Chávez López      *");
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("****************************************");
        }
    }
}
