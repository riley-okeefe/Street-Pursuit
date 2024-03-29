using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    public void LoadStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadHTP()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void LoadCarSelect()
    {
        SceneManager.LoadScene("CarSelection");
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
        
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    
}
