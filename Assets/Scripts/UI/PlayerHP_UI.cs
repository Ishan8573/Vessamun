using UnityEngine;
using TMPro;

public class PlayerHPHUD : MonoBehaviour
{
    [SerializeField] private PlayerHealth player;
    [SerializeField] private TMP_Text label;

    private void Start()
    {
        if (player != null && label != null)
            label.text = $"HP: {player.CurrentHP}";
    }
}

