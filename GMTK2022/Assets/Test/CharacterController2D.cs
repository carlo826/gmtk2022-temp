using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController2D : MonoBehaviour
{
    public int speed = 20;
    public float friction = 0.1f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private GameObject dice;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0){
            sr.flipX = false;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0){
            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector2.right * speed);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector2.up * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector2.down * speed);
        rb.velocity -= friction*rb.velocity;
        //animator.SetFloat(speed,Mathf.Abs(Input.GetAxisRaw("Horizontal")));
 
    }

    public void checkDice(int finalSide){
         switch(finalSide){
            case 1:
              speedSlow();
              break;
            case 2:
              //TODO
              break;
            case 3:
              //TODO
              break;
            case 4:
              //TODO
              break;
            case 5:
              //TODO
              break;
            case 6:
              speedBoost();
              break;
         }
    }

     void speedBoost(){
        speed = speed * 2;
        Debug.Log("speed is " + speed);
    }

    void speedSlow(){
        speed = speed / 2;
        Debug.Log("speed is " + speed);
    }
}