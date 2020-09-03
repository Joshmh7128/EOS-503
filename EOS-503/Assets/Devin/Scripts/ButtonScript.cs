using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void Expand()
    {
        anim.Play("buttonExpand");
    }

    public void Contract()
    {
        anim.Play("buttonCollapse");
    }
}
