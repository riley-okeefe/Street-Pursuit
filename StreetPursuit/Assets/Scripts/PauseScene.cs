using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScene : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pausePopup;
    public GameObject resumeButton;
    public GameObject howToPlayButton;
    public GameObject mainMenuButton;
    public GameObject howToPlayPopup;
    public GameObject BackButton;
    public GameObject healthHud;
    public Slider healthSlider;
    public GameObject endScreen;
    public GameObject playAgainButton;
    public GameObject mainMenuButton2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DemoPlayerScript.playerHealth == 0)
        {
            healthHud.SetActive(false);
            pauseButton.SetActive(false);
            pausePopup.SetActive(false);
            resumeButton.SetActive(false);
            howToPlayButton.SetActive(false);
            mainMenuButton.SetActive(false);
            howToPlayPopup.SetActive(false);
            BackButton.SetActive(false);
            endScreen.SetActive(true);
        } else
        {
            PlayerHealth();
        }
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
        healthHud.SetActive(false);
        howToPlayPopup.SetActive(true);
        BackButton.SetActive(true);
    }

    public void backButton()
    {
        pausePopup.SetActive(true);
        resumeButton.SetActive(true);
        howToPlayButton.SetActive(true);
        mainMenuButton.SetActive(true);
        healthHud.SetActive(true);
        howToPlayPopup.SetActive(false);
        BackButton.SetActive(false);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
    }

    public void PlayerHealth()
    {
        healthSlider.value = DemoPlayerScript.playerHealth;
    }

    public void PlayAgainLevelOne() 
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void PlayAgainLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }
}
