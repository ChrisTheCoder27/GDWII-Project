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
    }

    public void LoadSpecificScene()
    {
        // Loads a scene as specified when the function gets called
        SceneManager.LoadScene(sceneIndex);
    }
}
