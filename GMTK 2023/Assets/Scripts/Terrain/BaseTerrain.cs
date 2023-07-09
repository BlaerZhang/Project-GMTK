using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTerrain : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
}
