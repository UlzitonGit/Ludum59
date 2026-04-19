using UnityEngine;

public class Slash : Modul
{
    [SerializeField] private SlashAttack _Slash;
    [SerializeField] private string tag;
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
        SlashAttack currentAttack = Instantiate(_Slash.gameObject, pos, Quaternion.identity).GetComponent<SlashAttack>();
        currentAttack.Initialize(damage, tag);
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