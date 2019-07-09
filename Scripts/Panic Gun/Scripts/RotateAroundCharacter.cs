using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundCharacter : MonoBehaviour
{
    public GameObject character;
    public float speed;
    public GameObject arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = Mathf.InverseLerp(-1f, 1f, Mathf.Sin(Time.time * speed));
        Vector3 eulerAngles = Vector3.forward * 90f * value;
        arm.transform.eulerAngles = eulerAngles;
    }

    //private void OnTriggerEnter2D(Collider2D other)
   // {
      //  if(other.tag == "Wall")
      //  {
//Speed *= -1;
      //  }
   // }
}
