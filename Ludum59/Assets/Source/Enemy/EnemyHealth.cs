using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private EnemyUI enemyUI;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private GameObject deathVFX;
    private bool _isDead;
    public void GetDamage(int damage)
    {
        health -= damage;
        enemyUI.UpdateUI(health);
        if (health <= 0 && !_isDead)
        {
            _isDead = true;
            enemyController.StopAllCoroutines();
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            enemyController.enabled = false;
            FindAnyObjectByType<GeneralEnemyManager>().EnemyKilled();
            FindAnyObjectByType<TurnsController>().ActionsPerformed();
            gameObject.SetActive(false);
        }
    }
}
