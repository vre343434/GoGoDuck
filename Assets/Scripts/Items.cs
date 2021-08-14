using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Items")]
public class Items : ScriptableObject
{
    [SerializeField] int itemNumber;
    [SerializeField] string itemName;
    [SerializeField] string itemDescribe;
    [SerializeField] Sprite itemImage;
    [SerializeField] int initialQuantity;

    public int GetItemNumber()
    {
        return itemNumber;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemDescribe()
    {
        return itemDescribe;
    }

    public Sprite GetItemImage()
    {
        return itemImage;
    }

    public int GetInitalQuantity()
    {
        return initialQuantity;
    }

    public int SetInitalQuantity()
    {
        return initialQuantity + 1;
    }



}
