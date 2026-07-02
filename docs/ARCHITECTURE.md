# Architektur

Die Engine wird bewusst von der Oberfläche getrennt.

```
Godot UI
      │
      ▼
Application Layer
      │
      ▼
BMH.Core
      │
      ▼
JSON / Savegames
```

## Domain

- Club
- Player
- League
- Season
- Fixture
- MatchResult

## Services

- PlayerFactory
- PlayerGenerator
- FixtureGenerator
- MatchSimulator
- TableCalculator

Die UI kennt niemals interne Berechnungen.