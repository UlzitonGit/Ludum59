using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    private int _index;
    private MoveUIList _moveUIList;
    private PlayerManager _playerManager;

    public void Init(int index, MoveUIList moveUIList, PlayerManager playerManager)
    {
        this._index = index;
        this._moveUIList = moveUIList;
        this._playerManager = playerManager;
        GetComponent<Button>().onClick.AddListener(() => _moveUIList.RemoveMove(index));
    }

    public void ChangeIndex(int index)
    { 
        GetComponent<Button>().onClick.RemoveAllListeners();
        this._index = index;
        GetComponent<Button>().onClick.AddListener(() => _moveUIList.RemoveMove(index));
    }
}
