using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coin = 0;

    public Text coinText;// hien thi tren giao dien

    public void AddCoin()
    {
        coin ++;
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        // cap nhat text hien thi diem
        coinText.text = coin.ToString("D2");
    }
}
