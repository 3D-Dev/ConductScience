using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject PlatformObject;
    public float radiusitneedstobespawned;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePrefab();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GeneratePrefab()
    {
        Instantiate(PlatformObject, new Vector3(Random.Range(-radiusitneedstobespawned, radiusitneedstobespawned), 0, Random.Range(-radiusitneedstobespawned, radiusitneedstobespawned)), Quaternion.identity);
        TrailProducer.Instance.canmove = true;
    }
}
