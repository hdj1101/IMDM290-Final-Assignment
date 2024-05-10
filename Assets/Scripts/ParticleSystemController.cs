using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    public GameObject[] particlesToControl;
    
    private bool weatherPlaying = false;
    private float timeElapsed;
    private List<ParticleSystem> particleSystems;

    
    // Start is called before the first frame update
    void Start()
    {
        particleSystems = null;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        if (weatherPlaying && timeElapsed >= 20)
        {
            timeElapsed -= 20;
            
            if (particleSystems != null)
            {
                foreach(ParticleSystem ps in particleSystems)
                {
                    ps.Stop();
                }

                particleSystems = null;

                weatherPlaying = false;
            }

        }
        else if (!weatherPlaying && timeElapsed >= 10)
        {
            timeElapsed -= 10;

            int prob = Random.Range(0,2 + particlesToControl.Length);

            Debug.Log("Number: " + prob);

            if (prob < particlesToControl.Length)
            {
                ActivateParticles(particlesToControl[prob]);
            }
        }
    }

    private void ActivateParticles(GameObject particles)
    {
        particleSystems = new List<ParticleSystem>();

        foreach(Transform child in particles.transform)
        {
            ParticleSystem ps = child.GetComponent<ParticleSystem>();
            
            if (ps != null)
            {
                particleSystems.Add(ps);

                ps.Play();
            }
        }
        
        weatherPlaying = true;
    }
}
