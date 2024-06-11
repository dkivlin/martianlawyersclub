using System;
using System.Collections.Generic;
using System.Linq;
using HoldemHand;
using UnityEngine;

/// <summary>
/// A manager for running texas holdem style poker interactions. 
/// </summary>
public class BalatroInteractionManager
{
    private const int k_tableTotalCards = 8;
    public CardTable m_cardTable;
    private Deck m_deck;

    public BalatroInteractionManager(Deck deck)
    {
        m_deck = deck;
        m_cardTable = new CardTable(k_tableTotalCards);
    }

    public void SortBySuit(bool _suit)
    {
    }

    public void PlayHand()
    {
    }

    public void Deal()
    {
        for (int i = 0; i < k_tableTotalCards; i++)
        {
            Card newCard = m_deck.DrawCard();
            m_cardTable.AddCard(newCard);
        }
    }

    public void Reset()
    {
        m_cardTable = new CardTable(k_tableTotalCards);
    }

    public List<int> GetBestHand()
    {
        uint bestHandValue = uint.MinValue;
        List<int> bestHandIds = new List<int>();

        //Get Table Card string
        string tableString = string.Empty;
        Card[] tableCards = m_cardTable.GetCards();
        tableString = tableCards.Aggregate(tableString, (current, t) => current + $"{t.ToString()} ");
        string description = string.Empty; ;

        ulong handMask = Hand.ParseHand(tableString);
        uint handValue = Hand.Evaluate(handMask);

        if (handValue >= bestHandValue)
        {
            if (handValue != bestHandValue)
            {
                bestHandIds.Clear();
            }
            description = Hand.DescriptionFromMask(handMask);
            bestHandValue = handValue;
        }

        Debug.Log(description);
        return bestHandIds;
    }
}
