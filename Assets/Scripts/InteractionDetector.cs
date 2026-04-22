using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private Interactable InteractableInRange = null;
    public GameObject InteractionIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractionIcon.SetActive(false);   
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            InteractableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Interactable interactable) && interactable.CanInteract())
        {
            InteractableInRange = interactable;
            InteractionIcon.SetActive(true);
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Interactable interactable) && interactable == InteractableInRange)
        {
            InteractableInRange = null;
            InteractionIcon.SetActive(false);
        }
    }
}
