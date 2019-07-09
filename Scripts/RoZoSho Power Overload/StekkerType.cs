using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StekkerType : BasicPickup
{  

    public enum Type
    {
        Rood,
        Blauw,
        Geel,
        Groen
    }

    public Type m_stekkerType;

    public override void Pickup(Player player)
    {
        if (StekkerManager.m_isPicked == false)
        {
            base.Pickup(player);
            switch (m_stekkerType)
            {
                case Type.Rood:
                    StekkerManager.m_red = true;
                    break;
                case Type.Blauw:
                    StekkerManager.m_blue = true;
                    break;
                case Type.Geel:
                    StekkerManager.m_yellow = true;
                    break;
                case Type.Groen:
                    StekkerManager.m_green = true;
                    break;
                default:
                    Debug.Log("There Is Something Wrong");
                    break;

            }
            DestroyPickup();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
