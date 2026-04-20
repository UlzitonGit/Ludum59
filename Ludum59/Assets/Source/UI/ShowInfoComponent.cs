using UnityEngine;
using UnityEngine.EventSystems;

public class ShowInfoComponent : MonoBehaviour, IPointerEnterHandler
{
    public bool canShow;
    [SerializeField] DropZone _mainClass;
    private int i;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(canShow)
            _mainClass.ShowInfo(i);
    }

    public void SetIndex(int index)
    {
        i=index;
    }
}
