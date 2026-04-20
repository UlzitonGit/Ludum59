using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int health;
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private GameObject deathBG;
    private bool isDefend;
    private int currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    public void GetDamage(int damage)
    {
        if (isDefend) damage = damage / 3;
        currentHealth -= damage;
        playerUI.UpdateUI(currentHealth);
        if (currentHealth <= 0)
        {
            deathBG.SetActive(true);
        }
    }

    public void Heal(int heal)
    {
        if(currentHealth + heal > health) return;
        currentHealth += heal;
        playerUI.UpdateUI(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            isDefend = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            isDefend = false;
        }
    }
}
