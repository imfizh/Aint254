using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour
{
    private health Health;
    public float tickTime;
    private void Start()
    {
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //take damge
            //Health.damage();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //keep taking damage
            tickTime -= Time.deltaTime;
            if (tickTime<=0)
            {
                Health.damage();
                tickTime = 1.0f;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //stop taking damage
            
        }
    }
   
}
