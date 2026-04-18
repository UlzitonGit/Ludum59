using UnityEngine;

public abstract class Modul : MonoBehaviour
{
    [SerializeField] protected int turnsToPrepare;
    protected int curentTurn;
    public abstract bool Prepare();

    public abstract void Perform(Vector3 pos);
}
