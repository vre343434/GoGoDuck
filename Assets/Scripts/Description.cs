using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] GameObject descriptionName;
    [SerializeField] GameObject descriptionImage;
    [SerializeField] GameObject descriptionQuantity;
    [SerializeField] GameObject descriptionText;
    [SerializeField] GameObject useButton;

    public void SetDescription(Items item)
    {
        descriptionName.GetComponent<Text>().text = item.GetItemName();
        descriptionImage.GetComponent<Image>().sprite = item.GetItemImage();
        descriptionQuantity.GetComponent<Text>().text = item.GetInitalQuantity().ToString();
        descriptionText.GetComponent<Text>().text = item.GetItemDescribe();
    }

}
