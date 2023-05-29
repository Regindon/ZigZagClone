using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 _movement;
    private bool _xDirection;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _xDirection = !_xDirection;
        }

        _movement = _xDirection ? new Vector3(-1, 0, 0) : new Vector3(0, 0, 1);
        
        transform.Translate(_movement * (speed * Time.deltaTime));
        
    }
}
