public class Motor
{
    private int litros_de_aceite;
    private int potencia;

    public Motor(int potencia)
    {
        this.litros_de_aceite = 0;
        this.potencia = potencia;
    }

    public int GetLitrosDeAceite()
    {
        return this.litros_de_aceite;
    }

    public void SetLitrosDeAceite(int litros_de_aceite)
    {
        this.litros_de_aceite = litros_de_aceite;
    }

    public int GetPotencia()
    {
        return this.potencia;
    }

    public void SetPotencia(int potencia)
    {
        this.potencia = potencia;
    }
}

public class Coche
{
    private Motor motor;
    private string marca;
    private string modelo;
    private double precioAcumuladoAverias;

    public Coche(string marca, string modelo)
    {
        this.marca = marca;
        this.modelo = modelo;
        this.motor = new Motor(0);
        this.precioAcumuladoAverias = 0;
    }

    public string GetMarca()
    {
        return this.marca;
    }

    public string GetModelo()
    {
        return this.modelo;
    }

    public Motor GetMotor()
    {
        return this.motor;
    }

    public double GetPrecioAcumuladoAverias()
    {
        return this.precioAcumuladoAverias;
    }

    public void AcumularAveria(double importe)
    {
        this.precioAcumuladoAverias += importe;
    }
}
public class Garaje
{
    private Coche coche;
    private string averiaAsociada;
    private int numCochesAtendidos;

    public bool AceptarCoche(Coche coche, string averiaAsociada)
    {
        if (this.coche == null)
        {
            this.coche = coche;
            this.averiaAsociada = averiaAsociada;
            this.numCochesAtendidos++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DevolverCoche()
    {
        this.coche = null;
        this.averiaAsociada = null;
    }

    public int GetNumCochesAtendidos()
    {
        return this.numCochesAtendidos;
    }
}
using System;

public class PracticaPOO
{
    static void Main(string[] args)
    {
        Garaje garaje = new Garaje();

        Coche coche1 = new Coche("Marca1", "Modelo1");
        Coche coche2 = new Coche("Marca2", "Modelo2");

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("Iteración {0}", i+1);
            if (garaje.AceptarCoche(coche1, "averia1"))
            {
                double importeAveria = Math.Round(new Random().NextDouble() * 100, 2);
                coche1.AcumularAveria(importeAveria);
                if (garaje.GetAveriaAsociada() == "aceite")
                {
                    coche1.SetLitrosDeAceite(coche1.GetLitrosDeAceite() + 10);
                }
                Console.WriteLine("El coche1 ha sido atendido en el garaje. Importe de avería: {0}", importeAveria);
                garaje.DevolverCoche();
            }
            else
            {
                Console.WriteLine("El garaje ya está atendiendo otro coche.");
            }

            if (garaje.AceptarCoche(coche2, "aceite"))
            {
                double importeAveria = Math.Round(new Random().NextDouble() * 100, 2);
                coche2.AcumularAveria(importeAveria);
                if (garaje.GetAveriaAsociada() == "aceite")
                {
                    coche2.SetLitrosDeAceite(coche2.GetLitrosDeAceite() + 10);
                }
                Console.WriteLine("El coche2 ha sido atendido en el garaje. Importe de avería: {0}", importeAveria);
                garaje.DevolverCoche();
            }
            else
            {
                Console.WriteLine("El garaje ya está atendiendo otro coche.");
            }
        }

        Console.WriteLine("Información del coche1: Marca: {0}, Modelo: {1}, Litros de aceite: {2}, Importe acumulado de averías: {3}",
            coche1.GetMarca(), coche1.GetModelo(), coche1.GetLitrosDeAceite(), coche1.GetImporteAverias());
        Console.WriteLine("Información del coche2: Marca: {0}, Modelo: {1}, Litros de aceite: {2}, Importe acumulado de averías: {3}",
            coche2.GetMarca(), coche2.GetModelo(), coche2.GetLitrosDeAceite(), coche2.GetImporteAverias());
    }
}

