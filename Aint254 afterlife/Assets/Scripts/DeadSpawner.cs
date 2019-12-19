using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadSpawner : MonoBehaviour
{
    public Return rs;

    //public GameObject deadplayer;
    //Vector3 pos;
    public GameObject player;
    bool checkIfDead = false;
    public Image screenEffect;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == false)
        {
            //GetPos();
            //Instantiate(deadplayer,pos,transform.rotation);
            checkIfDead = true;
            screenEffect.enabled = true;
        }
        
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == true)
        {
            
            if (rs.rangeCheck == true)
            {
                screenEffect.enabled = false;
                checkIfDead = false;
            }
        }
        
    }
    //void GetPos()
    //{
    //    pos = player.transform.position;
    //    pos.z -= 1;
    //}
}
