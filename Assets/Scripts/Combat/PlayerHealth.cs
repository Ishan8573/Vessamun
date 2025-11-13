using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHP = 80;  
    public int CurrentHP { get; private set; }

    private void Awake()
    {
        CurrentHP = maxHP;                      
    }
}

