using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> platformList;
    [SerializeField]private GameObject firstPlatform;
    private GameObject currentPlatform;
    private Vector3 hitPosition;
    private Platform currentPlatformScript;
    
    
    public Color newColor;
    public Material targetMaterial;
    
    
    
    
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
        
        /*
        if (Vector3.Distance(hitPosition, currentPlatformScript.endPosition.position)<2f)
        {
            
            Debug.Log("SpawnPlatform");
            SpawnPlatform();
        }
        */
    }

    private void SpawnPlatform()
    {
        GameObject randomPlatform = platformList[Random.Range(0, platformList.Count)];

        Transform spawnTransform = currentPlatformScript.endPosition;
        
        GameObject newPlatform = Instantiate(randomPlatform, currentPlatformScript.endPosition.position, Quaternion.identity);
        
        currentPlatform = newPlatform;
        
        currentPlatformScript = currentPlatform.GetComponent<Platform>();
        
        Debug.Log(" ******************************* "+newPlatform.transform.GetChild(0).gameObject.transform.position);

    }
    
    
}
