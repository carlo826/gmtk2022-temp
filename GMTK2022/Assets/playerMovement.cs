using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 1;
    public float friction = 0.1f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector2.left * speed);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector2.right * speed);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector2.up * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector2.down * speed);

        //Debug.Log(Input.mousePosition);
        
        rb.velocity -= friction*rb.velocity;
    }

        public void checkDice(int finalSide){
         switch(finalSide){
            case 1:
              speedSlow();
              break;
            case 2:
              projectileSpeedSlow();
              break;
            case 3:
              //TODO
              break;
            case 4:
              //TODO
              break;
            case 5:
              projectileSpeedBoost();
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

    void projectileSpeedBoost(){
        GameObject player = GameObject.Find("PlayerCharacter");
        player.GetComponent<playerAttack>().speed = player.GetComponent<playerAttack>().speed * 2;
        Debug.Log("Attackspeed is now " + player.GetComponent<playerAttack>().speed);
    }

    void projectileSpeedSlow(){
        GameObject player = GameObject.Find("PlayerCharacter");
        player.GetComponent<playerAttack>().speed = player.GetComponent<playerAttack>().speed / 2;
        Debug.Log("Attackspeed is now " + player.GetComponent<playerAttack>().speed);
    }
}
