using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0f,1000f)]float moveSpeed = 10f;
    [SerializeField] [Range(0f, 1000f)] float jump = 10f;
    Animator anim;
    Rigidbody2D rigidbody;
    [SerializeField] BackpackControl backpackControl;
    Items[] items;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        items = backpackControl.GetItems();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!backpackControl.GetMessageActive())
            Move();
    }

    private void Move()
    {
        //todo嘗試修改為Kinematic

        var horizontal = Input.GetAxis("Horizontal");
        var deltaX = horizontal * Time.deltaTime * moveSpeed;
        var direction = new Vector2(deltaX, 0);

        AnimationControl(horizontal);

        rigidbody.AddForce(direction);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Ground"));

        //消除下滑
        if (hit.normal.x != 0f)
        {
            rigidbody.AddForce(hit.normal * Vector2.Dot(Physics2D.gravity, hit.normal) - Physics2D.gravity);
        }

        if(Input.GetButton("Jump") && hit)
        {
            rigidbody.AddForce(new Vector2(0, jump));
        }

    }

    private void AnimationControl(float horizontal)
    {
        if (horizontal > 0)
        {
            anim.SetBool("isWalkRight", true);
            anim.SetBool("isWalkLeft", false);
        }
        else if (horizontal < 0)
        {
            anim.SetBool("isWalkRight", false);
            anim.SetBool("isWalkLeft", true);
        }
        else
        {
            anim.SetBool("isWalkRight", false);
            anim.SetBool("isWalkLeft", false);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (Items item in items)
        {
            if (other.gameObject.tag == item.GetItemNumber().ToString())
            {
                item.AddQuantity();
                Destroy(other.gameObject);
                backpackControl.ItemFramesRefresh();
                break;
            }
        }
    }

    public void SetPlayerLocation(Vector2 pos)
    {
        rigidbody.position = new Vector2(pos.x, pos.y);
    }

}
