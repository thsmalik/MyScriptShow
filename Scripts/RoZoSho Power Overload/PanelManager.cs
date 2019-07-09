using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static bool m_redIsInserted;
    public GameObject m_red;
    public static bool m_blueIsInserted;
    public GameObject m_blue;
    public static bool m_greenIsInserted;
    public GameObject m_green;
    public static bool m_yellowIsInserted;
    public GameObject m_yellow;
    private bool m_allIsTrue
    {
        get
        {
            if(m_redIsInserted && m_greenIsInserted && m_blueIsInserted && m_yellowIsInserted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    [SerializeField]private Animator m_door;

    private void Awake()
    {
        m_door.speed = 0;
    }

    private void Update()
    {
        ActivateGOIfTrue();
        //Debug.Log(m_allIsTrue);
        if (m_allIsTrue == true)
        {
            m_door.speed = 1;
            m_door.Play("DoorAnimation");
        }
        
    }

    private void ActivateGOIfTrue()
    {
        if(m_redIsInserted == true)
        {
            m_red.SetActive(true);
        }
        if (m_blueIsInserted == true)
        {
            m_blue.SetActive(true);
        }
        if (m_yellowIsInserted == true)
        {
            m_yellow.SetActive(true);
        }
        if (m_greenIsInserted == true)
        {
            m_green.SetActive(true);
        }
    }
}
