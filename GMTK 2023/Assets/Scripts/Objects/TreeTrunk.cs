using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 1. when both grids are on the water -> change sprite (floating) -> will not collide with other objects
/// 2. when on the water, near the land -> cannot be pushed towards the land
/// 3. when meet lava -> destroy
/// </summary>
public class TreeTrunk : PushableObject, IDestroyable, ITransformable
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 moveDirt = CheckColliderLocation(other.collider);
        
        // if the object is moving, all new movement to another direction should be avoided
        if (DOTween.IsTweening(transform, true) & lastMoveDirt != moveDirt) return;
        
        Push(moveDirt);
        lastMoveDirt = moveDirt;
    }
    
    // TODO: change sort order
    public void TransformObject(Collider2D other)
    {
        // change sprite
        
        // change collider state
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void DestroyObject()
    {      
        // play animation
        
        // disable object
        
        // game over interface: allow undo / restart
    }
}