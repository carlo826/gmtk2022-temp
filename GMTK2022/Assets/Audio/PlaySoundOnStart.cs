using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;
    // Start is called before the first frame update
    public void playSound()
    {
        SoundManager.Instance.PlaySound(_clip);
    }



    
}
