using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{ 
    private float StartPositionX, length;
    public float EffectStrength;
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        StartPositionX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (Camera.transform.position.x * EffectStrength);
        transform.position = new Vector3(StartPositionX + dist, transform.position.y, transform.position.z);
    }
}
