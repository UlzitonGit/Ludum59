using UnityEngine;

public class AttackModule : Modul
{
    private GridData _points;
    [SerializeField] private GameObject _attack;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Modul _nextModulInCombo;
    private void OnEnable()
    {
        turnsToPrepare = 1;
        curentTurn = turnsToPrepare;
        _points = FindAnyObjectByType<GridData>();
    }

    public override bool Prepare()
    {
        curentTurn--;
        if (curentTurn == 0)
        {
            return true;
        }
        return false;
    }

    public override void Perform(Vector3 pos)
    {
        Transform currentPoint =_points._grid[Random.Range(0, _points._grid.Length - 1)];
        Vector3 curPosition = new Vector3(currentPoint.position.x, 1,currentPoint.position.z);
        Instantiate(_attack, curPosition, Quaternion.identity);
        Collider[] hitColliders = Physics.OverlapSphere(curPosition, _radius, _mask);
        if (hitColliders.Length > 0)
        {
            hitColliders[0].GetComponent<IDamagable>().GetDamage(damage);
        }
        curentTurn = turnsToPrepare;
        if (_nextModulInCombo != null)
        {
            _nextModulInCombo.Perform(curPosition);
        }
        curentTurn = turnsToPrepare;
    }

    public override void SetChildModule(Modul module)
    {
        _nextModulInCombo = module;
    }
}
