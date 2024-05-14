using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    AudioManager audioManager;
    ScoreManager scoreManager;
    CoinManager coinManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        coinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
    }
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower,
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type) { 
             case Type.Coin:
                audioManager.PlaySFX(audioManager.coin);
                scoreManager.AddScore();
                coinManager.AddCoin();
                GameManager.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                audioManager.PlaySFX(audioManager.powerUp);
                GameManager.Instance.AddLife();
                scoreManager.EatingPowerUp();
                break;

            case Type.MagicMushroom:
                audioManager.PlaySFX(audioManager.powerUp);
                scoreManager.EatingPowerUp();
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                audioManager.PlaySFX(audioManager.powerUp);
                scoreManager.EatingPowerUp();
                player.GetComponent<Player>().Starpower();
                break;
        }
        Destroy(gameObject);
    }
}
