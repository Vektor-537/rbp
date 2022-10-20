using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    public List<poolobj> pool_;
    [SerializeField] GameObject prefObject;
    public poolobj pref;
    [SerializeField] private Transform cont;
    public int min = 100;
    public int max = 10000;
    public bool IsMax = false;
    public int Layer ;
    private void OnValidate() {
        if (IsMax) {
            max = int.MaxValue;
        }
    }
    private void createPool() {
        pool_ = new List<poolobj>();
        for (int i=0;i< min;i++) {
           CreateElement();
        }
    }
    private poolobj CreateElement(bool isActive= false) {
        var buff = Instantiate(pref, cont);

        buff.gameObject.SetActive(isActive);
        buff.gameObject.layer = Layer; 
       buff.init(); 
        if (isActive) { buff.ReStart(); }
       
        pool_.Add(buff);
        return buff;
    }
    private bool TryGetElement(out poolobj output) {
        foreach (var buff in pool_) {
            if (!buff.gameObject.activeInHierarchy) {
                output = buff;
                buff.ReStart();
                return true;
            }
        }
        output = null;
        return false;
    }
    public poolobj getFreeElement() {
        if (TryGetElement(out var buff)) {
            return buff;
        }
        if (IsMax)
        {
            return  CreateElement(true);
        }
        if (pool_.Count< max)
        {
            return CreateElement(true);
        }
        // throw new Exception("Pool is full");
        return null;
    }
    public poolobj getFreeElement(Vector3 pos) {
        poolobj buff = getFreeElement();
        buff.transform.position = pos;
        return buff;
    }
    public poolobj getFreeElement(Vector3 pos, Quaternion vel)
    {
        poolobj buff = getFreeElement();
        buff.transform.position = pos;
        buff.transform.rotation = vel;
        return buff;
    }
    public void Start() {
        Layer = gameObject.layer;
        pref = prefObject.GetComponent<poolobj>();

        createPool();

    }
    public string getSnar()
    {
        return pref.getSnar();
    }
    public int getLayer() {
        return Layer;
    }
}
