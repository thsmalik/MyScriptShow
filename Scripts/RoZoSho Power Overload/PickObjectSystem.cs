using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectSystem : MonoBehaviour
{


    public float m_pickUpRange;
    public Transform m_dest;
    public Transform m_camPos;
    private bool m_pickedUp;

    private void Update()
    {
        
    }

    

    private void DetectObject()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(m_camPos.position, m_camPos.forward, out hitInfo,m_pickUpRange))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StekkerType stekkerType = hitInfo.transform.GetComponent<StekkerType>();

                if(stekkerType != null)
                {
                    m_pickedUp = true;
                    hitInfo.transform.parent = m_dest.parent;
                    hitInfo.transform.GetComponent<Rigidbody>().useGravity = false;
                    hitInfo.transform.GetComponent<BoxCollider>().enabled = false;
                }
            }

            if(m_pickedUp == true && Input.GetKeyUp(KeyCode.E))
            {

            }
        }
    }
}
