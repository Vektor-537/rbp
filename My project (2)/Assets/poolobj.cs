using UnityEngine;

public class poolobj : MonoBehaviour
{
    public snar Snar;
    public bool debug_ = false;
    public float now = 0.0f, finish =  Mathf.Infinity;
    public bool debug(bool d) { debug_ = d; return debug_; }
    public void ReturnToPool()
    {
        if (Snar!=null) { Snar.ReturnToPool(); } 
        now = 0.0f;
        if (debug_) { Debug.Log("destroy"); }
    }
    public void ReturnToPool(float t)
    {
        if ((now + t)< finish) { finish = now + t; }
        
    }
    public void ReStart()
    {
        now = 0.0f;
        // gameObject.BroadcastMessage("ReStart_");
        Snar.ReStart();
        if (debug_)
        {
            Debug.Log("spawn");
        }
    }
    public void init()
    {
        Snar.init();
    }
    public string getSnar()
    {
        return Snar.getSnar();
    }
    public int getLayer()
    {
        return gameObject.layer;
    }
    void Update()
    {
        now += Time.fixedDeltaTime;
        if (now >= finish) {
            finish = Mathf.Infinity;
            this.ReturnToPool(); 
        }
    }
}

