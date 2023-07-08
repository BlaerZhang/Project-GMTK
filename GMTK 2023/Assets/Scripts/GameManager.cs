using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameState> savedStates = new List<GameState>();
    
    void Start()
    {
        SaveGameState();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UndoMove();
        }
        
        //TODO: add restart function
    }
    
    public static void SaveGameState()
    {
        savedStates.Add(GameState.GetCurrentState());
    }

    public static void UndoMove()
    {
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