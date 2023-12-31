using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Player : PushableObject, IDestroyable
{
    private MMF_Player dieFeedback;
    
    private void Start()
    {
        dieFeedback = GameObject.Find("DieFeedback").GetComponent<MMF_Player>();
    }
    
    protected override void Init()
    {
        base.Init();
        GetComponent<SpriteRenderer>().sortingOrder = 2;
        gameObject.tag = "Player";
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") ||
            other.gameObject.tag.Equals("Water") ||
            other.gameObject.tag.Equals("Lava"))
            DestroyObject();

        base.OnCollisionEnter2D(other);
    }

    public void DestroyObject()
    {
        // play animation
        dieFeedback.PlayFeedbacks();
        
        // disable object
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        // pause

        // game over interface: allow undo / restart
    }
}
