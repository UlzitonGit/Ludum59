using UnityEngine;

public abstract class Modul : MonoBehaviour
{
    [SerializeField] protected int turnsToPrepare;
    [SerializeField] protected int damage;
    protected int curentTurn;
    public abstract bool Prepare();

    public abstract void Perform(Vector3 pos);

    public abstract void SetChildModule(Modul module);
}
