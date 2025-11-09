using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public class Bootstrap : MonoBehaviour
{
    private GameStateMachine gsm;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gsm = GetComponent<GameStateMachine>();
        gsm.ChangeState(new MenuState(gsm)); 
    }
}
