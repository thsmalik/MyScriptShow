using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Level_5
{
    public class RubeGoldBergP2Activate : MonoBehaviour
    {
        [SerializeField]private PlayableDirector m_rubeGoldBergPart2;
        private bool m_isNotPlayed = true;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position,transform.position) < 3 && Input.GetKeyDown(KeyCode.E) && m_isNotPlayed == true)
            {
                m_rubeGoldBergPart2.Play();
                m_isNotPlayed = false;
            }
        }
    }
}
