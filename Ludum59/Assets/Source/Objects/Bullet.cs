using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpeedFire _speedFire;
    private string tag;
    private int damage;
    Vector3 direction;

    public void Init(string tag, int damage, SpeedFire speedFire)
    {
        this.tag = tag;
        this.damage = damage;
        this._speedFire = speedFire;
        ChooseRandomDirection();
    }

    private void ChooseRandomDirection()
    {
        int dir = UnityEngine.Random.Range(0, 2);
        if(dir == 0) direction = Vector3.right;
        else if(dir == 1) direction = Vector3.left;
    }

    private void Update()
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            other.GetComponent<IDamagable>().GetDamage(damage);
            _speedFire.PerformCombo(transform.position);
            Destroy(gameObject);
        }

        if (other.CompareTag("Obstacles"))
        {
            _speedFire.PerformCombo(transform.position);
            Destroy(gameObject);
        }
    }
}
