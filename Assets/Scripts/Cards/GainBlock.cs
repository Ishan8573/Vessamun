using UnityEngine;

[CreateAssetMenu(menuName = "Vessamun/CardEffects/Gain Block")]
public class GainBlockEffect : ScriptableCardEffect
{
    public int amount = 5;  

    public override void Resolve(CardContext ctx)
    {
        if (ctx.player != null)
        {
            Debug.Log($"Card gives {amount} block to player");
            ctx.player.AddBlock(amount);
        }
        else
        {
            Debug.LogWarning("GainBlockEffect: player is null");
        }
    }
}
