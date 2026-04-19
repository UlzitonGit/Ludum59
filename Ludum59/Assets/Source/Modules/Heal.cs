using UnityEngine;

public class Heal : Modul
{
    [SerializeField] private Modul _nextModulInCombo;
    private PlayerHealth playerHealth;
    private void OnEnable()
    {
        curentTurn = turnsToPrepare;
        playerHealth = FindAnyObjectByType<PlayerHealth>();
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
        playerHealth.Heal(damage);
        curentTurn = turnsToPrepare;
        PerformCombo(transform.position);
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
