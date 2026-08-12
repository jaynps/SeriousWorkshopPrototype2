using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private IInteractable currentInteractable; //using IInteractable.cs 
    private void OnTriggerEnter(Collider other) //other is the object that interacted
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null) //we need to use this if to check the object is able interact then print out the debug log.
        {
            currentInteractable = interactable;
            Debug.Log("Player approaching " + other.gameObject.name); // this is the message showing what object approaching
            interactable.ShowMessage(); // this shows what message 
        }
    }

    private void OnTriggerExit(Collider other)
    {

        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable == currentInteractable && currentInteractable != null) 
        {
            Debug.Log("Player is away from " + other.gameObject.name); // this is the message showing what object approaching
            currentInteractable.HideMessage();
            currentInteractable = null;
        }
    }

    public void Interact()
    {
        if(currentInteractable != null)
            currentInteractable.Interact();
    }
}
