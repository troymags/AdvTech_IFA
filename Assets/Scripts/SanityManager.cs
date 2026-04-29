using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{

    Slider sanitySlider;
    public Volume globalVolume;
    private ChromaticAberration chroma;
    private FilmGrain filmGrain;
    public Slider healthSlider;
    public int fullhealth;
    public float healthDropAmount = 5f;
    public float healthDropInterval = 1f;
    private float healthDropTimer;
    public int fullsanity;
    public int difficulty;

    public Laptop laptop;
    public GameObject gameOverScreen;
    public Button desktopButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sanitySlider = GetComponent<Slider>();

        sanitySlider.maxValue = fullsanity;
        sanitySlider.value = fullsanity;

        if (healthSlider != null)
        {
            healthSlider.maxValue = fullhealth;
            healthSlider.value = fullhealth;
        }

        if (globalVolume != null && globalVolume.profile != null)
        {
            globalVolume.profile.TryGet(out chroma);
            globalVolume.profile.TryGet(out filmGrain);
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
            desktopButton.interactable = false;
        }

        StartCoroutine(LoseSanity());
    }

    void Update()
    {
        UpdatePostProcessing();
    }

    public void GameOver()
    {
        Destroy(laptop.activeMinigame.gameObject);
        StopCoroutine(LoseSanity());

        if (chroma != null) chroma.active = false;
        if (filmGrain != null) filmGrain.active = false;

        if (gameOverScreen != null) gameOverScreen.SetActive(true);
        if (desktopButton != null) desktopButton.interactable = true;

        Debug.Log("Game Over");
    }

    public void ExittoDesktop()
    {
        Application.Quit();
    } 

    private void UpdatePostProcessing()
    {
        if (sanitySlider == null || globalVolume == null)
            return;

        float normalized = Mathf.InverseLerp(sanitySlider.minValue, sanitySlider.maxValue, sanitySlider.value);
        float intensity = Mathf.Clamp01((1f - normalized) / 0.75f);

        if (chroma != null)
        {
            chroma.active = intensity > 0f;
            chroma.intensity.value = intensity;
        }

        if (filmGrain != null)
        {
            filmGrain.active = intensity > 0f;
            filmGrain.intensity.value = intensity;
        }
    }
    IEnumerator LoseSanity()
    {
        while (sanitySlider.value >= 0)
        {
            sanitySlider.value -= 0.5f * difficulty;

            if (sanitySlider.value < sanitySlider.maxValue / 2)
            {
                healthDropTimer += Time.deltaTime;
                if (healthDropTimer >= healthDropInterval)
                {
                    if (healthSlider != null)
                    {
                        healthSlider.value = Mathf.Max(0, healthSlider.value - healthDropAmount);
                    }
                    healthDropTimer = 0f;
                    Debug.Log("Health dropped due to low sanity");
                }
            }
            else
            {
                healthDropTimer = 0f;
            }

            yield return null;
        }

        if (healthSlider == null || healthSlider.value <= 0)
        {
            GameOver();
            Debug.Log("Game Over");
        }
    }

}

