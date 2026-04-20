using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform middlePos;
    [SerializeField] private Transform[] points;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float _moveDuration = 0.2f;
    [SerializeField] private float _rotDuration = 0.2f;
    [SerializeField] private InputActionReference gameScreen;
    [SerializeField] private InputActionReference modulesScreen;
    [SerializeField] private InputActionReference collectScreen;
    bool _isMoving = false;

    private void Start()
    {
        StartCoroutine(SmoothMoving(points[2].position, points[2].rotation));
    }

    private void OnEnable()
    {
        gameScreen.action.Enable();
        gameScreen.action.performed += SmoothMoveScreen;
        modulesScreen.action.Enable();
        modulesScreen.action.performed += SmoothMoveCards;
        collectScreen.action.Enable();
        collectScreen.action.performed += SmoothMoveCollect;
    }

    private void OnDisable()
    {
        gameScreen.action.Disable();
        gameScreen.action.performed -= SmoothMoveScreen;
        modulesScreen.action.Disable();
        modulesScreen.action.performed -= SmoothMoveCards;
        collectScreen.action.Disable();
        collectScreen.action.performed -= SmoothMoveCollect;
    }

    private void SmoothMoveScreen(InputAction.CallbackContext obj)
    {
        if (TutorialController.Instance.isTutorial)
        {
            if (TutorialController.Instance.StagePick != 1 || !TutorialController.Instance.CanMoveScreen)
            {
                return;
            }
        }
        StartCoroutine(SmoothMoving(points[0].position, points[0].rotation));
        if (TutorialController.Instance.isTutorial)
        {
            TutorialController.Instance.StagePick = 2;
            TutorialController.Instance.CanMoveScreen = false;
            TutorialController.Instance.SwitchPanel(13);
        }
    }
    private void SmoothMoveCards(InputAction.CallbackContext obj)
    {
        if (TutorialController.Instance.isTutorial)
        {
            if (TutorialController.Instance.StagePick != 0 || !TutorialController.Instance.CanMoveScreen)
            {
                return;
            }
        }
        StartCoroutine(SmoothMoving(points[1].position, points[1].rotation));
        if (TutorialController.Instance.isTutorial)
        {
            TutorialController.Instance.StagePick = 1;
            TutorialController.Instance.CanMoveScreen = false;
            TutorialController.Instance.SwitchPanel(4);
        }
    }
    private void SmoothMoveCollect(InputAction.CallbackContext obj)
    {
        if (TutorialController.Instance.isTutorial)
        {
            if (TutorialController.Instance.StagePick != 2 || !TutorialController.Instance.CanMoveScreen)
            {
                return;
            }
        }
        StartCoroutine(SmoothMoving(points[2].position, points[2].rotation));
        TutorialController.Instance.CanMoveScreen = false;
        TutorialController.Instance.SwitchPanel(24);
    }

    private IEnumerator SmoothMoving(Vector3 target, Quaternion targetRot)
    {
        if (!_isMoving)
        {
            _isMoving = true;
            Vector3 start = transform.position;
            float elapsed = 0f;
        
           // while (elapsed < _moveDuration)
           // {
           //     float t = elapsed / _moveDuration;
           //     transform.position = Vector3.Lerp(start, middlePos.position, t);
           //     transform.rotation = Quaternion.Slerp(transform.rotation,  middlePos.rotation, t);
            //    elapsed += Time.deltaTime;
            //    yield return null;
            //}
           // start = transform.position;
            //elapsed = 0f;
        
            while (elapsed < _moveDuration)
            {
                float t = elapsed / _moveDuration;
                float r = elapsed / _rotDuration;
                transform.position = Vector3.Lerp(start, target, t);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, r);
                elapsed += Time.deltaTime;
                yield return null;
            }
        
            transform.position = target;
            _isMoving = false;
        }
    }
}
