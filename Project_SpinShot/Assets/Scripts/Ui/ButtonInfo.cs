using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int itemId;
    public TMP_Text priceTxt;
    public TMP_Text quantityTxt;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        priceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManager>().ShopItems[2,itemId].ToString();
        quantityTxt.text = "Price: $" + ShopManager.GetComponent<ShopManager>().ShopItems[3, itemId].ToString();
    }
}
