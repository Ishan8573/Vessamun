using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHP = 100;  
    public int CurrentHP { get; private set; }

    public int CurrentBlock {get; private set; }

    private void Awake()
    {
        CurrentHP = maxHP; 
        CurrentBlock = 0;                     
    }

    public void AddBlock(int amount)
    {
        amount = Mathf.Max(0, amount);
        int before = CurrentBlock;
        CurrentBlock += amount;
        Debug.Log($"Player gained {amount} block: {before} = {CurrentBlock}");
    }

    public void ResetBlock()
    {
        if (CurrentBlock > 0)
        {
            Debug.Log($"Block reset: {CurrentBlock} = 0");
            CurrentBlock = 0;
        }
    }

    public void takeDamage(int amount)
    {
        amount = Mathf.Max(0, amount);
        int damageLeft = amount;

        if (CurrentBlock > 0 && damageLeft > 0)
        {
            int beforeBlock = CurrentBlock;
            int blocked = Mathf.Min(CurrentBlock, damageLeft);
            CurrentBlock -= blocked;
            damageLeft -= blocked;
            Debug.Log($"Block absorbed {blocked} damage: {beforeBlock} = {CurrentBlock}");
        }

        if (damageLeft > 0)
        {
            int beforeHP = CurrentHP;
            CurrentHP = Mathf.Max(0, CurrentHP - damageLeft);
            Debug.Log($"Player took {damageLeft} damage: {beforeHP} = {CurrentHP}");
        }
    }
}

