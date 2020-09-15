using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{

    public BoxCollider2D SideBlock1;
    public BoxCollider2D SideBlock2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer,8);
        //Physics2D.IgnoreLayerCollision(GetComponent<PolygonCollider2D>(),SideBlock2);
        transform.Rotate(Vector3.forward * 75 * Time.deltaTime);
    }
}
