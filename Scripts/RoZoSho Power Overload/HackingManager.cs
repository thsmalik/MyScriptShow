using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingManager : MonoBehaviour
{
    [SerializeField] private GameObject m_cirlce;
    [SerializeField] private Vector3 m_directions;
    [SerializeField] private float m_speed;
    [SerializeField] private GameObject[] m_cips;
    [SerializeField] private bool m_isAllTrue = true;
    [SerializeField] private GameObject theDoor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateAroundCirlce();
        SpeedUp();
        PressSpaceToUnlock();
        CheckDistanceCips();        
        CheckCipsBool();
        if(m_isAllTrue == true)
        {
            theDoor.SetActive(false);
        }
    }

    private void RotateAroundCirlce()
    {
        transform.RotateAround(m_cirlce.transform.position, m_directions, m_speed * Time.deltaTime);
    }

    private void PressSpaceToUnlock()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            m_speed *= -1;            
        }
    }

    private void SpeedUp()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_speed <= 130)
        {
            m_speed += 10;
        }
    }

    private void CheckDistanceCips()
    {
        foreach (GameObject c in m_cips)
        {
            if (Vector3.Distance(c.transform.position, transform.position) < 230f)
            {                
                if (Input.GetKeyDown(KeyCode.Space) && c.GetComponent<ReturnBoolCips>().IsUnlocked == false)
                {
                    c.GetComponent<ReturnBoolCips>().IsUnlocked = true;
                    Vector2 _dir = c.transform.parent.position - c.transform.position;
                    _dir.Normalize();
                    _dir *= -1;
                    c.transform.Translate(_dir, Space.Self);

                } else if(Input.GetKeyDown(KeyCode.Space) && c.GetComponent<ReturnBoolCips>().IsUnlocked == true)
                {
                    c.GetComponent<ReturnBoolCips>().IsUnlocked = false;
                    Vector2 _dir = c.transform.position - c.transform.parent.position;
                    _dir.Normalize();
                    _dir *= -1;
                    
                    c.transform.Translate(_dir, Space.Self);
                }
            }            
        }        
    }    

    private void CheckCipsBool()
    {
        if (m_isAllTrue == false)
        {
            m_isAllTrue = true;
        }
        foreach (GameObject c in m_cips)
        {
            if(c.GetComponent<ReturnBoolCips>().IsUnlocked == false)
            {
                m_isAllTrue = false;
                break;
            }
            
        }        
        if (m_isAllTrue == true)
        {
            Debug.Log("Its All True");
            PressEToHack.doneHacking = true;
        }
        
        
    }
}
