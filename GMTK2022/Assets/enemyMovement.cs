using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private Vector2 playerPosition;
    private GameObject player;
    private Rigidbody2D rb;
    private Transform position;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        rb = GetComponent<Rigidbody2D>();
        position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.GetComponent<Transform>().position;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed);
        Debug.Log("position:" + playerPosition);
    }
}