using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Camera _camera;

    private Vector2 _prevMousePosition;

    private Vector2 _mousePosition;

    [SerializeField]
    private Transform _target;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField]
    private float _alingTime = 0.1f;
    
    private float _sx;

    private float _sy;

    private float _sz;

    private float _direction;

    private float? _lastDirection;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _prevMousePosition = _mousePosition;
            _mousePosition = Input.mousePosition;
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            // _prevMousePosition = _mousePosition;
            // _mousePosition = Input.mousePosition;
            //
            // var direcion = Mathf.Sign((_prevMousePosition.x - _mousePosition.x));
            // var ea = _camera.transform.parent.transform.localEulerAngles;
            // _camera.transform.parent.rota

            var axis = Input.GetAxis("Mouse X");
            
            if (Mathf.Approximately(axis, Mathf.Epsilon))
                return;

            _direction =  axis > 0 ? 1f : -1f;

            _camera.transform.parent.Rotate(Vector3.up * _direction * Time.deltaTime * 100f);

        }

        // if (_lastDirection.HasValue)
        // {
        //     if (_lastDirection.Value > 0 && _direction < 0)
        //     {
        //         _sx = 0f;
        //         _sy = 0f;
        //         _sz = 0f;
        //     }
        //     
        //     if (_lastDirection.Value < 0 && _direction > 0)
        //     {
        //         _sx = 0f;
        //         _sy = 0f;
        //         _sz = 0f;
        //     }
        //     
        // }
        

        var xAngle = Mathf.SmoothDampAngle(_rigidbody.transform.eulerAngles.x, _camera.transform.eulerAngles.x, ref _sx,
            _alingTime);
        
        var yAngle = Mathf.SmoothDampAngle(_rigidbody.transform.eulerAngles.y, _camera.transform.eulerAngles.y, ref _sy,
            _alingTime);

        var zAngle = Mathf.SmoothDampAngle(_rigidbody.transform.eulerAngles.z, _camera.transform.eulerAngles.z, ref _sz,
            _alingTime);


        
        
        _rigidbody.transform.eulerAngles = new Vector3(xAngle, yAngle, zAngle);

        _lastDirection = _direction;
        // _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, _camera.transform.rotation, Time.deltaTime * _speed);
    }
    
    private float _speed = 1;
    
    private void OnGUI()
    {
        _speed = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), _speed, 0.0F, 100.0F);
    }
}
