using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class UIManager : MonoBehaviour
{
    #region Static instance
    // Public static property to access the singleton instance of GameStateManager
    public static UIManager instance
    {
        get
        {
            // If the instance is not set, instantiate a new one from resources
            if (_instance == null)
            {
                // Loads the GameStateManager prefab from Resources folder and instantiates it
                var go = (GameObject)GameObject.Instantiate(Resources.Load("UIManager"));
            }
            // Return the current instance (if set) or the newly instantiated instance
            return _instance;
        }
        // Private setter to prevent external modification of the instance
        private set { }
    }
    // Private static variable to hold the singleton instance of GameStateManager
    private static UIManager _instance;
    #endregion

    public GameObject gamePlayUI;
    public GameObject mainMenuUI;
    public GameObject levelCompleteUI;
    public GameObject gameCompleteUI;
    public GameObject levelFailedUI;
    public GameObject pauseMenuUI;

    public Text modeText;    
    public Text ShotsLeftCount;

    public Text LevelCount;

    private void Awake()
    {
        #region Singleton Pattern
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion
    }


    public void UpdateShotsleft(int count)
    {        
        ShotsLeftCount.text = count.ToString();
    }

    public void UpdateLevelCount(int count)
    {
        LevelCount.text = count.ToString();
    }

    public void UIMainMenu()
    {
        DisableAllUIPanels();
        mainMenuUI.SetActive(true);
    }

    public void PlayButton()
    {
        LevelManager.instance.LoadNextLevel();
    }

    public void UIGamePlay() // same as UIRolling.. consider merging them into one method for UIGameplay? make sure there are no issues first
    {
        DisableAllUIPanels();
        gamePlayUI.SetActive(true);
    }



    public void UILevelFailed()
    {
        DisableAllUIPanels();
        levelFailedUI.SetActive(true);
    }

    public void UILevelComplete()
    {
        DisableAllUIPanels();
        levelCompleteUI.SetActive(true);
    }

    public void UIGameComplete()
    {
        DisableAllUIPanels();
        gameCompleteUI.SetActive(true);
    }

    public void UIPaused()
    {
        DisableAllUIPanels();
        pauseMenuUI.SetActive(true);
    }

    public void DisableAllUIPanels()
    {
        gamePlayUI.SetActive(false);
        mainMenuUI.SetActive(false);
        levelCompleteUI.SetActive(false);
        gameCompleteUI.SetActive(false);
        levelFailedUI.SetActive(false);
        pauseMenuUI.SetActive(false);
    }



}
