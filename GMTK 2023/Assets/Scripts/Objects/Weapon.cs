using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PushableObject, IDestroyable
{
    protected override void Init()
    {
        base.Init();
        gameObject.tag = "Weapon";
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Lava") ||
            other.gameObject.tag.Equals("Water"))
            DestroyObject();
        
        base.OnCollisionEnter2D(other);
    }

    public void DestroyObject()
    {      
        // play animation
        
        // disable object
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
