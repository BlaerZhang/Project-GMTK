using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class PushableObject : MonoBehaviour, IPushable
{
    private string lastPusher;

    public void Push(Vector3 dirt)
    {
        transform.DOMove(transform.position + dirt, 0.2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print(other.collider.name);
        // if the last pusher and the current pusher are different, the movement caused by the current pusher is not allowed
        if (DOTween.IsTweening(transform, true) & !other.collider.tag.Equals(lastPusher)) return;
        Push(CheckColliderLocation(other.collider));
        lastPusher = other.collider.tag;
    }

    private Vector3 CheckColliderLocation(Collider2D other)
    {
        Vector3 moveDirt = Vector3.zero;
        Vector3 relativeLoc = transform.position - other.transform.position;
        moveDirt = new Vector3(Mathf.RoundToInt(relativeLoc.x), Mathf.RoundToInt(relativeLoc.y));

        return moveDirt;
    }
}
