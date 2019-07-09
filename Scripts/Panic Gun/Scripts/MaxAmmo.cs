using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxAmmo : MonoBehaviour
{
    public PlayerShooting ammo;
    public TMP_Text textt;
    // Start is called before the first frame update
    void Start()
    {
        ammo = FindObjectOfType<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        textt.text = "MAX AMMO : " + ammo.MaxAmmo.ToString(); 
    }
}
