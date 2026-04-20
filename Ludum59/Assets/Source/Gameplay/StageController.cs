using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TurnsController turnsController;
    [SerializeField] private ChipSpawnController modsUIController;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GeneralEnemyManager enemyManager;
    [SerializeField] private int stageEnemyAdd;
    [SerializeField] private Transform player;
    [SerializeField] private TrashCleaner _trashCleaner;
    [SerializeField] private Animator animator;
    [SerializeField] private DamagableSphere damagableSphere;
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
        damagableSphere.Init();
        if (stageCount % stageEnemyAdd == 0)
        {
            enemyManager.SetEnemyCount(1);
        }
        player.position = pos;
        enemyManager.Initialize(this);
        modsUIController.Spawn();
        turnsController.CardsUsed = false;
        turnsController.PathDone = false;
        turnsController.TurnReadyCheck();
        playerManager.AddToTurns();
        _text.text = "STAGE " + stageCount.ToString();
        allEnemiesDead = false;
        if (stageCount > 3)
        {
            StartCoroutine(End());
        }
    }

    public void AllEnemiesDead()
    {
        allEnemiesDead = true;
    }

    IEnumerator End()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
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
