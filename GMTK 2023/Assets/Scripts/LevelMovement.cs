using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelMovement : MonoBehaviour
{
    public float stepDistance = 1f;

    private bool isWallMoving = false;

    void Update()
    {
        isWallMoving = DOTween.IsTweening(transform, true);
        Move();
    }

    private void Move()
    {
        // cannot move wall when moving
        if (isWallMoving) return;
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.DOMoveY(transform.position.y + stepDistance, 0.2f)
                .OnComplete(() => { GameManager.SaveGameState(); });
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.DOMoveX(transform.position.x - stepDistance, 0.2f)
                .OnComplete(() => { GameManager.SaveGameState(); });
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.DOMoveY(transform.position.y - stepDistance, 0.2f)
                .OnComplete(() => { GameManager.SaveGameState(); });
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.DOMoveX(transform.position.x + stepDistance, 0.2f)
                .OnComplete(() => { GameManager.SaveGameState(); });
        }
    }
}
