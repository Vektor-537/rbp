using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeReference] public GameObject block; 
    GameObject buf;
    public Vector3 pos = new Vector3(0, 0, 0); 
    public Vector3 pos1 = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

        buf = transform.GetComponent<AllHitbox>().spavnPlaner(block, pos);
        

    }

    // Update is called once per frame
    void Update()
    {
        pos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pos1 = Camera.main.ScreenToWorldPoint(pos);
            pos1.z = 0;
            buf = transform.GetComponent<AllHitbox>().spavnPlaner(block, pos1);
        }
    }
}
