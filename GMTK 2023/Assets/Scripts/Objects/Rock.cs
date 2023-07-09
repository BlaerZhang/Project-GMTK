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
        if (other.collider.tag.Equals("Water"))
        {
            DestroyObject();
            return;
        }
        
        Vector3 moveDirt = CheckColliderLocation(other.collider);
        
        // if the object is moving, all new movement to another direction should be avoided
        if (DOTween.IsTweening(transform, true) & lastMoveDirt != moveDirt) return;
        
        Push(moveDirt);
        lastMoveDirt = moveDirt;
        
        
    }

    public void TransformObject()
    {
        // change sprite
        
        // change collider state
        
    }

    public void DestroyObject()
    {      
        // play animation
        
        // disable object
        
    }
}