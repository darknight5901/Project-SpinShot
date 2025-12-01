using System.Collections.Generic;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public float currency;
    public int inventorySize = 6;
    public List<BaseItem> iContent = new List<BaseItem>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddItemToList(BaseItem item)
    {
        if (iContent.Count < inventorySize)
        {
            iContent.Add(item);
            Debug.Log($"Item {item} was added, the new inventory size is {iContent.Count}");
        }
        else
        {
            Debug.Log($"The list is full. Cannot add {item}. The max size is {inventorySize}");
        }
    }
}
