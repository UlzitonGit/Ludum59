using System;
using UnityEngine;

public class PolarAttack : Modul
{
    [SerializeField] private ParticleSystem _polar;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _mask;
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
        Collider[] hitColliders = Physics.OverlapSphere( pos, _radius, _mask);
        Instantiate(_polar, pos, Quaternion.Euler(new Vector3(90, 0, 0)));
        if (hitColliders.Length > 0)
        {
            hitColliders[0].GetComponent<IDamagable>().GetDamage(damage);
        }
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
