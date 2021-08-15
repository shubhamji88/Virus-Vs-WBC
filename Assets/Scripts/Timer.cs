using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text timerText;
    private float startTime;
    public int countDownTime;
    public int numInfected;
    private DeadPopup deadPopup;
    void Start()
    {
        deadPopup = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeadPopup>();
        StartCoroutine(CountDownStart());
    }

    public void incrementInfected()
    {
        numInfected++;
    }
    public void decrementInfected()
    {
        if(numInfected>0)
            numInfected--;
        if(numInfected<=0 && (SceneManager.GetActiveScene().name == "level2"))
            SceneManager.LoadScene("level3");
    }
    // Update is called once per frame

    IEnumerator CountDownStart()
    {
        while (countDownTime > 0)
        {
            timerText.text = "Infected: " + numInfected + " Time Left: " + countDownTime.ToString() + " sec";
            if (countDownTime < 5)
            {
                timerText.color = Color.red;
            }
            else if (countDownTime < 15)
            {
                timerText.color = Color.blue;
            }
            else
            {
                timerText.color = Color.white;
            }
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        deadPopup.PopUpBox("Time's UP!! \n Better Luck next time");
    }
}
