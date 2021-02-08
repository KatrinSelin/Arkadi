using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public Transform level2enemies;
	private bool level2complete = false;
	public GameObject level2rewards;
	public EnemySpawner enemySpawner;
	public int enemiesToSpawn;
	public int waveCount;
	public int waveToWin;
	public GameObject finalCutScene;
	public AudioSource music;
	public AudioClip waveMusic;

	// Use this for initialization
	protected void Start () {

		music.Play();
		level2rewards.SetActive(false);
		EnemySpawner.activated = false;
		enemiesToSpawn = waveCount * 2;
		finalCutScene.SetActive(false);
		

	}

	// Update is called once per frame
	protected void Update () {

		if (level2enemies.childCount == 0 && level2complete == false)
        {
			HUD.Message("You destroyed all the enemies! Now find Power Up!");
			level2complete = true;
			level2rewards.SetActive(true);
			
		}

		if (enemySpawner.transform.childCount == 0 && EnemySpawner.activated && !IsInvoking())
        {
			
			if (waveCount > waveToWin)
            {
				enemySpawner.gameObject.SetActive(false);
				finalCutScene.SetActive(true);
				music.Stop();
				return;
            }
			
			
			if (waveCount == 0)
            {
				music.clip = waveMusic;
				music.Play();
            }
			waveCount++;
			HUD.Message("Wave" + " " + waveCount);
			enemiesToSpawn = Random.Range(waveCount * 1, waveCount * 1);
			Invoke("spawnWave", 3);

			// spawnWave();
		}

	}

	public void spawnWave()
    {
		for (int i = 0; i < enemiesToSpawn; i++)
		{
			enemySpawner.Invoke("Spawn", i);
		}
	}
}