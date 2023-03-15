using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
  [SerializeField] private float health;
  [SerializeField] private float maxHealth;
  [SerializeField] private GameObject healthBarUI;
  [SerializeField] private Slider healthBar;
  [SerializeField] private GameObject deathMenu;
  

  private void Awake()
  {
    health = maxHealth;
    deathMenu.SetActive(false);
  }

  private void Update()
  {
    healthBar.value = CalculateHealth();
    if (health < maxHealth)
      healthBarUI.SetActive(true);
  }

  private float CalculateHealth()
  {
    return health / 100;
  }

  public void TakeDamage(float damage)
  {
    health -= damage;
    CheckIsAlive();
  }
  
  private void CheckIsAlive()
  {
    if (health <= 0)
    {
      if (gameObject.CompareTag("Player"))
      {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
      }
      Destroy(gameObject);
    }
  }
}
