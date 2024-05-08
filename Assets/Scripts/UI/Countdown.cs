using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    private int countdownTime = 390;

    private void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (countdownTime > 0) { 
            yield return new WaitForSeconds(1f);//cho 1 giay

            countdownTime--;//giam thoi gian dem nguoc

            countdownText.text = countdownTime.ToString();//hien thi thoi gian dem nguoc 
        }
        countdownText.text = "Hết thời gian!";
    }
}
