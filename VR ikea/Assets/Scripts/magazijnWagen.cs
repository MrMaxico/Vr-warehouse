using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazijnWagen : MonoBehaviour
{
    OrderListManager orderListManager;
    public Transform palletLocation;
    public bool checkOrder;
    public List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag != "pallet") {
            items.Add(other.gameObject);
        }
        if (!checkOrder) {
            StartCoroutine(WaitAndCheck());
            checkOrder = true;
        }
    }
    public IEnumerator WaitAndCheck() {
        yield return new WaitForSeconds(5);
        orderListManager.CheckOrder(items);
    }
}
