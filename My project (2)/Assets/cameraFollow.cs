using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Rigidbody2D follov;
    public void setFollov(Rigidbody2D f) { follov = f; }
    public void setFollov() { }
    public float speed = 0.125f;
    Vector3 z = new Vector3(0, 0, -10);

    void FixedUpdate()
    {
        if (follov != null)
        {
            Vector3 dp = follov.transform.position + z;
            Vector3 sp = Vector3.Lerp(transform.position, dp, speed);
            transform.position = sp;
        }
    }
}
