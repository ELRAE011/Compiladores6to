// Función para pedir un número al usuario
function pedirNumero(mensaje: string): number {
    let numero: number | null = null;
    while (!numero) {
      const input = prompt(mensaje);
      if (input === null) {
        return NaN;
      }
      numero = parseFloat(input);
      if (isNaN(numero)) {
        alert("El valor introducido no es un número válido.");
        numero = null;
      }
    }
    return numero;
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
  const a = pedirNumero("Introduce el coeficiente a: ");
  const b = pedirNumero("Introduce el coeficiente b: ");
  const c = pedirNumero("Introduce el coeficiente c: ");
  
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
  