using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameDeathScreen : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }
}
