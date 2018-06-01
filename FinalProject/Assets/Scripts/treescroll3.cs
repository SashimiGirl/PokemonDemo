using UnityEngine;
using System.Collections;

public class treescroll3 : MonoBehaviour
{
    private MeshRenderer texture;
    public int sortingLayer;



    // Use this for initialization
    void Start()
    {
        texture = GetComponent<MeshRenderer>();
        texture.GetComponent<Renderer>().sortingLayerID = sortingLayer;
    }

    // Update is called once per frame
    void Update()
    {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime / 100f;
        mat.mainTextureOffset = offset;
    }
}
