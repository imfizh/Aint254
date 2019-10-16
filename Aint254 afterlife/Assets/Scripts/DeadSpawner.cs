using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadSpawner : MonoBehaviour
{
    public Return rs;
    
    public GameObject deadplayer;
    public GameObject player;
    Vector3 pos;
    bool checkIfDead = false;
    public Image screenEffect;
    bool checkRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == false)
        {
            GetPos();
            Instantiate(deadplayer,pos,transform.rotation);
            checkIfDead = true;
            screenEffect.enabled = true;
        }
        
        if (Input.GetKeyDown(KeyCode.K) && checkIfDead == true)
        {
            
            if (rs.rangeCheck == true)
            {
                checkRange = true;
            }
            
            if (checkRange == true)
            {
                screenEffect.enabled = false;
                checkIfDead = false;
                checkRange = false;
            }
        }
        
    }
    void GetPos()
    {
        pos = player.transform.position;
        pos.z -= 1;
    }
}
