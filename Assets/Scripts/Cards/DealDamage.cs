using UnityEngine;

[CreateAssetMenu(menuName = "Vessamun/CardEffects/Deal Damage")]
public class DealDamageEffect : ScriptableCardEffect
{
    public int amount = 6;

    public override void Resolve(CardContext ctx)
    {
        if (ctx.enemy != null)
            ctx.enemy.TakeDamage(amount);
    }
}

