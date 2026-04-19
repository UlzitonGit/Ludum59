using System;
using System.Collections;
using UnityEngine;

public class ShiledZone : MonoBehaviour, IClearable
{
    [SerializeField] private int lifespan;
    private TurnsController controller;
    private void Start()
    {
        controller = FindAnyObjectByType<TurnsController>();
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
            lifespan--;
            if (lifespan == 0)
            {
                ClearTrash();
            }
        }
        StartCoroutine(ShieldLifeSpan());
    }
}
