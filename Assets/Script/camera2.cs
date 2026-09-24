using System.Threading;
using UnityEngine;

public class camera2 : MonoBehaviour
{
    public GameObject Monita;//モニター
    private Vector3 MonitarCoordinates;//モニター座標
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Monita = GameObject.Find("monita-");
        MonitarCoordinates=Monita.transform.position;
        MonitarCoordinates.y =0.63f;
        MonitarCoordinates.z =-1.6f;
        transform.position= MonitarCoordinates;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//a