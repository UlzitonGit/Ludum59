using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float _moveDuration = 0.2f;
    [SerializeField] private InputActionReference gameScreen;
    [SerializeField] private InputActionReference modulesScreen;
    bool _isMoving = false;

    private void OnEnable()
    {
        gameScreen.action.Enable();
        gameScreen.action.performed += SmoothMoveScreen;
        modulesScreen.action.Enable();
        modulesScreen.action.performed += SmoothMoveCards;
    }

    private void OnDisable()
    {
        gameScreen.action.Disable();
        gameScreen.action.performed -= SmoothMoveScreen;
        modulesScreen.action.Disable();
        modulesScreen.action.performed -= SmoothMoveCards;
    }

    private void SmoothMoveScreen(InputAction.CallbackContext obj)
    {
        StartCoroutine(SmoothMoving(points[0].position));
    }
    private void SmoothMoveCards(InputAction.CallbackContext obj)
    {
        StartCoroutine(SmoothMoving(points[1].position));
    }

    private IEnumerator SmoothMoving(Vector3 target)
    {
        _isMoving = true;
        Vector3 start = transform.position;
        float elapsed = 0f;
        
        while (elapsed < _moveDuration)
        {
            float t = elapsed / _moveDuration;
            transform.position = Vector3.Lerp(start, target, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.position = target;
        _isMoving = false;
    }
}
