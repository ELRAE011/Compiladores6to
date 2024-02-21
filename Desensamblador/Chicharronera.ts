import * as readline from "readline";

const reader = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

// Función para pedir un número al usuario
async function pedirNumero(mensaje: string): Promise<number> {
  return new Promise((resolve) => {
    reader.question(mensaje, (input) => {
      const numero = parseFloat(input);
      if (isNaN(numero)) {
        console.log("El valor introducido no es un número válido.");
        resolve(pedirNumero(mensaje));
      } else {
        resolve(numero);
      }
    });
  });
}

// Función para resolver una ecuación de segundo grado por la fórmula general
function resolverEcuacion(a: number, b: number, c: number): [number, number] {
  const discriminante = b ** 2 - 4 * a * c;
  if (discriminante > 0) {
    const x1 = (-b + Math.sqrt(discriminante)) / (2 * a);
    const x2 = (-b - Math.sqrt(discriminante)) / (2 * a);
    return [x1, x2];
  } else if (discriminante === 0) {
    const x = -b / (2 * a);
    return [x, x];
  } else {
    return [NaN, NaN];
  }
}

// Pedir los datos de la ecuación al usuario
async function main() {
  try {
    const a = await pedirNumero("Introduce el coeficiente a: ");
    const b = await pedirNumero("Introduce el coeficiente b: ");
    const c = await pedirNumero("Introduce el coeficiente c: ");

    // Resolver la ecuación
    const [x1, x2] = resolverEcuacion(a, b, c);

    // Mostrar los resultados
    if (isNaN(x1) && isNaN(x2)) {
      console.log("La ecuación no tiene soluciones reales.");
    } else if (x1 === x2) {
      console.log(`La ecuación tiene una solución única: x = ${x1}`);
    } else {
      console.log(`La ecuación tiene dos soluciones: x1 = ${x1} y x2 = ${x2}`);
    }
  } catch (error) {
    console.error("Ha ocurrido un error:", error);
  } finally {
    reader.close();
  }
}

main();

//CODIGO PARA CORRER EL PROGRAMA EN CMD
//ts-node .\Chicharronera.ts

//Coeficiente a:1
//Coeficiente b:-3
//Coeficiente c:2