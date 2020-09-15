using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManagerController : MonoBehaviour
{
    public SpriteRenderer[] CorPrimariaObj;
    public ParticleSystem[] CorPrimariaParticle;
    public SpriteRenderer[] CorAux1Obj;
    public Text[] CorAux1Text;
    public Image[] CorAux1Img;
    // public Text[] CorAux2Text;
    public SpriteRenderer[] CorAux2Obj;
    public Image[] CorAux2Img;
    public Image[] CorAux1ImgButton;
    public Camera[] CorBGObj;

    private Color CorPrimaria;
    private Color CorAux1;
    private Color CorAux1Alpha;
    private Color CorAux2;
    private Color CorBG;

    ArrayList Esquema2;

    int status = 1;

    // Start is called before the first frame update
    void Start()
    {
        Esquema2 = new ArrayList{
          new Color(0.8396226f,0.03564434f,0.1227824f),
          new Color(0.9764706f,0.4196079f,0.1215686f),
          new Color(0.9764706f,0.4196079f,0.1215686f,0.2509804f),
          new Color(0.5f,0.120283f,0.1885328f),
          new Color(0.9716981f,0.913768f,0.8112763f)
        };

        CorPrimaria = new Color(0.15f,0.6f,1f);
        CorAux1 = new Color(0.0509804f,0.2941177f,0.4078432f);
        CorAux1Alpha = new Color(0.0509804f,0.2941177f,0.4078432f,0.2509804f);
        CorAux2 = new Color(0.2524475f,0.3176735f,0.5754717f);
        CorBG = new Color(0.949f,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreController.score ==3)
            StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor(){

        yield return new WaitForSeconds(2);
            StartCoroutine(ChangeColorsProEsquema2());
     }

     IEnumerator ChangeColorsProEsquema2(){
         if(status == 1){
             foreach(SpriteRenderer x in CorPrimariaObj){
                x.color = Color.Lerp(x.color,(Color)Esquema2[0],0.05f);
            }
             foreach(ParticleSystem x in CorPrimariaParticle){
                x.startColor = Color.Lerp(x.startColor,(Color)Esquema2[0],0.05f);
            }
            foreach(SpriteRenderer x in CorAux1Obj){
                x.color = Color.Lerp(x.color,(Color)Esquema2[1],0.05f);
            }
            foreach(Text x in CorAux1Text){
                x.color = Color.Lerp(x.color,(Color)Esquema2[1],0.05f);
            }
            foreach(Image x in CorAux1Img){
                x.color = Color.Lerp(x.color,(Color)Esquema2[2],0.05f);
            }
            foreach(Image x in CorAux1ImgButton){
                x.color = Color.Lerp(x.color,(Color)Esquema2[1],0.05f);
            }
            foreach(SpriteRenderer x in CorAux2Obj){
                x.color = Color.Lerp(x.color,(Color)Esquema2[3],0.05f);
            }
            foreach(Image x in CorAux2Img){
                x.color = Color.Lerp(x.color,(Color)Esquema2[3],0.05f);
            }
            
            foreach(Camera x in CorBGObj){
                x.backgroundColor = Color.Lerp(x.backgroundColor,(Color)Esquema2[4],0.05f);
            }
         }
         yield return new WaitForSeconds(15);
            StartCoroutine(ChangeColorsProEsquema1());
     }
     IEnumerator ChangeColorsProEsquema1(){
         if(status == 1){
             foreach(SpriteRenderer x in CorPrimariaObj){
                x.color = Color.Lerp(x.color,CorPrimaria,0.05f);
            }
            foreach(ParticleSystem x in CorPrimariaParticle){
                x.startColor = Color.Lerp(x.startColor,CorPrimaria,0.05f);
            }
            foreach(SpriteRenderer x in CorAux1Obj){
                x.color = Color.Lerp(x.color,CorAux1,0.05f);
            }
            foreach(Text x in CorAux1Text){
                x.color = Color.Lerp(x.color,CorAux1,0.05f);
            }
            foreach(Image x in CorAux1Img){
                x.color = Color.Lerp(x.color,CorAux1Alpha,0.05f);
            }
            foreach(Image x in CorAux1ImgButton){
                x.color = Color.Lerp(x.color,CorAux1,0.05f);
            }
            foreach(SpriteRenderer x in CorAux2Obj){
                x.color = Color.Lerp(x.color,CorAux2,0.05f);
            }
            foreach(Image x in CorAux2Img){
                x.color = Color.Lerp(x.color,CorAux2,0.05f);
            }
            foreach(Camera x in CorBGObj){
                x.backgroundColor = Color.Lerp(x.backgroundColor,CorBG,0.05f);
            }
         }
         yield return new WaitForSeconds(15);
                     StartCoroutine(ChangeColorsProEsquema2());

         
     }
}
