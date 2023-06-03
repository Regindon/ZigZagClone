using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public Transform endPosition;
    [SerializeField] private float speed;
    [SerializeField] private GameObject platformChild;
    private Transform _objectTransform;
    private Vector3 _translateVector3;
    [SerializeField] private PlatformManager platformManager;
    private GameObject _platformManagerGameObject;
    
    private void Start()
    {
        _platformManagerGameObject = GameObject.FindWithTag("PlatformManager");
        platformManager = _platformManagerGameObject.GetComponent<PlatformManager>();
        _objectTransform = platformChild.transform;
        _translateVector3 = new Vector3(0, -1, 0);
    }

    private void Update()
    {
        Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(_objectTransform.position);
        
        if (objectScreenPosition.y < 110)
        {
            transform.Translate(_translateVector3 * speed * Time.deltaTime);
        }

        if (objectScreenPosition.y < -600)
        {
            platformManager.currentPlatformCount--;
            Destroy(gameObject);
        }
    }

    
}
