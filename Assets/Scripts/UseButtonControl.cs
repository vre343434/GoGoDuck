using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UseButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float Ping;
    private bool IsStart = false;
    private float LastTime = 0;

    Coroutine buttonCoroutine;

    [SerializeField] BackpackControl backpackControl;
    [SerializeField] Text descriptionQuantity;
    Items myItem;

    public void SetItem(Items item)
    {
        myItem = item;
    }

    void Update()
    {
        if (IsStart && Time.time - LastTime > Ping)
        {
            buttonCoroutine = StartCoroutine(UseItemContinuously());
            IsStart = false;
        }
    }

    IEnumerator UseItemContinuously()
    {
        while(true)
        {
            myItem.MinusQuantity();
            Debug.Log("ªø«ö~" + myItem.GetQuantity());
            backpackControl.ItemFramesRefresh();
            QuantityRefresh();
            yield return new WaitForSeconds(Ping);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LongPress(true);
        myItem.MinusQuantity();
        Debug.Log("«ö¤U" + myItem.GetQuantity());
        backpackControl.ItemFramesRefresh();
        QuantityRefresh();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsStart)
        {
            LongPress(false);
            Debug.Log("©ï°_");
        }
        StopCoroutine(buttonCoroutine);
    }

    public void LongPress(bool bStart)
    {
        IsStart = bStart;
        LastTime = Time.time;
    }

    public void QuantityRefresh()
    {
        descriptionQuantity.text = myItem.GetQuantity().ToString();
        if (myItem.GetQuantity() <= 0) 
        {
            backpackControl.CloseDescribe();
        }
    }
}
