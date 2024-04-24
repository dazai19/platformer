using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject gameUI;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            if (deathMenu != null) deathMenu.SetActive(true);
            if (gameUI != null) gameUI.SetActive(false);
        }
    }
}
