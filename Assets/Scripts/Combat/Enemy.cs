using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public int currentHP;

    public void Apply(EnemyData d)
    {
        data = d;
        currentHP = d.maxHP;
        GetComponent<SpriteRenderer>().sprite = d.sprite;
        name = $"Enemy_{d.enemyName}";
    }
}

