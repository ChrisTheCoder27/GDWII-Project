using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void LoadNextScene()
    {
        // Loads the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Unpauses the game and sets the time back to normal
        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadSpecificScene()
    {
        // Loads a scene as specified when the function gets called
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        // Quits the game, but won't quit in the editor, so a Debug.Log statement is made
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
