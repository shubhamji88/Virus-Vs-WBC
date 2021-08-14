using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPopup : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpBox;
    public Animator animator;
    public void PopUpBox()
    {

        popUpBox.SetActive(true);
        Time.timeScale = 0;
        animator.SetTrigger("pop");

    }
    public void resume()
    {
        Debug.Log("resume");
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "level1")
            SceneManager.LoadScene("level1");
        else if (SceneManager.GetActiveScene().name == "level2")
            SceneManager.LoadScene("level1");
        animator.SetTrigger("close");
    }
}
