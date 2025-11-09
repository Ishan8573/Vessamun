using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    private GameStateMachine gsm;

    private void Awake()
    {
        gsm = FindAnyObjectByType<GameStateMachine>();
    }

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        Debug.Log("Start button clicked");
        gsm.ChangeState(new GameplayState(gsm));
    }
    
    private void ExitGame()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }
}