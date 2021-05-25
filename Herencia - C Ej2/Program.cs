using System;

namespace Herencia___C_Ej2
{
    class Persona
    {
        public string nombre { get; set; }
        public int edad { get; set; }
        public string DNI;
        public string sexo { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
        public const string hombre = "H";
        public const string mujer = "M";
        public const int bajopeso = -1;
        public const int pordebajopesoideal = 0;
        public const int sobrepeso = 1;


        public Persona()
        {
            nombre = "";
            edad = 0;
            sexo = hombre;
            peso = 1;
            altura = 1;
            generaDNI();
        }

        public Persona(string nnombre, int nedad, string nsexo)
        {
            nombre = nnombre;
            edad = nedad;
            sexo = nsexo;
            peso = 1;
            altura = 1;
            generaDNI();
        }

        public Persona(string nnombre, int nedad, string nsexo, decimal npeso, decimal naltura)
        {
            nombre = nnombre;
            edad = nedad;
            sexo = nsexo;
            peso = npeso;
            altura = naltura;
            generaDNI();
        }

        public Boolean esMayorDeEdad()
        {
            if (edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int calcularIMC()
        {
            decimal valor = peso / altura * altura;

            if (valor < 20)
            {
                return bajopeso;
            }
            else
            {
                if (valor > 25)
                {
                    return sobrepeso;
                }
                else
                {
                    return pordebajopesoideal;
                }
            }
        }

        private void comprobarSexo()
        {
            if ((this.sexo != "H") & (this.sexo != "M"))
            {
                sexo = "H";
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", nombre, edad, DNI, sexo, peso, altura);
        }

        public void generaDNI()
        {
           
            var chars = "ABCDEFGHJKLMNPQRSTVWXYZ";
            var charnums = "0123456789";
            var stringChars = new char[8];
            var miDNI = new char[9];
            Random random = new Random();
            int num = 0;
            int resto = 0;
            char letra;
            string cadena;

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = charnums[random.Next(charnums.Length)];

            }

            cadena = new string(stringChars);
            num = Convert.ToInt32(cadena);

            resto = num % 23;
            
            letra = chars[resto];

            for (int i = 0; i < miDNI.Length-1; i++)
            {
                miDNI[i] = stringChars[i];
            }
            miDNI[miDNI.Length - 1] = letra;
            DNI = new string (miDNI) ;
        }

        static void Main(string[] args)
        {
            Persona pers1;
            Persona pers2;
            Persona pers3 = new Persona();
            string nom;
            int edad;
            string sexo;
            decimal peso;
            decimal altura;

            Console.WriteLine("Introduce el nombre:");
            nom = Console.ReadLine();
            Console.WriteLine("Introduce la edad:");
            edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce el sexo:");
            sexo = Console.ReadLine();
            Console.WriteLine("Introduce el peso:");
            peso = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Introduce la altura:");
            altura = Convert.ToDecimal(Console.ReadLine());

            pers1 = new Persona(nom, edad, sexo, peso, altura);
            pers2 = new Persona(nom, edad, sexo);
            pers3.nombre = nom;
            pers3.edad = edad;
            pers3.sexo = sexo;
            pers3.peso = peso;
            pers3.altura = altura;

            Console.WriteLine("La Persona1 tiene: {0}",pers1.calcularIMC());
            Console.WriteLine("La Persona2 tiene: {0}", pers2.calcularIMC());
            Console.WriteLine("La Persona3 tiene: {0}", pers3.calcularIMC());

            pers1.comprobarSexo();
            pers2.comprobarSexo();
            pers3.comprobarSexo();

            if (pers1.esMayorDeEdad())
            {
                Console.WriteLine("Persona1 es mayor de edad");
            }
            else
            {
                Console.WriteLine("Persona1 no es mayor de edad");
            }
            if (pers2.esMayorDeEdad())
            {
                Console.WriteLine("Persona2 es mayor de edad");
            }
            else
            {
                Console.WriteLine("Persona2 no es mayor de edad");
            }
            if (pers3.esMayorDeEdad())
            {
                Console.WriteLine("Persona3 es mayor de edad");
            }
            else
            {
                Console.WriteLine("Persona3 no es mayor de edad");
            }

            Console.WriteLine(pers1.ToString());
            Console.WriteLine(pers2.ToString());
            Console.WriteLine(pers3.ToString());
        }
    }
}
