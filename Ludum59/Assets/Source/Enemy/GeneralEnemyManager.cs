using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneralEnemyManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private EnemyController[] enemiesPrefabs;
    [SerializeField] private TurnsController playerTurns;
    private List<EnemyController> enemies = new List<EnemyController>();

    public void Initialize()
    {
        enemies.Add(Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)], _gridData._grid[57].transform.position, Quaternion.identity));
        for (int i = 0; i < enemies.Count; i++)
        {
            playerTurns.InitActionObjects();
        }
    }

    public void StartAction()
    {
        foreach (var enemy in enemies)
        {
            enemy.StartMovement(playerTurns);
        }
    }
}
