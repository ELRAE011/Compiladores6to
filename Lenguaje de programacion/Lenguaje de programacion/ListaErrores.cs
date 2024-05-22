/*
 * Created by SharpDevelop.
 * User: sigar
 * Date: 12/03/2024
 * Time: 12:31 a. m.
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
	/// Description of ListaErrores.
	/// </summary>
	public partial class ListaErrores : Form
	{
		public List<string[]> datos;
		public ListaErrores()
		{
			InitializeComponent();
			datos = new List<string[]>();
            datos.Add(new string[] { "1", "Error de sintaxis", "Ocurre cuando el codigo no sigue la gramatica del lenguaje de programacion", "Revisa el codigo en busca de errores tipograficos" });
            datos.Add(new string[] { "2", "Acceso a indices fuera de rango", "Ocurre al intentar dividir un numero entre cero", "Agrega una validacion para evitar la division  por cero o revisa las condiciones que llevan la division" });
            datos.Add(new string[] { "3", "Acceso a indices fuera de rango", "Ocurre al intentar acceder a una lista o arreglo mas alla de sus limites", "Verifica los limites del arreglo antes de acceder a un  indice y asegurate de que esten dentro de los rangos validos" });
            datos.Add(new string[] { "4", "Uso incorrecto de variables no inicializadas", "Ocurre al intentar utilizar una variable no inicializadacon un valor", "Inicializa todas las variables antes de utilizarlas para evitar comportamientos inesperados" });
            datos.Add(new string[] { "5", "Bucle infinito", "Ocurre cuando un bucle no tiene una condicion de salida o la condicion nunca se cumple", "Revisa la lógica del bucle y asegúrate de que haya una condición de salida que eventualmente se cumpla." });
            datos.Add(new string[] { "6", "Fugas de memoria", "Ocurre cuando la memoria asignada dinámicamente no se libera adecuadamente después de su uso", "Utiliza herramientas de análisis de memoria o técnicas como el Garbage Collector (en lenguajes como Java o C#) para gestionar la memoria correctamente" });
            datos.Add(new string[] { "7", "Referencias a puntero nulo o no inicializados", "Ocurre al intentar acceder a un puntero que no apunta a una dirección de memoria válid", "Verifica que los punteros estén inicializados correctamente antes de utilizarlos y asegúrate de que no estén apuntando a NULL u otra dirección inválida" });
            datos.Add(new string[] { "8", "Errores de logica", "Ocurren cuando el código no produce los resultados esperados debido a un error en la lógica de programación", "Revisa la lógica del programa paso a paso, utilizando herramientas de depuración si es necesario, para identificar y corregir el erro" });
            datos.Add(new string[] { "9", "Dependencias faltantes o incorrectas", "Ocurren cuando el programa depende de bibliotecas o módulos que no están instalados o están mal configurados", "Asegúrate de que todas las dependencias del programa estén instaladas y configuradas correctamente según las especificaciones del proyecto" });
            datos.Add(new string[] { "10", "Errores de concurrencia", "Ocurren cuando múltiples hilos o procesos acceden a recursos compartidos de forma incorrecta, lo que puede provocar condiciones de carrera o bloqueos", "Utiliza mecanismos de sincronización, como semáforos, mutex o locks, para gestionar el acceso concurrente a los recursos compartidos y evitar condiciones de carrera" });
            datos.Add(new string[] { "11", "Falta de llaves", "Este error ocurre cuando falta una llave de apertura { o una llave de cierre } en un bloque de código, lo que puede provocar errores de sintaxis o lógica", "Asegúrate de que cada llave de apertura { tenga una llave de cierre } " });
            datos.Add(new string[] { "12", "Llaves sobrantes", "Este error ocurre cuando hay una llave de apertura { o una llave de cierre } que no tienen su pareja correspondiente, lo que puede causar confusiones en la estructura del código", "Revisa el código para eliminar las llaves que no son necesarias o que no tienen su pareja correspondiente, manteniendo la estructura del código coherente y legible" });
            datos.Add(new string[] { "13", "Falta de OR (|)", "Este error ocurre cuando falta un OR | al final de una declaración o instrucción donde es necesario según las reglas de sintaxis del lenguaje de programación", "Agrega (OR) | al final de cada declaración o instrucción donde sea necesario para garantizar la correcta interpretación del código por parte del compilador o intérprete" });
            datos.Add(new string[] { "14", "Sobran (OR) |", "Este error ocurre cuando hay (OR) | adicionales al final de las declaraciones que no son necesarios según las reglas de sintaxis del lenguaje de programación", "Elimina los (OR) | adicionales al final de las declaraciones para mantener el código limpio y evitar posibles errores de interpretación" });
            datos.Add(new string[] { "15", "Errores de indentacion ", "Este error ocurre cuando la indentación del código no sigue un patrón coherente, lo que puede dificultar la legibilidad y comprensión del código", "Ajusta la indentación del código para seguir un patrón coherente, utilizando un número consistente de espacios o tabulaciones para cada nivel de anidamiento y facilitar la lectura del código" });
            datos.Add(new string[] { "16", "Mala asignacion de tipos de datos", "Este error ocurre cuando se asigna un tipo de dato incorrecto a una variable, lo que puede provocar comportamientos inesperados o errores de ejecución", "Asegúrate de asignar el tipo de dato correcto a cada variable y corrige la declaración de la variable si es necesario para que coincida con el tipo de dato esperado y evitar posibles errores de tipo" });
            datos.Add(new string[] { "17", "Uso incorrecto de operadores ", "Este error ocurre cuando se utiliza un operador incorrecto en una operación, lo que puede llevar a resultados inesperados o errores en la ejecución del código", "Revisa el uso de operadores en el código y asegúrate de utilizar el operador correcto según la operación que deseas realizar, evitando confusiones y errores en el código" });
            datos.Add(new string[] { "18", "Uso de nombres de variables reservados", "Ocurre al intentar utilizar palabras reservadas del lenguaje de programación como nombres de variables", "Cambia el nombre de la variable por uno que no sea una palabra reservada"});
            datos.Add(new string[] { "19", "Erro de escritura en nombres de variables o funciones", "Ocurre al escribir incorrectamente el nombre de una variable o función", "Corrige la escritura del nombre de la variable o función para que coincida exactamente con su declaración en el código" });
            datos.Add(new string[] { "20", "Declaraciones redundantes o inecesarias", "Ocurre al incluir declaraciones en el código que no son necesarias o que se repiten", "Elimina las declaraciones redundantes o innecesarias para simplificar el código y reducir la posibilidad de errores" });
            datos.Add(new string[] { "21", "Desbordamiento de memoria", "Ocurre cuando se asigna o se utiliza más memoria de la disponible, lo que puede llevar a fallos en la ejecución del programa", "Revisa y optimiza el uso de memoria en el programa, evitando la creación de estructuras de datos excesivamente grandes o recursiones profundas que puedan consumir toda la memoria disponible" });
            datos.Add(new string[] { "22", "Confucion entre operadores de asignacion y comparacion", "Ocurre al utilizar el operador de asignación = en lugar del operador de comparación ==, o viceversa", "Utiliza el operador correcto según la operación que desees realizar: = para asignación y == para comparación" });
            datos.Add(new string[] { "23", "No manejo de excepciones o errores", "Ocurre cuando no se incluye código para manejar excepciones o errores que puedan ocurrir durante la ejecución del programa", "Implementa bloques try-catch o manejo de errores para capturar y gestionar excepciones de manera adecuada, garantizando una ejecución segura del programa" });
            datos.Add(new string[] { "24", "Falta cerrar parentecis ", "Faltan cerrar los parentecis", "Pon el parentecis faltante para corregir el error " });
            datos.Add(new string[] { "25", "Falta de return", "Falta retornar a la variable", "Anexa la palabra return para retornar la variable y  corregir el error " });
            datos.Add(new string[] { "26", "Falta de corchetes", "Este error ocurre cuando falta un corchete de apertura [ o un corchete de cierre ] en un bloque de código, lo que puede provocar errores de sintaxis o lógica", "Asegúrate de que cada corchete de apertura [ tenga un corchete de cierre ] " });
            datos.Add(new string[] { "27", "Falta de comillas", "Este error ocurre cuando falta una comilla de apertura o una comilla de cierre en un bloque de código", "Asegúrate de que cada comilla de apertura tenga una comilla de cierre " });
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
