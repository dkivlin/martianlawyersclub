using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Data for cards dealt to the table
/// </summary>
public struct CardTable
{
    private List<Card> m_cards;

    public CardTable(int cardCount)
    {
        m_cards = new List<Card>(cardCount);
    }

    public void DiscardSelected(int _i)
    {
        m_cards.Remove(m_cards[_i]);
    }

    public void AddCard(Card card)
    {
        m_cards.Add(card);
    }

    public Card[] GetCards()
    {
        return m_cards.ToArray();
    }

    public void ClearTable()
    {
        m_cards.Clear();
    }
}
