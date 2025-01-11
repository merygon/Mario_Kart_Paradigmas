# Proyecto: Videojuego de Carreras al Estilo Mario Kart

## Integrantes del Equipo
- María González Gómez
- David Tarrasa Puebla

## Descripción General
Desarrollo de un videojuego de carreras inspirado en Mario Kart, implementado en Unity utilizando C#. El proyecto incluye una experiencia completa de menús interactivos, selección de personajes y vehículos, selección de circuitos, y modos de juego (carrera o contrarreloj). Además, cuenta con un sistema para mostrar el podio final al terminar las carreras.

## Características Principales

### Menús Interactivos
- Menú principal con opciones de iniciar el juego, configuración y salir.
- Selección de personaje con avatares personalizados.
- Selección de coche con diferentes estéticas y estadísticas (velocidad, manejo, aceleración).
- Elección de circuito con diferentes diseños y niveles de dificultad.
- Selección del modo de juego: Carrera o Contrarreloj.

### Sistema de Carrera
- Circuitos en 3D con diseños variados.
- IA para coches controlados por el juego.
- Cálculo de posiciones en tiempo real.
- Sistema de conteo de vueltas.

### Final de Carrera
- Podio final que muestra las posiciones obtenidas por cada participante.
- Pantalla de resultados con tiempos y posiciones.

### Gráficos y Sonido
- Estética vibrante y colorida.
- Música y efectos de sonido personalizados.

## Requisitos del Sistema
- Unity 2022.3 o superior.
- .NET Framework 4.7.1 o superior.
- Controlador compatible con Unity (opcional para más inmersión).

## Estructura del Proyecto

![image](https://github.com/user-attachments/assets/26fc8cb6-ab76-4823-b10a-f04144997af9)





## Guía de Uso

1. **Iniciar el Juego**
   - Desde el menú principal, el jugador puede:
     - Iniciar una nueva partida.
     - Ajustar configuraciones como sonido, controles y gráficos.
     - Salir del juego.

2. **Selección de Personaje y Vehículo**
   - El jugador puede elegir entre diferentes personajes y coches, cada uno con atributos únicos:
     - **Personajes**: Diseños únicos y efectos visuales.
     - **Coches**: Diversos estilos y estadísticas que afectan el rendimiento en carrera.

3. **Selección de Circuito y Modo de Juego**
   - **Circuitos**: Selección de pistas con curvas empinadas, rampas y obstáculos.
   - **Modos de Juego**:
     - Carrera: Competencia contra IA y otros jugadores.
     - Contrarreloj: Supera tu mejor tiempo.

4. **Sistema de Carrera**
   - Durante la carrera:
     - El jugador compite completando un número definido de vueltas.
     - La IA utiliza un sistema de nodos para seguir la pista.
     - Se calcula la posición en tiempo real.

5. **Final de Carrera**
   - Visualización del podio con los tres primeros puestos.
   - Tabla de resultados con los tiempos y posiciones finales.

## Arquitectura del Sistema
El proyecto utiliza un enfoque modular para separar las funcionalidades clave:
- **Menús y UI**: Los menús están diseñados utilizando el sistema de UI de Unity. Scripts dedicados controlan las transiciones y opciones seleccionadas.
- **Control del Vehículo**: Físicas realistas para el movimiento de los coches. Scripts especializados para coches controlados por el jugador e IA.
- **Gestor de Carreras**: Controla el inicio, desarrollo y fin de las carreras. Maneja eventos como vueltas completadas, colisiones y posiciones.
- **Sistema de Podio**: Calcula los resultados finales. Muestra una animación de podio al finalizar.

## Optimizaciones de Rendimiento
- LOD (Level of Detail) para reducir la carga gráfica.
- Scripts optimizados para evitar cálculos innecesarios en cada frame.
- Reducción de colisiones utilizando capas y filtros.

## Limitaciones y Trabajo Futuro

### Limitaciones Actuales
- Físicas simplificadas para coches IA.
- IA puede comportarse de manera errática en curvas cerradas.
- Ausencia de multijugador en línea.

### Mejoras Propuestas
- Implementación de multijugador en línea.
- Mejora en la IA para un comportamiento más humano.
- Incorporación de power-ups y objetos interactivos.


