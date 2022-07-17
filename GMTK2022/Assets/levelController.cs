using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
     private static float levelTime = 20f;
     private float currentTime = levelTime;
     public GameObject background;
     private int currentLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0){
            currentTime -= Time.deltaTime;
        }
        else{
            if (GameObject.Find("Enemy(Clone)") != null){
                Debug.Log("ENEMY EXISTS");
            }

            currentTime = levelTime;
        }
    }
}
