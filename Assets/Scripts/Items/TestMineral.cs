using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMineral : MonoBehaviour
{
    [SerializeField]
    Mineral mineral;    

    private void OnCollisionEnter(Collision collision) 
    {
        Collider other = collision.collider;
        if (other.CompareTag("Player"))
        {
            Debug.Log("IIIIIIIIIIIIOOO");
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            mineral.Analyze(player);
            Destroy(gameObject);

            //player.HealPlayer();
        }
    }
}