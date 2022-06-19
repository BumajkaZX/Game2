using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MainScript : MonoBehaviour
{
    [SerializeField]
    GameObject pervBoat = null;
    int numberOfBoats = 0;
    public int maxBoats = 4;
    public bool _attack;

    [SerializeField]
    GameObject attackItem = null;
    [SerializeField]
    GameObject bezierItem = null;
    [SerializeField]
    GameObject _image = null;
    [SerializeField]
    float rad = 0, zaderjka = 0;
    [SerializeField]
    int numItems = 0;
    Vector2 startImageTransform;
    bool imageBack;
    bool imageForward;
    public float speedShift = 0;
    public int numOfItems;
    public int Choosen = 0;
    public GameObject[] attackItems;
    bool first;
    public float distanceBtwItems = 0;
    public int RockItem = 0;
    [SerializeField]
    NumberOfBoats UICanv = null;
    [SerializeField]
    GameObject rock = null;
   
    
   
    private void Awake()
    {
        
    }
    private void Start()
    {
       
        startImageTransform = _image.GetComponent<RectTransform>().anchoredPosition;
      
    }
    public void SpawnBoats(Vector3 curPos)
    {
        
            if (numberOfBoats < maxBoats)
            {
                GameObject _obj = Instantiate(pervBoat, curPos, Quaternion.identity);
                numberOfBoats++;
            }
        
    }
   
    public void SpawnAttack(Vector3 pos, bool isEmpty, GameObject _plot, bool isAttack)
    {
        switch (Choosen)
        {
            case 0:
                StartCoroutine(Spawn(pos, isEmpty, _plot, isAttack));
                break;
            case 1:
                if (RockItem > 0)
                {
                    StartCoroutine(SpawnRocks(pos, isEmpty, _plot, isAttack, Choosen));
                    RockItem--;
                    UICanv.CountItems();
                }
                break;
        }
        
    }
    IEnumerator Spawn(Vector3 pos, bool isEmpty, GameObject _plot, bool isAttack)
    {
        if (!isEmpty && !isAttack)
        {
            _plot.GetComponentInParent<PplAttack>().IsAttack();
            yield return new WaitForSeconds(2f);
            
        }
         
        for (int i = 0; i < numItems; i++)
        {
            float smX = Random.Range(-rad, rad);
            float smZ = Random.Range(-rad, rad);
            Vector3 smF = new Vector3(pos.x + smX, pos.y, pos.z + smZ);
            GameObject bz = Instantiate(bezierItem, smF, Quaternion.identity);
            StartCoroutine(SpawnAttack(pos, bz));
            yield return new WaitForSeconds(zaderjka);
        }
    }
    IEnumerator SpawnRocks (Vector3 pos, bool isEmpty, GameObject _plot, bool isAttack, int Choosen)
    {
        if (!isEmpty && !isAttack)
        {
            _plot.GetComponentInParent<PplAttack>().IsAttack();
            yield return new WaitForSeconds(2f);

        }

        
           
            GameObject bz = Instantiate(bezierItem, pos, Quaternion.identity);
            StartCoroutine(SpawnAttackRocks(bz));
            yield return new WaitForSeconds(zaderjka);
        
    }
    IEnumerator SpawnAttack(Vector3 pos, GameObject bz)
    {
       
                GameObject ob = Instantiate(attackItem, new Vector3(bz.transform.GetChild(0).position.x, bz.transform.GetChild(0).position.y, bz.transform.GetChild(0).position.z), Quaternion.Euler(-270, 0, 0));
                ob.GetComponent<DestroySp>().TransFR(bz.transform.GetChild(0), bz.transform.GetChild(1), bz.transform.GetChild(2), bz.transform.GetChild(3));
                yield return new WaitForSeconds(5f);
                Destroy(bz);
   
    }
    IEnumerator SpawnAttackRocks(GameObject bz)
    {
        GameObject rk = Instantiate(rock, new Vector3(bz.transform.GetChild(0).position.x, bz.transform.GetChild(0).position.y, bz.transform.GetChild(0).position.z), Quaternion.Euler(-270, 0, 0));
        rk.GetComponent<DestroySp>().TransFR(bz.transform.GetChild(0), bz.transform.GetChild(1), bz.transform.GetChild(2), bz.transform.GetChild(3));
        yield return new WaitForSeconds(5f);
       
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (_image.GetComponent<RectTransform>().anchoredPosition.x >= startImageTransform.x)
                imageForward = false;
            first = false;
            imageBack = true;
        }  
        if (imageBack)
        {
            _image.GetComponent<RectTransform>().anchoredPosition = new Vector2(_image.GetComponent<RectTransform>().anchoredPosition.x - Time.deltaTime * speedShift, _image.GetComponent<RectTransform>().anchoredPosition.y);
           // _image.transform.position = new Vector3(_image.transform.position.x - Time.deltaTime * speedShift, startImageTransform.y,startImageTransform.z);
            //if (_image.transform.position.x <= startImageTransform.x)
            if (_image.GetComponent<RectTransform>().anchoredPosition.x <= startImageTransform.x )
                imageBack = false;
        }
        if ((Input.GetKeyDown(KeyCode.Q) ^ Input.GetKeyDown(KeyCode.E)) && !imageBack)
        {
            imageForward = true;
            attackItems[Choosen].GetComponent<Image>().color = Color.white;
        }
        if (imageForward)
        {
            
            
            if (_image.GetComponent<RectTransform>().anchoredPosition.x <= startImageTransform.x + distanceBtwItems * numOfItems)
            {
                _image.GetComponent<RectTransform>().anchoredPosition = new Vector2(_image.GetComponent<RectTransform>().anchoredPosition.x + Time.deltaTime * speedShift, _image.GetComponent<RectTransform>().anchoredPosition.y);

            }

            if (Input.GetKeyDown(KeyCode.Q) )
            {
                if (first)
                {
                    changeColor(true);
                }
                first = true;
                

            }
            if (Input.GetKeyDown(KeyCode.E) )
            {
                if (first)
                {
                    changeColor(false);
                }
                first = true;

            }

        }
    }
    void changeColor(bool Q)
    {
      
            
            if (Q)
            {

                if (Choosen == numOfItems - 1)
                    Choosen = 0;
                else
                    Choosen++;
                for (int i = 0; i < numOfItems; i++)
                {
                    if (i != Choosen)
                        attackItems[i].GetComponent<Image>().color = Color.black;
                }
                attackItems[Choosen].GetComponent<Image>().color = Color.white;

            }
            if (!Q)
            {
                if (Choosen == 0)
                    Choosen = numOfItems - 1;
                else
                    Choosen--;
                for (int i = 0; i < numOfItems; i++)
                {
                    if (i != Choosen)
                        attackItems[i].GetComponent<Image>().color = Color.black;
                }
                attackItems[Choosen].GetComponent<Image>().color = Color.white;


            }
        
    }
   
}
