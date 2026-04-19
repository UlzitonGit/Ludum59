using System;
using UnityEngine;

internal class Trail : MonoBehaviour, IClearable
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamagable>().GetDamage(damage);
        }
    }

    public void ClearTrash()
    {
        Destroy(gameObject);
    }
}
