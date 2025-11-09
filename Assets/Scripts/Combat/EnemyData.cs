
using UnityEngine;

[CreateAssetMenu(menuName = "Vessamun/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public Sprite sprite;
    public int maxHP = 30;
    public bool isBoss = false;
}
