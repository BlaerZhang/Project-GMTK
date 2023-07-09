using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPushable
{
    void Push(Vector3 dirt);
}

public interface IDestroyable
{
    void DestroyObject();
}

public interface ITransformable
{
    void TransformObject();
}
