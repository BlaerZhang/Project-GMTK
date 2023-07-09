﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Water : BaseTerrain 
    {
        protected override void Init()
        {
            base.Init();
            gameObject.tag = "Water";
            
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            col.size = new Vector2(0.9f, 0.9f);
            
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }
}