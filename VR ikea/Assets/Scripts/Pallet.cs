using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public List<GameObject> palletItems;

    public Transform[] bigItems;
    private bool hasToBeFilled; //zorgt ervoor dat 1 item niet alles in de pallet vult, een glitch
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemData>().size == "Medium")
        {
            hasToBeFilled = true;
            for (int i = 0; i < bigItems.Length; i++)
            {
                foreach (Transform child in bigItems[i])
                {
                    if (child.gameObject.GetComponent<PalletPosition>().isFull == false && hasToBeFilled)
                    {
                        other.transform.position = child.position;
                        palletItems.Add(other.gameObject);
                        child.gameObject.GetComponent<PalletPosition>().isFull = true;
                        bigItems[i].gameObject.GetComponent<PalletPosition>().isFull = true;
                        hasToBeFilled = false;
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
                if (bigItems[i].gameObject.GetComponent<PalletPosition>().isFull == false && hasToBeFilled)
                {
                    other.transform.position = bigItems[i].position;
                    palletItems.Add(other.gameObject);
                    bigItems[i].gameObject.GetComponent<PalletPosition>().isFull = true;
                    hasToBeFilled = false;
                }
            }
        }
    }
}
