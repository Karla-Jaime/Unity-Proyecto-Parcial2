using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMineral : MonoBehaviour
{
    [SerializeField]
    Mineral mineral;    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            mineral.Pickup(player);
            Destroy(gameObject);

            //player.HealPlayer();
        }
    }
}