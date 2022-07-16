using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Vector2 aimDirection;
    public float speed = 0.1f;
    public GameObject projectile;
    private Rigidbody2D projectileInstance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection = aimDirection - (Vector2)transform.position;
        //Debug.Log(aimDirection);

        if (Input.GetMouseButtonDown(0)) {
            projectileInstance = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector2(0,0))).GetComponent<Rigidbody2D>();
            //projectileInstance.GetComponent<Rigidbody2D>();
            //Debug.Log("AIM DIRECTION X:" + aimDirection.x);
            //Debug.Log("AIM DIRECTION Y:" + aimDirection.y);

            Vector2 direction = new Vector2(aimDirection.x, aimDirection.y);
            direction.Normalize();
            projectileInstance.AddForce(direction*speed);
        }
    }
}
