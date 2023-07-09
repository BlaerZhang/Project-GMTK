using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[Serializable]
public class GameState
{
    #region dataToSave
    public List<bool> terrainsActiveness;
    
    public List<Sprite> objectSprites;
    public List<bool> objectsActiveness;
    public List<Vector3> objectPositions;
    
    public Vector3 levelPosition;
    #endregion

    public static GameState GetCurrentState()
    {
        GameState gameStateToSave = new GameState();
        SavedElement[] elementsToSaveOnScene = GameObject.FindObjectsOfType<SavedElement>();

        gameStateToSave.terrainsActiveness = new List<bool>();
        
        gameStateToSave.objectSprites = new List<Sprite>();
        gameStateToSave.objectsActiveness = new List<bool>();
        gameStateToSave.objectPositions = new List<Vector3>();

        foreach(SavedElement element in elementsToSaveOnScene)
        {
            Debug.Log(element.name + element.type);
            if(element.type == SavedElement.Type.Terrain)
            {
                gameStateToSave.terrainsActiveness.Add(element.isActiveAndEnabled);
            }
            else if(element.type == SavedElement.Type.Object)
            {
                gameStateToSave.objectSprites.Add(element.transform.GetComponent<SpriteRenderer>().sprite);
                gameStateToSave.objectsActiveness.Add(element.isActiveAndEnabled);
                gameStateToSave.objectPositions.Add(element.transform.position);
            }
            else if(element.type == SavedElement.Type.Level)
            {
                gameStateToSave.levelPosition = element.transform.position;
            }
        }
        return gameStateToSave;
    }
    
    public void LoadGameState()
    {
        SavedElement[] elementsToLoadOnscene = GameObject.FindObjectsOfType<SavedElement>();
        
        List<bool> remainingTerrainsActiveness =  new List<bool>(terrainsActiveness);
        
        List<Sprite> remainingObjectSprites =  new List<Sprite>(objectSprites);
        List<bool> remainingObjectsActiveness =  new List<bool>(objectsActiveness);
        List<Vector3> remainingObjectPosition =  new List<Vector3>(objectPositions);

        foreach(SavedElement elementToLoad in elementsToLoadOnscene)
        {
            if(elementToLoad.type == SavedElement.Type.Terrain)
            {
                elementToLoad.gameObject.SetActive(remainingTerrainsActiveness[0]);
                // elementToLoad.transform.position = playerPos;
                // elementToLoad.GetComponent<SpriteRenderer>().sprite = playerSprite;
                // elementToLoad.GetComponent<Player>().UndoSpriteIndex();
            }
            else if(elementToLoad.type == SavedElement.Type.Object)
            {
                elementToLoad.GetComponent<SpriteRenderer>().sprite = remainingObjectSprites[0];
                remainingObjectSprites.RemoveAt(0);
                
                elementToLoad.gameObject.SetActive(remainingObjectsActiveness[0]);
                remainingObjectsActiveness.RemoveAt(0);

                elementToLoad.transform.position = remainingObjectPosition[0];
                remainingObjectPosition.RemoveAt(0);
            }
            else if(elementToLoad.type == SavedElement.Type.Level)
            {
                elementToLoad.transform.position = levelPosition;
            }
            // TODO: add more cases: collider enable/disable, sprite switch 
        }
    }
}
