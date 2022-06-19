
using UnityEngine;



public class CellGenerate : MonoBehaviour
{
    public GameObject Parent;
    public GameObject Cell;
    public int rowCells = 5;
    public int columnCells = 5;
    float tside;
    GameObject[,] objCellArray = new GameObject[1,1];
    public bool Island;
    [SerializeField]
    Material otherSide = null;
    [ContextMenu("Generate")]

    public void CellGen()
    {
        Vector3[,] cellarray = new Vector3[rowCells, columnCells];
        objCellArray = new GameObject [rowCells, columnCells];
        tside = Cell.transform.localScale.x / 100;
        float g = Mathf.Sqrt(3) / 2 * tside;
        
        for (int i = 0; i < rowCells; i++)
        {
            for (int j = 0; j < columnCells; j++)
            {
                if (j % 2 == 0)
                {
                    GameObject obj = Instantiate(Cell, new Vector3(Cell.transform.position.x + 1.5f * tside * j, Cell.transform.position.y, Cell.transform.position.z + g * 2 * i), Quaternion.Euler(-90, 30, 0));
                    obj.transform.parent = Parent.transform;
                    cellarray[i, j] = obj.transform.position;
                    objCellArray[i, j] = obj;
                }
                else
                {
                    GameObject obj = Instantiate(Cell, new Vector3(Cell.transform.position.x + 1.5f * tside * j, Cell.transform.position.y ,(Cell.transform.position.z + g * 2 * i) + g), Quaternion.Euler(-90, 30, 0));
                    obj.transform.parent = Parent.transform;
                    cellarray[i, j] = obj.transform.position;
                    objCellArray[i, j] = obj;                 
                }
            }
        }
        for (int i = 0; i < rowCells / 2; i++)
        {
            for (int j = 0; j < columnCells; j++)
            {



                objCellArray[i, j].GetComponent<MeshRenderer>().material = otherSide;
                objCellArray[i, j].gameObject.layer = 8;
            }
        }
      
        Cell.SetActive(false);
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        for (int i = 0;i < objCellArray.GetLength(0); i++)
        {
            for (int j = 0; j < objCellArray.GetLength(1); j++)
            {
                Destroy(objCellArray[i, j]);
            }
        }
    }
    

}
