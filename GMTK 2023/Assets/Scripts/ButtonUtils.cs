using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtils : MonoBehaviour
{

    private GameObject backPanel = null;
    private void Start()
    {
        backPanel = GameObject.Find("Back Panel");

        if (backPanel != null)
        {
            backPanel.SetActive(false);
        }
    }

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
        backPanel.SetActive(true);
    }

    public void CancelBack()
    {
        backPanel.SetActive(false);
    }

    public void SimpleBack()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
