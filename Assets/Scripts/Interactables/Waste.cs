using UnityEngine;

public class Waste : MonoBehaviour, IInteractable
{
    //must use public, so outside can access these functions.
    public void ShowMessage()
    {
        Debug.Log("Press E to interact");
    }

    public void  Interact()
    {
        Debug.Log("Waste collected");
    }

    public void  HideMessage()
    {
        Debug.Log("Message is hidden!");
    }
}
