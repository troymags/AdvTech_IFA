using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class DaDManager : MonoBehaviour
{
    public GameObject objectToDrag;
    public GameObject objectToDragToPos;

    public float dropDistance;

    public bool isLocked;

    public static bool isDaDCompleted;

    public static int objectsCorrect = 0;
    private bool completionScheduled;

    public float completionDelay = 3f;

    Vector2 objectInitialPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DaDManager.objectsCorrect = 0;
        DaDManager.isDaDCompleted = false;
        objectInitialPos = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(objectToDrag.transform.position, objectToDragToPos.transform.position);
        if (Distance < dropDistance)
        {
            DaDManager.objectsCorrect++;
            objectToDrag.transform.position = objectToDragToPos.transform.position;
            objectToDragToPos.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            objectToDrag.GetComponent<Image>().color = new Color32(155, 255, 155, 255);

            if (DaDManager.objectsCorrect == 3 && !completionScheduled)
            {
                completionScheduled = true;
                StartCoroutine(delayCompletion());
                Debug.Log("DaD Completed after 3 correct drops");
            }
        }
        else 
        {
            objectToDrag.transform.position = objectInitialPos;
        }
    }

     private IEnumerator delayCompletion()
    {
        yield return new WaitForSeconds(completionDelay);
        isDaDCompleted = true;
    }
}
