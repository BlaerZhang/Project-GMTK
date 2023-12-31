using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static List<GameState> savedStates = new List<GameState>();

    public static GameManager instance;

    private static MMF_Player undoFeedback;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        undoFeedback = GameObject.Find("UndoFeedback").GetComponent<MMF_Player>();
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
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("Scene Loaded " + scene.name);
        emptySavedStates();
        SaveGameState();
    }

    public static void LoadLevel(int levelIndexInName)
    {
        string levelName = "Level " + levelIndexInName;
        SceneManager.LoadScene(levelName);
    }
    
    private void OnDestroy ()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void emptySavedStates()
    {
        savedStates.Clear();
    }
    
    public static void SaveGameState()
    {
        savedStates.Add(GameState.GetCurrentState());
    }

    public static void UndoMove()
    {
        // print("savedStates.Count " + savedStates.Count);
        if(savedStates.Count<=1)
        {
            Debug.Log("No moves to undo");
        }
        else
        {
            savedStates[savedStates.Count-2].LoadGameState();
            savedStates.RemoveAt(savedStates.Count-1);
            undoFeedback.PlayFeedbacks();
        }
    }
}