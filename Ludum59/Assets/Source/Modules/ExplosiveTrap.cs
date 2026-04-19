using UnityEngine;

public class ExplosiveTrap : MonoBehaviour
{
    [SerializeField] private GameObject _vfx;
    private Trap _trap;
    private string tag;
    private int damage;
    Vector3 direction;

    public void Init(string tag, int damage, Trap _trap)
    {
        this.tag = tag;
        this.damage = damage;
        this._trap = _trap;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            other.GetComponent<IDamagable>().GetDamage(damage);
            Instantiate(_vfx, this.transform.position, Quaternion.identity);
            _trap.PerformCombo(transform.position);
            Destroy(gameObject);
        }
    }
}