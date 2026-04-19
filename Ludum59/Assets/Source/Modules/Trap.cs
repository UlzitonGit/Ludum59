using UnityEngine;

public class Trap : Modul
{
    [SerializeField] private GameObject _attack;
    [SerializeField] private string tag;
    [SerializeField] private Modul _nextModulInCombo;
    private void OnEnable()
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
        ExplosiveTrap trap = Instantiate(_attack, pos, Quaternion.identity).GetComponent<ExplosiveTrap>();
        trap.Init(tag, damage, this);
        curentTurn = turnsToPrepare;
    }

    public void PerformCombo(Vector3 pos)
    {
        if (_nextModulInCombo != null)
        {
            _nextModulInCombo.Perform(pos);
        }
    }

    public override void SetChildModule(Modul module)
    {
        _nextModulInCombo = module;
    }
}