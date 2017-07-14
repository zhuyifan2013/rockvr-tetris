using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    public string[] block;
    public GameObject blockCube;
    private float halfSize;
    private float halfSizeFloat;
    private float childSize;
    private bool[,] blockMatrix;
    private int size;

    // Use this for initialization
    void Start()
    {
        size = block.Length;
        int width = block[0].Length;
        halfSize = (size + 1) * 0.5f;
        childSize = (size - 1) * 0.5f;
        halfSizeFloat = size * 0.5f;
        blockMatrix = new bool[size, size];
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (block[y][x] == '1')
                {
                    blockMatrix[y, x] = true;
                    var cube = Instantiate(blockCube, new Vector3(x - childSize, childSize - y, 0), Quaternion.identity) as GameObject;
                    cube.transform.parent = this.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
