using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findEnemy : MonoBehaviour
{
    public float dis= Mathf.Infinity;
    public GameObject pos=null;
    public  CircleCollider2D circleCollider2D;
    public int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        circleCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        dis = Mathf.Infinity;
    }
    void OnTriggerStay2D(Collider2D collider)
    {
      
        Vector3 diff = collider.gameObject.transform.position - transform.position;
        float curDistance = diff.sqrMagnitude;
        if (curDistance < dis)
        {
            pos = collider.gameObject;
            dis = curDistance;
        }
    }
    public GameObject getClosestEnemy() {
       
        return pos;
    }
    public bool findClosestEnemy()
    {
        if (circleCollider2D.enabled) 
        {
            a++;
            if (a>1)
            {
                a = 0;
                circleCollider2D.enabled = false;
                return true; 
            }
        }
        circleCollider2D.enabled = true;
        return false;
    }
    public void setRadius(float r) { circleCollider2D.radius = r; }
}
