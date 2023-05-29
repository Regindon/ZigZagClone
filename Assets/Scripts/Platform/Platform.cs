using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public Transform endPosition;
    [SerializeField] private float speed;
    [SerializeField] private GameObject platformChild;
    private MeshRenderer _objectRenderer;
    private Transform _objectTransform;
    private bool _isObjectInLowerPart;
    private int _visibleLimit;
    private Vector3 _translateVector3;
    
    

    private void Start()
    {
        _objectTransform = gameObject.transform;
        _objectRenderer = platformChild.GetComponent<MeshRenderer>();
        _translateVector3 = new Vector3(0, -1, 0);

    }

    private void Update()
    {
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(_objectTransform.position);
        Debug.Log(objectScreenPosition.y);
        
        
        if (objectScreenPosition.y < 30)
        {
            transform.Translate(_translateVector3 * speed * Time.deltaTime);
        }
        
        

        if (objectScreenPosition.y < -600)
        {
            Destroy(gameObject);
        }


    }

    

    
}
