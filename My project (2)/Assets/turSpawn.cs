using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turSpawn : MonoBehaviour
{
    [System.Serializable]
    public struct turPos
    {
        [SerializeField] public GameObject _gameObject;
        [SerializeField] public Vector3 _pos;
    }
    [SerializeField] public List<turPos> turs;
   
    // Start is called before the first frame update
    void Start()
    {
        foreach (turPos t in turs)
        {
            gameObject.GetComponent<seg>().spavnTur(t._gameObject, t._pos);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
