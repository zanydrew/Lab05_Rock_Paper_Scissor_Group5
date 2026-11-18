using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Rock - Paper - Scissors : starter script
// Follow the slides and complete every TODO.
// 1 = Rock, 2 = Paper, 3 = Scissors, 4 = Unknown ("?")
public class GameController : MonoBehaviour
{
    Image imgYou;       // your selected image (rock, paper, scissor)
    Image imgCom;       // computer selected image (rock, paper, scissor)

    Text txtYou;        // the score you win
    Text txtCom;        // the score computer win
    Text txtResult;     // the result

    int cntYou = 0;     // number you win
    int cntCom = 0;     // number computer win


    private void InitGame()
    {
        // TODO (slides 37-40): find the UI objects by name and get their components.
        // Example:
        // imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        // Also find: ImgCom, TxtYou, TxtCom, TxtResult_

        imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImgCom").GetComponent<Image>();
        txtYou = GameObject.Find("TxtYou").GetComponent<Text>();
        txtCom = GameObject.Find("TxtCom").GetComponent<Text>();
        txtResult = GameObject.Find("TxtResult_").GetComponent<Text>();


        // TODO: set the text of txtResult to "Select the button below"

        txtResult.text = "Select the button below";
        txtYou.text = "0";
        txtCom.text = "0";
    }

    void Start()
    {
        // init the game
        InitGame();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // exit if press escape key
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         Application.Quit();
    //     }
    // }

    // Slides 24-31: link this function to the On Click () event of every button.
    // Pass the button itself as the GameObject parameter.
    public void OnButtonClick(GameObject buttonObject)
    {
        Debug.Log(buttonObject.name + " clicked ");

        // TODO (slide 34): get the number from the first character of the button name
        int you = int.Parse(buttonObject.name.Substring(0, 1));
        CheckResult(you);
    }

    void CheckResult(int you)
    {
        // TODO (slide 33): game logic
        // 1. com = random number 1..3  ->  UnityEngine.Random.Range(1, 4)
        // 2. k = you - com
        // 3. k == 0              -> "Draw."
        //    k == 1 or k == -2   -> "You win."       (cntYou++)
        //    otherwise           -> "Computer win."  (cntCom++)
        // 4. call SetResult(yourResult, comResult)
        // Debug.Log("Your result is: " + yourResult);

        int com = Random.Range(1, 4);
        int k = you - com;

        if (k == 0)
        {
            txtResult.text = "It's a tie";
        }
        else if (k == 1 || k == -2)
        {
            txtResult.text = "Player Wins";
            cntYou++;
        }
        else
        {
            txtResult.text = "Computer Wins";
            cntCom++;
        }
        SetResult(you, com);
    }

    void SetResult(int you, int com)
    {
        // TODO (slide 41):
        // 1. change imgYou.sprite and imgCom.sprite
        //    Resources.Load("img_" + you, typeof(Sprite)) as Sprite
        imgYou.sprite = Resources.Load<Sprite>("img_" + you);
        imgCom.sprite = Resources.Load<Sprite>("img_" + com);
        // 2. flip the computer image on the x axis: localScale = (-1, 1, 1)
        imgCom.rectTransform.localScale = new Vector3(-1, 1, 1);
        // 3. update txtYou.text and txtCom.text with the scores
        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();
    }
}
