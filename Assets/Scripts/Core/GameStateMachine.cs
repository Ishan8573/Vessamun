using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private GameState currentState;

    public Controls Input { get; private set; }

    private void Awake()
    {
        Input = new Controls();  
    }

    public void ChangeState(GameState newState)
    {
        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null) currentState.Update();
    }

    private void OnDestroy()
    {
        currentState?.Exit();   // let the active state unsubscribe first
        Input.Dispose();
    }
}
