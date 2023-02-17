using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderListManager : MonoBehaviour
{
    public List <GameObject> itemsOrder;
    public bool isCompleted;
    public Text[] itemText;
    public GameObject warehouseManager;
    public int itemValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemsOrder.Count; i++)
        {
            itemText[i] = itemsOrder[i].itemName.ToString; //kijkt in scriptableObject voor naam item
        }
        
    }

    //List.Remove(yourObject)


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pallet")
        {
            if (other.GetComponent<Pallet>().items == itemsOrder)
            {
                //alle items zitten op de pallet en gaan in de bus
                warehouseManager.GetComponent<WarehouseManager>().points += itemValue;
                
            }

            else
            {
                for (int i = 0; i < other.GetComponent<Pallet>().items.Count; i++)
                {
                    
                       
                        if (other.GetComponent<Pallet>().items.Intersect(itemsOrder).Any()) // check if there is equal items
                        {
                            GameObject[] equalItems = other.GetComponent<Pallet>().items.Intersect(itemsOrder); // get list of equal items (2, 6, 9)
                            for (int i = 0; i < equalItems.Length; i++)
                            {
                                equalItems[i].color = Color.gray;
                            }
                        }
                    
                }
                itemText[1].color = Color.gray;
            }
        }
    }
}
