using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text onScreenText;
    public string text = "";
    // Start is called before the first frame update
    void Start()
    {
        onScreenText.text = "Press K to kill self";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            onScreenText.text = text;
        }
    }
}
