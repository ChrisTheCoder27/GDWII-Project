using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int levelOneIndex;

    public void StartGame()
    {
        // Loads the first level using its build index
        SceneManager.LoadScene(levelOneIndex);
    }

    public void Quit()
    {
        // Quits the game, but won't quit in the editor, so a Debug.Log statement is made
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
