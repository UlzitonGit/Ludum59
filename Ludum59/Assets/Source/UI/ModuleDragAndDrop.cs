using UnityEngine;
using UnityEngine.EventSystems;

public class ModuleDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private ModuleInfo modulePrefab;
    private ModsUIController modsUIController;
    private Vector3 startPosition;
    private Transform startParent;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private GameObject prefab;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        modsUIController = FindAnyObjectByType<ModsUIController>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform);
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 localPoint))
        {
            transform.localPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        
        GameObject dropZone = GetDropZone(eventData);
        
        if (dropZone != null && dropZone.CompareTag("DropZone"))
        {
            DropZone zone = dropZone.GetComponent<DropZone>();
            if (zone != null)
            {
                zone.OnObjectDropped(modulePrefab);
                Destroy(gameObject);
                modsUIController.AddUsedCards();
                if (TutorialController.Instance.isTutorial)
                {
                    if (TutorialController.Instance.cardsPicked == 0)
                    {
                        TutorialController.Instance.SwitchPanel(7);
                        TutorialController.Instance.cardsPicked = 1;
                    }
                    else if (TutorialController.Instance.cardsPicked == 1)
                    {
                        TutorialController.Instance.SwitchPanel(10);
                        TutorialController.Instance.cardsPicked = 2;
                    }
                }
            }
        }
        else
        {
            ReturnToStart();
        }
    }

    private GameObject GetDropZone(PointerEventData eventData)
    {
        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        
        foreach (var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("DropZone"))
                return hit.gameObject;
        }
        return null;
    }

    private void ReturnToStart()
    {
        transform.position = startPosition;
        transform.SetParent(startParent);
    }
}