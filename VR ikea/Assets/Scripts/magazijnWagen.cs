using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazijnWagen : MonoBehaviour
{
    public Transform palletLocation;
    public bool checkOrder;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pallet")
        {
            other.transform.position = palletLocation.position;
            checkOrder = true;
        }
    }
}
