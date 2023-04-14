using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public List<GameObject> palletItems;

    public Transform[] bigItems;
    private bool hasToBeFilled; //zorgt ervoor dat 1 item niet alles in de pallet vult, een glitch
    private int childCounter; //telt voor de grote dozen hoeveel kleine er zijn
    public Transform parentItems;
    public GameObject placeParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemData>().size == "Small")
        {
            hasToBeFilled = true;
            for (int i = 0; i < bigItems.Length; i++)
            {
                foreach (Transform child in bigItems[i])
                {
                    if (child.gameObject.GetComponent<PalletPosition>().isFull == false && hasToBeFilled && bigItems[i].gameObject.GetComponent<PalletPosition>().isFull == false)
                    {
                        other.transform.position = child.position;
                        Instantiate(placeParticle, transform.position, transform.rotation);
                        other.transform.parent = parentItems;
                        other.transform.rotation = child.rotation;
                        //other.GetComponent<Rigidbody>().freezeRotation = true;
                        //other.GetComponent<Rigidbody>().isKinematic = true;
                        other.GetComponent<ItemData>().palletLocation = child;
                        palletItems.Add(other.gameObject);
                        child.gameObject.GetComponent<PalletPosition>().isFull = true;
                        hasToBeFilled = false;
                        print("addMediumItem");
                        //other.GetComponent<Rigidbody>().isKinematic = true;
                        other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                    }
                }
            }
        }

        //als er een grote item op de pallet wordt gelegd
        if (other.GetComponent<ItemData>().size == "Medium")
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
                            other.transform.rotation = bigItems[i].rotation;
                            //other.GetComponent<Rigidbody>().freezeRotation = true;
                            other.transform.position = bigItems[i].position;
                            other.transform.parent = parentItems;
                            //other.GetComponent<Rigidbody>().isKinematic = true;
                            other.GetComponent<ItemData>().palletLocation = bigItems[i];
                            palletItems.Add(other.gameObject);
                            bigItems[i].gameObject.GetComponent<PalletPosition>().isFull = true;
                            hasToBeFilled = false;
                            print("addBigItem");
                            //other.GetComponent<Rigidbody>().isKinematic = true;
                            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

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
            print("removeItem");
            other.transform.SetParent(null);
            other.GetComponent<ItemData>().palletLocation.gameObject.GetComponent<PalletPosition>().isFull = false;
            //other.transform.rotation = Quaternion.identity;
            palletItems.Remove(other.gameObject);
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            other.GetComponent<Rigidbody>().freezeRotation = false;

        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < palletItems.Count; i++)
        {
            palletItems[i].GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
}
