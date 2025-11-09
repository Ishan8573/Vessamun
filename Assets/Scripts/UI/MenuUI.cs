using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button startButton;
    private GameStateMachine gsm;

    private void Awake()
    {
        gsm = FindAnyObjectByType<GameStateMachine>();
    }

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }
    
    private void StartGame()
    {
        Debug.Log("Start button clicked (UI Button)");
        gsm.ChangeState(new GameplayState(gsm));
    }
}