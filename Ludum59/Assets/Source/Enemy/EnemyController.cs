using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CreatureMovement movement;
    [SerializeField] List<string> turns = new List<string>();
    [SerializeField] private float _moveDelay;
    [SerializeField] private int _moveCount;

    public void StartMovement()
    {
        StartCoroutine(MoveCharacterDelay());
    }
    IEnumerator MoveCharacterDelay()
    {
        for (int i = 0; i < _moveCount; i++)
        {
            yield return new WaitForSeconds(_moveDelay);
            movement.SetDirection(turns[Random.Range(0, turns.Count)]);
        }
    }
}
