using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private Texture2D cursor;

    private void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void StartGame(string tutorial)
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetString("Tutorial", tutorial);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
