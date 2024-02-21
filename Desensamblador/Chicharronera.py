import math
def calcular_raices(a, b, c):
  """
  ax^2 + bx + c = 0

  Parámetros:
    a: El coeficiente cuadrático (a != 0)
    b: El coeficiente lineal
    c: El término independiente
  """

  # Cálculo del discriminante
  discriminante = b**2 - 4*a*c

  # Raíces reales
  if discriminante >= 0:
    x1 = (-b + math.sqrt(discriminante)) / (2*a)
    x2 = (-b - math.sqrt(discriminante)) / (2*a)
    return x1, x2

  # Raíces complejas
  else:
    parte_real = -b / (2*a)
    parte_imaginaria = math.sqrt(-discriminante) / (2*a)
    x1 = complex(parte_real, parte_imaginaria)
    x2 = complex(parte_real, -parte_imaginaria)
    return x1, x2

# Solicitar coeficientes al usuario
a = float(input("Ingrese el coeficiente cuadrático (a): "))
b = float(input("Ingrese el coeficiente lineal (b): "))
c = float(input("Ingrese el término independiente (c): "))

# Calcular e imprimir las raíces
raices = calcular_raices(a, b, c)

print(f"Raíz 1: {raices[0]}")
print(f"Raíz 2: {raices[1]}")
