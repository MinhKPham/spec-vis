using UnityEngine;
using System.Collections;

using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class LineVisualizer : MonoBehaviour
{
	public float size = 10.0f;
	public float amplitude = 1.0f;
	public int cutoffSample = 128; //MUST BE LOWER THAN SAMPLE SIZE
	public FFTWindow fftWindow;
    public GameObject bar;
    public GameObject top;
    List<GameObject> bars;
    List<GameObject> bars2;
    List<GameObject> tops;
    private float[] samples = new float[2048]; //MUST BE A POWER OF TWO
	private LineRenderer lineRenderer;
	private float stepSize;

	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(cutoffSample);
		stepSize = size/cutoffSample;
        bars = new List<GameObject>();
        bars2 = new List<GameObject>();
        tops = new List<GameObject>();
        for (int i = 0; i < cutoffSample; i++)
        {
            bars.Add(Instantiate(bar, new Vector3(i*bar.transform.localScale.x*1.2f - size / 2, 5, 0), Quaternion.identity));
            tops.Add(Instantiate(top, new Vector3(i * top.transform.localScale.x*1.2f - size / 2, 10, 0), Quaternion.identity));
            bars2.Add(Instantiate(bar, new Vector3(i * bar.transform.localScale.x * 1.2f - size / 2, 5, 40), Quaternion.identity));
        }
    }

	// Update is called once per frame
	void Update ()
	{
		AudioListener.GetSpectrumData(samples,0,fftWindow);

		int i = 0;
        float max = 0;
		for(i = 0; i < cutoffSample; i++)
		{

			Vector3 position = new Vector3(i*stepSize-size/2,samples[i]*amplitude,0.0f);
            if (samples[i] * amplitude > max) max = samples[i] * amplitude;
            float result = samples[i] * amplitude*(1+i*2/cutoffSample);
            if (result < 1) result = 1;
            if (result > 17) result = 17;
            bars2[i].transform.localScale = new Vector3(bars2[i].transform.localScale.x, result*10, bars2[i].transform.localScale.z);
            bars[i].GetComponent<addforce>().force = result*200;
            //lineRenderer.SetPosition(i,position);
        }
        
	}
}
