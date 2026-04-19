using System.Collections;
using UnityEngine;

public class CreatureMovement : MonoBehaviour
{
    [SerializeField] public GridData _gridData;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _checkPos;
    [SerializeField] private Transform _shipTransform;
    [SerializeField] private float _moveDuration = 0.2f;
    private string lastMove;
    private bool _isMoving = false;
    private float _startY;
    MovesData _moves;

    private void Awake()
    {
        _moves = new MovesData();
    }

    public void SetDirection(string direction)
    {
        if(direction == _moves.left) TryMove(new Vector3(-_gridData._cellSize, 0, 0));
        if(direction == _moves.right)  TryMove(new Vector3(_gridData._cellSize, 0, 0));
        if(direction == _moves.up)  TryMove(new Vector3(0, 0, _gridData._cellSize));
        if(direction == _moves.down)  TryMove(new Vector3(0, 0, -_gridData._cellSize));
        RotateShip(direction);
        lastMove = direction;
    }
    private void Start()
    {
        _startY = transform.position.y;
    }
    private void TryMove(Vector3 direction)
    {
        Ray ray = new Ray(_checkPos.position, direction);
        RaycastHit hit;
        
        float rayDistance = _gridData._cellSize;
        
        if (Physics.Raycast(ray, out hit, rayDistance, _layerMask))
        {
            if (hit.collider.CompareTag("Cell"))
            {
                Vector3 targetPos = hit.collider.transform.position;
                targetPos.y = _startY;
                if(!_isMoving)
                    StartCoroutine(SmoothMove(targetPos));
            }
        }
    }
    private IEnumerator SmoothMove(Vector3 target)
    {
        _isMoving = true;
        Vector3 start = transform.position;
        float elapsed = 0f;
        
        while (elapsed < _moveDuration)
        {
            float t = elapsed / _moveDuration;
            transform.position = Vector3.Lerp(start, target, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.position = target;
        _isMoving = false;
    }

    private void RotateShip(string direction)
    {
        if(direction == _moves.left) _shipTransform.rotation = Quaternion.Euler(0, 180, 0);
        if(direction == _moves.right)  _shipTransform.rotation = Quaternion.Euler(0, 0, 0);
        if(direction == _moves.up)  _shipTransform.rotation = Quaternion.Euler(0, -90, 0);
        if(direction == _moves.down) _shipTransform.rotation = Quaternion.Euler(0, 90, 0);
    }

    public string GetLastMove()
    {
        return lastMove;
    }
}