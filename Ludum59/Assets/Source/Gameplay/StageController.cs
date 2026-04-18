using System;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private TurnsController turnsController;
    [SerializeField] private ModsUIController modsUIController;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GeneralEnemyManager enemyManager;

    private void Start()
    {
       StartNewStage();
    }

    public void StartNewStage()
    {
        enemyManager.Initialize();
        modsUIController.SpawnRandomObjects();
        turnsController.CardsUsed = false;
        turnsController.PathDone = false;
        turnsController.TurnReadyCheck();
        playerManager.AddToTurns();
    }
}
