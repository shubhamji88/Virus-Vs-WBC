using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class  SoundManagerScript : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip jump;
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
                Debug.Log("Jump soudn");
                audioSrc.PlayOneShot (jump);
                break;
        }
    }
}