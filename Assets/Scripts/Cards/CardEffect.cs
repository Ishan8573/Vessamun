using UnityEngine;

public abstract class ScriptableCardEffect : ScriptableObject
{
    public abstract void Resolve(CardContext ctx);
}

public struct CardContext
{
    public PlayerHealth player;
    public Enemy enemy;
}
