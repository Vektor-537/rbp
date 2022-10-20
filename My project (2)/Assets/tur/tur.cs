using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tur : MonoBehaviour
{
    private Vector3 point = new Vector3(Mathf.Infinity, 0, 0);
    //  [SerializeReference] turType type;
    public pool Pool;
    public List<GameObject> targets;
    public GameObject obj;
    public float angl = 10.0f;
    public float dist = 10.0f;
    public float anglVel = 2.0f;
    public float dis = Mathf.Infinity;
    public bool fire = false;
    public bool slep = true;
    public bool find = true;
    [SerializeReference] public GameObject animatorObjPref;
    [SerializeReference] public GameObject finder;
    private findEnemy FindEnemy_;
    private Animator animator;
    private Quaternion stand = Quaternion.Euler(0, 0, 0);
    private GameObject animatorObj;
    [SerializeReference] public string snar_;
    // Start is called before the first frame update
    void Start()
    {
        animatorObj = Instantiate(animatorObjPref, transform.position, transform.rotation, transform);
        animatorObj.GetComponent<fire>().setTur(this);
        animator = animatorObj.GetComponent<Animator>();
        animator.SetBool("fire", false);
        animator.SetBool("slep", true);
        animator.SetFloat("speed", Random.Range(0.9f, 1.1f));
        finder.layer = Pool.getLayer();
        FindEnemy_ = finder.GetComponent<findEnemy>();
        FindEnemy_.setRadius(dist);
    }
    void Update()
    {
        if (find)
        {
            if (FindEnemy_.findClosestEnemy()) {
                obj = FindEnemy_.getClosestEnemy();
                find = false;
                if (obj != null)
                {
                    point = obj.transform.position;
                    dis = Vector3.Distance(point, transform.position);
                }
                else { dis = Mathf.Infinity; }
            }
        }



        if (dis < dist)
        {
            slep = false;
            animator.SetBool("slep", false);
            Quaternion mark = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
              (Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg - 90));
            transform.rotation = Quaternion.Lerp(transform.rotation, mark, Time.deltaTime * anglVel);
            float angle = Quaternion.Angle(mark, transform.rotation);
            if (Mathf.Abs(angle) < angl)
            {
                transform.rotation = mark;
               fire = true;
                animator.SetBool("fire", true);
            }
        }
        else
        {
            if (!slep)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, stand, Time.deltaTime * anglVel);
                fire = false;
                animator.SetBool("fire", false);
                float angle = Quaternion.Angle(stand, transform.rotation);
                if (Mathf.Abs(angle) < angl)
                {
                    transform.rotation = stand;
                    animator.SetBool("slep", true);
                    slep = true;
                }
            }
        }
    }
    public void setTargets(List<GameObject> t) { targets = t; }
    public void setPool(pool p) { Pool = p; }
    public int a = 0;
    public void fire_()
    {
        if (Pool != null)
        {
            Pool.getFreeElement(transform.position, transform.rotation);
            a += 1;
        }
    }
    public void FindEnemy()
    {
        find = true;
    }
    public string getSnar()
    {
        return snar_;
    }
}
