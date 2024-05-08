using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    void Start()
    {
        // goi coroutine de cho 2 giay truoc khi chuyen man hinh
        StartCoroutine(LoadGameAfterDelay(2f));
    }

    IEnumerator LoadGameAfterDelay(float delay)
    {
        // cho 2 giay
        yield return new WaitForSeconds(delay);

        // Load man hinh tro choi chinh
        SceneManager.LoadScene("1-1");
    }
}
