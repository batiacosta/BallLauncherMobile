
using System;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public bool CanDetach
    {
        get => _canDetach;
        set
        {
            _canDetach = value;
            if (_joint2D is null) _joint2D = GetComponent<SpringJoint2D>();
            if (_pivot is null) _pivot = _joint2D.connectedBody;
            if (_canDetach) _joint2D.enabled = true;
        }
    }

    private bool _canDetach = false;
    private SpringJoint2D _joint2D = null;
    private Rigidbody2D _pivot = null;

    private void Update()
    {
        if (!_canDetach) return;
        
        var distance = Vector2.Distance(transform.position, _pivot.position);
        if (distance < 0.5f)
        {
            _joint2D.enabled = false;
            _canDetach = false;
        }
    }

    public void EnableSpringJoint()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        _joint2D.enabled = true;
    }
}
