using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item Stats", order = 2, fileName = "New Item Stats")]

public class ItemData : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string itemLocation;
    [SerializeField] string size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
