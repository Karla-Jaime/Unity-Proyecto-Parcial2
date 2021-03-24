using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMineral : MonoBehaviour
{
    [SerializeField]
    Mineral mineral;

    public GameObject uiObject;

    
    
    void Start()
    {   
        uiObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Collider other = collision.collider;
        if (other.CompareTag("Player"))
        {
            Debug.Log("IIIIIIIIIIIIOOO");
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            Inventory.instance.Add(mineral);
            
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        uiObject.SetActive(true);
        yield return new WaitForSeconds(7);
        uiObject.SetActive(false);
        Destroy(gameObject);
    }
}