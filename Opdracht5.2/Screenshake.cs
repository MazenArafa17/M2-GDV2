using System.Collections;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    // Originele positie van de camera (start positie)
    private Vector3 origin;
    // Hoelang de shake effect duurt in seconden
    private float shakeTime;
    // Hoe sterk/ver de camera beweegt
    private float shakeForce;
    // Telt hoe veel tijd is verstreken sinds de shake begon
    private float elapsedTime = 0f;

    void Start()
    {
        // Sla de originele positie op
        origin = transform.position;
        // Luister naar events van andere scripts
        HitBumper.onHitBumper += ShakeBumper;
    }

    // Verwijder event listeners wanneer dit script uitgeschakeld wordt
    private void OnDisable()
    {
        HitBumper.onHitBumper -= ShakeBumper;
    }

    // Wordt aangeroepen wanneer de bumper geraakt wordt
    private void ShakeBumper(Transform _, int points) {
        shakeTime = .2f;      // Korte shake: 0.1 seconde
        shakeForce = .25f;    // Kleine amplitude
        elapsedTime = 0f;     // Reset de timer
        StopCoroutine("TrembleStep");  // Stop eventueel lopende shake
        StartCoroutine("TrembleStep"); //Start de shake
    }
    // Coroutine die de camera aan het trillen zet
    private IEnumerator TrembleStep() {
        // Blijf trillen zolang we nog tijd over hebben
        while (elapsedTime < shakeTime)
        {
            // Verplaats de camera naar een willekeurige positie rond de origineel
            transform.position = new Vector3(
                origin.x + Random.Range(-shakeForce, shakeForce),  // Random x
                origin.y + Random.Range(-shakeForce, shakeForce),  // Random y
                origin.z                                            // Z blijft hetzelfde
            );
            // Update de verstreken tijd in de coroutine
            elapsedTime += Time.deltaTime;
            // Wacht tot volgende frame
            yield return new WaitForEndOfFrame();
        }
        // Zet de camera terug op de originele positie
        transform.position = origin;
    }
}