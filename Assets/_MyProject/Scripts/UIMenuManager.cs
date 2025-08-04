using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject GameUIPanel;
    public GameObject mainPlayer;

    private void Start()
    {
        Time.timeScale = 0f; // Pause the game at the start
        MainMenuPanel.SetActive(true);
        GameUIPanel.SetActive(false);
        if (mainPlayer != null)
        {
            mainPlayer.SetActive(false); // Ensure the player is inactive at the start
        }


    }
    
    public void PlayGame()
    {
        Time.timeScale = 1f;
        MainMenuPanel.SetActive(false);
        GameUIPanel.SetActive(true);
        if (mainPlayer != null)
        {
            mainPlayer.SetActive(true); // Activate the player when starting the game
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Settings()
    {

        // Implement settings functionality here
        Debug.Log("Settings button clicked.");

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
