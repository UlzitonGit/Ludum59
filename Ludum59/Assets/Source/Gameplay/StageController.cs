using System;
using TMPro;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TurnsController turnsController;
    [SerializeField] private ModsUIController modsUIController;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GeneralEnemyManager enemyManager;
    [SerializeField] private int stageEnemyAdd;
    [SerializeField] private Transform player;
    [SerializeField] private TrashCleaner _trashCleaner;
    private Vector3 pos;
    private int stageCount = 0;
    public bool allEnemiesDead = false;

    private void Start()
    {
        pos = player.position;
        StartNewStage();
    }

    public void StartNewStage()
    {
        stageCount++;
        if (stageCount % stageEnemyAdd == 0)
        {
            enemyManager.SetEnemyCount(1);
        }
        player.position = pos;
        enemyManager.Initialize(this);
        modsUIController.SpawnRandomObjects();
        turnsController.CardsUsed = false;
        turnsController.PathDone = false;
        turnsController.TurnReadyCheck();
        playerManager.AddToTurns();
        _text.text = "STAGE " + stageCount.ToString();
        allEnemiesDead = false;
    }

    public void AllEnemiesDead()
    {
        allEnemiesDead = true;
    }

    public void CheckStageState()
    {
        print("Checking stage state");
        if (allEnemiesDead)
        {
            _trashCleaner.ClearTrash();
            turnsController.EndStage();
            print("started");
            StartNewStage();
            //turnsController.InitActionObjects();
        }
    }

   
}
