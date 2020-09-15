using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonController : MonoBehaviour
{

    public PlayerController Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CanStart(){
        Player.setCanStart();
    }
}
