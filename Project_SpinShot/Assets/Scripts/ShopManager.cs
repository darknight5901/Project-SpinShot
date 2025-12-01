using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] ShopItems = new int[9, 9];
    public float currency;
    public TMP_Text coinsTxt;
    public TMP_Text roundTxt;
    void Start()
    {
        roundTxt.text = "Round " + GameManager._.currentRound.ToString();
        coinsTxt.text = "Coins " + currency.ToString();
        //Item Id
        ShopItems[1, 1] = 1;
        ShopItems[1, 2] = 2;
        ShopItems[1, 3] = 3;
        ShopItems[1, 4] = 4;
        ShopItems[1, 5] = 5;

        //Price
        ShopItems[2, 1] = 1;
        ShopItems[2, 2] = 1;
        ShopItems[2, 3] = 1;
        ShopItems[2, 4] = 1;
        ShopItems[2, 5] = 1;

        //Quantity
        ShopItems[3, 1] = 0;
        ShopItems[3, 2] = 0;
        ShopItems[3, 3] = 0;
        ShopItems[3, 4] = 0;
        ShopItems[3, 5] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject buttonRef = GameObject.FindWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (currency >= ShopItems[2, buttonRef.GetComponent<ButtonInfo>().itemId])
        {
            currency -= ShopItems[2, buttonRef.GetComponent<ButtonInfo>().itemId];
            ShopItems[3, buttonRef.GetComponent<ButtonInfo>().itemId]++;
            coinsTxt.text = "Coins " + currency.ToString();
            buttonRef.GetComponent<ButtonInfo>().quantityTxt.text = ShopItems[3, buttonRef.GetComponent<ButtonInfo>().itemId].ToString();
        }
    }

    private void OnValidate()
    {
        coinsTxt.text = "Coins " + currency.ToString();
        roundTxt.text = "Round " + GameManager._.currentRound.ToString();

    }
}
