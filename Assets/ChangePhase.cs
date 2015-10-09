using UnityEngine;
using System.Collections;

public class ChangePhase : MonoBehaviour {

    public Transform cameraTransform;
    public Transform clawTransform;
    public Transform gameObjectTransform;

    Vector3 cameraPosition ;
    
   
    // Use this for initialization
    void Start() {
        cameraPosition = cameraTransform.position;
      
    } 

    // Update is called once per frame
    void Update() {
       
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraPosition, 0.02f);
      


    }


    void OnTriggerEnter(Collider other)
    {
        _move(other);



    }

    private void OnTriggerStay(Collider other)
    {
        _move(other);



    }

    private void _move(Collider collider)
    {
        if (collider.tag.Equals("cubfixed"))
        {

           
            cameraPosition.y += 4;
            clawTransform.position = new Vector3(clawTransform.position.x, clawTransform.position.y + 4, clawTransform.position.z);
            gameObjectTransform.position = new Vector3(gameObjectTransform.position.x, gameObjectTransform.position.y + 4, gameObjectTransform.position.z);


        }
    }
}
