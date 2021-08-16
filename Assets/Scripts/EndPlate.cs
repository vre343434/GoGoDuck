using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlate : MonoBehaviour
{
    [SerializeField] BackpackControl backpackControl;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            backpackControl.OpenMessage();
        }
    }
}
