using UnityEngine;

public class ToxicTrail : Modul
{
    [SerializeField] private GameObject _trailPrefab;
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
        Instantiate(_trailPrefab.gameObject, transform.position, Quaternion.identity);
        curentTurn = turnsToPrepare;
    }

    public override void SetChildModule(Modul module)
    {
        _nextModulInCombo = module;
    }
}
