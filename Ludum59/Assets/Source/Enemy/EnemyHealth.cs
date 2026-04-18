using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private EnemyUI enemyUI;
    private bool _isDead;
    public void GetDamage(int damage)
    {
        health -= damage;
        enemyUI.UpdateUI(health);
        if (health <= 0 && !_isDead)
        {
            _isDead = true;
            FindAnyObjectByType<GeneralEnemyManager>().EnemyKilled();
            FindAnyObjectByType<TurnsController>().ActionsPerformed();
            Destroy(gameObject);
        }
    }
}
