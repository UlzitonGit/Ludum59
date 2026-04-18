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
    public int enemiesAlive = 0;
    private StageController stageController;

    public void Initialize(StageController _stageController)
    {
        enemies.Clear();
        enemiesAlive = 0;
        stageController = _stageController;
        enemies.Add(Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)], new Vector3(_gridData._grid[57].transform.position.x, 1.3f,_gridData._grid[57].transform.position.z), Quaternion.identity));
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].GetComponent<CreatureMovement>()._gridData = _gridData;
            playerTurns.InitActionObjects();
            enemiesAlive++;
        }
    }

    public void StartAction()
    {
        foreach (var enemy in enemies)
        {
            enemy.StartMovement(playerTurns);
        }
    }

    public void EnemyKilled()
    {
        enemiesAlive--;
        if (enemiesAlive == 0)
        {
            stageController.AllEnemiesDead();
        }
    }
}
