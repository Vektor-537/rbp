using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seg : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> targets;
    public List<GameObject> turList = new List<GameObject>();
    public float hp = 100.0f;
    public List<pool> Pool;
    public GameObject deat;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setTargets(List<GameObject> t) { targets = t; }
    public void setPool(List<pool> p) { Pool = p; }
    public void spavnTur(GameObject tur, Vector3 pos)
    {
        GameObject buf = Instantiate(tur, transform.position + pos, transform.rotation, transform);
        tur t = buf.GetComponent<tur>();
        if (targets != null) { t.setTargets(targets); } else { Debug.Log("target = null"); }
        string snar = t.getSnar();

        if (Pool != null)
        {
            foreach (pool p in Pool)
            {
                if (p.getSnar() == snar) { t.setPool(p); break; }
            }
        }
        else 
        { 
            //Debug.Log("pool = null"); 
        }

        turList.Add(buf);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //   Debug.Log(other);
    }
    void ApplyDamage(float t)
    {
        //  Debug.Log(t);
        hp -= t;
        if (hp <= 0)
        {
            //seg.RemoveAll(item => item == null);
            transform.parent.GetComponent<planer>().deadSeg(gameObject);
            if (deat != null)
            {
                Instantiate(deat, transform.parent);
            }
            Destroy(gameObject);
           // gameObject.
        }
    }
}
