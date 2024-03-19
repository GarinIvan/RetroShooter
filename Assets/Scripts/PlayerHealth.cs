using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Image healthRectTransform;
    private float _maxHealth;
    public GameObject gameplayUI;
    public GameObject gameOverScreen;
    public Animator animator;
    private void Start()
    {
        _maxHealth = health;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    private void DrawHealthBar()
    {
        healthRectTransform.fillAmount = health/_maxHealth;
    }
    public void AddHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, _maxHealth);
        DrawHealthBar();
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<GrenageCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        gameOverScreen.GetComponent<Animator>().SetTrigger("Show");
        animator.SetTrigger("Death");
    }
}
