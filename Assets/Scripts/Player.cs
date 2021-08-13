using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var deltaX = horizontalInput * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
                
        if (horizontalInput > 0 )
        {
            anim.SetBool("isWalkRight",true);
        }
        else if (horizontalInput < 0)
        {
            anim.SetBool("isWalkLeft", true);
        }
        else
        {
            anim.SetBool("isWalkRight", false);
            anim.SetBool("isWalkLeft", false);
        }


        transform.position = new Vector2(newXPos, transform.position.y);
    }
}
