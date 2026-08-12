using TMPro;
using UnityEngine;

public class Waste : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI interactionText;
    //must use public, so outside can access these functions.

    void Start()
    {
        //interactionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>;
        if(interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
        //Debug.Log("Press E to interact");
    }
    public void ShowMessage()
    {
        if(interactionText != null)
        {
            interactionText.gameObject.SetActive(true);
        }
        //Debug.Log("Press E to interact");
    }

    public void  Interact()
    {

        //Debug.Log("Waste collected");
        GameManager.Instance.AddWaste();
        interactionText.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void  HideMessage()
    {
        if(interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
        //Debug.Log("Message is hidden!");
    }
}
