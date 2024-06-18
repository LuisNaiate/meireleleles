using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrumarCamera : MonoBehaviour
{
    public Transform target; // O objeto que queremos seguir
    public float smoothSpeed = 0.125f; // A velocidade de suaviza��o do movimento

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // A posi��o que queremos alcan�ar, mantendo a coordenada Z da c�mera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Interpola��o linear para suavizar o movimento
            transform.position = smoothedPosition; // Atualiza a posi��o do objeto que est� seguindo
        }
    }
}
