using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class FtDManager : MonoBehaviour
{
    public int duckCount;
    public Text text;
    public Button duckButton;
    public Sprite duckFluffed;


    public bool isFluffed;
    public bool isFtDCompleted = false;
    private bool completionScheduled;

    public float completionDelay = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        duckCount = 0;
        isFluffed = false;
        isFtDCompleted = false;
        completionScheduled = false;
        text.text = "Fluff the duck! :) " + duckCount + "/50";
    }
    public void FluffTheDuck()
    {
        if (!isFluffed)
        {
            duckCount++;
            text.text = "Fluff the duck! :) " + duckCount + "/50";
        }

        if (duckCount == 50 && !completionScheduled)
        {
            isFluffed = true;
            completionScheduled = true;
            text.text = "The duck is fluffed! :)";
            duckButton.interactable = false;
            duckButton.image.sprite = duckFluffed;

            StartCoroutine(delayCompletion());
            Debug.Log("Completed!");
        }
    }

    private IEnumerator delayCompletion()
    {
        yield return new WaitForSeconds(completionDelay);
        isFtDCompleted = true;
    }
}
