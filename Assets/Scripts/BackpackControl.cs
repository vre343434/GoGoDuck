using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackControl : MonoBehaviour
{

    [SerializeField] GameObject BackpackInterface;
    bool IsBackpackOpen = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OpenBackpack()
    {
        IsBackpackOpen = !IsBackpackOpen;
        BackpackInterface.SetActive(IsBackpackOpen);
    }
}
