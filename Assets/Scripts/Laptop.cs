using Unity.VisualScripting;
using UnityEngine;

public class Laptop : MonoBehaviour, Interactable
{
    public GameObject Player;
    private PlayerMovement playerMovement;

    public GameObject mgOnetoTen;
    public GameObject mgDragandDrop;
    public GameObject mgFlufftheDuck;

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

        if (isOn)
        {
            Debug.Log("Playing laptop minigames");
            playerMovement = Player.GetComponent<PlayerMovement>();
            playerMovement.enabled = false;

            Instantiate(mgFlufftheDuck, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public void SetOn(bool on)
    {
        if (isOn = on)
        {
            Debug.Log("Laptop turned on");
        }
    }
}
