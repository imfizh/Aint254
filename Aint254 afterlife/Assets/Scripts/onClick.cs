using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClick : MonoBehaviour
{
    public Text HTP_text;
    public GameObject play_but;
    public GameObject HTP_but;
    public GameObject back_but;
   public void LoadText()
    {
        play_but.SetActive(false);
        HTP_but.SetActive(false);
        HTP_text.enabled = true;
        back_but.SetActive(true);
    }
    public void Back()
    {
        play_but.SetActive(true);
        HTP_but.SetActive(true);
        HTP_text.enabled = false;
        back_but.SetActive(false);
    }
}
