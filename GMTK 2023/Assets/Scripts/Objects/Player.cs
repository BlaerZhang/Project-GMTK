using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PushableObject, IDestroyable
{
    protected override void Init()
    {
        base.Init();
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        base.OnCollisionEnter2D(other);
        // throw new NotImplementedException();
    }

    public void DestroyObject()
    {
        // play animation
        
        // disable object

        // game over interface: allow undo / restart
    }
}
