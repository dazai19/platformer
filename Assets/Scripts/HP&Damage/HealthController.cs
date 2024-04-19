using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private GameObject healthBarUI;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject heal;


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
            else
            {
                Destroy(gameObject, .1f);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player") && collision.CompareTag("Heal") && health != maxHealth)
        {
            health += 20;
            if (health > maxHealth) health = maxHealth;
            Destroy(collision.gameObject);
        }
    }
}
