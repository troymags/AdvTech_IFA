using UnityEngine;
using UnityEngine.UI;

public class FtDManager : MonoBehaviour
{
    [SerializeField]
    private int duckCount;
    [SerializeField]
    private Text text;

    public bool isFluffed;
    public bool isCompleted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start()
    {
        duckCount = 0;
        text.text = "Fluff the duck! :) " + duckCount + "/50";
    }
    public void FluffTheDuck()
    {
        if (!isFluffed)
        {
            duckCount++;
            text.text = "Fluff the duck! :) " + duckCount + "/50";
        }

        if (duckCount == 50)
        {
            Debug.Log("Completed!");
            isFluffed = true;
            text.text = "The duck is fluffed! :)";
        }
    }
}
