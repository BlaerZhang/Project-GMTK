using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static List<GameState> savedStates = new List<GameState>();
    
    void Start()
    {
        SaveGameState();
    }

    // TODO: better way to lock undo when objects are moving
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UndoMove();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public static void SaveGameState()
    {
        savedStates.Add(GameState.GetCurrentState());
    }

    public static void UndoMove()
    {
        print("savedStates.Count " + savedStates.Count);
        if(savedStates.Count<=1)
        {
            Debug.Log("No moves to undo");
        }
        else
        {
            savedStates[savedStates.Count-2].LoadGameState();
            savedStates.RemoveAt(savedStates.Count-1);
        }
    }
}