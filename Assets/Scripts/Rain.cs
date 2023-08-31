using System.Collections;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private Light dirLight;
    [SerializeField] private float minTimeChangeWeather;
    [SerializeField] private float maxTimeChangeWeather;
    [SerializeField] private float minLightIntensity;
    [SerializeField] private float maxLightIntensity;
    private ParticleSystem _ps; 
    private bool _isRain;  

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>(); 
        _ps.Stop();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        switch (_isRain)
        {
            case true when dirLight.intensity > minLightIntensity:
                LightIntensity(-1);
                break;
            case false when dirLight.intensity < maxLightIntensity:
                LightIntensity(1);
                break;
        }
    }

    private void LightIntensity(int mult)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }

    private IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTimeChangeWeather, maxTimeChangeWeather));
            
            switch (_isRain)
            {
                case true:
                    _ps.Stop();
                    break;
                default:
                    _ps.Play();
                    break;
            }

            _isRain = !_isRain; 
        }
    }
}
