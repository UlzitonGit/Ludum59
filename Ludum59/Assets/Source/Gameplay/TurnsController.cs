using System;
using TMPro;
using UnityEngine;

public class TurnsController : MonoBehaviour
{
    [SerializeField] private GameObject _turnButton;
    [SerializeField] private GeneralEnemyManager _enemyManager;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private MoveUIList _movesUI;
    [SerializeField] private TextMeshProUGUI _turnsText;
    private int allActionObjects;
    private int currentActionObjects;
    private int turnCount;

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
        for (int i = 0; i < 5; i++)
        {
            _movesUI.RemoveMove(0);
        }
        currentActionObjects = allActionObjects;
    }
}
