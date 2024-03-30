using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pausePopup;
    public GameObject resumeButton;
    public GameObject howToPlayButton;
    public GameObject mainMenuButton;
    public GameObject howToPlayPopup;
    public GameObject BackButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pausePopup.SetActive(true);
        resumeButton.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        resumeButton.SetActive(false);
        pausePopup.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void HowToPlay()
    {
        resumeButton.SetActive(false);
        howToPlayButton.SetActive(false);
        mainMenuButton.SetActive(false);
        pausePopup.SetActive(false);
        howToPlayPopup.SetActive(true);
        BackButton.SetActive(true);
    }

    public void backButton()
    {
        pausePopup.SetActive(true);
        resumeButton.SetActive(true);
        howToPlayButton.SetActive(true);
        mainMenuButton.SetActive(true);
        howToPlayPopup.SetActive(false);
        BackButton.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
