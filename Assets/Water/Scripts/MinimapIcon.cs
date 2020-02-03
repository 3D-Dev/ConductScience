using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
    public Camera mainCarmera;
    public Camera miniMapCamera;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        mainCarmera = Camera.main.gameObject.GetComponent<Camera>();
        //miniMapCamera = gameObject.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<GameObject>();
        this.transform.position = mainCarmera.transform.position;
        this.transform.rotation = mainCarmera.transform.rotation;
    }
}
