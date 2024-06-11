using UnityEngine;
using UnityEngine.UI;

public class CardTableUI : MonoBehaviour
{
    [SerializeField] private Image[] m_cards;

    private int RemoveSelected(CardTable m_cardHand)
    {
        for (int i = m_cards.Length - 1; i >= 0; i--)
        {
            CardManager mgr = m_cards[i].gameObject.GetComponent<CardManager>();
            if (mgr.Selected)
            {
                mgr.Deselect();
                m_cardHand.DiscardSelected(i);
            }
        }

        Card[] cards = m_cardHand.GetCards();
        return cards.Length;
    }

    public int RemoveCards(CardTable m_cardHand)
    {
        return RemoveSelected(m_cardHand);
    }

    public void SetCards(CardTable m_cardHand)
    {
        Card[] cards = m_cardHand.GetCards();
        for (int i = 0; i < cards.Length; i++)
        {
            m_cards[i].sprite = cards[i].Sprite;
            m_cards[i].color = Color.white;
        }
    }

    public void ClearTable()
    {
        for (int i = 0; i < m_cards.Length; i++)
        {
            m_cards[i].sprite = null;
            m_cards[i].color = Color.clear;
        }
    }
}
