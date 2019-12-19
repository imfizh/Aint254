using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            if (other.gameObject.tag == "Player")
            {
                FindObjectOfType<sceneLoader>().LoadLevel2();
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            if (other.gameObject.tag == "Player")
            {
                FindObjectOfType<sceneLoader>().LoadLevel3();
            }
        }
        
    }
    
}
