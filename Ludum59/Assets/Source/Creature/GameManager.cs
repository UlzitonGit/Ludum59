using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _moveDelay;
    [SerializeField] private CreatureMovement _player;
    [SerializeField] private MoveUIList _moveList;
    
    private List<string> turns = new List<string>();

    public void Initialize(string direction)
    {
        if(turns.Count >= 5) return;
        turns.Add(direction);
        _moveList.AddMove(direction);
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
    }
}