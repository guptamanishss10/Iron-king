using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationMovement : MonoBehaviour
{
    // Start is called before the first frame update
     private Spider spider;

    public void Start()
    {
        spider = transform.parent.GetComponent<Spider>();
    }
    public void fire()
    {
        spider.Attack();
    }
}
