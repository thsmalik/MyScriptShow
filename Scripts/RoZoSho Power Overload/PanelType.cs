using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelType : BasicPickup
{
    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    public enum Type
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public Type m_panelType;

    public IDamageableObject health;
    // Start is called before the first frame update

    private void Start()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }


    public override void Pickup(Player player)
    {
        /*switch (m_panelType)
        {
            case Type.Red: 
                if(StekkerManager.m_red = true && PanelManager.m_redIsInserted == false)
                {
                    base.Pickup(player);
                }
                else
                {
                    Debug.Log("Nope");
                }
                break;
            case Type.Blue:
                if (StekkerManager.m_blue = true && PanelManager.m_blueIsInserted == false)
                {
                    base.Pickup(player);
                }
                else
                {
                    Debug.Log("Nope");
                }
                break;
            case Type.Yellow:
                if (StekkerManager.m_yellow = true && PanelManager.m_yellowIsInserted == false)
                {
                    base.Pickup(player);
                }
                else
                {
                    Debug.Log("Nope");
                }
                break;
            case Type.Green:
                if (StekkerManager.m_green = true && PanelManager.m_greenIsInserted == false)
                {
                    base.Pickup(player);
                }
                else
                {
                    Debug.Log("Nope");
                }
                break;

            default:
                Debug.Log("Something Is Wrong");
                break;
        }           
        */

        base.Pickup(player);

        switch (m_panelType)
        {
            case Type.Red: 
                if(StekkerManager.m_red == true)
                {
                    PanelManager.m_redIsInserted = true;
                    StekkerManager.m_red = false;
                }
                else
                {
                    health.ChangeHealth(-20);
                    Debug.Log("Damage Your Ass");
                }
                break;
            case Type.Blue:
                if (StekkerManager.m_blue == true)
                {
                    PanelManager.m_blueIsInserted = true;
                    StekkerManager.m_blue = false;
                }
                else
                {
                    health.ChangeHealth(-20);
                    Debug.Log("Damage Your Ass");
                }
                break;
            case Type.Yellow:
                if (StekkerManager.m_yellow == true)
                {
                    PanelManager.m_yellowIsInserted = true;
                    StekkerManager.m_yellow = false;
                }
                else
                {
                    health.ChangeHealth(-20);
                    Debug.Log("Damage Your Ass");
                }
                break;
            case Type.Green:
                if (StekkerManager.m_green == true)
                {
                    PanelManager.m_greenIsInserted = true;
                    StekkerManager.m_green = false;
                }
                else
                {
                    health.ChangeHealth(-20);
                    Debug.Log("Damage Your Ass");
                }
                break;
            default:
                Debug.Log("Something Is Wrong");
                break;
        }
    }

}
