using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    [SerializeField] private GameObject[] hints;
    public static TutorialController Instance { get; private set; }

    public int ScreenMoveCount = 0;
    
    public bool isTutorial = true;

    public int cardsPicked = 0;

    public int StagePick = 0;

    [HideInInspector] public bool CanMoveScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        isTutorial = PlayerPrefs.GetString("Tutorial") == "Tutorial";
        for (int i = 0; i < panels.Length; i++)
        {
            {
                panels[i].SetActive(true);
                print( panels[i].name);
                if ( panels[i].GetComponentInChildren<Button>(true) != null)
                {
                    var i1 = i;
                    panels[i].GetComponentInChildren<Button>(true).onClick.AddListener(() => SwitchPanel(i1));
                    print("true");
                }
                else
                {
                    print("false");
                }
                panels[i].SetActive(false);
            }
        }

        if (isTutorial)
        {
            panels[0].SetActive(true);
        }
    }

    public void SwitchPanel(int index)
    {
        index++;
        print("SwitchPanel" + index);
  
        if(panels[index - 1].activeInHierarchy == false && index != 1) return;
        panels[index - 1].SetActive(false);
     

        if (index < panels.Length)
        {
            panels[index].SetActive(true);   
        }
        else
        {
            isTutorial = false;
            PlayerPrefs.SetString("Tutorial", "None");
        }
    }

    public void SetCanMoveScreen(bool canMoveScreen)
    {
        CanMoveScreen = canMoveScreen;
    }

    public void ShowHint(int hint)
    {
        hints[hint].SetActive(true);
    }

    public void HideHint(int hint)
    {
        hints[hint].SetActive(false);
    }
}
