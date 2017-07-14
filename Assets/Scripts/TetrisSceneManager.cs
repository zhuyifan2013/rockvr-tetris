using UnityEngine;
using System.Collections;

public struct FieldBlock
{
    public Vector2 blockPosition;
    public bool isFull;
    public GameObject fieldBlockPrefab;

    public FieldBlock(Vector2 blockPostion, bool isFull, GameObject fieldBlockPrefab)
    {
        this.blockPosition = blockPostion;
        this.isFull = isFull;
        this.fieldBlockPrefab = fieldBlockPrefab;
        this.fieldBlockPrefab.transform.position = this.blockPosition;
    }
}

public class TetrisSceneManager : MonoBehaviour
{

    public int FieldWidth = 10;
    public int FieldLenght = 20;
    public FieldBlock[,] field;
    public GameObject blockPrefab;

    private void Awake()
    {
        blockPrefab = Resources.Load<GameObject>("Block");
    }
    // Use this for initialization
    void Start()
    {
        CreateTetrisScene();
        IsFullBlock();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateTetrisScene()
    {
        field = new FieldBlock[FieldWidth, FieldLenght];
        for (int y = 0; y < FieldWidth - 1; y++)
        {
            for (int x = 0; x < FieldLenght - 1; x++)
            {
                field[y, x] = new FieldBlock(new Vector2(y, x), true, Instantiate(blockPrefab,this.gameObject.transform,false)as GameObject);
            }
        }
    }
    void IsFullBlock()
    {
        for (int y = 0; y < FieldWidth - 1; y++)
        {
            for (int x = 0; x < FieldLenght - 1; x++)
            {
                if (field[y, x].isFull)
                {
                    GameObject obj= GameObject.CreatePrimitive(PrimitiveType.Cube);
                    obj.transform.parent = field[y, x].fieldBlockPrefab.transform;
                    obj.transform.position = field[y, x].blockPosition;
                    obj.transform.localScale = new Vector3(0.99f, 0.99f, 0.99f);
                }
            }
        }
    }
}
