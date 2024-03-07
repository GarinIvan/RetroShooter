using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public RectTransform healthRectTransform;
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
        healthRectTransform.anchorMax = new Vector2(health / _maxHealth, 1);
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        gameOverScreen.GetComponent<Animator>().SetTrigger("Show");
        animator.SetTrigger("Death");
    }
}
