/*
 * Created by SharpDevelop.
 * User: sigar
 * Date: 20/02/2024
 * Time: 09:06 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace chicharronera
{
	class Program
	{
		    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese los coeficientes de la ecuación cuadrática (ax^2 + bx + c = 0):");

        Console.Write("Coeficiente a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Coeficiente b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Coeficiente c: ");
        double c = double.Parse(Console.ReadLine());

        double discriminante = b * b - 4 * a * c;

        if (discriminante > 0)
        {
        	/*Calcula la primer solucion x1 utilizando la libreria Math.sqrt la cual calcula raiz cuadrada de un numero dado
        	(-b + raiz(discriminate/ 2a)*/
            double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
            /*Calcula la primer solucion x2 utilizando la libreria Math.sqrt la cual calcula raiz cuadrada de un numero dado
            (-b - raiz(discriminate/ 2a)*/
            double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
            Console.WriteLine("Las soluciones son x1 = " + x1 + " y x2 = " + x2);
        }
        else if (discriminante == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("La solución única es x = " + x);
        }
        else
        {
            Console.WriteLine("La ecuación no tiene soluciones reales.");
        }

        Console.ReadLine();
    }
		
	}
}