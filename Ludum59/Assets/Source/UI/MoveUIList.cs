using UnityEngine;

public class MoveUIList : MonoBehaviour
{
    [SerializeField] private Transform _grid;
    [SerializeField] private GameObject _moveLeft;
    [SerializeField] private GameObject _moveRight;
    [SerializeField] private GameObject _moveUp;
    [SerializeField] private GameObject _moveDown;
    [SerializeField] private GameObject _startButton;
    private int _moveCount;

    public void AddMove(string direction)
    {
        if(direction == "left") Instantiate(_moveLeft, _grid);
        if(direction == "right")  Instantiate(_moveRight, _grid);
        if(direction == "up")  Instantiate(_moveUp, _grid);
        if(direction == "down")  Instantiate(_moveDown, _grid);
        _moveCount++;
        if (_moveCount == 5)
        {
            _startButton.SetActive(true);
        }
    }
}
