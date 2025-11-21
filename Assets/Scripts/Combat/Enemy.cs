using UnityEngine;
using TMPro;  

public enum EnemyIntentType
{   
    attack
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
            hpTextInstance.text = $"HP: {currentHP}";
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
        }
    }

    public void TakeDamage(int amount)
    {
        amount = Mathf.Max(0, amount);
        currentHP = Mathf.Max(0, currentHP - amount);

        if (currentHP == 0) 
            Debug.Log($"{data.enemyName} defeated!");
    }
}



