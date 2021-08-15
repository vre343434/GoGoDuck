using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameButton : MonoBehaviour
{
    [SerializeField] Description description;
    [SerializeField] GameObject buttonImage;
    [SerializeField] GameObject buttonQuantity;
    Items myItem;


    public void SetItem(Items items)
    {
        myItem = items;
        buttonImage.GetComponent<Image>().sprite = myItem.GetItemImage();
        buttonQuantity.GetComponent<Text>().text = myItem.GetQuantity().ToString();
    }

    public void ShowDescription()
    {
        description.SetDescription(myItem);
    }

}
