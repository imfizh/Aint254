using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
   public void LoadGameOver()
    {
        Cursor.lockState = CursorLockMode.None; ;
        SceneManager.LoadScene("Game Over");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadGameComplete()
    {
        SceneManager.LoadScene("Game finish");
    }
    public void LoadStartScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
