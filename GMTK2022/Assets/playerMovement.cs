using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 1;
    public float friction = 0.1f;
    private Rigidbody2D rb;
    GameObject dicetext;
    GameObject player;

    public float animSpeed = 1;
    public float animStop = 0;

    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dicetext = GameObject.Find("DiceText");
        player = GameObject.Find("PlayerCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", animStop);

        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(Vector2.left * speed);
            animator.SetFloat("Speed", animSpeed);
        }
            
        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(Vector2.right * speed);
            animator.SetFloat("Speed", animSpeed);

        }
        if (Input.GetKey(KeyCode.W)) {
             rb.AddForce(Vector2.up * speed);
             animator.SetFloat("Speed", animSpeed);
        }
           
        if (Input.GetKey(KeyCode.S)){
             rb.AddForce(Vector2.down * speed);
             animator.SetFloat("Speed", animSpeed);
        }
           

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
              attackSpeedSlow();
              break;
            case 4:
              attackSpeedBoost();
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
        dicetext.GetComponent<ChangeDiceText>().changeText("YOU GOT SPEED BOOST",true);
        Debug.Log("speed is " + speed);
    }

    void speedSlow(){
        speed = speed / 2;
        dicetext.GetComponent<ChangeDiceText>().changeText("OH NO! SLOWED!",false);
        Debug.Log("speed is " + speed);
    }

    void projectileSpeedBoost(){
        dicetext.GetComponent<ChangeDiceText>().changeText("FASTER BULLETS!",true);
        player.GetComponent<playerAttack>().speed = player.GetComponent<playerAttack>().speed * 2;
        Debug.Log("Attackspeed is now " + player.GetComponent<playerAttack>().speed);
    }

    void projectileSpeedSlow(){
        dicetext.GetComponent<ChangeDiceText>().changeText("SLOWER BULLETS!",false);
        player.GetComponent<playerAttack>().speed = player.GetComponent<playerAttack>().speed / 2;
        Debug.Log("Attackspeed is now " + player.GetComponent<playerAttack>().speed);
    }

    void attackSpeedBoost(){
        dicetext.GetComponent<ChangeDiceText>().changeText("ATTACKSPEED BOOST!",true);
        player.GetComponent<playerAttack>().attackDelay = player.GetComponent<playerAttack>().attackDelay / 2;
        Debug.Log("Attackspeed is now " + player.GetComponent<playerAttack>().attackDelay);
    }

    void attackSpeedSlow(){
        dicetext.GetComponent<ChangeDiceText>().changeText("ATTACKSPEED SLOW!",false);
        player.GetComponent<playerAttack>().attackDelay = player.GetComponent<playerAttack>().attackDelay * 2;
        Debug.Log("Attackspeed is now " + player.GetComponent<playerAttack>().attackDelay);
    }
}
