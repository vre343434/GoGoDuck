using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    Items myItem;
    [SerializeField] GameObject Description;

    public void SetItem(Items item)
    {
        myItem = item;
    }
    public void SetDescription()
    {

    }

}
