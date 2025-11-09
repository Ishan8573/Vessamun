using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameplayState : GameState
{
    private GameStateMachine gsm;
    private InputAction backAction;

    public GameplayState(GameStateMachine gsm)
    {
        this.gsm = gsm;
    }

    public override void Enter()
    {
        Debug.Log("Entered Gameplay State");

        gsm.Input.Gameplay.Enable();
        backAction = gsm.Input.Gameplay.Back;
        backAction.performed += BackPressed;
    }

    private void BackPressed(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Debug.Log("Returning to Menu (New Input System)");
        gsm.ChangeState(new MenuState(gsm));
    }

    public override void Update() { }

    public override void Exit()
    {
        if (backAction != null)
            backAction.performed -= BackPressed;

        gsm.Input.Gameplay.Disable();
        Debug.Log("Exiting Gameplay State");
    }
}
