using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_move : MonoBehaviour
{
    [Tooltip("move speed")]
    [SerializeField] public float move_speed = 5f;
    public Rigidbody2D rb;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
     //   Camera.main.GetComponent<cameraFollow>().setFollov(rb);
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate() {
        rb.MovePosition(rb.position+move* move_speed*Time.fixedDeltaTime);
    
    }
}
