using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public List<GameObject> palletItems;

    public Transform[] bigItems;
    public Transform[] mediumItems;
    public Transform[] smallItems;

    private int bigItemCounter;
    private int mediumItemCounter;
    private int smallItemCounter;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ItemData>().size == "Small")
        {
            if(smallItemCounter < smallItems.Length)
            {
                other.transform.position = smallItems[smallItemCounter].position;
                smallItemCounter++;
                palletItems.Add(other.gameObject);
            }
        }

        if (other.GetComponent<ItemData>().size == "Medium")
        {
            print("nee");
            if (mediumItemCounter < mediumItems.Length)
            {
                print("ja");
                other.transform.position = mediumItems[mediumItemCounter].position;
                mediumItemCounter++;
                palletItems.Add(other.gameObject);
            } 
            
        }

        if (other.GetComponent<ItemData>().size == "Big")
        {
            if (bigItemCounter < bigItems.Length)
            {
                other.transform.position = bigItems[bigItemCounter].position;
                bigItemCounter++;
                palletItems.Add(other.gameObject);
            }
                
            
        }
    }
}
