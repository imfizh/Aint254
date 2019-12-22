using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    private GameObject Key;
    public Text KeyText;
    public bool PickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        Key = GameObject.Find("Key");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&PickedUp == false)
        {
            KeyText.text = "Press E to pick up key";
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
            KeyText.text = "";
        }

    }
    public void inspect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            KeyText.text = "";
            PickedUp = true;
            Destroy(Key);
        }
    }
}
