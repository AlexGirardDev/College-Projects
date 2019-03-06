using UnityEngine;
using System.Collections.Generic;

public class Audio : MonoBehaviour {

	public AudioClip[] audioFiles;
	public List<AudioClip> usableAudio = new List<AudioClip>();
	public Level level;
	public float nextAudioTime = 0;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < level.used.Length; i++)
		{
			if (level.used[i])
			{
				usableAudio.Add(audioFiles[i]);	
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (nextAudioTime <= 0)
		{
			
			int nextAudio = Random.Range(0, usableAudio.Count);
			this.audio.PlayOneShot(usableAudio[nextAudio]);
			nextAudioTime = Random.Range(5f, 10f);	
		}
		else
		{
			nextAudioTime -= Time.deltaTime;	
		}
	}
}
