using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI WasteCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        int collectedWaste = GameManager.Instance.collectedWaste;
        WasteCountText.text = $"Waste: {collectedWaste}";
    }
}
