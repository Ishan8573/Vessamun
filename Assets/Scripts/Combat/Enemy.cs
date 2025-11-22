using UnityEngine;
using TMPro;  

public enum EnemyIntentType
{   
    attack,
    block
}

[System.Serializable]
public class EnemyIntent
{
    public EnemyIntentType type;
    public int value;
    public string description;
}

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public int currentHP;
    public int CurrentBlock {get; private set;}

    [Header("Intents")]
    [SerializeField] private EnemyIntent[] possibleIntents;
    private EnemyIntent currentIntent;
    public EnemyIntent CurrentIntent => currentIntent;

    [Header("UI")]
    public GameObject hpTextPrefab;     
    private TMP_Text hpTextInstance;    

    public void Apply(EnemyData d)
    {
        data = d;
        currentHP = d.maxHP;
        CurrentBlock = 0;
        GetComponent<SpriteRenderer>().sprite = d.sprite;
        name = $"Enemy_{d.enemyName}";

        if (possibleIntents != null && possibleIntents.Length > 0 && currentIntent == null)
        {
            ChooseRandomIntent();
        }

        if (hpTextPrefab != null)
        {
            var go = Instantiate(hpTextPrefab);
            go.transform.SetParent(transform, false);
            go.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            go.transform.localRotation = Quaternion.identity;

            hpTextInstance = go.GetComponentInChildren<TMP_Text>();

            if (hpTextInstance != null)
            {
                hpTextInstance.text = $"HP: {currentHP}";
            }
        }
    }

    private void Update()
    {
        if (hpTextInstance != null)
        {
            hpTextInstance.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            hpTextInstance.text = $"HP: {currentHP}\nBlock: {CurrentBlock}";
        }
    }

    public void ChooseRandomIntent()
    {
        if (possibleIntents == null || possibleIntents.Length == 0)
        {
            Debug.LogWarning("Enemy has no intents");
            currentIntent = null;
            return;
        }
        currentIntent = possibleIntents[Random.Range(0, possibleIntents.Length)];
        Debug.Log($"Enemy chose intent: {currentIntent.description}");
    }

    public void ExecuteCurrentIntent(PlayerHealth player)
    {
        if (currentIntent == null)
        {
            Debug.LogWarning("Enemy has no intent to execute");
        }

        switch (currentIntent.type)
        {
            case EnemyIntentType.attack:
                if (player != null)
                {
                    Debug.Log($"Enemy executes Attack for {currentIntent.value}");
                    player.takeDamage(currentIntent.value);
                }
                break;

            case EnemyIntentType.block: 
                Debug.Log($"Enemy gains {currentIntent.value} block");
                AddBlock(currentIntent.value);
                break;
        }
    }
    
    public void TakeDamage(int amount)
    {
        amount = Mathf.Max(0, amount);
        int damageLeft = amount;

        if (CurrentBlock > 0 && damageLeft > 0)
        {
            int beforeBlock = CurrentBlock;
            int blocked = Mathf.Min(CurrentBlock, damageLeft);
            CurrentBlock -= blocked;
            damageLeft -= blocked;
            Debug.Log($"Enemy block absorbed {blocked} damage: {beforeBlock} = {CurrentBlock}");
        }

        if (damageLeft > 0)
        {
            int beforeHP = currentHP;
            currentHP = Mathf.Max(0, currentHP - damageLeft);
            Debug.Log($"{data.enemyName} took {damageLeft} damage: {beforeHP} = {currentHP}");

            if (currentHP == 0)
                Debug.Log($"{data.enemyName} defeated!");
        }
    }

    public void AddBlock (int amount)
    {
        amount = Mathf.Max(0, amount);
        int before = CurrentBlock;
        CurrentBlock += amount;
        Debug.Log($"{data.enemyName} gained {amount} block: {before} = {CurrentBlock}");
    }

}



