using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experience;
public class PlatformManager : MonoBehaviour
{
    public GameObject PlatformObject;
    public float radiusitneedstobespawned;
    private Vector3 GeneraterPos;
    // Start is called before the first frame update
    void Start()
    {
        GeneraterPos = new Vector3(0, 0, 0);
        GeneratePrefab();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GeneratePrefab()
    {
        GeneraterPos = new Vector3(Random.Range(-radiusitneedstobespawned, radiusitneedstobespawned), 0, Random.Range(-radiusitneedstobespawned, radiusitneedstobespawned));
        Instantiate(PlatformObject, GeneraterPos, Quaternion.identity);
        ExperienceData.Instance.SetEachQuad(GeneraterPos);
        TrailProducer.Instance.canmove = true;
    }
}
