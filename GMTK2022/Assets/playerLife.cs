using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

     void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Collision");
        Debug.Log(other.gameObject);
        GetComponent<PlayDMG>().playSound();

        if (other.gameObject.CompareTag("Enemy")){
            isDead = true;
            Debug.Log("PLAYER DEAD");
            //Debug.Log(other.gameObject.GetComponent<enemyController>().health);
            
        }
    }
}
