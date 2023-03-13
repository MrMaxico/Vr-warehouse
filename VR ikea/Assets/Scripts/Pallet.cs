using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public List<GameObject> palletItems;

    public Transform[] bigItems;
    private bool hasToBeFilled; //zorgt ervoor dat 1 item niet alles in de pallet vult, een glitch
    private int childCounter; //telt voor de grote dozen hoeveel kleine er zijn


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemData>().size == "Medium")
        {
            hasToBeFilled = true;
            for (int i = 0; i < bigItems.Length; i++)
            {
                foreach (Transform child in bigItems[i])
                {
                    if (child.gameObject.GetComponent<PalletPosition>().isFull == false && hasToBeFilled && bigItems[i].gameObject.GetComponent<PalletPosition>().isFull == false)
                    {
                        other.transform.position = child.position;
                        //other.transform.parent = transform;
                        //other.GetComponent<Rigidbody>().isKinematic = true;
                        other.GetComponent<ItemData>().palletLocation = child;
                        palletItems.Add(other.gameObject);
                        child.gameObject.GetComponent<PalletPosition>().isFull = true;
                        hasToBeFilled = false;
                        print("addMediumItem");
                    }
                }
            }
        }

        //als er een grote item op de pallet wordt gelegd
        if (other.GetComponent<ItemData>().size == "Big")
        {
            hasToBeFilled = true;
            for (int i = 0; i < bigItems.Length; i++)
            {
                childCounter = 0;
                foreach (Transform child in bigItems[i])
                {
                    if (child.gameObject.GetComponent<PalletPosition>().isFull == false)
                    {
                        childCounter++;
                        if (childCounter == 4 && bigItems[i].gameObject.GetComponent<PalletPosition>().isFull == false && hasToBeFilled)
                        {
                            other.transform.position = bigItems[i].position;
                            //other.transform.parent = transform;
                            //other.GetComponent<Rigidbody>().isKinematic = true;
                            other.GetComponent<ItemData>().palletLocation = bigItems[i];
                            palletItems.Add(other.gameObject);
                            bigItems[i].gameObject.GetComponent<PalletPosition>().isFull = true;
                            hasToBeFilled = false;
                            print("addBigItem");
                        }
                    }
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ItemData>().size == "Medium" && other.GetComponent<ItemData>().palletLocation.gameObject.GetComponent<PalletPosition>().isFull || other.GetComponent<ItemData>().size == "Big" && other.GetComponent<ItemData>().palletLocation.gameObject.GetComponent<PalletPosition>().isFull)
        {
            //print("removeItem");
            //other.transform.SetParent(null);
            //other.GetComponent<ItemData>().palletLocation.gameObject.GetComponent<PalletPosition>().isFull = false;
            //other.GetComponent<Rigidbody>().isKinematic = false;
            //other.transform.rotation = Quaternion.identity;
            //palletItems.Remove(other.gameObject);
        }
    }
}
