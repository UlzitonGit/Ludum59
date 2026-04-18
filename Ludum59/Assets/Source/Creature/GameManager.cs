using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float _moveDelay;
    [SerializeField] private CreatureMovement _player;
    [SerializeField] private MoveUIList _moveList;
    [SerializeField] private TurnsController _turnsController;
    private List<string> turns = new List<string>();

    private void Start()
    {
        _turnsController.InitActionObjects();
    }

    public void Initialize(string direction)
    {
        if(turns.Count >= 5) return;
        turns.Add(direction);
        _moveList.AddMove(direction);
    }

    public void RemoveMove(int index)
    {
        turns.RemoveAt(index);
    }

    public void Move()
    {
        if(turns.Count == 5)
            StartCoroutine(MoveCharacterDelay());
    }

    IEnumerator MoveCharacterDelay()
    {
        foreach (var turn in turns)
        {
            yield return new WaitForSeconds(_moveDelay);
            _player.SetDirection(turn);
        }
        _turnsController.ActionsPerformed();
    }
}