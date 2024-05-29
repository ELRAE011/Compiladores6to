/*
 * Created by SharpDevelop.
 * User: TEAM FARRU Y COMPAÑIAS SA. DE CV.
 * Date: 06/03/2024
 * Time: 08:49 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions; 
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Lenguaje_de_programacion
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
    {
		private Timer searchTimer;
        private string[] palabrasRojo = { "W", "X", "Y", "Z", "Syndra",
            "Darius", "Alistar", "Ashe", "Annie", "Ammumu", "Akali", "Bardo", "Brand", "Braum", "Camile", "Corki", "Mundo",
            "Draven", "Kaisa", "Morgana", "Numeros", "Palabras", "Or", "Jax", "Fizz", "Gnar", "Div", "Of", "Not"};
		
        private string[] palabrasAzul = { "Veigar", "Kain", "Diana", "Jhin", "Garen", "Katablanca", "Katanegra", "Kataroja", "Tristana",
            "Talon", "Katarina", "Teemo", "Zilean", "Shako", "Iterador", "Function", "Downto", "Until", "Repeat"};
		
        private string[] palabrasVerde = { "=", "+", "-", "|", "/", "*", "==", "!=", "&&", "(", ")", "[", "]",
             ",", ".", ";", "<", ">", "_", "\"", "\'\'", "{", "}", "%"};
		
        private List<string[]> datos;
        public List<string[]> datosErrores;
        //private List<string[]> datosErrores = new List<string[]>();
        
        public MainForm()
        {
            InitializeComponent();
            InicializarDgvListaErrores();
            datos = new List<string[]>();
            datosErrores = new List<string[]>();
            ListaPalabras();
            searchTimer = new Timer();
		    searchTimer.Interval = 500;
		    searchTimer.Tick += SearchTimer_Tick;
        }
        void RichTextBox1TextChanged(object sender, EventArgs e)
        {
            ColoriseText();
            BuscarPalabra();
            InicializarDgvListaErrores();
		    // Reiniciar el temporizador cada vez que se detecta un cambio en el texto
		    searchTimer.Stop();
		    searchTimer.Start();
            dataGridView1.Rows.Clear();
            
            // Obtener el texto actual del RichTextBox
    	string texto = richTextBox1.Text;
    	
    	// Validar estructura de if
        ValidarDeclaracionVariable(texto);

	    // Verificar si ya no quedan caracteres especiales en el texto
	    if (!QuedanCaracteresEspeciales(texto))
	    {
	        // Limpiar los errores del DataGridView
	        LimpiarErroresDataGridView();
	    }
        }// Método para manejar el evento de cambio de selección en el DataGridView
        private void ValidarDeclaracionVariable(string texto)
        {
            // Reiniciar la lista de errores
            LimpiarErrores();

            // Tokenizar el texto
            string[] tokens = texto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Variables para rastrear los elementos esperados
            string[] elementosEsperados = { "Annie", "identificador", "=", "valor", ";" };
            int indiceElementoEsperado = 0;

            // Recorrer los tokens
            foreach (string token in tokens)
            {
                // Validar el token actual
                switch (elementosEsperados[indiceElementoEsperado])
                {
                    case "Annie":
                        if (token != "Annie")
                        {
                            AgregarError(ObtenerIdErrores("Annie"), "Error de sintaxis", "Se esperaba 'int'", "Inicia la declaración de la variable con 'int'");
                        }
                        break;
                    case "identificador":
                        if (!EsIdentificadorValido(token))
                        {
                            AgregarError(ObtenerIdErrores("identificador"), "Error de sintaxis", "Identificador no válido", "Usa un nombre de variable válido o escribe uno");
                        }
                        break;
                    case "=":
                        if (token != "=")
                        {
                            AgregarError(ObtenerIdErrores("="), "Error de sintaxis", "Se esperaba '='", "Usa '=' para asignar un valor a la variable");
                        }
                        break;
                    case "valor":
                        if (!EsValorValido(token))
                        {
                            AgregarError(ObtenerIdErrores("valor"), "Error de sintaxis", "Valor no válido", "Asigna un valor válido a la variable");
                        }
                        break;
                    case "|":
                        if (!token.EndsWith("|"))
                        {
                            AgregarError(ObtenerIdErrores("|"), "Error de sintaxis", "Se esperaba ';'", "Termina la declaración de la variable con ';'");
                        }
                        break;
                    default:
                        break;
                }

                // Pasar al siguiente elemento esperado
                indiceElementoEsperado++;

                // Si llegamos al final de los elementos esperados, reiniciamos el índice
                if (indiceElementoEsperado >= elementosEsperados.Length)
                {
                    indiceElementoEsperado = 0;
                }
            }

            // Actualizar el DataGridView después de validar
            ActualizarDgvListaErrores();
        }

        private bool EsIdentificadorValido(string token)
        {
            // Lista de palabras reservadas
            string[] palabrasReservadas = { "Alistar", "Ashe", "Annie", "Ammumu", "Akali", "Bardo", "Brand", "Braum", "Camile", "Corki", "Mundo", "Draven", "Kaisa" };
            //string[] palabrasReservadas = { "int", "float", "if", "else", "while", "return" };


            // Verificar si es una palabra reservada
            if (palabrasReservadas.Contains(token))
            {
                return false;
            }

            // Verificar si sigue las reglas de nombres de variables
            // Regla: Debe empezar con una letra o guion bajo y puede contener letras, dígitos o guion bajo
            if (string.IsNullOrEmpty(token) || !char.IsLetter(token[0]) && token[0] != '_')
            {
                return false;
            }

            // Verificar que el resto de los caracteres sean letras, dígitos o guion bajo
            for (int i = 1; i < token.Length; i++)
            {
                if (!char.IsLetterOrDigit(token[i]) && token[i] != '_')
                {
                    return false;
                }
            }

            return true;
        }

        private bool EsValorValido(string token)
        {
            int parsedValue;
            return int.TryParse(token, out parsedValue);
        }
        private string ObtenerIdErrores(String elementoEsperado)
        {
            switch (elementoEsperado)
            {
                case "Annie":
                    return "200";
                case "identificador":
                    return "201";
                case "=":
                    return "202";
                case "valor":
                    return "203";
                case "|":
                    return "204";
                default:
                    return "";
            }

        }
        private void LimpiarErrores()
        {
            // Limpiar los errores existentes en el DataGridView
        }

        void DataGridView1SelectionChanged(object sender, EventArgs e)
		{
			// Deshabilitar la edición del DataGridView cuando se selecciona una celda
		    dataGridView1.ReadOnly = true;
		    dataGridView1.AllowUserToAddRows = false;
		    dataGridView1.AllowUserToDeleteRows = false;
		    
		}
        
        private void InicializarDgvListaErrores()
        {
            dgvListaErrores.ColumnCount = 4;
            dgvListaErrores.Columns[0].Name = "ID";
            dgvListaErrores.Columns[1].Name = "Error";
            dgvListaErrores.Columns[2].Name = "Descripción";
            dgvListaErrores.Columns[3].Name = "Solución";
        }

        
        private void AgregarError(string id, string tipo, string descripcion, string solucion)
        {
            if (!ErrorPresente(id))
            {
                datosErrores.Add(new string[] { id, tipo, descripcion, solucion });
                ActualizarDgvListaErrores();
            }

        }

        private void QuitarError(string id)
        {
            var error = datosErrores.FirstOrDefault(dato => dato[0] == id);
            if (error != null)
            {
                datosErrores.Remove(error);
                ActualizarDgvListaErrores();
            }
        }

        private void ActualizarDgvListaErrores()
        {
            dgvListaErrores.Rows.Clear();
            foreach (var dato in datosErrores)
            {
                dgvListaErrores.Rows.Add(dato);
            }
        }
        
        private void ColoriseText()
        {
        	// Código para resaltar palabras clave según el color especificado
            int cursorPosition = richTextBox1.SelectionStart;
            string texto = richTextBox1.Text;

            richTextBox1.SelectAll();
            richTextBox1.SelectionColor = richTextBox1.ForeColor;

            ResaltarPalabras(texto, palabrasRojo, Color.Red);
            ResaltarPalabras(texto, palabrasAzul, Color.Blue);
            ResaltarPalabras(texto, palabrasVerde, Color.Green);

            ColorizeQuotedText();

            richTextBox1.SelectionStart = cursorPosition;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        } 
        // Método para resaltar palabras clave en el texto del RichTextBox
        private void ResaltarPalabras(string texto, string[] palabras, Color color)
        {
        	// Código para resaltar palabras clave en el texto
            foreach (var palabra in palabras)
            {
                int index = 0;
                while ((index = texto.IndexOf(palabra, index)) != -1)
                {
                    richTextBox1.Select(index, palabra.Length);
                    richTextBox1.SelectionColor = color;
                    index += palabra.Length;
                }
            }
        }
        // Método para resaltar texto entre comillas en el RichTextBox
        private void ColorizeQuotedText()
        {
        	// Código para resaltar texto entre comillas
            string pattern = "\"([^\"]*)\"";
            MatchCollection matches = Regex.Matches(richTextBox1.Text, pattern);

            foreach (Match match in matches)
            {
                int startIndex = match.Index;
                int length = match.Length;
                richTextBox1.Select(startIndex, length);
                richTextBox1.SelectionColor = Color.Blue;
            }
        }
        
		private void BuscarPalabra()
		{
	    	string palabraEscrita = richTextBox1.Text;
		   	 var palabras = ObtenerPalabras(palabraEscrita);
		    
		    dataGridView1.Rows.Clear();
		
		    foreach (string palabra in palabras)
		    {
		        // Validar si la primera letra de la palabra es mayúscula
		        if (!char.IsUpper(palabra[0]) && !EsSimbolo(palabra))
		        {
		            continue;
		        }
		
		        var datosEncontrados = datos.Where(dato => dato[1].Equals(palabra, StringComparison.OrdinalIgnoreCase));
		
		        foreach (var datoEncontrado in datosEncontrados)
		        {
		            dataGridView1.Rows.Add(datoEncontrado[0], datoEncontrado[1], datoEncontrado[2]);
		        }
		        
	    	}
		}
		  

		private List<string> ObtenerPalabras(string texto)
		{
		    List<string> palabras = new List<string>();
		
		    // Itera sobre cada palabra en las listas palabrasRojo, palabrasAzul y palabrasVerde
		    foreach (string palabra in palabrasRojo.Concat(palabrasAzul).Concat(palabrasVerde))
		    {
		        int index = texto.IndexOf(palabra);
		        // Mientras encuentre la palabra en el texto
		        while (index != -1)
		        {
		            // Agrega la palabra a la lista de palabras
		            palabras.Add(palabra);
		            // Continúa buscando desde la siguiente posición después de la palabra encontrada
		            index = texto.IndexOf(palabra, index + 1);
		        }
		    }
		
		    return palabras;
		}

        private bool EsSimbolo(string palabra)
		{
		    // Verificar si la palabra es un símbolo
		    return palabrasVerde.Contains(palabra);
		}
		private void SearchTimer_Tick(object sender, EventArgs e)
		{
		    // Se activa cuando ha pasado el tiempo de inactividad
		    searchTimer.Stop();
		    BuscarPalabra();
		    
		}
        private void ListaPalabras()
        {
	            datos.Add(new string[] { "1", "W", "Se utiliza para declarar variables/ es una varible" });
	            datos.Add(new string[] { "2", "X", "Se utiliza para declarar variables/ es una varible" });
	            datos.Add(new string[] { "3", "Y", "Se utiliza para declarar variables/ es una varible" });
	            datos.Add(new string[] { "4", "Z", "Se utiliza para declarar variables/ es una varible" });
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
	            datos.Add(new string[] { "29", "KataBlanca", "Define un miembro de clase como inaccesible desde cualquier otro objeto" });
	            datos.Add(new string[] { "30", "KataNegra", "Define una clase Como Protegida" });
	            datos.Add(new string[] { "31", "KataRoja", "Define una clase como Abstracta" });
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
	            datos.Add(new string[] { "48", "Or", "Operador Logico Or" });
	            datos.Add(new string[] { "49", "\"", "Se usa Para abrir y cerrar Strings" });
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
        }
        

        public void ListaErrores()
		{
        	datosErrores = new List<string[]>();
            datosErrores.Add(new string[] { "1", "Error de sintaxis", "Ocurre cuando el codigo no sigue la gramatica del lenguaje de programacion", "Revisa el codigo en busca de errores tipograficos" });
            datosErrores.Add(new string[] { "2", "Acceso a indices fuera de rango", "Ocurre al intentar dividir un numero entre cero", "Agrega una validacion para evitar la division  por cero o revisa las condiciones que llevan la division" });
            datosErrores.Add(new string[] { "3", "Acceso a indices fuera de rango", "Ocurre al intentar acceder a una lista o arreglo mas alla de sus limites", "Verifica los limites del arreglo antes de acceder a un  indice y asegurate de que esten dentro de los rangos validos" });
            datosErrores.Add(new string[] { "4", "Uso incorrecto de variables no inicializadas", "Ocurre al intentar utilizar una variable no inicializadacon un valor", "Inicializa todas las variables antes de utilizarlas para evitar comportamientos inesperados" });
            datosErrores.Add(new string[] { "5", "Bucle infinito", "Ocurre cuando un bucle no tiene una condicion de salida o la condicion nunca se cumple", "Revisa la lógica del bucle y asegúrate de que haya una condición de salida que eventualmente se cumpla." });
            datosErrores.Add(new string[] { "6", "Fugas de memoria", "Ocurre cuando la memoria asignada dinámicamente no se libera adecuadamente después de su uso", "Utiliza herramientas de análisis de memoria o técnicas como el Garbage Collector (en lenguajes como Java o C#) para gestionar la memoria correctamente" });
            datosErrores.Add(new string[] { "7", "Referencias a puntero nulo o no inicializados", "Ocurre al intentar acceder a un puntero que no apunta a una dirección de memoria válid", "Verifica que los punteros estén inicializados correctamente antes de utilizarlos y asegúrate de que no estén apuntando a NULL u otra dirección inválida" });
            datosErrores.Add(new string[] { "8", "Errores de logica", "Ocurren cuando el código no produce los resultados esperados debido a un error en la lógica de programación", "Revisa la lógica del programa paso a paso, utilizando herramientas de depuración si es necesario, para identificar y corregir el erro" });
            datosErrores.Add(new string[] { "9", "Dependencias faltantes o incorrectas", "Ocurren cuando el programa depende de bibliotecas o módulos que no están instalados o están mal configurados", "Asegúrate de que todas las dependencias del programa estén instaladas y configuradas correctamente según las especificaciones del proyecto" });
            datosErrores.Add(new string[] { "10", "Errores de concurrencia", "Ocurren cuando múltiples hilos o procesos acceden a recursos compartidos de forma incorrecta, lo que puede provocar condiciones de carrera o bloqueos", "Utiliza mecanismos de sincronización, como semáforos, mutex o locks, para gestionar el acceso concurrente a los recursos compartidos y evitar condiciones de carrera" });
            datosErrores.Add(new string[] { "11", "Falta de llaves", "Este error ocurre cuando falta una llave de apertura { o una llave de cierre } en un bloque de código, lo que puede provocar errores de sintaxis o lógica", "Asegúrate de que cada llave de apertura { tenga una llave de cierre } " });
            datosErrores.Add(new string[] { "12", "Llaves sobrantes", "Este error ocurre cuando hay una llave de apertura { o una llave de cierre } que no tienen su pareja correspondiente, lo que puede causar confusiones en la estructura del código", "Revisa el código para eliminar las llaves que no son necesarias o que no tienen su pareja correspondiente, manteniendo la estructura del código coherente y legible" });
            datosErrores.Add(new string[] { "13", "Falta de OR (|)", "Este error ocurre cuando falta un OR | al final de una declaración o instrucción donde es necesario según las reglas de sintaxis del lenguaje de programación", "Agrega (OR) | al final de cada declaración o instrucción donde sea necesario para garantizar la correcta interpretación del código por parte del compilador o intérprete" });
            datosErrores.Add(new string[] { "14", "Sobran (OR) |", "Este error ocurre cuando hay (OR) | adicionales al final de las declaraciones que no son necesarios según las reglas de sintaxis del lenguaje de programación", "Elimina los (OR) | adicionales al final de las declaraciones para mantener el código limpio y evitar posibles errores de interpretación" });
            datosErrores.Add(new string[] { "15", "Errores de indentacion ", "Este error ocurre cuando la indentación del código no sigue un patrón coherente, lo que puede dificultar la legibilidad y comprensión del código", "Ajusta la indentación del código para seguir un patrón coherente, utilizando un número consistente de espacios o tabulaciones para cada nivel de anidamiento y facilitar la lectura del código" });
            datosErrores.Add(new string[] { "16", "Mala asignacion de tipos de datos", "Este error ocurre cuando se asigna un tipo de dato incorrecto a una variable, lo que puede provocar comportamientos inesperados o errores de ejecución", "Asegúrate de asignar el tipo de dato correcto a cada variable y corrige la declaración de la variable si es necesario para que coincida con el tipo de dato esperado y evitar posibles errores de tipo" });
            datosErrores.Add(new string[] { "17", "Uso incorrecto de operadores ", "Este error ocurre cuando se utiliza un operador incorrecto en una operación, lo que puede llevar a resultados inesperados o errores en la ejecución del código", "Revisa el uso de operadores en el código y asegúrate de utilizar el operador correcto según la operación que deseas realizar, evitando confusiones y errores en el código" });
            datosErrores.Add(new string[] { "18", "Uso de nombres de variables reservados", "Ocurre al intentar utilizar palabras reservadas del lenguaje de programación como nombres de variables", "Cambia el nombre de la variable por uno que no sea una palabra reservada"});
            datosErrores.Add(new string[] { "19", "Erro de escritura en nombres de variables o funciones", "Ocurre al escribir incorrectamente el nombre de una variable o función", "Corrige la escritura del nombre de la variable o función para que coincida exactamente con su declaración en el código" });
            datosErrores.Add(new string[] { "20", "Declaraciones redundantes o inecesarias", "Ocurre al incluir declaraciones en el código que no son necesarias o que se repiten", "Elimina las declaraciones redundantes o innecesarias para simplificar el código y reducir la posibilidad de errores" });
            datosErrores.Add(new string[] { "21", "Desbordamiento de memoria", "Ocurre cuando se asigna o se utiliza más memoria de la disponible, lo que puede llevar a fallos en la ejecución del programa", "Revisa y optimiza el uso de memoria en el programa, evitando la creación de estructuras de datos excesivamente grandes o recursiones profundas que puedan consumir toda la memoria disponible" });
            datosErrores.Add(new string[] { "22", "Confucion entre operadores de asignacion y comparacion", "Ocurre al utilizar el operador de asignación = en lugar del operador de comparación ==, o viceversa", "Utiliza el operador correcto según la operación que desees realizar: = para asignación y == para comparación" });
            datosErrores.Add(new string[] { "23", "No manejo de excepciones o errores", "Ocurre cuando no se incluye código para manejar excepciones o errores que puedan ocurrir durante la ejecución del programa", "Implementa bloques try-catch o manejo de errores para capturar y gestionar excepciones de manera adecuada, garantizando una ejecución segura del programa" });
            datosErrores.Add(new string[] { "24", "Falta cerrar parentecis ", "Faltan cerrar los parentecis", "Pon el parentecis faltante para corregir el error " });
            datosErrores.Add(new string[] { "25", "Falta de return", "Falta retornar a la variable", "Anexa la palabra return para retornar la variable y  corregir el error " });
            datosErrores.Add(new string[] { "26", "Falta de corchetes", "Este error ocurre cuando falta un corchete de apertura [ o un corchete de cierre ] en un bloque de código, lo que puede provocar errores de sintaxis o lógica", "Asegúrate de que cada corchete de apertura [ tenga un corchete de cierre ] " });
            datosErrores.Add(new string[] { "27", "Falta de comillas", "Este error ocurre cuando falta una comilla de apertura o una comilla de cierre en un bloque de código", "Asegúrate de que cada comilla de apertura tenga una comilla de cierre " });
        }
            
		void Label7Click(object sender, EventArgs e)
		{
		    string rutaArchivoExcel = @"C:\Users\sigar.JUAN\Documents\GitHub\Compiladores6to\palabras reservadas 1.xlsx";
		    if (System.IO.File.Exists(rutaArchivoExcel))
		    {
		        Process.Start(rutaArchivoExcel);
		    }
		    else
		    {
		        MessageBox.Show("El archivo especificado no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
		void Label8Click(object sender, System.EventArgs e)
		{
			PalabrasReservadas palabrasreservadas = new PalabrasReservadas();
            palabrasreservadas.Show();
		}
		
		void Label9Click(object sender, EventArgs e)
		{
			string rutaArchivoExcel = @"C:\Users\sigar.JUAN\Documents\GitHub\Compiladores6to\palabras reservadas 1.xlsx";
		    if (System.IO.File.Exists(rutaArchivoExcel))
		    {
		        Process.Start(rutaArchivoExcel);
		    }
		    else
		    {
		        MessageBox.Show("El archivo especificado no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
		void Label10Click(object sender, EventArgs e)
		{
			ListaErrores listaErrores = new ListaErrores();
            listaErrores.Show();
		}

		private bool ErrorPresente(string id)
		{
		    return datosErrores.Any(dato => dato[0] == id);
		}


        void RichTextBox1KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si se está borrando un paréntesis, una llave, un corchete o una comilla
            if (e.KeyChar == (char)Keys.Back)
            {
                // Obtener el texto actual del RichTextBox
                string texto = richTextBox1.Text;

                // Obtener el índice del cursor
                int index = richTextBox1.SelectionStart;

                // Verificar si el caracter en la posición anterior es una palabra reservada o un simbolo importante
                if (index > 0 && index <= texto.Length)
                {
                    char charToCheck = texto[index - 1];
                    if (charToCheck == ' ' || charToCheck == '=' || charToCheck == '|')
                    {
                        // Validar declaración de variables
                        ValidarDeclaracionVariable(texto);
                    }
                }
            }
        }
            /*
            // Verificar si se está borrando un paréntesis, una llave, un corchete o una comilla
            if (e.KeyChar == (char)Keys.Back)
            {
                // Obtener el texto actual del RichTextBox
                string texto = richTextBox1.Text;

                // Obtener el índice del cursor
                int index = richTextBox1.SelectionStart;

                // Verificar si el caracter en la posición anterior es un paréntesis, una llave, un corchete o una comilla
                if (index > 0 && index <= texto.Length && (texto[index - 1] == '(' || texto[index - 1] == ')' || texto[index - 1] == '{' || texto[index - 1] == '}' || texto[index - 1] == '[' || texto[index - 1] == ']' || texto[index - 1] == '\"'))
                {
                    // Obtener el id correspondiente al tipo de error
                    string id = ObtenerIdError(texto[index - 1]);

                    // Agregar el error si no está presente
                    if (!ErrorPresente(id))
                    {
                        AgregarError(id, "Falta cerrar " + texto[index - 1], "Este error ocurre cuando falta un " + texto[index - 1] + " en el código", "Agrega el " + texto[index - 1] + " que falta para corregir el error");
                    }
                }
            }

            if (e.KeyChar == '(')
            {
                AgregarError("24", "Falta cerrar paréntesis", "Este error ocurre cuando falta un paréntesis en el código", "Agrega el paréntesis que falta para corregir el error");
            }
            else if (e.KeyChar == ')')
            {
                QuitarError("24");
            }

            if (e.KeyChar == '{')
            {
                AgregarError("11", "Falta de llave", "Este error ocurre cuando falta una llave de apertura { o una llave de cierre } en un bloque de código", "Asegúrate de que cada llave de apertura { tenga una llave de cierre } ");
            }
            else if (e.KeyChar == '}')
            {
                QuitarError("11");
            }

            if (e.KeyChar == '[')
            {
                AgregarError("26", "Falta de corchete", "Este error ocurre cuando falta un corchete de apertura [ o un corchete de cierre ] en un bloque de código", "Asegúrate de que cada corchete de apertura [ tenga un corchete de cierre ] ");
            }
            else if (e.KeyChar == ']')
            {
                QuitarError("26");
            }

		}

        private string ObtenerIdError(char caracter)
        {
            switch (caracter)
            {
                case '(':
                    return "24";
                case ')':
                    return "24";
                case '{':
                    return "11";
                case '}':
                    return "11";
                case '[':
                    return "26";
                case ']':
                    return "26";
                case '\"':
                    return "27";
                default:
                    return "";
            }
        }*/
				
		private void LimpiarErroresDataGridView()
		{
		    // Eliminar todos los errores del DataGridView
		    dgvListaErrores.Rows.Clear();
		}

		private bool QuedanCaracteresEspeciales(string texto)
		{
		    // Verificar si quedan caracteres especiales en el texto
		    return texto.Contains('(') || texto.Contains(')') || texto.Contains('{') || texto.Contains('}') || texto.Contains('[') || texto.Contains(']') || texto.Contains('\"');
		}
		
		void DgvListaErroresSelectionChanged(object sender, EventArgs e)
		{
			dgvListaErrores.ReadOnly = true;
		    dgvListaErrores.AllowUserToAddRows = false;
		    dgvListaErrores.AllowUserToDeleteRows = false;
		}
		
		void LblDiagramasClick(object sender, EventArgs e)
		{
			string rutaArchivoExcel = @"C:\Users\sigar.JUAN\Documents\GitHub\Compiladores6to\diagramas de passcal.docx";
		    if (System.IO.File.Exists(rutaArchivoExcel))
		    {
		        Process.Start(rutaArchivoExcel);
		    }
		    else
		    {
		        MessageBox.Show("El archivo especificado no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
		
		void LblIconoDiagramasClick(object sender, EventArgs e)
		{
			string rutaArchivoExcel = @"C:\Users\sigar.JUAN\Documents\GitHub\Compiladores6to\diagramas de passcal.docx";
		    if (System.IO.File.Exists(rutaArchivoExcel))
		    {
		        Process.Start(rutaArchivoExcel);
		    }
		    else
		    {
		        MessageBox.Show("El archivo especificado no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
		
		void LblAutomataClick(object sender, EventArgs e)
		{
            string rutaArchivoExcel = @"C:\Users\sigar.JUAN\Documents\GitHub\Compiladores6to\Autómatas.docx";
		    if (System.IO.File.Exists(rutaArchivoExcel))
		    {
		        Process.Start(rutaArchivoExcel);
		    }
		    else
		    {
		        MessageBox.Show("El archivo especificado no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
		
		void LblIconoAutomataClick(object sender, EventArgs e)
		{
			string rutaArchivoExcel = @"C:\Users\sigar.JUAN\Documents\GitHub\Compiladores6to\Autómatas.docx";
		    if (System.IO.File.Exists(rutaArchivoExcel))
		    {
		        Process.Start(rutaArchivoExcel);
		    }
		    else
		    {
		        MessageBox.Show("El archivo especificado no existe.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
		    }
		}
    }
}
