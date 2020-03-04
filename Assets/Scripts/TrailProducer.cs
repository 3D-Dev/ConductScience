using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experience;

public class TrailProducer : MonoBehaviour
{
    private static TrailProducer instance;
    public static TrailProducer Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TrailProducer>();

            return instance;
        }
    }

    public bool canmove;
    public bool collisionflag;
    public Quaternion rotation;
    //public bool 
    public GameObject TrailHolder;
    public GameObject trailObject;
    public GameObject RestartButton;
    public GameObject ExportButton;
    public List<GameObject> trailObjectsList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjectsGenerate());
    }
    IEnumerator ObjectsGenerate()
    {
        GameObject temp = Instantiate(trailObject, transform.position, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(0.07f);
        trailObjectsList.Add(temp);
        temp.transform.parent = TrailHolder.transform;
        StartCoroutine(ObjectsGenerate());

    }
    public void Enabletrail()
    {
        GameObject temp = Instantiate(new GameObject());
        foreach (Transform a in TrailHolder.transform)
        {
            a.GetComponent<MiniMapComponent>().enabled = true;
            a.parent = temp.transform;
        }
        RestartButton.gameObject.SetActive(true);
        ExportButton.gameObject.SetActive(true);
        ExperienceData.Instance.isActive = true;
        canmove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canmove == true && ExportButton.gameObject.activeSelf== true)
            ExportButton.gameObject.SetActive(false);
    }
}
