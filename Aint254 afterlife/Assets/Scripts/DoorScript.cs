using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public Text locked;
    private KeyScript PkdUp;
    // Start is called before the first frame update
    void Start()
    {
        PkdUp = GameObject.Find("KeyCubeTrigger").GetComponent<KeyScript>();
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
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
        {
            if (other.gameObject.tag == "Player")
            {
                if (PkdUp.PickedUp == false)
                {
                    locked.text = "It's locked";
                }
                else if (PkdUp.PickedUp == true)
                {
                    FindObjectOfType<sceneLoader>().LoadGameComplete();
                }

            }
        }
    }
        private void OnTriggerExit(Collider other)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
            {
                if (other.gameObject.tag == "Player")
                {
                    //FindObjectOfType<sceneLoader>().LoadGameComplete();
                    locked.text = "";
                }
            }
        }
    }
