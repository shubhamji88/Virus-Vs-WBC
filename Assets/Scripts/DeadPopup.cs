using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DeadPopup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text Text;
    public void PopUpBox(string message)
    {

        popUpBox.SetActive(true);
        Time.timeScale = 0;
        Text.text = message;
        animator.SetTrigger("pop");
        
    }
    public void resume()
    {
        Debug.Log("resume");
        Time.timeScale = 1;
        animator.SetTrigger("close");
        if (SceneManager.GetActiveScene().name == "level1")
            SceneManager.LoadScene("level1");
        else if (SceneManager.GetActiveScene().name == "level2")
            SceneManager.LoadScene("level2");
        else if (SceneManager.GetActiveScene().name == "level3")
            SceneManager.LoadScene("level3");

    }
    
}
