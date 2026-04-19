using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour, IClearable
{
    [SerializeField] private int damage;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask layer;
    [SerializeField] private LayerMask enemyLayerMask;
    private TurnsController controller;
    public Transform nextBarier;
    private bool barierFound;
    private BarierMod _barierMod;
    private bool canShock = true;

    public void Init(BarierMod barierMod)
    {
        _barierMod = barierMod;
        lineRenderer.gameObject.SetActive(false);
        controller = FindAnyObjectByType<TurnsController>();
        CheckNearestBarier();
    }

    private void FixedUpdate()
    {
        if(!barierFound || !canShock || !controller.GetTurnActive()) return;
        Vector3 direction = nextBarier.position - transform.position;
        float distance = direction.magnitude;
        
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, direction.normalized, out hit, distance, enemyLayerMask))
        {
            if (hit.transform.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.GetDamage(damage);
                _barierMod.PerformCombo(hit.transform.position);
                StartCoroutine(Reload());
            }
        }
    }

    private void CheckNearestBarier()
    {
        List<Vector3> poses = new List<Vector3>();
        Collider[] bariers = Physics.OverlapSphere(transform.position, 25f, layer);
        print(bariers.Length);
        float minDistance = 100;
        int index = 0;
        bool localbarierFound = false;
        for (int i = 0; i < bariers.Length; i++)
        {
            if (Vector3.Distance(transform.position, bariers[i].transform.position) < minDistance && Vector3.Distance(transform.position, bariers[i].transform.position) > 1)
            {
                index = i;
                minDistance = Vector3.Distance(transform.position, bariers[i].transform.position);
                localbarierFound = true;
            }
        }

        if (localbarierFound)
        {
            lineRenderer.transform.parent = null;
            lineRenderer.transform.localScale = new Vector3(1, 1, 1);
            lineRenderer.transform.position = new Vector3(0, 0, 0);
            nextBarier = bariers[index].transform;
            barierFound = true;
            poses.Add(nextBarier.position);
            poses.Add(transform.position);
            lineRenderer.SetPositions(poses.ToArray());
            lineRenderer.gameObject.SetActive(true);
        }
    }

    IEnumerator Reload()
    {
        canShock = false;
        yield return new WaitForSeconds(1f);
        canShock = true;
    }

    public void ClearTrash()
    {
        Destroy(lineRenderer.gameObject);
        Destroy(gameObject);
    }
}
