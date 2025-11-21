using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;  
    public int CurrentHP { get; private set; }

    private void Awake()
    {
        CurrentHP = maxHP;                      
    }

    public void takeDamage(int amount)
    {
        amount = Mathf.Max(0, amount);
        int before = CurrentHP;
        CurrentHP = Mathf.Max(0, CurrentHP - amount);
        Debug.Log($"Player took {amount} damage: {before} -> {CurrentHP}");
    }
}

