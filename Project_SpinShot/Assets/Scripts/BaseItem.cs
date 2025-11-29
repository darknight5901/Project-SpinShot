using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    None, Upgrade, Consumable
}
public enum ItemRarity
{
    None, Common, Uncommon, Rare, Epic, Legendary
}
[CreateAssetMenu]
public class BaseItem : ScriptableObject
{
    public ItemType itemType;
    public ItemRarity itemRarity;
    public string itemName;
    public string itemDescription;
    public Image itemIcon;
    

    [Header("item values")]
    public UpgradeGuality upgradeGuality;
    public UpgradeType upgradeType;
    public float upgradeValue;
   public BaseItem(ItemType itemType, ItemRarity itemRarity, string itemName, string itemDescription, Image itemIcon, UpgradeGuality upgradeGuality, UpgradeType upgradeType, float upgradeValue)
    {
        this.itemType = itemType;
        this.itemRarity = itemRarity;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemIcon = itemIcon;
        this.upgradeGuality = upgradeGuality;
        this.upgradeType = upgradeType;
        this.upgradeValue = upgradeValue;
    }
}
