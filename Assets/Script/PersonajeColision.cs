using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeColision : MonoBehaviour
{

//En los runners es la layer 6
     void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 8)
        {
            
            GameManager.Instance.Choque();
        }
    }
}
