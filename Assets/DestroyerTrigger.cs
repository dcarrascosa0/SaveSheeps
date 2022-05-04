using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string tagFilter;
    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("hay")) // 2
        {
            Destroy(other.gameObject); // 3
        }
    }
}
