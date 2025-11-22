using UnityEngine;
using TMPro;

public class PlayerHPHUD : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private TMP_Text label;

    private void Start()
    {
        if (player == null)
        player = FindFirstObjectByType<PlayerHealth>();

        if (label == null)
        label = GetComponent<TMP_Text>();

        UpdateLabel();
    }

    private void Update()
    {
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        if (player == null || label == null)
        return;
        label.text = $"HP: {player.CurrentHP} | Block: {player.CurrentBlock}";
    }
}

