using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> platformList;
    [SerializeField] private GameObject rightPlatform;
    [SerializeField] private GameObject leftPlatform;
    [SerializeField] private GameObject firstPlatform;
    private GameObject currentPlatform;
    private GameObject selectedPlatform;
    private Vector3 hitPosition;
    private Platform currentPlatformScript;
    
    
    public Color newColor;
    public Material targetMaterial;


    private int _spawnedPlatformCount;
    private int _spawnedRightPlatform;
    private int _spawnedLeftPlatform;
    private bool _spawnRightPlatform;
    private bool _spawnLeftPlatform;
    private bool _spawnRandom;
    
    
    
    void Start()
    {
        currentPlatform = firstPlatform;
        currentPlatformScript = currentPlatform.GetComponent<Platform>();
        targetMaterial.color = newColor;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                hitPosition = hit.point;
                if (hit.collider.isTrigger)
                {
                    Debug.Log("spawn platform hit detect");
                    SpawnPlatform();
                }
                
            }
        }
        
    }

    private void SpawnPlatform()
    {
        for (var i = 0; i < 25; i++)
        {
            var decider = CheckWhatToSpawn();
            float random;
            switch (decider)
            {
                case 3:
                    random = Random.Range(1, 3);
                    if (random<=1)
                    {
                        selectedPlatform = rightPlatform;
                        Spawn();
                        _spawnedRightPlatform++;
                    }
                    else
                    {
                        selectedPlatform = leftPlatform;
                        Spawn();
                        _spawnedLeftPlatform++;
                    }
                    i++;
                    //Debug.Log(selectedPlatform+"case 3");
                    break;
                
                case 2:
                    selectedPlatform = leftPlatform;
                    Spawn();
                    Spawn();
                    _spawnedLeftPlatform+=2;
                    i++;
                    //Debug.Log(selectedPlatform+"case 2");
                    break;
                    
                case 1:
                    selectedPlatform = rightPlatform;
                    Spawn();
                    Spawn();
                    _spawnedRightPlatform+=2;
                    i++;
                    //Debug.Log(selectedPlatform+"case 1");
                    break;
                
                case 4:
                    random = Random.Range(1, 5);
                    //Debug.Log(random);
                    selectedPlatform = random<=1 ? rightPlatform : leftPlatform;
                    if (random<=1)
                    {
                        selectedPlatform = rightPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedRightPlatform+=4;
                    }
                    else if (random<=2)
                    {
                        selectedPlatform = leftPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedLeftPlatform+=4;
                    }
                    else if (random<=3)
                    {
                        selectedPlatform = rightPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedRightPlatform+=5;
                    }
                    else
                    {
                        selectedPlatform = leftPlatform;
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        Spawn();
                        _spawnedLeftPlatform+=5;
                    }
                    i++;
                    //Debug.Log(selectedPlatform+"case 4");
                    break;
            }
        }
        
        
        

    }

    private void Spawn()
    {
        GameObject newPlatform = Instantiate(selectedPlatform, currentPlatformScript.endPosition.position, Quaternion.identity);
        
        currentPlatform = newPlatform;
        
        currentPlatformScript = currentPlatform.GetComponent<Platform>();

        _spawnedPlatformCount++;
    }

    private int CheckWhatToSpawn()
    {
        
        if (_spawnedLeftPlatform>_spawnedRightPlatform+5)
        {
            return 1;
        }
        
        if (_spawnedRightPlatform>_spawnedLeftPlatform+5)
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
    
    
}
