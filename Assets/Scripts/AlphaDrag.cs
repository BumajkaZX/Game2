
using UnityEngine;

public class AlphaDrag : MonoBehaviour
{
    [SerializeField]
    GameObject hex = null;
    Vector3 defPoint;
    Vector3 defScale;
    [SerializeField]
    float up = 1f;
    [SerializeField]
    float scaleUp = 1f;
    [SerializeField]
    Material blackMat = null;
    [SerializeField]
    Material originalMat = null;
    MeshRenderer meshRenderer;
    [SerializeField]
    MainScript mainScript = null;
    [SerializeField]
    float spawnUp = 0f;
    [SerializeField]
    bool isEmpty;
    bool isOther;
    bool isAttack;
    bool isEmptyScript;
    Vector3 origin;
    GameObject _plot = null;
    GameObject par = null;
    [SerializeField]
    Material AllDone = null;
    bool isUnion;
    [SerializeField]
    GameObject _text = null;
    private void Start()
    {
        if (gameObject.layer == 8)
        {
            isOther = true;
        }
        else if (gameObject.layer == 13)
        {
            isUnion = true;
            Debug.Log(isUnion);
        }
        isAttack = false;
        isEmpty = true;
        isEmptyScript = true;
        originalMat = GetComponent<MeshRenderer>().material;
        meshRenderer = GetComponent<MeshRenderer>();
        origin = transform.position;
        defScale = hex.transform.localScale;
        defPoint = hex.transform.position;
    }
    private void OnMouseEnter()
    {
        if (!isAttack  && isOther && mainScript._attack)
        {
            
            meshRenderer.material = blackMat;
            hex.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y + up, hex.transform.position.z);
            hex.transform.localScale = new Vector3(hex.transform.localScale.x + scaleUp, hex.transform.localScale.y + scaleUp, hex.transform.localScale.z + scaleUp);
        }
        if (isUnion && !mainScript._attack && isEmpty)
        {
            meshRenderer.material = blackMat;
            hex.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y + up, hex.transform.position.z);
            hex.transform.localScale = new Vector3(hex.transform.localScale.x + scaleUp, hex.transform.localScale.y + scaleUp, hex.transform.localScale.z + scaleUp);
        }

    }
    private void OnMouseExit()
    {
        meshRenderer.material = originalMat;
        hex.transform.position = defPoint;
        hex.transform.localScale = defScale;
    }
    private void OnMouseDown()
    {
        if ((mainScript._attack && isOther && mainScript.Choosen == 0 )|| (mainScript._attack && isOther && mainScript.Choosen == 1 && mainScript.RockItem > 0))
        {
            if (!isEmptyScript && !isUnion)
                par.SetActive(true);
            Vector3 cellPos = new Vector3(origin.x, origin.y + spawnUp, origin.z);
            if (!isAttack) 
            mainScript.SpawnAttack(cellPos, isEmpty, _plot, isAttack);
            isAttack = true;
            originalMat = AllDone;
            hex.transform.position = defPoint;
            hex.transform.localScale = defScale;
        }
        if (!mainScript._attack && isUnion)
        {
            
            Vector3 cellPos = new Vector3(origin.x, origin.y + spawnUp, origin.z);
            if (isEmpty)
            {
                mainScript.SpawnBoats(cellPos);
                hex.transform.position = defPoint;
                hex.transform.localScale = defScale;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isAttack)
        {

            if (other.gameObject.layer == 9)
            {
                isEmpty = false;
                _plot = other.gameObject;
                par = _plot.transform.parent.gameObject;
                if (!isUnion)
                {
                    par.SetActive(false);
                }
                if (isUnion)
                    _text.GetComponent<NumberOfBoats>().NumberUp();
                isEmptyScript = false;
            }
        }
    }

}
