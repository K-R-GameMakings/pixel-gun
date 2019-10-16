using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
    [SyncVar(hook ="OnChangeHealth")]public int currentHealth = maxHealth;
    public RectTransform healthBar;
    public RectTransform healthBarCam;
    public GameObject player;
    public void TakeDamage(int amount) {

        if (!isServer) {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Destroy(player.gameObject);
        }
           
    }
    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health * 2, healthBar.sizeDelta.y);
        healthBarCam.sizeDelta = new Vector2(health * 2, healthBarCam.sizeDelta.y);
    }
}
