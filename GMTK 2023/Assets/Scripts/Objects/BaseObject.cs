using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))][RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseObject : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        
        col.size = new Vector2(0.9f, 0.9f);
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
