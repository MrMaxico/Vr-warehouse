using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OrderListManager : MonoBehaviour
{
    public GameObject[] itemsOrder;
    public bool isCompleted;
    public Text[] itemNames;
    public GameObject warehouseManager;
    public int itemValue;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemsOrder.Length; i++)
        {
            itemNames[i] = itemsOrder[i].name; //kijkt in scriptableObject voor naam item
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    //List.Remove(yourObject)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pallet")
        {
            if (other.GetComponent<Pallet>().palletItems == itemsOrder)
            {
                //alle items zitten op de pallet en gaan in de bus
                warehouseManager.GetComponent<WarehouseManager>().points += itemValue;
                
            }

            else
            {
                for (int i = 0; i < other.GetComponent<Pallet>().palletItems.Length; i++)
                {
                    if (itemsOrder.Intersect(other.GetComponent<Pallet>().palletItems).Any()) // check if there is equal items
                    {
                        GameObject[] correctItems = itemsOrder.Intersect(other.GetComponent<Pallet>().palletItems).ToArray<GameObject>(); 
                        
                        for (int g = 0; g < correctItems.Length; g++)
                        {
                            if(itemsOrder[g] == correctItems[g])
                            {
                                itemNames[g].color = Color.green;
                            }

                            
                        }
                    }
                    
                }

                
            }
        }
    }
}
