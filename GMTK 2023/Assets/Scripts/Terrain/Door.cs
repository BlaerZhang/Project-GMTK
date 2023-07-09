using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] [RequireComponent(typeof(SavedElement))]
public class Door : MonoBehaviour, IDestroyable
{
    private void Awake()
    {
        gameObject.tag = "Door";
        GetComponent<SavedElement>().type = SavedElement.Type.Terrain;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Key")) DestroyObject();
    }

    public void DestroyObject()
    {      
        // play animation
        
        // disable object
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
