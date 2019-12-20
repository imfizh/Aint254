using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadSpawner : MonoBehaviour
{
    public Return rs;

    public GameObject player;
    bool checkIfDead = false;
    public Image screenEffect;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == true)
        {
            
            if (rs.rangeCheck == true)
            {
                screenEffect.enabled = false;
                checkIfDead = false;
            }
        }
        
    }
    public void die()
    {
        checkIfDead = true;
        screenEffect.enabled = true;
    }
}
