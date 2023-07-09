using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 1. when on the lava -> change sprite (floating) -> will not collide with other objects and walls
/// 2. when meet water -> destroy
/// </summary>
public class Rock : PushableObject, IDestroyable, ITransformable
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Enemy") ||
            other.gameObject.tag.Equals("Water"))
            DestroyObject();
        
        if (other.gameObject.tag.Equals("Lava")) TransformObject(other.collider);
        
        base.OnCollisionEnter2D(other);
    }

    // TODO: change sort order
    public void TransformObject(Collider2D other)
    {
        // change sprite
        GetComponent<SpriteRenderer>().color = Color.black;
        
        // disable the original terrain sprite and collider
        other.GetComponent<SpriteRenderer>().enabled = false;
        other.GetComponent<BoxCollider2D>().enabled = false;
        
        // change collider state
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DestroyObject()
    {      
        // play animation
        
        // disable object
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}