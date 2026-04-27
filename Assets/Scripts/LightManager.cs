using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    Light2D sanityLight;
    public int lightRadius;
    public UnityEngine.UI.Slider sanitySlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sanityLight = GetComponent<Light2D>();

        sanityLight.pointLightOuterRadius = lightRadius;

        StartCoroutine(LoseSanity());
    }

    IEnumerator LoseSanity()
    {
        while (sanitySlider.value > 0)
        {
            if (sanityLight.pointLightOuterRadius > 1)
            {
                sanityLight.pointLightOuterRadius = lightRadius * (sanitySlider.value / sanitySlider.maxValue);
            }
            yield return null;
        }
        Debug.Log("Game Over");
    }
}
