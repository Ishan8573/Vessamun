using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private Transform handParent;   
    [SerializeField] private CardView cardViewPrefab;  

    [SerializeField] private PlayerHealth player;
    private Enemy enemy; 

    private readonly List<CardView> views = new();

    [System.Obsolete]
    private void Start()
    {
        if (deck == null) deck = FindObjectOfType<Deck>();
        if (player == null) player = FindObjectOfType<PlayerHealth>();
        enemy = FindObjectOfType<Enemy>();

        DrawStartingHand();
    }

    public void DrawStartingHand()
    {
        ClearHand();
        var cards = deck.Draw(5);
        foreach (var cd in cards)
        {
            var v = Instantiate(cardViewPrefab, handParent);
            v.Bind(cd, OnPlayCard);
            views.Add(v);
        }
    }

    private void ClearHand()
    {
        foreach (var v in views) Destroy(v.gameObject);
        views.Clear();
    }

    private void OnPlayCard(CardData card)
    {
        var ctx = new CardContext { player = player, enemy = enemy };
        if (card.effect != null)
            card.effect.Resolve(ctx);

        deck.Discard(card);

        var view = views.Find(v => v.Data == card);
        if (view != null) { views.Remove(view); Destroy(view.gameObject); }
    }
}
