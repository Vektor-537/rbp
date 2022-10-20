using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(pool))]
public class AllHitbox : MonoBehaviour
{
    [SerializeReference] public List<GameObject> targets; 
    public List<GameObject> planers=new List<GameObject>();
    public List<GameObject> seg = new List<GameObject>();
    [SerializeReference] public List <pool> Pool; 
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        seg.RemoveAll(item => item == null); 
        planers.RemoveAll(item => item == null);
    }
    public List<GameObject> getTargets() { return targets; }
    public List<GameObject> getSeg() { return seg; }
    public GameObject spavnPlaner(GameObject planer, Vector3 pos)
    {
        GameObject buf = Instantiate(planer, transform.position + pos, transform.rotation, transform);
        planer pl = buf.GetComponent<planer>();
        if (targets != null) { pl.setTargets(targets); } else { Debug.Log("target = null"); }
        if (Pool != null) { pl.setPool(Pool); } else { Debug.Log("pool = null"); }
        pl.setGlobalSegList(seg);  
        planers.Add(buf);
        return buf;

    }
   
}
