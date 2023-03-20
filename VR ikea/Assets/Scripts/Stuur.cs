using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuur : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("playerLeftHand"))
        {
            print("wauw");
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
