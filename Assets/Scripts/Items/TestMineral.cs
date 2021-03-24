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
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            Inventory.instance.Add(mineral);
            Destroy(gameObject);
        
            mineral.Analyze(player);
        }
    }
}