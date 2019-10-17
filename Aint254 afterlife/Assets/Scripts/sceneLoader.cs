using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
   public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
