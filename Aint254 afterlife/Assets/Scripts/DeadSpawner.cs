using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadSpawner : MonoBehaviour
{
    public Image screenEffect;
    private GameObject GhostWall;
    private void Start()
    {
        GhostWall = GameObject.FindGameObjectWithTag("GhostWall");
    }
    void Update()
    {
        
    }
    public void die()
    {
        screenEffect.enabled = true;
        GhostWall.GetComponent<BoxCollider>().enabled = false;
    }
    public void unDie()
    {
        screenEffect.enabled = false;
        GhostWall.GetComponent<BoxCollider>().enabled = true;
    }
}
