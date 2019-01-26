using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    // Use this for initialization
   void OnTriggerExit(Collider other)
    {
        if (other.tag != "Boundry")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
