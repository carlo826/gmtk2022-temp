using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDMG : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    // Start is called before the first frame update
    public void playSound()
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
