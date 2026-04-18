using System;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private TurnsController turnsController;
    [SerializeField] private ModsUIController modsUIController;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GeneralEnemyManager enemyManager;
    private Vector3 pos;

    private void Start()
    {
       StartNewStage();
       pos = playerManager.transform.position;
    }

    public void StartNewStage()
    {
        //playerManager.transform.position = pos;
        enemyManager.Initialize();
        modsUIController.SpawnRandomObjects();
        turnsController.CardsUsed = false;
        turnsController.PathDone = false;
        turnsController.TurnReadyCheck();
        playerManager.AddToTurns();
    }
}
