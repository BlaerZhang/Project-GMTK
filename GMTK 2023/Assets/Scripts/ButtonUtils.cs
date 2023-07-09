using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtils : MonoBehaviour
{

    public void StartNewGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void GotoSelect()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void SelectLevel(int levelIndex)
    {
        int levelIndexInName = levelIndex - 1;
        string levelName = "Level " + levelIndexInName.ToString();
        SceneManager.LoadScene(levelName);
    }

    public void TryBacktoMenu()
    {
        
    }
    
    public void ConfirmBacktoMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void SimpleBack()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
