using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    static AudioSource audioSrc;
    private static AudioClip jump;

    // Start is called before the first frame update
    void Start()
    {

        jump = Resources.Load<AudioClip>("jumpSound");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {

            case "jump":
                audioSrc.PlayOneShot (jumpSound);
                break;
        }
    }
}