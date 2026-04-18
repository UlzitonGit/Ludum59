using UnityEngine;

public class GeneralEnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyController[] enemies;

    public void StartAction()
    {
        foreach (var enemy in enemies)
        {
            enemy.StartMovement();
        }
    }
}
