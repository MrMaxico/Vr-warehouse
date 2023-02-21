using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Enemy Stats", order = 2, fileName = "New Enemy Stats")]

public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public string itemLocation;
    [SerializeField] public string size;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
