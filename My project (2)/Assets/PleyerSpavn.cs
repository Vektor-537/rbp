using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PleyerSpavn : MonoBehaviour
{
    [SerializeReference] public GameObject block;
    [SerializeReference] public GameObject cam;
    List<GameObject> all;
    GameObject buf;
    Vector3 pos = new Vector3(0, 0, 0);
    void Start()
    {
        buf=  transform.GetComponent<AllHitbox>().spavnPlaner(block,pos);
        cam.GetComponent<CinemachineVirtualCamera>().m_Follow = buf.transform;

     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var foundCanvasObjects = FindObjectsOfType<CanvasRenderer>();
            Debug.Log(foundCanvasObjects + " : " + foundCanvasObjects.Length);  
        }
        
    }
}
