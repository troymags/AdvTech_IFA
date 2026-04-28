using Unity.VisualScripting;
using UnityEngine;

public class Laptop : MonoBehaviour, Interactable
{
    public GameObject Player;
    private PlayerMovement playerMovement;

    public OtTManager mgOnetoTen;
    public DaDManager mgDragandDrop;
    public FtDManager mgFlufftheDuck;
    private MonoBehaviour activeMinigame;

    public bool isOn { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        if (activeMinigame is FtDManager ftd && ftd.isFtDCompleted)
        {
            Debug.Log("Fluff the duck completed, starting drag and drop");
            Destroy(activeMinigame.gameObject);
            activeMinigame = null;
            activeMinigame = Instantiate(mgDragandDrop, Vector3.zero, Quaternion.identity);

        }

        if (activeMinigame is DaDManager && DaDManager.isDaDCompleted)
        {
            Debug.Log("Drag and drop completed, starting one to ten");
            Destroy(activeMinigame.gameObject);
            activeMinigame = null;
            activeMinigame = Instantiate(mgOnetoTen, Vector3.zero, Quaternion.identity);
        }

        if (activeMinigame is OtTManager ott && ott.isOtTCompleted)
        {
            Debug.Log("One to ten completed, laptop minigames completed!");
            Destroy(activeMinigame.gameObject);
            activeMinigame = null;
            playerMovement.enabled = true;
            SetOn(false);
        }
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

            activeMinigame = Instantiate(mgFlufftheDuck, Vector3.zero, Quaternion.identity);
        }
    }

    public void SetOn(bool on)
    {
        isOn = on;
        if (isOn)
        {
            Debug.Log("Laptop turned on");
        }
    }
}
