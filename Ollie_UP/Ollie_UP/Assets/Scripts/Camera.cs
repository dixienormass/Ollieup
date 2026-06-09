using UnityEngine;

public class Camera : MonoBehaviour
{
    
    public Transform player;


    void Awake()
    {
        transform.position = player.transform.position + new Vector3(0,1,-5);
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,1,-5);
        
    }
}
