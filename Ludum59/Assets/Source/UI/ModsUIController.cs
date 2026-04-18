using UnityEngine;
using System.Collections.Generic;

public class ModsUIController : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private TurnsController _turnsController;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private int cardsUsed;
  
    
    public void SpawnRandomObjects()
    {
        cardsUsed = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject randomPrefab = GetRandomObject();
            Transform spawnPoint = spawnPoints[i];
            SpawnObjectAtPoint(randomPrefab, spawnPoint);
        }
    }
 
    
    private GameObject GetRandomObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        return objectsToSpawn[randomIndex];
    }
    
    private void SpawnObjectAtPoint(GameObject prefab, Transform point)
    {
        if (prefab == null)
        {
            return;
        }
        
        Vector3 spawnPosition = new Vector3(0,0,0);
        
        
        GameObject spawnedObject = Instantiate(prefab, point);
        spawnedObject.transform.localPosition = spawnPosition;
        spawnedObjects.Add(spawnedObject);
 
    }
    public void AddUsedCards()
    {
        cardsUsed++;
        if (cardsUsed == 2)
        {
            ClearSpawnedObjects();
        }
    }
    
    public void ClearSpawnedObjects()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] != null)
            {
                Destroy(spawnedObjects[i]);
            }
        }
        spawnedObjects.Clear();
        _turnsController.CardsUsed = true;
        _turnsController.TurnReadyCheck();
    }
}