using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    GameManager GameManager;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    public void ReastartLevel()
    {

       
       ResetDestinationCounts();     
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("------------------------------------------------------");
        Debug.Log("MapLength = " + GameManager.GameData.MapLength);
        Debug.Log("CurentLevel = " + GameManager.GameData.CurentLevel);
        Debug.Log("TotalDestinationCount = " + GameManager.GameData.TotalDestinationCount);
        Debug.Log("CurrentDestinationCount = " + GameManager.GameData.CurrentDestinationCount);
        Debug.Log("NumberOfLevels = " + GameManager.GameData.NumberOfLevels);
        Debug.Log("PlayerX = " + GameManager.GameData.PlayerX);
        Debug.Log("PlayerZ = " + GameManager.GameData.PlayerZ);

    }

    public void LoadLevelMenu()
    {
       
        ResetDestinationCounts();
        SceneManager.LoadSceneAsync(0); // Load Level Menu
    }

    void ResetDestinationCounts()
    {
        GameManager.ResetTotalDestinationCount();
        GameManager.ResetCurrentDestinationCount();
    }
}


