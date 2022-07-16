using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;


    void Start()
    {
        
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[1];
    }
  

     
    // Level move zoned enter, if collider is a player
    // Move game to another scene
   void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");
        
        // Could use other.GetComponent<Player>() to see if the game object has a Player component
        // Tags work too. Maybe some players have different script components?
        if(other.tag == "Player") {
            // Player entered, so move level
            Debug.Log("Switching Scene to " + sceneBuildIndex);
            ChangeSprite();
        }
    }
}
