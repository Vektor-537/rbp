using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snar : MonoBehaviour
{
    [Tooltip("move speed")]
    [SerializeField] public float move_speed = 1f;
    public Rigidbody2D rb;
    private Vector2 move = new Vector2(1, 1);
    public float destroy_time = 5.0f;
    public float life_time = 0.0f;
    public bool up = false;
    public bool live = true;
    private bool Force = false;
    private bool Impulse = true;
    public bool off = false;
    private Vector2 def = new Vector2(0, 1);
    [SerializeField] public poolobj Poolobj;
    [SerializeReference] public string snar_;
    private Animator animator_; 
 
    private bool debug_ = false;
    public void debug(bool d) { debug_ = d; }
    // Start is called before the first frame update
    void Start()
    {     
        animator_ = gameObject.GetComponent<Animator>();
    }
   public void init()
    {
        animator_ = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      

        if (up)
        {
            move = transform.rotation * def;
            move = move.normalized;
            up = false;
            if (Force){ rb.AddForce(move * move_speed, ForceMode2D.Force); }
            if (Impulse){ rb.AddForce(move * move_speed, ForceMode2D.Impulse); }
        }
        life_time += Time.fixedDeltaTime;
        if ((life_time > destroy_time)|off)
        {
            if (debug_) { Debug.Log("off " + off + " life_time " + life_time); }
            Poolobj.ReturnToPool();
            off = false;
            //life_time = 0.0f;
        }
        //   rb.MovePosition(rb.position + move * move_speed * Time.fixedDeltaTime);Invoke("ReStart",1.0f); 
    }
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
     
    }
    public void ReStart()
    {
        if (debug_)
        {
            Debug.Log("ReStart");
        }
        life_time = 0.0f;
        gameObject.SetActive(true);
   
        up = true;
        live = true;
        animator_.SetBool("life", true);
    }
    void OnBecameInvisible()
    {
        Poolobj.ReturnToPool();
    }
    public string getSnar()
    {
        return snar_;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (live) {
            if (debug_)
            {
                Debug.Log("hit", other);
            }
            other.BroadcastMessage("ApplyDamage", 5.0f);
            animator_.SetTrigger("boom");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
            live = false;
            animator_.SetBool("life", false);
        }
    }

    }