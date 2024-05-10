using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager: MonoBehaviour
{
    public int score = 0;

    public Text scoreText;// hien thi tren giao dien

    // ham nay duoc goi khi mario thu thap mot tien xu
    public void AddScore()
    {
        score += 100;
        UpdateScoreUI();
    }

    // ham nay duoc goi khi mario tieu diet mot ke thu
    public void DefeatEnemy()
    {
        score += 200;
        UpdateScoreUI();
    }

    // ham nay duoc goi khi mario thu thap power up
    public void EatingPowerUp()
    {
        score += 1000;
        UpdateScoreUI();
    }

    public void UpdateScoreFromTimeBonus(int timeBonus)
    {
        int timeBonusMultiplier = 10; //ty le de chuyen doi thoi gian con lai thanh diem so
        int timeBonusScore = timeBonus * timeBonusMultiplier;
        score += timeBonusScore;

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // cap nhat text hien thi diem
        scoreText.text = score.ToString("D6");
    }
}
