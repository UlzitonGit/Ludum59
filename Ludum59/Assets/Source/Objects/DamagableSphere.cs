using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamagableSphere : MonoBehaviour
{
    [SerializeField] private int lifeSpan;
    [SerializeField] private TurnsController turnsController;
    [SerializeField] private GridData grid;
    private int currentSpan;
    public void Init()
    {
        TeleportOnRandomPosition();
        currentSpan = lifeSpan;
        StartCoroutine(ShieldLifeSpan());
    }

    private void TeleportOnRandomPosition()
    {
        Vector3 pos = grid._grid[Random.Range(0, grid._grid.Length - 1)].transform.position;
        transform.position = new Vector3(pos.x, transform.position.y, pos.z); ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && turnsController.GetTurnActive())
        {
            TeleportOnRandomPosition();
            EnemyHealth enemy = FindFirstObjectByType<EnemyHealth>();
            if(enemy !=null)
                enemy.GetDamage(2);
            
        }
    }
    IEnumerator ShieldLifeSpan()
    {
        yield return new WaitForSeconds(1);
        if (turnsController.GetTurnActive())
        {
            currentSpan--;
            if (currentSpan == 0)
            {
                TeleportOnRandomPosition();
                currentSpan = lifeSpan;
            }
        }
        StartCoroutine(ShieldLifeSpan());
    }
}
