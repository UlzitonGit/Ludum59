using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneralEnemyManager : MonoBehaviour
{
    [SerializeField] private GridData _gridData;
    [SerializeField] private EnemyController[] enemiesPrefabs;
    [SerializeField] private TurnsController playerTurns;
    [SerializeField] private int enemiesCount;
    private List<EnemyController> enemies = new List<EnemyController>();
    public int enemiesAlive = 0;
    private StageController stageController;

    public void Initialize(StageController _stageController)
    {
        enemies.Clear();
        enemiesAlive = 0;
        for (int i = 0; i < enemiesCount; i++)
        {
            int randomPoint = Random.Range(0, _gridData._grid.Length - 1);
            enemies.Add(Instantiate(enemiesPrefabs[Random.Range(0, enemiesPrefabs.Length)], new Vector3(_gridData._grid[randomPoint].transform.position.x, 1.3f,_gridData._grid[randomPoint].transform.position.z), Quaternion.identity));
        }
        stageController = _stageController;
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
        playerTurns.SetAllActionObjects(-1);
        if (enemiesAlive == 0)
        {
            stageController.AllEnemiesDead();
            foreach (var enemy in enemies)
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    public void SetEnemyCount(int count)
    {
        enemiesCount += count;
    }
}
