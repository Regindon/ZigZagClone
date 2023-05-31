using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 _movement;
    private bool _xDirection;
    private bool _move;
    
    
    void Update()
    {
        Debug.Log(_move);
        
        if (!_move)
        {
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        if (Input.GetMouseButtonDown(0) && _move)
        {
            _xDirection = !_xDirection;
        }

        

        _movement = _xDirection ? new Vector3(-1, 0, 0) : new Vector3(0, 0, 1);
        
        transform.Translate(_movement * (speed * Time.deltaTime));
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            _move = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            _move = false;
        }
    }
}
