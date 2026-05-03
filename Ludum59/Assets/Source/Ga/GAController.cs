using System;
using UnityEngine;
using GameAnalyticsSDK;

public class GAController : MonoBehaviour
{
    private void Start()
    {
        OnLevelStarted();
    }

    public void OnLevelStarted()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "MainGame");
        Debug.Log($"Начат уровень");
    }
    
    public void OnLevelCompleted()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "MainGame");
        Debug.Log($"Уровень пройден");
    }
    
    public void OnLevelFailed()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "MainGame");
        Debug.Log($"Уровень провален");
    }
}
