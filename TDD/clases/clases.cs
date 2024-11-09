using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.clases
{
    public class Vaso
    {
        public int Size { get; private set; }  // Tamaño en onzas (oz)
        public int Quantity { get; private set; }  // Cantidad de vasos disponibles

        public Vaso(int size, int quantity)
        {
            Size = size;
            Quantity = quantity;
        }

        public int GetCantidadVasos()
        {
            return Quantity;
        }

        public bool GiveVasos(int amount)
        {
            if (Quantity >= amount)
            {
                Quantity -= amount;
                return true;
            }
            return false;
        }
    }

    public class Cafetera
    {
        public int CantidadCafe { get; private set; }

        public Cafetera(int cantidadCafe)
        {
            CantidadCafe = cantidadCafe;
        }

        public int GetCantidadDeCafe()
        {
            return CantidadCafe;
        }

        public bool GiveCafe(int cantidad)
        {
            if (CantidadCafe >= cantidad)
            {
                CantidadCafe -= cantidad;
                return true;
            }
            return false;
        }
    }

    public class Azucarero
    {
        public int CantidadAzucar { get; private set; }

        public Azucarero(int cantidadAzucar)
        {
            CantidadAzucar = cantidadAzucar;
        }

        public int GetCantidadDeAzucar()
        {
            return CantidadAzucar;
        }

        public bool GiveAzucar(int cantidad)
        {
            if (CantidadAzucar >= cantidad)
            {
                CantidadAzucar -= cantidad;
                return true;
            }
            return false;
        }
    }

    public class CoffeeMachine
    {
        private Vaso smallCup;
        private Vaso mediumCup;
        private Vaso largeCup;
        private Cafetera cafetera;
        private Azucarero azucarero;

        public CoffeeMachine()
        {
            smallCup = new Vaso(3, 0);  // Tamaño pequeño: 3 oz
            mediumCup = new Vaso(5, 0);  // Tamaño mediano: 5 oz
            largeCup = new Vaso(7, 0);  // Tamaño grande: 7 oz
            cafetera = new Cafetera(0);
            azucarero = new Azucarero(0);
        }

        public void AddCups(int small, int medium, int large)
        {
            smallCup = new Vaso(3, small);
            mediumCup = new Vaso(5, medium);
            largeCup = new Vaso(7, large);
        }

        public void AddCoffee(int cantidad)
        {
            cafetera = new Cafetera(cantidad);
        }

        public void AddSugar(int cantidad)
        {
            azucarero = new Azucarero(cantidad);
        }

        public Vaso GetTipoVaso(string tipoDeVaso)
        {
            return tipoDeVaso switch
            {
                "small" => smallCup,
                "medium" => mediumCup,
                "large" => largeCup,
                _ => null
            };
        }

        public string GetVasoDeCafe(string tipoDeVaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            var vaso = GetTipoVaso(tipoDeVaso);
            if (vaso == null || !vaso.GiveVasos(cantidadDeVasos))
            {
                return "Error: No more cups available.";
            }

            var sizeInOz = vaso.Size * cantidadDeVasos;
            if (!cafetera.GiveCafe(sizeInOz))
            {
                return "Error: Not enough coffee available.";
            }

            if (!azucarero.GiveAzucar(cantidadDeAzucar))
            {
                return "Error: Not enough sugar available.";
            }

            return $"Dispensing {cantidadDeVasos} {tipoDeVaso} cup(s) of coffee with {cantidadDeAzucar} sugar units.";
        }
    }

}
