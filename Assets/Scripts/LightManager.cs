using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    Light2D sanityLight;
    public int lightRadius;
    public UnityEngine.UI.Slider sanitySlider;
    public float lightFalloffSpeed = 0.5f;

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
                float targetRadius = lightRadius * (sanitySlider.value / sanitySlider.maxValue);
                targetRadius = Mathf.Max(3f, targetRadius);
                sanityLight.pointLightOuterRadius = Mathf.MoveTowards(
                    sanityLight.pointLightOuterRadius,
                    targetRadius,
                    lightFalloffSpeed * Time.deltaTime);
            }
            yield return null;
        }
        Debug.Log("Game Over");
    }
}
