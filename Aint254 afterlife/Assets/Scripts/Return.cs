using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public Text theText;
    
    public bool rangeCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && rangeCheck == true)
        {
            
            rangeCheck = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DeadPlayer")
        {
            theText.text = "Press K to return to body";
            rangeCheck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DeadPlayer")
        {
            theText.text = "";
            rangeCheck = false;
        }
    }
}
