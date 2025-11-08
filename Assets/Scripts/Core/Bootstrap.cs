using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class Bootstrap : MonoBehaviour
{
    private GameStateMachine gsm;

    void Start()
    {
        gsm = GetComponent<GameStateMachine>();
        gsm.ChangeState(new MenuState(gsm)); 
    }
}
