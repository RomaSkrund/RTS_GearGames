using System.Collections;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private Light dirLight;
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
        if (_isRain && dirLight.intensity > 0.25f)
        {
            LightIntensity(-1);
        } 
        else if (!_isRain && dirLight.intensity < 0.7f)
        {
            LightIntensity(1);
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
            yield return new WaitForSeconds(Random.Range(60f, 90f));
            

            if( _isRain )
            {
                _ps.Stop();
            } 
            else
            {
                _ps.Play();
            }

            _isRain = !_isRain; 
        }
    }
}
