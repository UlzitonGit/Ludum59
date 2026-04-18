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
        turnsToPrepare = 8;
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
        _polar.Play();
        print("Attack");
        Collider[] hitColliders = Physics.OverlapSphere( transform.position, _radius, _mask);
        curentTurn = turnsToPrepare;
        if (_nextModulInCombo != null)
        {
            _nextModulInCombo.Perform(transform.position);
        }
        curentTurn = turnsToPrepare;
    }
}
