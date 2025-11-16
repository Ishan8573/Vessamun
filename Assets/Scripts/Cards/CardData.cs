using UnityEngine;

public enum CardType { Attack, Skill, Power }

[CreateAssetMenu(menuName = "Vessamun/Card")]
public class CardData : ScriptableObject
{
    public string cardName = "Strike";
    [TextArea] public string description = "5 damage.";
    public CardType type = CardType.Attack;
    public int cost = 1;

    public ScriptableCardEffect effect;
}
