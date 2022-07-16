using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Collision");
        Debug.Log(other.gameObject);

        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<enemyController>().health--;
            Debug.Log(other.gameObject.GetComponent<enemyController>().health);
        }
        else
        {
            Debug.Log("NOT ENEMY");
        }
        Destroy(gameObject);
    }
}
