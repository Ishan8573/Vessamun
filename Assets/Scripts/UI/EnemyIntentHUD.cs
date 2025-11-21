using UnityEngine;
using TMPro;

public class EnemyIntentHUD : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private TMP_Text label;

    private void Start()
    {
        if (label == null)
            label = GetComponent<TMP_Text>();

        UpdateLabel();
    }

    private void Update()
    {
        if (enemy == null || !enemy.gameObject.scene.IsValid()) 
            enemy = FindFirstObjectByType<Enemy>();
            
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        if (label == null) return;

        if (enemy != null && enemy.CurrentIntent != null)
        {
            label.text = $"Enemy intent: {enemy.CurrentIntent.description}";
        }
        else
        {
            label.text = "Enemy intent: (none)";
        }
    }   
}

