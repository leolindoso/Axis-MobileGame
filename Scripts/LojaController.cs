using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojaController : MonoBehaviour
{

    public Text PrecoText;
    private int PrecoAtual = 0;
    private string ItemAtual;
    public GameObject BuyScreen;
    public LockButtonsController[] Buttons;
    public AudioClip SuccessSFX;
    public AudioClip FailSFX;
    public AudioSource SomBuyScreen;

    public LockButtonsController[] list;
    public bool random;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PrecoText.IsActive() && !random){
            PrecoText.text = PrecoAtual.ToString();
        }
        
    }

    public void ComprarItem(){
        
        if(PlayerPrefs.GetInt("Player Keys") >= PrecoAtual){
            PlayerPrefs.SetString(ItemAtual,"TRUE");
            PlayerPrefs.SetInt("Player Keys",PlayerPrefs.GetInt("Player Keys") - PrecoAtual);
            BuyScreen.SetActive(false);
            foreach(LockButtonsController x in Buttons){
                x.Check();
            }
            SomBuyScreen.pitch = 1.3f;
            SomBuyScreen.PlayOneShot(SuccessSFX);
        }else{
            SomBuyScreen.pitch = 1f;
            SomBuyScreen.PlayOneShot(FailSFX);
        }
        
    }
    public void ComprarItemMoeda(){
        PrecoAtual = 75;
        list = new LockButtonsController[Buttons.Length];
        
        for(int i = 0;i < list.Length;i++){
            if(Buttons[i].gameObject.active){
                list[i] = Buttons[i];
                print(list[i].gameObject.name);
            }
        }
        int index = Random.Range(0,list.Length);
        if(list[index].gameObject.active){
            ItemAtual = list[index].GetComponent<LockButtonsController>().ItemAtual;
        }
        if(PlayerPrefs.GetInt("Player Coins") >= 75){
            PlayerPrefs.SetString(ItemAtual,"TRUE");
            PlayerPrefs.SetInt("Player Coins",PlayerPrefs.GetInt("Player Coins") - 75);
            BuyScreen.SetActive(false);
            foreach(LockButtonsController x in Buttons){
                x.Check();
            }
            SomBuyScreen.pitch = 1.3f;
            SomBuyScreen.PlayOneShot(SuccessSFX);
        }else{
            SomBuyScreen.pitch = 1f;
            SomBuyScreen.PlayOneShot(FailSFX);
        }
        
    }

    public void DefinirItem(string item){
        ItemAtual = item;
    }
    public void DefinirPreco(int preco){
        PrecoAtual = preco;
    }
}
