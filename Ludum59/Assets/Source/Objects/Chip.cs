using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chip : MonoBehaviour
{
    [SerializeField] private GameObject[] chips;

    private void Start()
    {
        chips[Random.Range(0, chips.Length)].SetActive(true);
    }
}
