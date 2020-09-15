using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCoinsController : MonoBehaviour
{
    public bool key = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!key){
            GetComponent<Text>().text = PlayerPrefs.GetInt("Player Coins").ToString();
        }else{
            GetComponent<Text>().text = PlayerPrefs.GetInt("Player Keys").ToString();
        }
    }
}
