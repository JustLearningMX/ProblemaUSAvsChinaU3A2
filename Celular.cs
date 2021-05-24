using System;

namespace DS_DPRN2_U3_A2_HICL
{
    class Celular
    {
        //Declaramos sus atributos
        protected int? anio;
        protected string marca;

        //Propiedades Getter y Setter
        public int? Anio { get => anio; set => anio = value; }
        public string Marca { get => marca; set => marca = value; }

        //Constructor de la clase
        public Celular(int? anio, string marca)
        {
            //Guardamos los datos
            this.Anio = anio;
            this.Marca = marca;
        }
    }
}
