using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private float detachDelay;
    [SerializeField] private float respawnDelay;
    
    private Rigidbody2D _currentBallRigidbody2D = null;
    private SpringJoint2D _joint = null;
    
    private Camera _mainCamera;
    private bool _isDragging;
    
    void Start()
    {
        _mainCamera = Camera.main;
        SpawnBall();
    }
    
    void Update()
    {
        if (_currentBallRigidbody2D == null) return;
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (_isDragging)
            {
                LaunchBall();
            }

            _isDragging = false;
            
            return;
        }

        _isDragging = true;
        
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector3 worldFingerPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

        _currentBallRigidbody2D.isKinematic = true;
        _currentBallRigidbody2D.position = worldFingerPosition;
    }

    private void SpawnBall()
    {
        //pivot.gameObject.SetActive(true);
        GameObject ballInstance = Instantiate(ballPrefab, pivot.position, quaternion.identity);

        _currentBallRigidbody2D = ballInstance.GetComponent<Rigidbody2D>();
        _joint = ballInstance.GetComponent<SpringJoint2D>();
        _joint.connectedBody = pivot;
    }
    
    private void LaunchBall()
    {
        _currentBallRigidbody2D.isKinematic = false;
        _currentBallRigidbody2D = null;
        
        Invoke(nameof(DetachBall), detachDelay);
    }

    private void DetachBall()
    {
        _joint.enabled = false;
        //_joint.gameObject.SetActive(false);
        _joint = null;
        
        Invoke(nameof(SpawnBall), respawnDelay);
    }
}
