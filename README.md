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
- Modos de juego:
   Carrera: Competición contra IA y superación de obstáculos.
   Contrarreloj: Completar tantas vueltas como sea posible dentro del límite de tiempo.

### Sistema de Carrera
- Circuitos 3D: Escenarios detallados con curvas, rampas y obstáculos.
- IA para coches controlados por el juego.
- Tiempo y posición en tiempo real: Información mostrada en pantalla durante la carrera.
- Sistema de conteo de vueltas: Registra las vueltas completadas por el jugador y la IA.

### Final de Carrera
- Podio final que muestra las posiciones obtenidas por cada participante.
- Pantalla de resultados con tiempos y posiciones.

### Gráficos y Sonido
- Estética vibrante y colorida: Diseños inspirados en videojuegos clásicos de carreras.
- Música y efectos de sonido: Ambientación inmersiva para las carreras y menús.

## Requisitos del Sistema
- Unity 2022.3 o superior.
- .NET Framework 4.7.1 o superior.
- Controlador compatible con Unity (opcional para más inmersión).

## Controles del Juego
Acción	            Teclado	
Acelerar	            W	      
Frenar	            S	      
Girar a la izquierda	A	      
Girar a la derecha	D	
Pausa	               (botón pausa en pantalla)	

## Estructura del Proyecto

```
.
├── Assets/
│   ├── Scripts/
│   │   ├── Menús/
│   │   │   ├── MainMenuController.cs
│   │   │   ├── CharacterSelectionMenu.cs
│   │   │   ├── VehicleSelectionMenu.cs
│   │   │   ├── CircuitSelectionMenu.cs
│   │   ├── Gameplay/
│   │   │   ├── RaceController.cs
│   │   │   ├── TimeTrialController.cs
│   │   │   ├── PodiumController.cs
│   │   │   └── PlayerController.cs
│   │   ├── AI/
│   │   │   ├── CarEngine.cs
│   │   │   ├── CarWheel.cs
│   │   │   └── Path.cs
│   │   └── Utilities/
│   │       ├── GameManager.cs
│   │       └── AudioManager.cs
│   ├── Scenes/
│   │   ├── MainMenu.unity
│   │   ├── CharacterSelection.unity
│   │   ├── VehicleSelection.unity
│   │   ├── CircuitSelection.unity
│   │   ├── RaceScene.unity
│   │   ├── Circuit1.unity
│   │   ├── Circuit2.unity
│   │   ├── Circuit3.unity
│   │   └── Podium.unity
│   ├── Prefabs/
│   ├── Models/
│   ├── Textures/
│   ├── Audio/
│   └── UI/
└── README.md

```

## Guía de Uso

1. **Iniciar el Juego**
   - Desde el menú principal, el jugador puede:
     - Iniciar una nueva partida.
     - Entender los controles.
     - Salir del juego.

2. **Selección de Personaje y Vehículo**
   - El jugador puede elegir entre diferentes personajes y coches, cada uno con atributos únicos:
     - **Personajes**: Diseños únicos y efectos visuales.
     - **Coches**: Diversos estilos y estadísticas que afectan el rendimiento en carrera.

3. **Selección de Circuito y Modo de Juego**
   - **Circuitos**: Selección de pistas con curvas empinadas, rampas y obstáculos.
   - **Modos de Juego**:
     - Carrera: Competencia contra IA y superación de obstáculos.
     - Contrarreloj: Completar las 3 vueltas con un límite de tiempo.

4. **Sistema de Carrera**
   - Durante la carrera:
     - El jugador compite completando un número definido de vueltas.
     - La IA utiliza un sistema de nodos para seguir la pista.
     - Se calcula la posición en tiempo real y el tiempo por vuelta.

5. **Final de Carrera**
   - Visualización del podio con los tres primeros puestos.
   - Tabla de resultados con los tiempos y posiciones finales.

## Arquitectura del Sistema
El proyecto utiliza un enfoque modular para separar las funcionalidades clave:
- **Menús y UI**: Los menús están diseñados utilizando el sistema de UI de Unity. Scripts dedicados controlan las transiciones y opciones seleccionadas.
- **Control del Vehículo**: Físicas realistas para el movimiento de los coches. Scripts especializados para coches controlados por el jugador e IA.
- **Gestor de Carreras**: Controla el inicio, desarrollo y fin de las carreras. Maneja eventos como vueltas completadas, colisiones y posiciones.
- **Sistema de Podio**: Calcula los resultados finales. Muestra una animación de podio al finalizar.


## Limitaciones y Trabajo Futuro

### Limitaciones Actuales
- Físicas simplificadas para coches IA.
- IA puede comportarse de manera errática en curvas cerradas.
- Ausencia de multijugador en línea.

### Mejoras Propuestas
- Implementación de multijugador en línea.
- Mejora en la IA para un comportamiento más humano.
- Incorporación de power-ups y objetos interactivos.


