using System;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserUI : MonoBehaviour
{
    [SerializeField]
    private Button m_discardButton;
    [SerializeField]
    private Button m_playhandButton;
    [SerializeField]
    private Button m_sortbyrankButton;
    [SerializeField]
    private Button m_sortbysuitButton;

    private void Awake()
    {
    }

    public void UpdateCurrencyValue(int newValue)
    {
    }

    public void SetTextValue(int value)
    {
    }
    
    public void ToggleBetSetterActive(bool active)
    {
    }
}
