using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Launcher : MonoBehaviour
{

    public GameObject projectile;
    public float timer = 5.0f;
    private float _t;
    public float shootVelocity = 100;
    // Start is called before the first frame update
    void Start()
    {
        _t = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if((_t-=Time.deltaTime) < 0){
            Launch();
            _t = timer;
        }
    }

    public void Launch(){
        GameObject o = Instantiate(projectile, this.gameObject.transform.position, this.gameObject.transform.rotation);
        
        o.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, shootVelocity));
    }
}
