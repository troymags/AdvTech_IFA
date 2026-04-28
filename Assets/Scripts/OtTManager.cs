using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class OtTManager : MonoBehaviour
{
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    int counter = 0;
    public int gamesCompletedCounter = 0;
    public bool isOtTCompleted;
    private bool completionScheduled;

    public Text text;

    public float completionDelay = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        counter = 0;
        isOtTCompleted = false;
        gamesCompletedCounter = 0;
        RestartGame();
    }


    public void RestartGame()
    {
        if (gamesCompletedCounter == 3 && !completionScheduled)
        {
            completionScheduled = true;
            counter = 0;
            text.text = "You did it! :) " + gamesCompletedCounter + "/3";
            StartCoroutine(delayCompletion());
            Debug.Log("OtT Completed after 3 wins");
        }

        else
        {
            text.text = "Win 3 games in a row! " + gamesCompletedCounter + "/3";
            counter = 0;
            shuffledButtons = buttons.OrderBy(a => Random.Range(0, 100)).ToList();
            for (int i = 1; i < 11; i++)
                {
                    shuffledButtons[i - 1].GetComponentInChildren<Text>().text = i.ToString();
                    shuffledButtons[i - 1].interactable = true;
                    shuffledButtons[i - 1].image.color = new Color32(210, 182, 225, 225);
                }
        }
    }

    public void pressButton(Button button)
    {
        if (int.Parse(button.GetComponentInChildren<Text>().text) - 1 == counter)
        {
            counter++;
            button.interactable = false;
            button.image.color = Color.green;

            if (counter == 10 && gamesCompletedCounter < 3)
            {
                    gamesCompletedCounter++;
                    StartCoroutine(presentResult(true));
            }
        }
        else
        {
            StartCoroutine(presentResult(false));
        }
    }
   
    public IEnumerator presentResult(bool win)
    {
        if (!win)
        {
            foreach (var button in shuffledButtons)
            {
                button.image.color = Color.red;
                button.interactable = false;
                gamesCompletedCounter = 0;
            }
        }
        yield return new WaitForSeconds(2f);
        RestartGame();
    }

     private IEnumerator delayCompletion()
    {
        yield return new WaitForSeconds(completionDelay);
        isOtTCompleted = true;
    }

}