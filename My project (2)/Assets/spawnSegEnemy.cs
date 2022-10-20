using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSegEnemy : MonoBehaviour
{
    [SerializeReference] public List<GameObject> seg;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject s in seg)
        {
            gameObject.GetComponent<planer>().spavnSeg(s, new Vector3(0, 0, 0));
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
