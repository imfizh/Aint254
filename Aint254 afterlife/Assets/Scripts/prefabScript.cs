using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabScript : MonoBehaviour
{
    bool checkRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && checkRange == true)
        {
            Destroy(transform.parent.gameObject);
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
