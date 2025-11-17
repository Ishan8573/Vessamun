using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 3;   
    public int MaxEnergy => maxEnergy;

    public int CurrentEnergy { get; private set; }

    private void Awake()
    {
        Refill();                                
    }
    
    public void Refill()
    {
        CurrentEnergy = maxEnergy;
        Debug.Log($"Energy refilled to {CurrentEnergy}");
    }

    public bool CanAfford(int cost)
    {
        return cost <= CurrentEnergy;
    }

    public void Spend(int cost)
    {
        cost = Mathf.Max(0, cost);
        CurrentEnergy = Mathf.Clamp(CurrentEnergy - cost, 0, maxEnergy);
        Debug.Log($"Spent {cost} energy → {CurrentEnergy} left");
    }
}
