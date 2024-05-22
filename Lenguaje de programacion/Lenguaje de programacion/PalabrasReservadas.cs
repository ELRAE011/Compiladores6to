/*
 * Created by SharpDevelop.
 * User: sigar
 * Date: 06/03/2024
 * Time: 09:19 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Lenguaje_de_programacion
{
	/// <summary>
	/// Description of PalabrasReservadas.
	/// </summary>
	public partial class PalabrasReservadas : Form
	{
		public List<string[]> datos;
		public PalabrasReservadas()
		{		
			InitializeComponent();
            datos = new List<string[]>();
            datos.Add(new string[] { "1", "Azir", "Se utiliza para declarar sumas" });
            datos.Add(new string[] { "2", "Lux", "Se utiliza para hacer restas" });
            datos.Add(new string[] { "3", "Ryze", "Se utiliza para hacer multiplicaciones" });
            datos.Add(new string[] { "4", "Trynda", "Seutiliza para hacer divisiones" });
            datos.Add(new string[] { "5", "Kain", "Se utiliza para ejecutar un bloque de codigo si se cumple una condicion" });
            datos.Add(new string[] { "6", "Diana", "Se utiliza para  ejecutar un bloque de codigo si la condicion espesifica de la estructura if no se cumple" });
            datos.Add(new string[] { "7", "Jhin", "Se utiliza para iterar sobre una secuencia" });
            datos.Add(new string[] { "8", "Garen", "Se utiliza para ejecutar un bloque de codigo mientras se cumpla una condicion" });
            datos.Add(new string[] { "9", "Katarina", "Define un miembro de clase como accesible desde cualquier otro objeto" });
            datos.Add(new string[] { "10", "Syndra", "Indica que un miembro de clase pertenece a la clase en lugar de las intancias de la clase" });
            datos.Add(new string[] { "11", "Darius", "Indica que es un metodo, no devuleve ningun valor" });
            datos.Add(new string[] { "12", "Veigar", "Marca el inicio del programa" });
            datos.Add(new string[] { "13", "Alistar", "Se usa para declarar variables" });
            datos.Add(new string[] { "14", "Ashe", "Se usa para declarar variables(letras,numero y simbolos" });
            datos.Add(new string[] { "15", "Annie", "Se usa para declarar variables de numeros enteros" });
            datos.Add(new string[] { "16", "Ammumu", "Se usa para declarar variables de numeros con punto decimal" });
            datos.Add(new string[] { "17", "Akali", "Representa numeros de punto flotante" });
            datos.Add(new string[] { "18", "Bardo", "Representa numeros de punto flotante" });
            datos.Add(new string[] { "19", "Brand", "Representa un valor boleano es decir verdadero o falso" });
            datos.Add(new string[] { "20", "Braum", "Representa un solo carácter" });
            datos.Add(new string[] { "21", "Camile", "Representa enteros mas grandes que int" });
            datos.Add(new string[] { "22", "Corki", "Representa enteros mas pequeños que int" });
            datos.Add(new string[] { "23", "Mundo", "Indica una constante" });
            datos.Add(new string[] { "24", "Draven", "Indica un tipo de dato" });
            datos.Add(new string[] { "25", "Kaisa", "Inicia un ciclo de Instrucciones" });
            datos.Add(new string[] { "26", "Teemo", "Se usa Para Escribir en Consola" });
            datos.Add(new string[] { "27", "Zilean", "Se utiliza para leer lo escrito por el usuario " });
            datos.Add(new string[] { "28", "Shako", "Se utiliza para hacer una Instrucción" });
            datos.Add(new string[] { "29", "Kata Blanca", "Define un miembro de clase como inaccesible desde cualquier otro objeto" });
            datos.Add(new string[] { "30", "Kata Negra", "Define una clase Como Protegida" });
            datos.Add(new string[] { "31", "Kata Roja", "Define una clase como Abstracta" });
            datos.Add(new string[] { "32", "Morgana", "Se usa para determinar datos Absolutos o Reales(No pueden Cambiar su Valor)" });
            datos.Add(new string[] { "33", "Numeros", "Obtiene los numeros del 0 al 9 y los contruidos con esa bace" });
            datos.Add(new string[] { "34", "Palabras", "Se usa para definir palabras como nombres del programa y algunas variables acepta letras,numeros y simbolos" });
            datos.Add(new string[] { "35", "Tristana", "En un bucle,  se utiliza para salir del bucle antes de que se complete la iteración normal" });
            datos.Add(new string[] { "36", "Talon", " se utiliza  para devolver un valor de una función" });
            datos.Add(new string[] { "37", "=", " Se ocupa como asignacion de datos" });
            datos.Add(new string[] { "38", " ", "Espacio En el Lenguaje De Programacion" });
            datos.Add(new string[] { "39", "	", "Tabulacion Del Lenguaje De Programacion" });
            datos.Add(new string[] { "40", "+", "Se Usa Para sumar Datos o concatenar strings, tambien es utilizado para saber si el numero es positivo" });
            datos.Add(new string[] { "41", "-", "Se usa para restar datos (Numericos), tambien es utilizado antes de un numero para indicar que el numero es negativo" });
            datos.Add(new string[] { "42", "|", "Indica el final de una declaracion o instrucción" });
            datos.Add(new string[] { "43", "/", "Se usa para Dividir Datos (Numericos)" });
            datos.Add(new string[] { "44", "*", "Se usa para Multiplicar Datos (Numericos)" });
            datos.Add(new string[] { "45", "==", "Se usa Para comparar 2 Tipos de Datos y Verificar Si son Iguales" });
            datos.Add(new string[] { "46", "!=", "Se usa Para comparar 2 Tipos de Datos y Verificar Si son Diferentes" });
            datos.Add(new string[] { "47", "&&", "Operador Logico And " });
            datos.Add(new string[] { "48", "or", "Operador Logico Or" });
            datos.Add(new string[] { "49", "\"\"", "Se usa Para abrir y cerrar Strings" });
            datos.Add(new string[] { "50", "\'\'", "Se usa para abrir y cerrar chars" });
            datos.Add(new string[] { "51", "(", "Abren Metodos o Parametros" });
            datos.Add(new string[] { "52", ")", "Cierran Metodos O parametros" });
            datos.Add(new string[] { "53", "()", "Aseguran que sean Metodos O parametros" });
            datos.Add(new string[] { "54", "[", "Se usa Para Arreglos y Datos Numericosa" });
            datos.Add(new string[] { "55", "]", "Se usa Para Arreglos y Datos Numericos" });
            datos.Add(new string[] { "56", "[]", "Se usa Para Arreglos y Datos Numericos" });
            datos.Add(new string[] { "57", ",", "Se usa para separar variables o parametros al declararlos" });
            datos.Add(new string[] { "58", ".", "Se usa para agregar funciones extras a los metodos" });
            datos.Add(new string[] { "59", ";", "Se usa Para Abrir o Cerrar secciones de codigo (Metodos,Programas, Parametros, depende el caso, etc...)" });
            datos.Add(new string[] { "60", "<", "Indica que un numero es menor que " });
            datos.Add(new string[] { "61", ">", "Indica que un numero es mayor que " });
            datos.Add(new string[] { "62", "_", "Se usa para separar palabras en nombres de variables " });
            datos.Add(new string[] { "63", "{", "Se usa para imprimir variables " });
	        datos.Add(new string[] { "64", "}", "Se usa para imprimir variables " });
	        datos.Add(new string[] { "65", "{}", "Se usa para imprimir variables " });
	        datos.Add(new string[] { "66", "Jax", "Son las etiquetas de caso que representan los posibles valores que puede tomar la expresión" });
	        datos.Add(new string[] { "67", "Fizz", "es una palabra clave utilizada para indicar el inicio de un bloque de código que se ejecutará si una condición en una estructura de control if, else if, else, while, for, entre otras, se evalúa como verdadera." });
	        datos.Add(new string[] { "68", "Gnar", "se utiliza para definir bloques de código reutilizables que realizan tareas específicas en lenguajes de programación como Pascal y PL/SQL." });
	        datos.Add(new string[] { "69", "Iterador", "su función puede variar según el contexto del lenguaje en el que se use. Sin embargo, en algunos contextos puede referirse a moverse hacia adelante en una estructura de datos o en un flujo de control." });
	        datos.Add(new string[] { "70", "Function", "Es el identificador que se utiliza para llamar a la función desde otras partes del programa." });
	        datos.Add(new string[] { "71", "Div", "Esta función devuelve el cociente entero de una división, es decir, el resultado de dividir un número por otro sin incluir el residuo." });
	        datos.Add(new string[] { "72", "%", "devuelve el residuo de la división entera de dos números. En términos más simples, mod te da el resto de dividir un número por otro." });
	        datos.Add(new string[] { "73", "Downto", "Se utiliza para iterar en orden descendente, es decir, desde un valor inicial hasta un valor final, disminuyendo en cada iteración" });
	        datos.Add(new string[] { "74", "Repeat", "es una estructura que repite un bloque de código hasta que se cumple una condición. " });
	        datos.Add(new string[] { "75", "Until", "se utiliza junto con la estructura de bucle repeat  Indica la condición de salida del bucle repeat. El bucle se repetirá hasta que la condición después de until sea verdadera. " });
	        datos.Add(new string[] { "76", "Of", "of se utiliza en las sentencias case para especificar los valores o rangos de valores que se compararán." });
	        datos.Add(new string[] { "77", "Not", "La función not es un operador lógico que se utiliza para negar o invertir el valor de una expresión booleana. " });
            foreach (string[] fila in datos)
	        {
	           	dataGridView1.Rows.Add(fila);
	        }	
		}
		void DataGridView1SelectionChanged(object sender, EventArgs e)
		{
			dataGridView1.ReadOnly = true;
		    dataGridView1.AllowUserToAddRows = false;
		    dataGridView1.AllowUserToDeleteRows = false;
		}
	}
}
