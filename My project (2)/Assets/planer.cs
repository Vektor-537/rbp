using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planer : MonoBehaviour
{
   public  List<GameObject> target ;
    public List<GameObject> segList = new List<GameObject>();
    public List<GameObject> globalSegList; 
    public List<pool> Pool;
    public GameObject deat;
    private bool debug_ = false;
    public void debug(bool d) { debug_ = d;  }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setTargets(List<GameObject>t) { target = t; }
    public void setGlobalSegList(List<GameObject> t) { globalSegList = t; }
    public void setPool(List<pool> p) { Pool = p; }
    public GameObject spavnSeg(GameObject seg, Vector3 pos) {
        GameObject buf = Instantiate(seg, transform.position+pos , transform.rotation, transform);
        if (buf.TryGetComponent(out seg sg))
        {
            if (target != null) { sg.setTargets(target); } else { Debug.Log("target = null"); }
            if (Pool != null) { sg.setPool(Pool); } else { Debug.Log("pool = null"); }
            if (globalSegList != null) { globalSegList.Add(buf); } else { Debug.Log("globalSegList = null"); }
            segList.Add(buf);
        }
        else 
        {
            if (debug_) { Debug.Log("no sg"); }
        }
        //seg sg = buf.GetComponent<seg>();

        return buf;
    }
    public void spavnSeg(GameObject seg) { spavnSeg( seg,new Vector3(0,0,0)); }
    public void deadSeg(GameObject seg) {
        segList.RemoveAll(item => item == seg);
        if (segList.Count <= 0) { deadPlaner(); }
    }
    public void deadPlaner() {

        if (deat != null)
        {
            Instantiate(deat, transform.parent);
        }
        Destroy(gameObject,2.0f);
    }
}
