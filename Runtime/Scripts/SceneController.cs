using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        string levelName = FindObjectOfType<LevelController>()?.GetNextLevel();
        SceneManager.LoadScene(levelName);
        print("Next scene: " + levelName);
    }
}