using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SignatureExplosion : MonoBehaviour, IClearable
{
    [SerializeField] private int lifespan;
    [SerializeField] private int damage;
    [SerializeField] private int _radius;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private GameObject _polar;
    private Vector3 pos;
    private TurnsController controller;
    private GridData grid;

    private void Start()
    {
        controller = FindAnyObjectByType<TurnsController>();
        grid = FindObjectOfType<GridData>();
        
        pos = grid._grid[Random.Range(0, grid._grid.Length - 1)].transform.position;
        transform.position = pos;
        StartCoroutine(ShieldLifeSpan());
    }

    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere( pos, _radius, _mask);
        Instantiate(_polar, pos, Quaternion.Euler(new Vector3(90, 0, 0)));
        if (hitColliders.Length > 0)
        {
            hitColliders[0].GetComponent<IDamagable>().GetDamage(damage);
        }
        Destroy(gameObject);
    }
    IEnumerator ShieldLifeSpan()
    {
        yield return new WaitForSeconds(1);
        if (controller.GetTurnActive())
        {
            lifespan--;
            if (lifespan == 0)
            {
                Explode();
            }
        }
        StartCoroutine(ShieldLifeSpan());
    }

    public void ClearTrash()
    {
        Destroy(gameObject);
    }
}
