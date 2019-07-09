using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StekkerManager : MonoBehaviour
{

    public static bool m_isPicked
    {
        get
        {
            if (m_red || m_blue || m_green || m_yellow == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static bool m_red;
    public static bool m_blue;
    public static bool m_green;
    public static bool m_yellow;




}
