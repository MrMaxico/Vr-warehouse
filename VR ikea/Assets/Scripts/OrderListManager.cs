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
      
    }

    //List.Remove(yourObject)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pallet")
        {
            itemsOrder.Intersect(other.GetComponent<Pallet>().palletItems).Any();
            correctItems = itemsOrder.Intersect(other.GetComponent<Pallet>().palletItems).ToArray<GameObject>();
            if(correctItems.Length == itemsOrder.Length)
            {
                print("allItemsCorrect");
                //alle items zitten op de pallet en gaan in de bus
            }
                
            else
            {
                for (int i = 0; i < other.GetComponent<Pallet>().palletItems.Count; i++)
                {
                    itemsOrder.Intersect(other.GetComponent<Pallet>().palletItems).Any();
                    
                    correctItems = itemsOrder.Intersect(other.GetComponent<Pallet>().palletItems).ToArray<GameObject>(); 
                        
                    for (int g = 0; g < correctItems.Length; g++)
                    {  
                        correctItems[g].GetComponent<Renderer>().material.color = Color.green;
                        // de correcte items worden groen maar de order is niet compleet
                    }
                }
            }
        }
    }
}
