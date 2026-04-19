using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElectroRail : MonoBehaviour, IClearable
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private int damage;
    [SerializeField] private int lifespan;
    private TurnsController controller;
    private Vector3 scaling;
    

    private void Start()
    {
        controller = FindAnyObjectByType<TurnsController>();
        ChooseScaling();
        StartCoroutine(ShieldLifeSpan());
        
    }

    public void ClearTrash()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    IEnumerator ShieldLifeSpan()
    {
        yield return new WaitForSeconds(1);
        if (controller.GetTurnActive())
        {
            _collider.size = _collider.size + scaling;
            var shape = _particleSystem.shape;
            shape.scale = shape.scale + scaling;
            lifespan--;
            if (lifespan == 0)
            {
                ClearTrash();
            }
        }
        StartCoroutine(ShieldLifeSpan());
    }

    private void ChooseScaling()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            scaling = new Vector3(2,0,0);
        }

        if (rand == 1)
        {
            scaling = new Vector3(0,0,2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamagable>().GetDamage(damage);
        }
    }
}
