using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class  SoundManagerScript : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip jump, hitenemy, fire, playerdeath;
    private static SoundManagerScript _instance;
    public static SoundManagerScript instance
    {
        get
        {
            return _instance;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void PlaySound(string clip)
    {

        switch (clip)
        {

            case "jump":
                Debug.Log("Jump sound");
                audioSrc.PlayOneShot (jump);
                break;
            case "hitenemy":
                Debug.Log("Enemy Death Sound");
                audioSrc.PlayOneShot(hitenemy);
                break;
            case "fire":
                Debug.Log("Gunfire sound");
                audioSrc.PlayOneShot(fire);
                break;
            case "playerdeath":
                Debug.Log("Game Over");
                audioSrc.PlayOneShot(playerdeath);
                break;
        }
    }
}