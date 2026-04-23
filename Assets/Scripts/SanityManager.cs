using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{

    Slider sanitySlider;
    public int fullsanity;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sanitySlider = GetComponent<Slider>();
        sanitySlider.maxValue = fullsanity;
        sanitySlider.value = fullsanity;

        StartCoroutine(LoseSanity());
    }

    IEnumerator LoseSanity()
    {
        while (sanitySlider.value > 0)
        {

            sanitySlider.value -= 2f * difficulty;
            yield return null;
        }
        Debug.Log("Game Over");
    }
}

