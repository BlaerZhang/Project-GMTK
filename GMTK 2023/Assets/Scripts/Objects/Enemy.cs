using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PushableObject, IDestroyable
{
    protected override void Init()
    {
        base.Init();
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        
    }
    
    public void DestroyObject()
    {
        // check if the other collider is other enemy
        
        // play animation
        
        // destroy object
    }
}