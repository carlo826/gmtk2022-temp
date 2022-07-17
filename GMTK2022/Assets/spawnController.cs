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
    private BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        width = col.bounds.max.x;
        height = gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Top/Bottom (True) or left/right (False)
        if(Random.Range(0, 2) > 0.5f){
            spawnX = Random.Range(col.bounds.min.x, col.bounds.max.x);

            // spawn on top (True) or bottom (False)
            if (Random.Range(0,2) > 0.5f) {
                spawnY = col.bounds.min.y;
            }
            else {
                spawnY = col.bounds.max.y;
            }
        }
        else {
            spawnY = Random.Range(col.bounds.min.y, col.bounds.max.y);

            // spawn on left(True) or right(False)
            if(Random.Range(0,2) > 0.5f){
                spawnX = col.bounds.min.x;
            }
            else{
                spawnX = col.bounds.max.x; 
            }
        }


        spawnPoint = new Vector2(spawnX, spawnY);
        //spawnPoint = ()
        if (currentTime > 0){
            currentTime -= Time.deltaTime;
        }
        else{
            Instantiate(enemies[0], spawnPoint, Quaternion.Euler(new Vector2(0,0)));
            //Debug.Log(spawnPoint);
            currentTime = spawnTime;
        }
    }
}