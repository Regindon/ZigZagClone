using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformManager : MonoBehaviour
{
    
    [SerializeField] private GameObject rightPlatform;
    [SerializeField] private GameObject leftPlatform;
    [SerializeField] private GameObject firstPlatform;
    private GameObject _currentPlatform;
    private GameObject _selectedPlatform;
    private Platform _currentPlatformScript;
    
    
    [SerializeField] private Material targetMaterial;
    [SerializeField] private Color startColor;
    [SerializeField] private List<Color> colorList = new List<Color>();

    
    [NonSerialized] public int currentPlatformCount;
    private int _spawnedRightPlatform;
    private int _spawnedLeftPlatform;
    private bool _spawnRightPlatform;
    private bool _spawnLeftPlatform;
    private bool _spawnRandom;


    private void Awake()
    {
        Screen.SetResolution(460,812,false);
        SetStartColor();
    }

    void Start()
    {
        _currentPlatform = firstPlatform;
        _currentPlatformScript = _currentPlatform.GetComponent<Platform>();
        
        SpawnPlatform();
    }
    
    void Update()
    {
        if (currentPlatformCount<90)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        for (var i = 0; i < 30; i++)
        {
            var decider = CheckWhatToSpawn();
            float random;
            switch (decider)
            {
                case 3:
                    random = Random.Range(1, 3);
                    if (random<=1)
                    {
                        _selectedPlatform = rightPlatform;
                        Spawn();
                        _spawnedRightPlatform++;
                    }
                    else
                    {
                        _selectedPlatform = leftPlatform;
                        Spawn();
                        _spawnedLeftPlatform++;
                    }
                    i++;
                    break;
                
                case 2:
                    _selectedPlatform = leftPlatform;
                    Spawn();
                    Spawn();
                    _spawnedLeftPlatform+=2;
                    i++;
                    break;
                    
                case 1:
                    _selectedPlatform = rightPlatform;
                    Spawn();
                    Spawn();
                    _spawnedRightPlatform+=2;
                    i++;
                    break;
                
                case 4:
                    random = Random.Range(1, 5);
                    _selectedPlatform = random<=1 ? rightPlatform : leftPlatform;
                    if (random<=1)
                    {
                        _selectedPlatform = rightPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedRightPlatform+=4;
                    }
                    else if (random<=2)
                    {
                        _selectedPlatform = leftPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedLeftPlatform+=4;
                    }
                    else if (random<=3)
                    {
                        _selectedPlatform = rightPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        
                        _spawnedRightPlatform+=3;
                    }
                    else
                    {
                        _selectedPlatform = leftPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedLeftPlatform+=3;
                    }
                    i++;
                    break;
            }
        }
        

    }

    private void Spawn()
    {
        GameObject newPlatform = Instantiate(_selectedPlatform, _currentPlatformScript.endPosition.position, Quaternion.identity);
        
        _currentPlatform = newPlatform;
        
        _currentPlatformScript = _currentPlatform.GetComponent<Platform>();
        
        currentPlatformCount++;
    }

    private int CheckWhatToSpawn()
    {
        if (_spawnedLeftPlatform>_spawnedRightPlatform+4)
        {
            return 1;
        }
        if (_spawnedRightPlatform>_spawnedLeftPlatform+4)
        {
            return 2;
        }
        if (Mathf.Abs(_spawnedLeftPlatform-_spawnedRightPlatform)<3)
        {
            return 4;
        }
        else
        {
            return 3;
        }
    }

    private void SetRandomColorPlatform()
    {
        targetMaterial.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
     
        // hexa code 77CAD7
        //Start HSV Code -->  188 - 72 - 79 - 100
    }

    public void SetPlatformColor(int i)
    {
        if (colorList.Count<i)
        {
            SetRandomColorPlatform();
        }
        else
        {
            targetMaterial.color = colorList[i];
        }
    }

    public void SetStartColor()
    {
        targetMaterial.color = startColor;
    }
    
    
}
