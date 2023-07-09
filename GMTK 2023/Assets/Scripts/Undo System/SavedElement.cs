using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// undo type
/// player: position, active, (sprite)
/// enemy: position, active, (sprite)
/// rock: position, active, sprite
/// tree: position, active, sprite 
///
/// water: active
/// lava: active
/// </summary>
public class SavedElement : MonoBehaviour
{
    public enum Type { Terrain, Object, Level };
    public Type type;
}