using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour
{
    public GameObject[] enemies;
    public static float spawnTime = 10f;
    private float currentTime = spawnTime;
    private float width;
    private float height;
    private float spawnX;
    private float spawnY;
    private Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        width = gameObject.transform.localScale.x;
        height = gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Top/Bottom (True) or left/right (False)
        if(Random.Range(0, 2) > 0.5f){
            spawnX = Random.Range(0, width);

            // spawn on top (True) or bottom (False)
            if (Random.Range(0,2) > 0.5f) {
                spawnY = 0;
            }
            else {
                spawnY = height;
            }
        }
        else {
            spawnY = Random.Range(0, height);

            // spawn on left(True) or right(False)
            if(Random.Range(0,2) > 0.5f){
                spawnX = 0;
            }
            else{
                spawnX = width; 
            }
        }


        spawnPoint = new Vector2(spawnX, spawnY);
        //spawnPoint = ()
        if (currentTime > 0){
            currentTime -= Time.deltaTime;
        }
        else{
            Instantiate(enemies[0], spawnPoint, Quaternion.Euler(new Vector2(0,0)));
            Debug.Log(spawnPoint);
            currentTime = spawnTime;
        }
    }
}