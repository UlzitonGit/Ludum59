using System;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawnController : MonoBehaviour
{
    [SerializeField] private Transform spp;
    [SerializeField] private GameObject chipPrefab;
    [SerializeField] private GameObject button;
    private List<GameObject> chips = new List<GameObject>();

    public void Spawn()
    {
        button.SetActive(true);
          
        AudioManager.Instance.Play("Chips");
        for (int i = 0; i < 3; i++)
        {
            chips.Add(Instantiate(chipPrefab, spp.position, Quaternion.identity));
        }
        TutorialController.Instance.ShowHint(2);
    }

    public void RemoveChips()
    {
        foreach (var chip in chips)
        {
            Destroy(chip.gameObject);
        }
        chips.Clear();
        TutorialController.Instance.HideHint(2);
    }
}
