using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstCutscene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(26f);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
        }
    }
}
