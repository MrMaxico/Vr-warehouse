using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderListManager : MonoBehaviour
{
    public GameObject[] items; //items
    public bool isCompleted;
    public Text[] itemText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                // itemtext[i] = items[i].itemName.ToString; //kijkt in scriptableObject voor naam item
            }
        }
    }

    void Completed()
    {

    }
}
