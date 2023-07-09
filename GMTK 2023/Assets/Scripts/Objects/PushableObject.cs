using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PushableObject : BaseObject, IPushable
{
    protected Vector3 lastMoveDirt = Vector3.zero;
    
    public void Push(Vector3 dirt)
    {
        transform.DOMove(transform.position + dirt, 0.2f);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        // print(other.collider.name);
        Vector3 moveDirt = CheckColliderLocation(other.collider);
        
        // if the object is moving, all new movement to another direction should be avoided
        if (DOTween.IsTweening(transform, true) & lastMoveDirt != moveDirt) return;
        
        Push(moveDirt);
        lastMoveDirt = moveDirt;
    }

    protected Vector3 CheckColliderLocation(Collider2D other)
    {
        Vector3 moveDirt = Vector3.zero;
        Vector3 relativeLoc = transform.position - other.transform.position;
        moveDirt = new Vector3(Mathf.RoundToInt(relativeLoc.x), Mathf.RoundToInt(relativeLoc.y));
        
        return moveDirt;
    }
}
