using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private GameState currentState;

    public void ChangeState(GameState newState)
    {
        if (currentState != null)
            currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
}
