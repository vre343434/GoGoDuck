using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackControl : MonoBehaviour
{

    [SerializeField] GameObject backpackInterface;
    [SerializeField] GameObject descriptionInterface;
    [SerializeField] GameObject messageInterface;
    [SerializeField] Player player;
    [SerializeField] GameObject itemContent;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform startPlate;
    [SerializeField] Items[] itemsDetail;

    [SerializeField] bool IsBackpackOpen = false;
    [SerializeField] bool resetQuantity = false;

    private void Start()
    {
        ItemFramesRefresh();
    }


    public void ItemFramesRefresh()
    {
        //���D:����qHierarchy�Ԥ~��Ū�����eDescription�A�L�k�qprefab��
        //�ק�:prefab framebutton�d�@�����ç@���ƻs�̾�

        int childCount = itemContent.transform.childCount;
        while (childCount > 0)
        {
            childCount -= 1;
            Destroy(itemContent.transform.GetChild(childCount).gameObject);
        }

        if (resetQuantity)
        {
            foreach (Items item in itemsDetail)
            {
                item.ResetQuantity();
            }
            resetQuantity = false;
        }


        foreach (Items item in itemsDetail)
        {
            if (item.GetQuantity() <= 0)
                continue;                      

            GameObject newItem = Instantiate(itemPrefab, itemContent.transform) as GameObject;
            newItem.GetComponent<FrameButton>().SetItem(item);
            newItem.gameObject.SetActive(true);  //�N���ö}��
        }
    }

    public void OpenBackpack()
    {
        ItemFramesRefresh();
        IsBackpackOpen = !IsBackpackOpen;
        backpackInterface.SetActive(IsBackpackOpen);
    }

    public void OpenDescribe()
    {
        ItemFramesRefresh();
        descriptionInterface.SetActive(true);
    }

    public void CloseDescribe()
    {
        descriptionInterface.SetActive(false);
    }

    public void OpenMessage()
    {
        messageInterface.SetActive(true);
    }

    public void CloseMessage()
    {
        messageInterface.SetActive(false);
    }

    public bool GetMessageActive()
    {
        return messageInterface.activeSelf;
    }

    public void ReStartGame()
    {
        resetQuantity = true;
        ItemFramesRefresh();
        player.SetPlayerLocation(new Vector2(startPlate.position.x, startPlate.position.y));
        CloseMessage();
    }

    public Items[] GetItems()
    {
        return itemsDetail;
    }
}
