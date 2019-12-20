using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HieroWallScript : MonoBehaviour
{
    public Text theText;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            theText.text = "Press E to inspect hieroglyphics";
        }

    }
    private void OnTriggerStay(Collider other)
    {
        inspect();
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            theText.text = "";
        }

    }
    public void inspect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            theText.text = "It says 'Sometimes death is the only way forward'";
        }
    }
}
