using UnityEngine;
using GameAnalyticsSDK;

public class GameAnalyticsInitializer : MonoBehaviour
{
    void Start()
    {
        GameAnalytics.Initialize();
        Debug.Log("GameAnalytics инициализирован");
    }
}