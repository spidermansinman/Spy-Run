using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light lightToFlicker; // La luz que parpadeará
    public float minFlickerSpeed = 0.1f; // Velocidad mínima de parpadeo
    public float maxFlickerSpeed = 0.5f; // Velocidad máxima de parpadeo
    public bool randomizeSpeed = false; // Si se debe randomizar la velocidad entre min y max
    public float flickerSpeed = 0.2f; // Velocidad de parpadeo si no se randomiza

    private Coroutine flickerCoroutine;

    void Start()
    {
        // Comienza el parpadeo
        flickerCoroutine = StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // Alterna la luz entre encendida y apagada
            lightToFlicker.enabled = !lightToFlicker.enabled;
            
            // Si randomizeSpeed es verdadero, usa un valor aleatorio entre minFlickerSpeed y maxFlickerSpeed
            float waitTime = randomizeSpeed ? Random.Range(minFlickerSpeed, maxFlickerSpeed) : flickerSpeed;

            // Espera hasta la próxima alternancia
            yield return new WaitForSeconds(waitTime);
        }
    }

    void OnDisable()
    {
        // Detiene el parpadeo cuando el objeto es desactivado
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
        }
    }

    void OnValidate()
    {
        // Asegura que minFlickerSpeed no sea mayor que maxFlickerSpeed
        if (minFlickerSpeed > maxFlickerSpeed)
        {
            minFlickerSpeed = maxFlickerSpeed;
        }
    }
}