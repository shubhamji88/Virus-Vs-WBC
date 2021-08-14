using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text bodyTopText;
    public TMP_Text bodyMidText;
    public TMP_Text bodyEndText;
    public TMP_Text headingText;
    public void PopUpBox(string heading, string bodyTop, string bodyMid, string bodyEnd)
    {
        
        popUpBox.SetActive(true);
        bodyTopText.text = bodyTop;
        bodyMidText.text = bodyMid;
        bodyEndText.text = bodyEnd;
        headingText.text = heading;
        Time.timeScale = 0;
        animator.SetTrigger("pop");
        
    }
    public void resume()
    {
        Time.timeScale = 1;
        animator.SetTrigger("close");
    }
}
