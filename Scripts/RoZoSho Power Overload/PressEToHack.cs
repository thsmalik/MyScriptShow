using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressEToHack : MonoBehaviour
{
    private Transform player;
    private bool isClose { get { return Vector3.Distance(transform.position, player.position) < 1.5; } }
    public static bool doneHacking;
    [SerializeField]private GameObject mainCam;
    [SerializeField]private GameObject actionCam;
    [SerializeField] private GameObject UItoHack;
    [SerializeField] private GameObject hack;
    [SerializeField] private bool isHacking;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        UItoHack.SetActive(false);
        hack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose && doneHacking == false)
        {
            UItoHack.SetActive(true);
        }
        else
        {
            UItoHack.SetActive(false);
        }
        
        if(isClose && Input.GetKeyDown(KeyCode.E) && doneHacking == false)
        {
            mainCam.SetActive(false);
            actionCam.SetActive(true);
            isHacking = true;
            hack.SetActive(true);
        }
        if(isClose && Input.GetKeyDown(KeyCode.Escape) || doneHacking == true)
        {
            mainCam.SetActive(true);
            actionCam.SetActive(false);
            isHacking = false;
            hack.SetActive(false);
        }
        if(isClose && isHacking == true)
        {
            UItoHack.SetActive(false);
        }
    }
}
