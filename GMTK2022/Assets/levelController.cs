using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{
    private static float levelTime = 13f;
    private float currentTime = levelTime;
    public GameObject background;
    private int currentLevel = 1;
    public bool isPaused = false;
    public GameObject dice;
    public GameObject diceText;
    public bool isRolling = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0 && isPaused == false){
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0 && isPaused == false){
            GameObject.Find("EnemySpawnBox").GetComponent<spawnController>().pauseSpawning();
            Debug.Log("KILL LAST ENEMIES");
        }
        if (GameObject.Find("Enemy(Clone)") == null && currentTime <= 0 && isPaused == false){
            StartCoroutine(transitionLevel());
            Debug.Log("NEW LEVEL");
        }
    }
    IEnumerator transitionLevel(){
        Debug.Log("TRANSITION LEVEL");
        yield return new WaitForSeconds(0.1f);
        isPaused = true;
        //GameObject.Find("PlayerCharacter").GetComponent<SpriteRenderer>().enabled = false;
        dice.SetActive(true);
        diceText.GetComponent<MeshRenderer>().enabled = true;


    }

    public IEnumerator diceRolled(){
        yield return new WaitForSeconds(2.5f);
        Debug.Log("meme");
        dice.SetActive(false);
        diceText.GetComponent<MeshRenderer>().enabled = false;

        currentLevel ++;
        currentTime = levelTime;
        GameObject.Find("EnemySpawnBox").GetComponent<spawnController>().startSpawning();

        isPaused = false;
    }
}
