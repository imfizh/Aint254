using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabScript : MonoBehaviour
{
    bool checkRange = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && checkRange == true)
        {
            //Destroy(transform.parent.gameObject);
            checkRange = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkRange = false;
        }
    }
}
