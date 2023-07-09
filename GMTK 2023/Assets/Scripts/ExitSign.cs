using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class ExitSign : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();

        col.isTrigger = false;
        col.size = new Vector2(0.9f, 0.9f);

        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // enter the next level
        if (other.collider.tag.Equals("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex - 2;
            print("finished level " + currentSceneIndex);
            print(SceneManager.sceneCountInBuildSettings);
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings - 2) GameManager.LoadLevel(nextSceneIndex);
            else
            {
                GameManager.LoadLevel(SceneManager.GetSceneByName("Level Selection").buildIndex);
            }
        }
    }
}
