using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButtonsController : MonoBehaviour
{
    public Button BotaoAtual;
    public bool OCTA;
    public bool HEXA;
    public bool CROSS;
    public bool HEART;
    public bool TREFOIL;
    public bool QUATREFOIL;
    public bool STAR4;
    public bool STAR5;
    public bool STAR6;
    public string ItemAtual;

    // Start is called before the first frame update
    void Start()
    {
        if(OCTA){
            ItemAtual = "OCTA";
        }else if(HEXA){
            ItemAtual = "HEXA";
        }else if(STAR6){
            ItemAtual = "STAR6";
        }else if(STAR5){
            ItemAtual = "STAR5";
        }else if(STAR4){
            ItemAtual = "STAR4";
        }else if(QUATREFOIL){
            ItemAtual = "QUATREFOIL";
        }else if(TREFOIL){
            ItemAtual = "TREFOIL";
        }else if(HEART){
            ItemAtual = "HEART";
        }else if(CROSS){
            ItemAtual = "CROSS";
        }
        
        if(PlayerPrefs.GetString(ItemAtual).Equals("TRUE")){
            BotaoAtual.gameObject.SetActive(true);
            BotaoAtual.interactable = true;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Check(){
        if(PlayerPrefs.GetString(ItemAtual).Equals("TRUE")){
            BotaoAtual.gameObject.SetActive(true);
            BotaoAtual.interactable = true;
            gameObject.SetActive(false);
        }
    }
}
