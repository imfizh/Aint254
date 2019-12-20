using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    public Text theText;
    public bool rangeCheck = false;
    private MovementScript ms;
    private health H;
    private void Start()
    {
        ms = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        H = GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && rangeCheck == true)
        {
            ms.Revive();
            H.fullHealth();
            rangeCheck = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DeadPlayer")
        {
            theText.text = "Press K to return to life";
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
