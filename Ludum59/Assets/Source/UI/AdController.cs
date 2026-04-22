using UnityEngine;

public class AdController : MonoBehaviour
{
    [SerializeField] private GameObject[] adPanels;

    public void ShowAdPanel(int index)
    {
        if (adPanels[index - 2] != null)
        {
            adPanels[index - 2].SetActive(true);
        }
    }
}
