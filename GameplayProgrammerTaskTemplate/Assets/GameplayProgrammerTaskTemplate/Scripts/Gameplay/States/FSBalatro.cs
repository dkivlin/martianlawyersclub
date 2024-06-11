using UnityEngine;
using Task = System.Threading.Tasks.Task;

/// <summary>
/// State responsible for running the flow of poker
/// </summary>
public class FSBalatro : FlowState
{
    private BalatroUI m_ui;
    private UIManager m_uiManager;

    private Deck m_deck;
    private BalatroInteractionManager m_balatroInteractionManager;
    private CardBacksDataObject m_cardBacksData;

    private CardBack m_cardBack;
    private BalatroPhase m_currentPhase;

    public FSBalatro(GameContext gameContext)
    {
        m_deck = new Deck();

        m_uiManager = gameContext.UIManager;
        m_balatroInteractionManager = new BalatroInteractionManager(m_deck);

        m_cardBacksData = Resources.Load<CardBacksDataObject>("Data/CardBackData");
        m_cardBack = new CardBack();
        m_cardBack.SetCardBack(m_cardBacksData.CardBack[0]);

        m_currentPhase = BalatroPhase.Deal;
    }

    public override void OnInitialise()
    {
        m_ui = m_uiManager.LoadUIScreen<BalatroUI>("UI/Screens/BalatroUI", this);

        m_ui.InitUI(m_cardBack);
    }

    public override void OnActive()
    {
        RunRoundPhase();
    }

    /// <summary>
    /// The poker round flow, must be called to progress, not updated.
    /// </summary>
    private void RunRoundPhase()
    {
        switch (m_currentPhase)
        {
            case BalatroPhase.Deal:
                m_currentPhase = BalatroPhase.Selection;
                m_balatroInteractionManager.Deal();
                m_ui.SetCardsInTable(m_balatroInteractionManager.m_cardTable);
                break;
            case BalatroPhase.Selection:
                break;
        }
    }

    private void SortBySuit(bool _suit)
    {
        m_balatroInteractionManager.SortBySuit(_suit);
    }

    private void PlayHand()
    {
        m_balatroInteractionManager.PlayHand();
    }

    private void DiscardSelected()
    {
        int cardsLeft = m_ui.RemoveSelectedFromTable(m_balatroInteractionManager.m_cardTable);
        for (int i = 0; i < 8 - cardsLeft; i++)
        {
            Card newCard = m_deck.DrawCard();
            m_balatroInteractionManager.m_cardTable.AddCard(newCard);
        }
        m_ui.SetCardsInTable(m_balatroInteractionManager.m_cardTable);
    }

    public override void ReceiveFlowMessages(object message)
    {
        switch (message)
        {
            case "discard":
                DiscardSelected();
                break;
            case "playhand":
                PlayHand();
                break;
            case "sortbysuit":
                SortBySuit(true);
                break;
            case "sortbyrank":
                SortBySuit(false);
                break;
            case SliderFlowMessage sliderFlowMessage:
                break;
        }
    }

    public override void ActiveUpdate()
    {
        m_ui.UpdateUI();
    }

    public override void ActiveFixedUpdate()
    {
    }

    public override void OnInactive()
    {
    }

    public override void OnDismiss()
    {
    }

    public override void FinishDismiss()
    {
        m_ui.DestroyUI();
    }
}
