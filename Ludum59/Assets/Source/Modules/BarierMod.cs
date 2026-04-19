using UnityEngine;

public class BarierMod : Modul
{
    [SerializeField] private Barier _barierPrefab;
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
        Barier barier = Instantiate(_barierPrefab, pos, Quaternion.identity).GetComponent<Barier>();
        barier.Init(this);
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