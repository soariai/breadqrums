
# breadqrums game (Fresh Starter)

A clean Unity project skeleton for **Lil Qrum – Breadtown** with a 2.5D, Sneaky‑Sasquatch‑style setup.

## How to use
1. Open Unity Hub and **create a new 3D (URP)** project, or open an empty URP project (Unity 2023 LTS recommended).
2. Quit Unity (if it opened), then **copy this entire folder** into your new project directory, letting it merge/replace files.
3. Reopen the project. Install via Package Manager (Window → Package Manager): **Cinemachine**, **Input System**, **ProBuilder**, **TextMeshPro** (if prompted).
4. Create scenes: `Boot`, `MainMenu`, `SourdoughStreet`, `DoughKneading` inside `Assets/Scenes/` and add them to Build Settings (in that order).
5. In `Boot`, add an empty GameObject with `GameManager` (from Scripts/Core). Set it to `DontDestroyOnLoad` via script already included.
6. In `SourdoughStreet`, add a Player (Capsule + CharacterController + CharacterController3D). Add a CinemachineVirtualCamera following Player and tilt ~30–35°.
7. Add `CameraObstructorFader` to the Main Camera and set `target` to Player; choose an obstruction layer (e.g., Buildings/Trees).
8. Press Play. Jobs, HUD, save/load, and the Dough Kneading stub are ready to wire into UI and scene flow.

## Notes
- Systems are **data‑driven** with ScriptableObjects (Jobs, Vehicles, Items, Districts).
- All folders you need are present; add assets gradually.
- URP post‑processing (Bloom/SSAO/Vignette) should be added via a Global Volume in your scene.
