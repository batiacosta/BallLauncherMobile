
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


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

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        if (_currentBallRigidbody2D == null) return;
        if (Touch.activeTouches.Count == 0)
        {
            if (_isDragging)
            {
                LaunchBall();
            }

            _isDragging = false;
            
            return;
        }

        _isDragging = true;

        Vector2 touchPosition = new Vector2();
        foreach (var touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition;
        }

        touchPosition /= Touch.activeTouches.Count;
        
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
