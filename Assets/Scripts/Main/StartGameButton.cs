using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGameButton : MonoBehaviour
{
    public void StartGamePlay()
    {
        SceneManager.LoadScene("ScreenSaver");
    }
}
