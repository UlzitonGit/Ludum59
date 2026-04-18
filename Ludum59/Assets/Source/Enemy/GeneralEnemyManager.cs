using System;
using UnityEngine;

public class GeneralEnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyController[] enemies;
    [SerializeField] private TurnsController playerTurns;

    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
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
