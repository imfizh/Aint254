using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    private DeadSpawner ds;
    private MovementScript ms;
    public int Health=3;
    public int numOfHearts=3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private void Start()
    {
        ds = GameObject.FindGameObjectWithTag("Player").GetComponent<DeadSpawner>();
        ms = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
    }
    public void damage()
    {
        Health -=1;
    }
    public void fullHealth()
    {
        Health = 3;
    }
    void dead()
    {
        if (Health == 0)
        {
            ds.die();
            ms.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health>numOfHearts)
        {
            Health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i<Health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i<numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        dead();
    }
}
