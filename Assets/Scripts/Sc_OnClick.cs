using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_OnClick : MonoBehaviour
{
    public AudioSource audioSource;
    public ParticleSystem ps;

    public float downTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown(){
        StartCoroutine(Kill());
    }

    IEnumerator Kill(){
        float _tps = 0;
        Vector3 s = gameObject.transform.localScale;
        audioSource.Play();
        ps.Play();

        GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<Sc_CameraShake>().isShaking = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        Vector3 _loc = gameObject.transform.position;
        while(_tps < downTime){
            gameObject.transform.position = _loc;
            _tps += Time.deltaTime;
            gameObject.transform.localScale = s / 1.1f;
            s = gameObject.transform.localScale;
            yield return null;
        }
        Destroy(this.gameObject, 0f);
        // FindObjectOfType<Camera>().isShaking = true;
    }
}
