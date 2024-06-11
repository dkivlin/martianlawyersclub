using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private bool m_selected;
    [SerializeField] Animator m_animator;

    public bool Selected { get { return m_selected; } }

    void Start()
    {
        m_selected = false;
    }

    public void Deselect()
    {
        m_animator.SetTrigger("Deselect");
        m_selected = false;
    }

    public void OnPressed()
    {
        m_selected = !m_selected;
        if (m_selected)
            m_animator.SetTrigger("Select");
        else
            m_animator.SetTrigger("Deselect");
    }
}
