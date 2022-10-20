using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    Transform cam;
    Vector3 lpos;
    public float pem = 1f;
    float tusx;
    // Start is called before the first frame update
    void Start()
    {
      //  QualitySettings.vSyncCount = 1;
        cam = Camera.main.transform;
       lpos= cam.position;
        Sprite s = GetComponent<SpriteRenderer>().sprite;
        Texture2D t= s.texture;
        tusx = t.width / s.pixelsPerUnit;
        int sum = 0;
        for (int i=0;i<40;i++) { sum += i; }
        Debug.Log("sum = "+sum);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 d = cam.position - lpos;
        d.z = 0;

        lpos = cam.position;
        transform.position += d*pem;
    }
}
