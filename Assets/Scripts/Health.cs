using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Image healthImage;

    private void UpdateUI() => healthImage.fillAmount = health / maxHealth;

    private void Awake() => health = maxHealth;

    private void Start() => UpdateUI();

    public void DecreaseHealth(float damage)
    {
        if (health <= 0)
            return;

        health -= damage*Time.deltaTime;
        UpdateUI();
        if (health <= 0)
            Death();
    }

    public void DecreaseHealth(float damage, bool flag)
    {
        if (health <= 0)
            return;

        health -= damage;
        UpdateUI();
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
