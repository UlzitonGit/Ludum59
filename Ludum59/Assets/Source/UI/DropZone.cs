using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropZone : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private PlayerModuleSlot playerModuleSlot;

    [SerializeField] private Image[] button;

    [SerializeField] List<ModuleInfo> _movesUI = new List<ModuleInfo>();
    [SerializeField] List<GameObject> _cards = new List<GameObject>();
    public void OnObjectDropped(ModuleInfo prefab)
    {
        playerModuleSlot.AddModule(prefab.module);
        for (int i = 0; i < 3; i++)
        {
            if (_movesUI[i] == null)
            {
                _movesUI[i] = prefab;
                button[i].sprite = prefab.icon;
                button[i].GetComponent<Button>().onClick.AddListener(() => { RemoveObject(i); });
                button[i].GetComponent<ShowInfoComponent>().canShow = true;
                button[i].GetComponent<ShowInfoComponent>().SetIndex(i);
                _cards[i] = Instantiate(prefab.gameObject, transform);;
                break;
            }
        }
    }

    private void RemoveObject(int index)
    {
        button[index].GetComponent<ShowInfoComponent>().canShow = false;
        print("Removing " + index);
        button[index].GetComponent<Button>().onClick.RemoveAllListeners();
        playerModuleSlot.DestroyModule(index);
        Destroy(_cards[index].gameObject);
        button[index].sprite = defaultSprite;
        _movesUI[index] = null;
        foreach (var card in _cards)
        {
            if (card != null)
            {
                card.SetActive(true);
            }
        }
    }

    public void ShowInfo(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_cards[i] != null && i != index)
            {
                _cards[i].SetActive(false);
            }
            if (_cards[i] != null && i == index)
            {
                _cards[i].SetActive(true);
            }
        }
    }

}
