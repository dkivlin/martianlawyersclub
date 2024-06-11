using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalatroUI : FlowScreenUI
{
    [SerializeField]
    private CardTableUI m_cardTable;

    public UserUI UserUI;

    private CardBack m_cardBack;
    private List<CardHandUI> m_cardHands = new List<CardHandUI>();

    public void InitUI(CardBack cardBack)
    {
        m_cardBack = cardBack;
    }

    public int RemoveSelectedFromTable(CardTable cardTable)
    {
        int cardsLeft = m_cardTable.RemoveCards(cardTable);
        return cardsLeft;
    }

    public void SetCardsInTable(CardTable cardTable)
    {
        m_cardTable.SetCards(cardTable);
    }

    public void EnableUserUi()
    {
        UserUI.gameObject.SetActive(true);
    }

    public void DisableUserUI()
    {
        UserUI.gameObject.SetActive(false);
    }

    public void Reveal()
    {
        for (int i = 0; i < m_cardHands.Count; i++)
        {
            m_cardHands[i].Reveal();
        }
    }

    public void Reset()
    {
        m_cardTable.ClearTable();
    }

    public override void UpdateUI()
    {
    }

    public override void DestroyUI()
    {
        Destroy(gameObject);
    }
}
