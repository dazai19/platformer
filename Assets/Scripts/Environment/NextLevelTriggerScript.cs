using System;
using UnityEngine;

public class NextLevelTriggerScript : MonoBehaviour
{
    [SerializeField] GameObject menuNextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            menuNextLevel.SetActive(true);
        }
    }
}
