using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;

public class OrderListManager : MonoBehaviour
{
    public List<GameObject> itemsOrder;
    public List<GameObject> correctItems;
    public bool isCompleted;
    public GameObject warehouseManager;
    public int itemValue;
    public Text[] itemNames;
    public GameObject pallet;
    public GameObject magazijnWagen;
    public GameObject particle;
    public GameObject orders;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < itemsOrder.Count; i++) {
            orders.transform.GetChild(i).GetChild(2).GetComponent<TMP_Text>().text = itemsOrder[i].GetComponent<ItemData>().itemName;
            Debug.Log(itemsOrder[i].name);
            orders.transform.GetChild(i).GetChild(3).GetComponent<TMP_Text>().text = itemsOrder[i].GetComponent<ItemData>().itemLocation;
        }
        //for (int i = 0; i < itemsOrder.Length; i++)
        //{
            //itemNames[i].text = itemsOrder[i].GetComponent<ItemData>().itemName; //kijkt in scriptableObject voor naam item
        //}
    }
    void Update()
    {
        bool checkOrder = magazijnWagen.GetComponent<magazijnWagen>().checkOrder;
        if (checkOrder) //pallet in truck, moet (if.other.tag pallet) worden een trigger
        {
            itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).Any();
            correctItems = itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).ToList<GameObject>();
            if (correctItems.Count == itemsOrder.Count && pallet.GetComponent<Pallet>().palletItems.Count == itemsOrder.Count)
            {
                print("allItemsCorrect");
                GameObject particlePrefab = Instantiate(particle, magazijnWagen.GetComponent<magazijnWagen>().palletLocation.position, Quaternion.identity);
                Destroy(particlePrefab, 1);
                //alle items zitten op de pallet en gaan in de bus
            }

            else
            {
                for (int i = 0; i < pallet.GetComponent<Pallet>().palletItems.Count; i++)
                {
                    itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).Any();

                    correctItems = itemsOrder.Intersect(pallet.GetComponent<Pallet>().palletItems).ToList<GameObject>();

                    for (int g = 0; g < correctItems.Count; g++)
                    {
                        correctItems[g].GetComponent<Renderer>().material.color = Color.green;
                        magazijnWagen.GetComponent<magazijnWagen>().checkOrder = false;
                        // de correcte items worden groen maar de order is niet compleet
                    }
                }
            }
        }
    }
    public void CheckOrder(List<GameObject> a) {
        for (int i = 0; i < itemsOrder.Count; i++) {
            if(a.Exists(element => element == itemsOrder[i])) {
                orders.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
            }
        }
        List<GameObject> result = a.Except(itemsOrder).ToList();
    }
    //List.Remove(yourObject)
}
