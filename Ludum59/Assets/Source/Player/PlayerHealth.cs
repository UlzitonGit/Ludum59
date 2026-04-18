using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private PlayerUI playerUI;

    public void GetDamage(int damage)
    {
        health -= damage;
        playerUI.UpdateUI(health);
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
