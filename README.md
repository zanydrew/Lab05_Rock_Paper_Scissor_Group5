# Rock – Paper – Scissors – Starter Project

Starter project for **Game Development – Building a Basic 2D Game** (CADT).

Open this project and follow the slides to build the game. The project is set up for you; the scene, the UI and the game logic are your work.

**Goal:** when you finish, your game looks like this.

| Start | After a round |
|---|---|
| ![start](Docs/expected/game_start.png) | ![result](Docs/expected/game_result.png) |

---

## What is already done

- Unity **6.3 LTS (`6000.3.8f1`)** project in 2D mode.
- Packages: **uGUI** (`com.unity.ugui`) and **2D Sprite**.
- **Active Input Handling = Input Manager (Old)** (the script uses `Input.GetKeyDown`).
- `Assets/Scenes/GameScene.unity` – an empty scene with a 2D **Main Camera**. It is in the Build Profile scene list.
- `Assets/Resources/` – the game textures, already imported as **Sprite (2D and UI)**, **Sprite Mode = Single**.
- `Assets/Scripts/ButtonController.cs` – a basic script that shows how a button calls a function.
- `Assets/Scripts/GameController.cs` – the game script with **TODO** comments.

```
W5-Template Project/
├── Assets/
│   ├── Resources/
│   │   ├── Image/                   # original lab images (png + square image.psd)
│   │   ├── img_1.png                # 1 = Rock      (used by the script)
│   │   ├── img_2.png                # 2 = Paper
│   │   ├── img_3.png                # 3 = Scissors
│   │   └── img_4.png                # 4 = Unknown "?"
│   ├── Scenes/GameScene.unity       # open this scene
│   └── Scripts/
│       ├── ButtonController.cs      # basic button example (complete)
│       └── GameController.cs        # complete the TODOs
└── Docs/expected/                   # screenshots of the finished game
```

> `GameController` loads `img_1` .. `img_4` with `Resources.Load("img_" + n)`. Do not rename or move these files.

> Two warnings (`CS0414 ... cntYou / cntCom is assigned but its value is never used`) appear at the start. They go away when you complete `CheckResult`.

## Open the project

1. Install **Unity 6000.3.8f1** with Unity Hub.
2. In Unity Hub, click **Add → Add project from disk**. Select the `W5-Template Project` folder.
3. Open the project. The first import takes a few minutes.
4. In the **Project** window, open `Assets/Scenes/GameScene`.
5. In the **Game** view, set the aspect to **16:9** (or **Full HD 1920x1080**).

---

## Your tasks

Follow the slides. Tick each box when it works.

### Part 1 – UI (slides 4–22)

- [ ] **Slide 14 – Check the images** (already imported for you)
  - Open `Assets/Resources`. Click `img_1`.
  - In the **Inspector**, check **Texture Type = Sprite (2D and UI)** and **Sprite Mode = Single**.
  - These are the images for the buttons and the result area:

    | File | Meaning |
    |---|---|
    | `img_1` | Rock |
    | `img_2` | Paper |
    | `img_3` | Scissors |
    | `img_4` | Unknown "?" |

  - If you import new images later, set the same two settings and click **Apply**.
- [ ] **Slides 4–8, 15 – Canvas and Main Panel**
  - **UI → Canvas** (Unity adds an **EventSystem**).
  - Canvas Scaler: **Scale With Screen Size**, reference **1920 x 1080**, match **0.5**.
  - **Canvas → UI → Panel**, rename to `Main Panel`.
- [ ] **Slides 16–21 – Scissor button**
  - **Main Panel → UI → Button – TextMeshPro**. Delete its child text.
  - Rename to `3_Scissor Button`. **Source Image** = `img_3`.
  - Width / Height = `170`–`260`. Rotation Z = `90`.
  - Change **Pressed Color**. Press **Play** and test.
- [ ] **Slide 22 – Rock and Paper buttons**
  - Create `1_Rock Button` (`img_1`) and `2_Paper Button` (`img_2`). Arrange the three buttons.

> The button name **must** start with `1_`, `2_` or `3_`. The script reads this number.

### Part 2 – Events (slides 23–32)

**How a button works.** A **Button** has an **On Click ()** list. When the player clicks, Unity calls every function in this list. `ButtonController.cs` is the smallest example:

```csharp
public class ButtonController : MonoBehaviour
{
    public void OnButtonClick(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " clicked " );
    }
}
```

- The function must be `public`. Otherwise it does not appear in the **On Click ()** menu.
- The `GameObject` parameter is the object you drag into the event. Pass the button itself, then the script knows which button was clicked.

- [ ] **Try it first (optional)** – Add `ButtonController` to any object. Link one button to `ButtonController → OnButtonClick (GameObject)` with the steps below. Press **Play** and click. Then remove the link and continue with `GameController`.
- [ ] **Slide 23** – Create an empty object `GameManager`. Attach `Assets/Scripts/GameController.cs` to it.
- [ ] **Slides 25–31** – For `1_Rock Button`, in **On Click ()**:
  1. Click **+**.
  2. Drag **GameManager** into **None (Object)**.
  3. Select **GameController → OnButtonClick (GameObject)**.
  4. Drag `1_Rock Button` into **None (Game Object)**.
- [ ] **Slide 32** – Do the same for the other two buttons.
- [ ] **Check:** press **Play**, click each button. The **Console** shows `1_Rock Button clicked`, and so on.

### Part 3 – Game logic (slides 33–34)

- [ ] Complete the TODO in `OnButtonClick`: get the number from the button name and call `CheckResult(you)`.
- [ ] **Check:** the Console shows `Your result is: 1` (or 2, 3).

Rule (1 = Rock, 2 = Paper, 3 = Scissors):

```
k = you - com
k == 0              -> Draw
k == 1 or k == -2   -> You win
otherwise           -> Computer wins
```

### Part 4 – Score system UI (slides 35–40)

- [ ] **Slide 36** – **Main Panel → UI → Panel**, name `UI_Panel`. Change **Top**, **Bottom** and **Color**.
- [ ] **Slides 37–38** – In `UI_Panel`, create images `ImgYou` and `ImgCom`. **Source Image** = `img_4`.
- [ ] **Slide 39** – Create the score area:
  ```
  UI_Panel
  ├── ImgScore_You  (Image)
  │   ├── Text      (Text - Legacy) "You"
  │   └── TxtYou    (Text - Legacy) "0"
  └── ImgScore_Com  (Image)
      ├── Text      (Text - Legacy) "Computer"
      └── TxtCom    (Text - Legacy) "0"
  ```
- [ ] **Slide 40** – Create the result text **`TxtResult_`** (Text - Legacy). Default text: `Select the button below`.

> Use **UI → Legacy → Text** for these texts. The script uses `UnityEngine.UI.Text`.
> The names must match the script exactly: `ImgYou`, `ImgCom`, `TxtYou`, `TxtCom`, `TxtResult_`.

### Part 5 – Complete the game (slides 41–42)

Complete the TODOs in `GameController.cs`:

- [ ] `InitGame()` – find `ImgYou`, `ImgCom`, `TxtYou`, `TxtCom`, `TxtResult_` and set the start text.
- [ ] `CheckResult()` – random computer choice, the rule above, update `txtResult` and the score counters, then call `SetResult`.
- [ ] `SetResult()` – load `img_<n>` from `Resources` for both images, flip `imgCom` on the x axis, update the score texts.
- [ ] **Check:** press **Play**. Your game matches the screenshots above.

### Bonus

- [ ] Animate `TxtResult_` (slide 40).
- [ ] Make the UI responsive (anchors) (slide 22).

---

## Troubleshooting

| Problem | Fix |
|---|---|
| `NullReferenceException` in `InitGame` | An object name does not match the name in the script. |
| `FormatException` in `OnButtonClick` | The button name does not start with `1`, `2` or `3`. |
| Images do not change | `img_1`..`img_4` were moved or renamed. They must stay directly in `Assets/Resources`. |
| Function missing in **On Click ()** menu | The function is not `public`, or the script has a compile error (check the **Console**). |
| Click does nothing | No **EventSystem** in the scene, or **On Click ()** is empty. |
| Unity asks to import **TMP Essentials** | Click **Import TMP Essentials**. |

## Homework (slide 43)

Group assignment: build on this game, or propose a new simple 2D game. Add at least one new UI element and a `SceneManager` scene change (for example Menu → Game). Submit a PDF with a demo video and the GitHub URL.
#   L a b 0 5 _ R o c k _ P a p e r _ S c i s s o r _ G r o u p 5  
 