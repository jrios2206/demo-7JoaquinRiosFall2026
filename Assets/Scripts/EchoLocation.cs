using UnityEngine;
using UnityEngine.InputSystem;

public class EchoLocation : MonoBehaviour
{
    public Light echoLight;
    public float maxRange = 20f;
    public float expandSpeed = 25f;
    public float maxIntensity = 20f;
    public float fadeSpeed = 15;
    public AudioSource screechSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            echoLight.range = 0;
            echoLight.intensity = maxIntensity;
            screechSound.Play();
        }
        echoLight.range += expandSpeed * Time.deltaTime;
        echoLight.intensity -= fadeSpeed * Time.deltaTime;
        if (echoLight.range > maxRange)
        {
            echoLight.range = maxRange;
        }

        if (echoLight.intensity < 0)
        {
            echoLight.intensity = 0;
        }
    }
}
