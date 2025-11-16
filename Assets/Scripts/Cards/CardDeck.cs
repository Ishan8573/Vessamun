using UnityEngine;
using System.Collections.Generic;


public class Deck : MonoBehaviour
{
    [Header("Starting Deck (Assets)")]
    public List<CardData> startingCards;

    private readonly List<CardData> drawPile = new();
    private readonly List<CardData> discardPile = new();

    private void Awake()
    {
        drawPile.Clear();
        drawPile.AddRange(startingCards);
        Shuffle(drawPile);
    }

    public List<CardData> Draw(int count)
    {
        var hand = new List<CardData>();
        for (int i = 0; i < count; i++)
        {
            if (drawPile.Count == 0)
            {
                drawPile.AddRange(discardPile);
                discardPile.Clear();
                Shuffle(drawPile);
                if (drawPile.Count == 0) break;
            }
            var top = drawPile[^1];
            drawPile.RemoveAt(drawPile.Count - 1);
            hand.Add(top);
        }
        return hand;
    }

    public void Discard(CardData card) => discardPile.Add(card);

    private void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int j = Random.Range(i, list.Count);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
