using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnsController : MonoBehaviour
{
    [SerializeField] private GameObject _turnButton;
    [SerializeField] private GeneralEnemyManager _enemyManager;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private MoveUIList _movesUI;
    [SerializeField] private TextMeshProUGUI _turnsText;
    [SerializeField] private StageController _stage;
    public bool PathDone;
    public bool CardsUsed;
    private int allActionObjects;
    public int currentActionObjects;
    private int turnCount;


    public void TurnReadyCheck()
    {
        if (PathDone && CardsUsed)
        {
            _turnButton.SetActive(true);
        }
        else
        {
            _turnButton.SetActive(false);
        }
    }
    public void InitActionObjects()
    {
        allActionObjects++;
        currentActionObjects = allActionObjects;
    }

    public void StartTurn()
    {
        _turnButton.SetActive(false);
        _enemyManager.StartAction();
        _playerManager.Move();
        turnCount++;
        _turnsText.text = "TURN " + turnCount.ToString();
    }

    public void ActionsPerformed()
    {
        currentActionObjects--;
        if (currentActionObjects == 0)
        {
            EndTurn();
        }
    }

    private void EndTurn()
    {
        StartCoroutine(TurnEnd());
    }

    IEnumerator TurnEnd()
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            _movesUI.RemoveMove(0);
        }
        currentActionObjects = allActionObjects;
        _stage.CheckStageState();
    }
    public void EndStage()
    {
        turnCount = 1;
        _turnsText.text = "TURN " + turnCount.ToString();
        allActionObjects = 0;
    }
}
