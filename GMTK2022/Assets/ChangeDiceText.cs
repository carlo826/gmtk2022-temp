using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeDiceText : MonoBehaviour
{

    private TextMeshPro changingText;
    public GameObject textobj;
    public TMP_ColorGradient greenvertexgradient;
    public TMP_ColorGradient redvertexgradient;

    // Start is called before the first frame update
    void Start()
    {
        changingText = textobj.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeText(string new_text, bool good){
        if(good){
            changingText.colorGradientPreset = greenvertexgradient;
        }
        else{
            changingText.colorGradientPreset = redvertexgradient;
        }
        changingText.SetText(new_text);
    }
}
