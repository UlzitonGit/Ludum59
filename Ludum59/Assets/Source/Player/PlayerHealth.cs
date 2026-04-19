using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private PlayerUI playerUI;
    private int currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        playerUI.UpdateUI(currentHealth);
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Heal(int heal)
    {
        if(currentHealth + heal > health) return;
        currentHealth += heal;
        playerUI.UpdateUI(currentHealth);
    }
}
