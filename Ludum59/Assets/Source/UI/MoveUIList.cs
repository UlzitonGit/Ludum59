using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveUIList : MonoBehaviour
{
    [SerializeField] private Transform _grid;
    [SerializeField] private GameObject _moveLeft;
    [SerializeField] private GameObject _moveRight;
    [SerializeField] private GameObject _moveUp;
    [SerializeField] private GameObject _moveDown;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private PlayerManager _playerManager;
    
    
    [SerializeField]  private List<GameObject> _movesUI = new List<GameObject>();
    private int _moveCount;
    MovesData _moves;

    private void Awake()
    {
        _moves = new MovesData();
    }

    public void AddMove(string direction)
    {
        if(direction == _moves.left) _movesUI.Add(Instantiate(_moveLeft, _grid)); 
        if(direction == _moves.right)  _movesUI.Add(Instantiate(_moveRight, _grid)); 
        if(direction == _moves.up)  _movesUI.Add(Instantiate(_moveUp, _grid)); 
        if(direction == _moves.down)  _movesUI.Add(Instantiate(_moveDown, _grid)); 
        _movesUI[_moveCount].GetComponent<MoveButton>().Init(_moveCount, this, _playerManager);
        _moveCount++;
        if (_moveCount == 5)
        {
            _startButton.SetActive(true);
        }
    }

    public void RemoveMove(int index)
    {
        print(index);
        GameObject toDestroy = _movesUI[index];
        _movesUI.RemoveAt(index);
        Destroy(toDestroy);
        _playerManager.RemoveMove(index);
        _moveCount--;
        _startButton.SetActive(false);
        if(_moveCount == 0) return;
        for (int i = 0; i != _moveCount; i++)
        {
            _movesUI[i].GetComponent<MoveButton>().ChangeIndex(i);
        }
    }
}
