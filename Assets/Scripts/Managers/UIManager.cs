using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI WasteCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject WinPanel;

    void Start()
    {
        HUD.SetActive(true);
        WinPanel.SetActive(false);
    }
    void Update()
    {
        int collectedWaste = GameManager.Instance.collectedWaste;
        WasteCountText.text = $"Waste: {collectedWaste}";
    }

    public void ShowWinPanel()
    {
        HUD.SetActive(false);
        WinPanel.SetActive(true);
    }
}
