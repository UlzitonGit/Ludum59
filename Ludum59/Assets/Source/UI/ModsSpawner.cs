using UnityEngine;
using System.Collections.Generic;

public class ModsSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private Transform[] spawnPoints;
    
    
    private void Start()
    {
        SpawnRandomObjects();
    }
    
    public void SpawnRandomObjects()
    {
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
 
    }
    
    public void ClearSpawnedObjects()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}