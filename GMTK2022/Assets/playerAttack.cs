    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Vector2 aimDirection;
    public float speed = 0.1f;
    public float attackDelay = 0.5f;
    private float nextDamageEvent = 0.0f;
    public GameObject projectile;
    private Rigidbody2D projectileInstance;
    public GameObject AudioManager; 
    // Start is called before the first frame update
    void Start()
    {
        Vector2 aimDirection;
        public float speed = 0.1f;
        public float attackDelay = 0.5f;
        private float nextDamageEvent = 0.0f;
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

            


            if (Input.GetKey(KeyCode.Space) && Time.time > nextDamageEvent ) {
                nextDamageEvent = Time.time + attackDelay;
                projectileInstance = Instantiate(projectile, transform.position, Quaternion.FromToRotation(aimDirection, transform.position)).GetComponent<Rigidbody2D>();

            //AudioManager.GetComponent<AudioManager>().Play("fireShoot");
                

                Vector2 direction = new Vector2(aimDirection.x, aimDirection.y);
                direction.Normalize();
                projectileInstance.AddForce(direction*speed);

                //Get the Screen positions of the object
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (projectileInstance.position);
            
                //Get the Screen position of the mouse
                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            
                //Get the angle between the points
                float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
    
                //Ta Daaa
                //projectileInstance.rotation =  Quaternion.Euler(new Vector3(0f,0f,angle));
                Debug.Log("PROJECTILE ROTATION X   " + projectileInstance.rotation);
                //Debug.Log("PROJECTILE ROTATION Y   " + projectileInstance.rotation.y);
                //Debug.Log("PROJECTILE ROTATION Z   " + projectileInstance.rotation.z);

                projectileInstance.rotation = angle;
            }
        }
        
        float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
                return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
                FindObjectOfType<AudioManager>().Play("fireSwosh");
        
        }
    }


    //Quaternion.Euler(new Vector2(0,0))