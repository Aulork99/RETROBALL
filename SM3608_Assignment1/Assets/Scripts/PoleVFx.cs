using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleVFx : MonoBehaviour
{
    public Material defaultmat;
    public float Scale;
    private Vector3 scaletransform;
    private Vector3 defaultscale;

    // Start is called before the first frame update
    public void Awake()
    {
        defaultmat = this.GetComponent<MeshRenderer>().material;
        scaletransform = new Vector3(transform.localScale.x*Scale,transform.localScale.y*Scale, transform.localScale.z * Scale);
        defaultscale = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball")) 
        {
            this.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<MeshRenderer>().material;
            transform.localScale = Vector3.Lerp(defaultscale,scaletransform,1);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ball")) 
        {
            this.GetComponent<MeshRenderer>().material = defaultmat;
            transform.localScale = Vector3.Lerp(defaultscale, scaletransform, 0);
        }

    }


}
