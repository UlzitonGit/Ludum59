using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private GameObject[] hearts;

    public void UpdateUI(int hp)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hp > i)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
