using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public List<GameObject> palletItems;

    public Transform[] bigItems;
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<ItemData>().size == "Medium")
        {
            for (int i = 0; i < bigItems.Length; i++)
            {
                if (bigItems[i].gameObject.GetComponent<PalletPosition>().isFull == false)
                {
                    foreach(Transform child in bigItems[i])
                    {
                        if(child.gameObject.GetComponent<PalletPosition>().isFull == false)
                        {
                            other.transform.position = child.position;
                            palletItems.Add(other.gameObject);
                            child.gameObject.GetComponent<PalletPosition>().isFull = true;
                            bigItems[i].gameObject.GetComponent<PalletPosition>().isFull = true;
                        }
                    }
                }

            }
        }

        if (other.GetComponent<ItemData>().size == "Big")
        {
            for (int i = 0; i < bigItems.Length; i++)
            {
                if (bigItems[i].gameObject.GetComponent<PalletPosition>().isFull == false)
                {
                    other.transform.position = bigItems[i].position;
                    palletItems.Add(other.gameObject);
                    bigItems[i].gameObject.GetComponent<PalletPosition>().isFull = true;
                }
            }
                
       
        }
    }
}
