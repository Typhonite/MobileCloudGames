using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour
{
    public AudioSource audioSource;
    float[] samples;
    public int frequency = 1024;

    // Use this for initialization
    void Start ()
    {
        // recuperando componente do objeto
        audioSource = GetComponent<AudioSource>();

        samples = new float[frequency];

        // string[] microfones = Microphone.devices;

        // recuperando o nome do dispositivo
        Debug.Log("Device: " + Microphone.devices[0]);

        //int min = 0;
        //int max = 0;
        //Microphone.GetDeviceCaps(null, out min, out max);
        //Debug.Log("Caps - min:" + min + ", max: " + max);


        // Iniciando o input
        //audioSource.clip = Microphone.Start(null, true, 100, frequency);
        audioSource.Play();
	}

	
	// Update is called once per frame
	void Update ()
    {
        transform.position = transform.parent.position - transform.up * Volume();
    }


    private float Volume()
    {
        float volume = 0;
        
        if(audioSource.isPlaying)
        {
            for(int canal = 0; canal < 2; canal++)
            {
                audioSource.GetOutputData(samples, canal);

                //if (samples != null)
                //{
                    for (int i = 0; i < frequency; i++)
                    {
                        volume += Mathf.Abs(samples[i]);
                    }
                //}
            }

            volume = volume / frequency;
        }

        return volume;
    }
}
