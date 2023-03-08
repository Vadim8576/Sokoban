using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject levelCompliteMenu;
    [SerializeField] Button nextButton;
    [SerializeField] TextMeshProUGUI levelNumber;

    GameManager gameManager;



    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelNumber.text = "Level: " + (gameManager.GetCurrentLevel() + 1).ToString();
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        gameManager.Pause();
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        gameManager.Play();
    }

    public void ShowLevelCompliteMenu()
    {
        levelCompliteMenu.SetActive(true);
        gameManager.Pause();


        //if (gameManager.GetCurrentLevel() == gameManager.GetNumberOfLevels())
        if (gameManager.GetCurrentLevel() == 2)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }
    }

    public void HideLevelCompliteMenu()
    {
        levelCompliteMenu.SetActive(false);
        gameManager.Play();
    }

}
