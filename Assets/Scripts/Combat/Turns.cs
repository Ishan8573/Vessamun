using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    public enum Turn { Player, Enemy }
    public Turn Current { get; private set; } = Turn.Player;

    [Header("References")]
    [SerializeField] private Enemy enemy;        
    [SerializeField] private PlayerHealth player;

    [Header("Timing")]
    [SerializeField] private float enemyDelay = 0.7f;
    [SerializeField] private HandManager hand;

    private bool battleOver = false;

    [System.Obsolete]
    private void Start()
    {
        if (enemy == null)
            enemy = FindObjectOfType<Enemy>();

        if (player == null)
            player = FindObjectOfType<PlayerHealth>();

        if (hand == null)
            hand = FindAnyObjectByType<HandManager>();

        Debug.Log("Turn Player");
        Current = Turn.Player;
        hand?.DrawStartingHand();
    }

    private void Update()
    {
        if (battleOver) return;

        if (Current == Turn.Player)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Debug.Log("Player Acted");
                if (enemy != null) enemy.TakeDamage(5);

                EndPlayerTurn();
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Player turn ended.");
                EndPlayerTurn();
            }
        }
    }

    private void SwitchToEnemy()
    {
        Current = Turn.Enemy;
        Debug.Log("Turn Enemy");
        Invoke(nameof(EnemyAct), enemyDelay);
    }

    private void EnemyAct()
    {
        if (battleOver) return;
        Debug.Log("Enemy Acted");

        CheckWinLose();
        if (!battleOver)
        {
            hand?.DrawStartingHand();
            Current = Turn.Player;
            Debug.Log("Turn Player");
        }
    }

    private void CheckWinLose()
    {
        if (enemy != null && enemy.currentHP <= 0)
        {
            battleOver = true;
            Debug.Log("Victory!");
        }
        if (player != null && player.CurrentHP <= 0)
        {
            battleOver = true;
            Debug.Log("Defeat!");
        }
    }

    private void EndPlayerTurn()
    {
        hand?.DiscardHand();
        SwitchToEnemy();
    }
}
