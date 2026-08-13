using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int collectedWaste {get; private set;} //anyone can get and nobody can modify except gamemanager.

    private GameState currentState;
    private int requiredWaste;
    [SerializeField]
    private UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        SetGameState(GameState.Playing);
        requiredWaste = 5;
    }

    public void AddWaste()
    {
        collectedWaste++;
        Debug.Log("Waste collected current count " + collectedWaste);
        if(collectedWaste >= requiredWaste)
        {
            SetGameState(GameState.Win);
            Debug.Log("Game Finished!!");
            //ui manager show win-panel
            uiManager.ShowWinPanel();
        }
    }

    void SetGameState(GameState state)
    {
        currentState = state;

    }

    public GameState GetGameState()
    {
        return currentState;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("ParkScene");
    }
}
