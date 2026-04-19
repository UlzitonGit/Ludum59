using UnityEngine;

public class Shield : Modul
{
    [SerializeField] private GameObject _shield;
    [SerializeField] private Modul _nextModulInCombo;

    private void Start()
    {
        curentTurn = turnsToPrepare;
 
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
        if(pos == Vector3.zero) pos = transform.position;
        Instantiate(_shield.gameObject, pos, Quaternion.identity);
        curentTurn = turnsToPrepare;
        if (_nextModulInCombo != null)
        {
            _nextModulInCombo.Perform(transform.position);
        }
        curentTurn = turnsToPrepare;
    }

    public override void SetChildModule(Modul module)
    {
        _nextModulInCombo = module;
    }
}
