using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberOfBoats : MonoBehaviour
{
    int Number = 0;
    [SerializeField]
    GameObject _text = null;
    int MaxNumber = 0;
    [SerializeField]
     int NumberOfItems = 0;
    [SerializeField]
    MainScript mainScript = null;
    [SerializeField]
    GameObject[] attackItems = null;
    int rockItem;
    
    
     void Start()
    {
        rockItem = mainScript.RockItem;
        
        mainScript.attackItems = attackItems;
        mainScript.numOfItems = NumberOfItems;
        MaxNumber = mainScript.maxBoats;
        attackItems[1].GetComponentInChildren<TextMeshProUGUI>().text = rockItem.ToString();
        _text.GetComponent<TextMeshProUGUI>().text = Number.ToString() + "/" + MaxNumber;
    }
    public void NumberUp()
    {
        Number++;
        _text.GetComponent<TextMeshProUGUI>().text = Number.ToString() + "/" + MaxNumber;
    }
    public void NumberDown()
    {
        Number--;
        _text.GetComponent<TextMeshProUGUI>().text = Number.ToString() + "/" + MaxNumber;
    }
    public void CountItems()
    {
        rockItem = mainScript.RockItem;
        attackItems[1].GetComponentInChildren<TextMeshProUGUI>().text = rockItem.ToString();
    }
}
