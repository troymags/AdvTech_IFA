using Unity.VisualScripting;
using UnityEngine;

public class Laptop : MonoBehaviour, Interactable
{
    public bool isOn { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public bool CanInteract()
    {
        return !isOn;
    }

    public void Interact()
    {
        PlayLaptop();
    }

    private void PlayLaptop()
    {
        SetOn(true);
    }

    public void SetOn(bool on)
    {
        if (isOn = on)
        {
            Debug.Log("Laptop turned on");
        }
    }
}
