using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PushableObject, IDestroyable
{
    protected override void Init()
    {
        base.Init();
        gameObject.tag = "Key";
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Lava") ||
            other.gameObject.tag.Equals("Water") ||
            other.gameObject.tag.Equals("Door"))
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
