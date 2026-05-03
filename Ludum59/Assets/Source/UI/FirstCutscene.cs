using System;
using System.Collections;
using GameAnalyticsSDK;
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
       
        string progressionId = "FirstCutsceneWatched";
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "firstCutscene", progressionId);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(2);
            string progressionId = "FirstCutsceneSkipped";
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "firstCutscene", progressionId);
        }
    }
}
