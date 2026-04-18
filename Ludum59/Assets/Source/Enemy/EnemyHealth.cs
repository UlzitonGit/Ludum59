using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private EnemyUI enemyUI;

    public void GetDamage(int damage)
    {
        health -= damage;
        enemyUI.UpdateUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
