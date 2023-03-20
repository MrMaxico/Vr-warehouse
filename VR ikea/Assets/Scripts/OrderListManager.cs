using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OrderListManager : MonoBehaviour
{
    public GameObject[] itemsOrder;
    public GameObject[] correctItems;
    public bool isCompleted;
    public GameObject warehouseManager;
    public int itemValue;
    public Text[] itemNames;
    public GameObject pallet;
    public GameObject magazijnWagen;
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemsOrder.Length; i++)
        {
            itemNames[i].text = itemsOrder[i].GetComponent<ItemData>().itemName; //kijkt in scriptableObject voor naam item
        }
    }
    void Update()
    {
        bool checkOrder = magazijnWagen.GetComponent<magazijnWagen>().checkOrder;
        if (checkOrder) //pallet in truck, moet (if.other.tag pallet) worden een trigger
        {
            itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).Any();
            correctItems = itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).ToArray<GameObject>();
            if (correctItems.Length == itemsOrder.Length && pallet.GetComponent<Pallet>().palletItems.Count == itemsOrder.Length)
            {
                print("allItemsCorrect");
                Instantiate(particle, magazijnWagen.GetComponent<magazijnWagen>().palletLocation.position, Quaternion.identity);
                //alle items zitten op de pallet en gaan in de bus
            }

            else
            {
                for (int i = 0; i < pallet.GetComponent<Pallet>().palletItems.Count; i++)
                {
                    itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).Any();

                    correctItems = itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).ToArray<GameObject>();

                    for (int g = 0; g < correctItems.Length; g++)
                    {
                        correctItems[g].GetComponent<Renderer>().material.color = Color.green;
                        magazijnWagen.GetComponent<magazijnWagen>().checkOrder = false;
                        // de correcte items worden groen maar de order is niet compleet
                    }
                }
            }
        }
    }

    //List.Remove(yourObject)
    
        
    
}
