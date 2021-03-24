using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showInfo : MonoBehaviour
{   
    public GameObject uiObject;
    

    void Start()
    {   
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider collision)
    {
        Collider other = collision.GetComponent<Collider>();
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            uiObject.SetActive(true);
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
    }
}
