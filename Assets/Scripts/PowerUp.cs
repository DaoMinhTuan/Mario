using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        
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
                GameManager.Instance.AddCoin();
                break;

            case Type.ExtraLife:
                GameManager.Instance.AddLife();
                break;

            case Type.MagicMushroom:
                audioManager.PlaySFX(audioManager.powerUp);
                player.GetComponent<Player>().Grow();
                break;

            case Type.Starpower:
                audioManager.PlaySFX(audioManager.powerUp);
                player.GetComponent<Player>().Starpower();
                break;
        }
        Destroy(gameObject);
    }
}
