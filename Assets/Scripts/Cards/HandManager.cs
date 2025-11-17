using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private Transform handParent;
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] private int handSize = 5;

    [SerializeField] private PlayerHealth player;
    private Enemy enemy; 
    [SerializeField] private Energy energy;

    private readonly List<CardView> views = new();

    [System.Obsolete]
    private void Start()
    {
        if (deck == null) deck = FindObjectOfType<Deck>();
        if (player == null) player = FindObjectOfType<PlayerHealth>();
        if (energy == null) energy = FindFirstObjectByType<Energy>();

        DrawStartingHand();
    }

    public void DrawStartingHand()
    {
        DiscardHand();
        var cards = deck.Draw(handSize);
        foreach (var cd in cards)
        {
            var v = Instantiate(cardViewPrefab, handParent);
            v.Bind(cd, OnPlayCard);
            views.Add(v);
        }
    }

    public void DiscardHand()
    {
        for (int i = views.Count - 1; i >= 0; i--)
        {
            var v = views[i];
            if (v != null)
            {
                if (v.Data != null) 
                deck.Discard(v.Data);
                Destroy(v.gameObject);
            }
        }
        views.Clear();
    }

    private void OnPlayCard(CardData card)
    {
        if (energy != null)
        {
            if(!energy.CanAfford(card.cost))
            {
                Debug.Log($"Not enough energy to play {card.cardName}. " + 
                $"Need {card.cost}, have {energy.CurrentEnergy}");
                return;
            }
            energy.Spend(card.cost);
        }
        Enemy enemy = FindFirstObjectByType<Enemy>();
        var ctx = new CardContext {
            player = player,
            enemy = enemy
        };
        if (card.effect != null)
            card.effect.Resolve(ctx);

        deck.Discard(card);

        var view = views.Find(v => v.Data == card);
        if (view != null)
        {
            views.Remove(view);
            Destroy(view.gameObject); 
        }
    }
}
