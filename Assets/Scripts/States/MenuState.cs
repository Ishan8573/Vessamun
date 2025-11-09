using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuState : GameState
{
    private GameStateMachine gsm;

    private InputAction startAction;

    public MenuState(GameStateMachine gsm)
    {
        this.gsm = gsm;
    }

    public override void Enter()
    {
        Debug.Log("Entered Menu State");

        gsm.Input.UI.Enable();
        startAction = gsm.Input.UI.Start;
        startAction.performed += OnStartPressed;
    }

    private void OnStartPressed(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        Debug.Log("Start game pressed (New Input System)");
        gsm.ChangeState(new GameplayState(gsm));
    }

    public override void Update()
    {
    }

    public override void Exit()
    {
        if (startAction != null)
            startAction.performed -= OnStartPressed;

        gsm.Input.UI.Disable();
        Debug.Log("Exiting Menu State");
    }
}


