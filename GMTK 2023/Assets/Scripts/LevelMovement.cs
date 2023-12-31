using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

[RequireComponent(typeof(SavedElement))]
public class LevelMovement : MonoBehaviour
{
    public float stepDistance = 1f;
    
    private Vector3 destination = Vector3.zero;

    private Vector3 lastDirt = Vector3.zero;
    
    private float nextMoveDelay = 0f;

    public static bool isMoving = false;

    private MMF_Player pushFeedback;


    private void Awake()
    {
        GetComponent<SavedElement>().type = SavedElement.Type.Level;
    }

    private void Start()
    {
        pushFeedback = GameObject.Find("PushFeedback").GetComponent<MMF_Player>();
    }

    void Update()
    {
        isMoving = DOTween.IsTweening(transform, true);
        GetMovementInput();
    }

    private void GetMovementInput()
    {
        Vector3 currentDestination = Vector3.zero;
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            nextMoveDelay = 0f;
            Vector3 currentDirt = Vector3.up;
            if (lastDirt == Vector3.down)
            {
                // print("delayed");
                nextMoveDelay = 0.05f;
            } 
            lastDirt = currentDirt;
            currentDestination = transform.position + stepDistance * currentDirt;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            nextMoveDelay = 0f;
            Vector3 currentDirt = Vector3.left;
            if (lastDirt == Vector3.right)
            {
                // print("delayed");
                nextMoveDelay = 0.05f;
            } 
            lastDirt = currentDirt;
            currentDestination = transform.position + stepDistance * currentDirt;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            nextMoveDelay = 0f;
            Vector3 currentDirt = Vector3.down;
            if (lastDirt == Vector3.up)
            {
                // print("delayed");
                nextMoveDelay = 0.05f;
            } 
            lastDirt = currentDirt;
            currentDestination = transform.position + stepDistance * currentDirt;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            nextMoveDelay = 0f;
            Vector3 currentDirt = Vector3.right;
            if (lastDirt == Vector3.left)
            {
                // print("delayed");
                nextMoveDelay = 0.05f;
            } 
            lastDirt = currentDirt;
            currentDestination = transform.position + stepDistance * currentDirt;
        }

        if(currentDestination != Vector3.zero & !isMoving)
        {
            destination = currentDestination;
            Invoke(nameof(Move), nextMoveDelay);
        }
    }

    private void Move()
    {
        transform.DOMove(destination, 0.2f)
            .OnComplete(() => { GameManager.SaveGameState(); });
        pushFeedback.PlayFeedbacks(); 
    }
}
