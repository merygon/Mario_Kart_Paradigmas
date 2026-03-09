# 🏎️ Mario Kart — Unity Racing Game

A fully playable **3D racing game** inspired by Mario Kart, built in Unity with C#. Features complete race flow, AI-controlled opponents, multiple circuits, and a final podium system.

---

## 🎮 Gameplay Features

- 🏁 **Race mode** — compete against AI opponents across 3D circuits with obstacles and ramps
- ⏱️ **Time trial mode** — complete laps within a time limit
- 🤖 **AI opponents** — node-based pathfinding system for realistic race behaviour
- 🧍 **Character & vehicle selection** — unique designs with different speed/handling/acceleration stats
- 🗺️ **3 circuits** — different layouts with varying difficulty
- 🏆 **Podium system** — final standings with animation after each race

---

## 🕹️ Controls

| Action | Key |
|---|---|
| Accelerate | W |
| Brake / Reverse | S |
| Turn left | A |
| Turn right | D |
| Pause | On-screen button |

---

## 🛠️ Tech Stack

| Component | Technology |
|---|---|
| Engine | Unity 2022.3+ |
| Language | C# |
| Physics | Unity Rigidbody + custom wheel physics |
| AI | Node-based waypoint pathfinding |
| UI | Unity UI System |
| Audio | Unity AudioManager |

---

## ⚙️ Requirements

- Unity 2022.3 or higher
- .NET Framework 4.7.1+
- Optional: gamepad controller

---

## 🗂️ Project Architecture

```
Assets/
├── Scripts/
│   ├── Menus/              # Main menu, character/vehicle/circuit selection
│   ├── Gameplay/           # Race, time trial, podium controllers
│   ├── AI/                 # CarEngine, CarWheel, pathfinding (Path.cs)
│   └── Utilities/          # GameManager, AudioManager
├── Scenes/
│   ├── MainMenu.unity
│   ├── CharacterSelection.unity
│   ├── RaceScene.unity
│   ├── Circuit1–3.unity
│   └── Podium.unity
├── Prefabs/
├── Models/
└── Audio/
```

---

## 🧩 System Design

The project uses a **modular architecture** with clear separation of concerns:

- **Menu system** — dedicated controllers per screen (character, vehicle, circuit selection) with smooth transitions
- **Vehicle physics** — realistic wheel simulation for both player and AI cars
- **Race manager** — handles lap counting, real-time position ranking, and race end detection
- **AI system** — opponents follow waypoint nodes with collision avoidance; behaviour degrades on tight corners (known limitation)
- **Podium system** — calculates final rankings and triggers end-of-race animation

---

## 🔧 Known Limitations & Future Work

- AI can behave erratically on sharp corners
- No online multiplayer
- **Planned improvements:** smarter AI with smoother pathing, power-ups and items, online multiplayer support

---

## 📚 Context

Built as a final project for the **Programming Paradigms** course — Universidad Pontificia Comillas (ICAI), 2024.

---

## 👩‍💻 Authors

- María González Gómez · [GitHub](https://github.com/merygon)
- David Tarrasa Puebla · [GitHub](https://github.com/davidtarrasa)
