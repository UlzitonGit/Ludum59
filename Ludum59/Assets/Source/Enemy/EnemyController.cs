using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CreatureMovement movement;
    [SerializeField] List<string> turns = new List<string>();
    [SerializeField] private float _moveDelay;
    [SerializeField] private int _moveCount;
    [SerializeField] private EnemyAttackController enemyAttack;
    private TurnsController _turnController;
    public void StartMovement(TurnsController turnController)
    {
        StartCoroutine(MoveCharacterDelay());
        this._turnController = turnController;
    }
    IEnumerator MoveCharacterDelay()
    {
        for (int i = 0; i < _moveCount; i++)
        {
            yield return new WaitForSeconds(_moveDelay);
            movement.SetDirection(turns[Random.Range(0, turns.Count)]);
            enemyAttack.ReloadModule();
        }
        _turnController.ActionsPerformed();
    }
}
