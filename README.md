# BallLauncherMobile

A small mobile-friendly Unity game where you launch a ball in an Angry-birds like style. The project was updated to Unity 6 and is kept intentionally small so you can inspect the scripts, tweak physics, and export mobile builds quickly.

## Demo / Gameplay

The player launches a ball by tapping (mobile) or clicking (desktop). Each tap applies an impulse upward and forward so the ball travels through the level. The mechanics are simple and tuned for mobile feel: short taps for small hops and spaced taps for long arcs.

Key scene: `Assets/Scenes/Level1.unity`

![Ball launcher mobile](https://github.com/user-attachments/assets/0d2a4960-e721-472b-92c6-0dad2088145b)


## What’s included

- A playable sample scene: `Assets/Scenes/Level1.unity`
- Ball prefab: `Assets/Prefabs/Ball.prefab`
- Main ball behaviour: `Assets/Scripts/Ball.cs`
- Physics material(s): `Assets/PhysicsMaterials/BouncyBall.physicsMaterial2D`

## Controls

- Mobile: Tap anywhere on the screen to launch the ball (or to give it another impulse while in flight).
- Desktop (Editor): Left-click anywhere in the Game view or press the Spacebar (if implemented in your input bindings) to replicate the tap.

Adjust the input behavior in `Assets/Scripts/Ball.cs` if you want keyboard-only testing or custom gestures.

## How to open and run (Unity 6)

1. Install Unity 6 via Unity Hub or your preferred method.
2. Open Unity Hub, choose "Add", and select the project folder `BallLauncherMobile` (the folder that contains `Assets/` and `ProjectSettings/`).
3. Open the project in Unity 6. If Unity prompts to upgrade project settings or packages, follow the prompts and review changes.
4. In the Project window, open `Assets/Scenes/Level1.unity` and press the Play button to test in the Editor.
5. To test on mobile devices, configure the target platform (File › Build Settings › Android or iOS), connect your device (or use emulator), and build & run.

Notes:
- The project was upgraded from an earlier Unity version to Unity 6; take a quick look at the Console for any package or API update messages after opening.
- For fastest iteration on mobile, enable Development Build and Auto-connect Profiler in Build Settings.

## Quick tips for tuning

- The ball’s launch impulse, gravity scale, and material bounciness are controlled in the `Ball` script and the Physics Material. Tweak `Assets/Scripts/Ball.cs` and `Assets/PhysicsMaterials/BouncyBall.physicsMaterial2D` to change feel.
- If you want to add obstacles or scoring, create new prefabs and add them to the scene; the ball prefab is ready to interact with 2D colliders.

## Project structure (short)

- `Assets/Scenes/Level1.unity` — sample level
- `Assets/Prefabs/Ball.prefab` — ball prefab used in the scene
- `Assets/Scripts/Ball.cs` — main control script, handles input and impulses
- `Assets/PhysicsMaterials/` — physics materials used by the ball

## Contributing

Contributions are welcome. Small, focused pull requests are easiest to review. Suggested improvements:

- Add more levels and menus
- Implement an on-screen UI with score and lives
- Add audio and particle feedback for taps and collisions

If you add features, please:

1. Keep changes scoped to a branch.
2. Provide a short description of the change and the design rationale in the PR.

## License

This project uses the MIT License — see the included `LICENSE` file or add one if you plan to publish.

## Contact / Author

Repo owner: batiacosta

If you want help updating or expanding the project (mobile input polish, analytics, or UI), open an issue or reach out via the repo.

---

Enjoy experimenting with the ball physics — small changes to the impulse or material go a long way to changing the game feel.
