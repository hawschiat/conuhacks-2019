using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundry : MonoBehaviour {
    
    // Use this for initialization
    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        Destroy(other.gameObject);
    }
}
