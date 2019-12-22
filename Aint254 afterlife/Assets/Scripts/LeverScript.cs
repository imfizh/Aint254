using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverScript : MonoBehaviour
{
    private GameObject LH;
    public Text LeverText;
    public bool Pulled = false;
    // Start is called before the first frame update
    void Start()
    {
        LH = GameObject.FindGameObjectWithTag("LightHolder");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player"&&Pulled == false)
        {
            LeverText.text = "Press E to release light";
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
            LeverText.text = "";
        }

    }
    public void inspect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LH.GetComponent<BoxCollider>().enabled = false;
            Pulled = true;
            LeverText.text = "";
        }
    }
    }


