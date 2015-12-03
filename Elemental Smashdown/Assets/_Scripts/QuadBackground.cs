using UnityEngine;
using System.Collections;

public class QuadBackground : MonoBehaviour {

    public static BackgroundType currentType = BackgroundType.Water;

    public Material fire;
    public Material grass;
    public Material water;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (currentType == BackgroundType.Fire)
        {
            Renderer mat = this.GetComponent<Renderer>();
            mat.material = fire;
        }
        else if (currentType == BackgroundType.Grass)
        {
            Renderer mat = this.GetComponent<Renderer>();
            mat.material = grass;
        }
        else
        {
            Renderer mat = this.GetComponent<Renderer>();
            mat.material = water;
        }

    }
}
