using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PushableObject, IDestroyable
{
    protected override void Init()
    {
        base.Init();
        GetComponent<SpriteRenderer>().sortingOrder = 2;
        gameObject.tag = "Enemy";
    }
    
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Weapon") ||
            other.gameObject.tag.Equals("Water") ||
            other.gameObject.tag.Equals("Lava")) DestroyObject();

        base.OnCollisionEnter2D(other);
    }
    
    public void DestroyObject()
    {
        // play animation
        
        // destroy object
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}