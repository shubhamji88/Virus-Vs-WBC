using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    private float startTime;
    public int countDownTime;
    void Start()
    {
        StartCoroutine(CountDownStart());
    }

    // Update is called once per frame
    void Update()
    {
        /*float t = Time.time - startTime;
        string min = ((int)t / 60).ToString();
        float sec = (t % 60);
        if (sec < 25.0)
        {
            timerText.color = Color.white;
        }
        else
        {
            timerText.color = Color.red;
        }
        timerText.text = min + " : " + sec.ToString("f0");*/

    }
    IEnumerator CountDownStart()
    {
        while (countDownTime > 0)
        {
            timerText.text = countDownTime.ToString() + " sec";
            if (countDownTime <5)
            {
                timerText.color = Color.red;
            }else if (countDownTime < 15)
            {
                timerText.color = Color.yellow;
            }
            else
            {
                timerText.color = Color.white;
            }
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
    }
}
