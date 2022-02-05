using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyInstance : MonoBehaviour
{
    [SerializeField] private float time = 5;
    private void OnEnable() => Destroy(gameObject, time);


}
