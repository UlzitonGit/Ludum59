using System;
using GameAnalyticsSDK;
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
        OnLivesRefilled(currentHealth, currentHealth-damage, "damage");
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
        OnLivesRefilled(currentHealth - heal, currentHealth, "heal");
        currentHealth += heal;
        playerUI.UpdateUI(currentHealth);
    }
    public void OnLivesRefilled(int livesBefore, int livesAfter, string source)
    {
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, "lives", livesBefore - livesAfter, "lives_type", source);
        Debug.Log($"Жизни обновленны: {livesBefore} → {livesAfter}");
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
