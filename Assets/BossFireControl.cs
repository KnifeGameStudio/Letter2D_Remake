using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireControl : MonoBehaviour
{
    public float velocidadMax = 0.01f;

    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;

    private float x;
    private float z;
    private float tiempo;
    private float angulo;
    void Start()
    {
        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        transform.localRotation = Quaternion.Euler(0, angulo, 0);
        velocidadMax = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {   
        xMax = transform.position.x + 1;
        xMin = transform.position.x - 1;
        zMax = transform.position.y + 1;
        zMin = transform.position.y - 1;
        tiempo += Time.deltaTime;

        if (transform.localPosition.x > xMax)
        {
            x = Random.Range(-velocidadMax, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            tiempo = 0.0f;
        }
        if (transform.localPosition.x < xMin)
        {
            x = Random.Range(0.0f, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            tiempo = 0.0f;
        }
        if (transform.localPosition.y > zMax)
        {
            z = Random.Range(-velocidadMax, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            tiempo = 0.0f;
        }
        if (transform.localPosition.y < zMin)
        {
            z = Random.Range(0.0f, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            tiempo = 0.0f;
        }


        if (tiempo > 1.0f)
        {
            
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            tiempo = 0.0f;
        }
        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y + z, transform.localPosition.z);
    }
}
