using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] [RequireComponent(typeof(SavedElement))]
public class Door : MonoBehaviour, IDestroyable
{
    private MMF_Player unlockFeedback;
    
    private void Start()
    {
        unlockFeedback = GameObject.Find("UnlockFeedback").GetComponent<MMF_Player>();
    }
    private void Awake()
    {
        gameObject.tag = "Door";
        GetComponent<SavedElement>().type = SavedElement.Type.Terrain;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Key")) DestroyObject();
    }

    public void DestroyObject()
    {      
        // play animation
        unlockFeedback.PlayFeedbacks();
        
        // disable object
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
