using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public List<GameObject> palletItems;

    public Transform[] bigItems;
    public Transform[] mediumItems;
    public Transform[] smallItems;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ItemData>().size == "Small")
        {
            for (int i = 0; i < smallItems.Length; i++)
            {
                if(smallItems[i] == null)
                {
                    other.transform.position = smallItems[i].position;
                    palletItems.Add(other.gameObject);
                }
            }
        }

        if (other.GetComponent<ItemData>().size == "Medium")
        {
            for (int i = 0; i < mediumItems.Length; i++)
            {
                if (mediumItems[i] == null)
                {
                    other.transform.position = mediumItems[i].position;
                    palletItems.Add(other.gameObject);
                }
            }
        }

        if (other.GetComponent<ItemData>().size == "Big")
        {
            print("hoi");
            for (int i = 0; i < bigItems.Length; i++)
            {
                if (bigItems[i] == null)
                {
                    other.transform.position = bigItems[i].position;
                    palletItems.Add(other.gameObject);
                }
            }
        }
    }
}
