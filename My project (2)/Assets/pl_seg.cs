using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl_seg : MonoBehaviour
{
    [SerializeReference] public GameObject seg; 
    [SerializeReference] public GameObject bigSeg;
    List<Vector3> pos_seg = new List<Vector3>();
    List<GameObject> buttons = new List<GameObject>();
    [SerializeField] int s_y=-1, f_y=2;
    [SerializeField] int s_x=-1, f_x=2;
    [SerializeReference] public GameObject button;
    public bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = s_y; i < f_y; i++)
        {
            for (int j = s_x; j < f_x; j++)
            {
                if (i == 0 & j == 0 | i == 0 & j == -1 | i == -1 & j == 0 | i == -1 & j == -1)
                {

                }
                else { pos_seg.Add(new Vector3(i, j, 0)); }
            }


        }
        gameObject.GetComponent<planer>().spavnSeg(bigSeg, new Vector3((float)-0.5,(float)- 0.5, 0));
        Debug.Log(""+ transform.name);
        foreach (Vector3 buf in pos_seg) {
            if (start) { gameObject.GetComponent<planer>().spavnSeg(seg, buf); }
            buttons.Add(gameObject.GetComponent<planer>().spavnSeg(button, buf));      
        }
        foreach (GameObject buf in buttons)
        {
            buf.SetActive(!start);

        }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
