using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamagableSphere : MonoBehaviour
{
    [SerializeField] private TurnsController turnsController;
    [SerializeField] private GridData grid;
    public void Init()
    {
        TeleportOnRandomPosition();
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
            EnemyHealth[] enemy = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);
            foreach (var enemyController in enemy)
            {
                enemyController.GetDamage(2);
            }
        }
    }
}
