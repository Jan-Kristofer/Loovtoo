using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("Gun Information")]

    [SerializeField] private float range;
    [SerializeField] private int magsize;
    [SerializeField] private float firerateSec;
    [SerializeField] private bool Automatic;
    [SerializeField] private float reloadTime;
    private int CurrentMagSize;
    private bool isreloading;
    private float TimeToNextShoot = 0f;
    public GameObject projectile;
    public GameObject bulletspawn;
    public float bulletforce;
    public int shotsFired;

    [Header("External stuff")]

    public GameObject gun;
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private GameObject player;
    public ParticleSystem MuzzleFlash;
    public ParticleSystem Blood;
    public GameObject ImpactEffect;
    public AudioClip Shoot_Sound;
    public AudioSource Audio_Source;
    public int ScoreAmt = 0;
    public Text ShotsFired;
    public Text Hits;
    public Text Accuracy;

    void Start()
    {
        gun = gameObject;
        CurrentMagSize = magsize;
        SetupAudio();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Automatic && Time.time >= TimeToNextShoot && CurrentMagSize > 0)
        {
            TimeToNextShoot = Time.time + 1f / firerateSec;
            Shoot();

        }
        else if (Input.GetButtonDown("Fire1") && !Automatic && Time.time >= TimeToNextShoot && CurrentMagSize > 0)
        {
            TimeToNextShoot = Time.time + 1f / firerateSec;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && CurrentMagSize != 35 && isreloading != true)
        {            
            StartCoroutine(Reload());
            return;
        }
        else if (CurrentMagSize <= 0 && isreloading != true)
        {      
            StartCoroutine(Reload());
            return;
        }

    }

    public void Shoot()
    {


        shotsFired++;
        Debug.Log(shotsFired);
        Audio_Source.Play();
        RaycastHit hit;
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            
            Debug.Log(hit.transform.tag);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)           
            {
                Destroy(enemy.gameObject);
                ScoreAmt += gameObject.GetComponent<TargetScript>().value;
                Debug.Log(ScoreAmt);
            }
        }
    }


    
    IEnumerator Reload()
    {
        isreloading = true;
        yield return new WaitForSeconds(reloadTime);
        CurrentMagSize = magsize;
        Debug.Log("Reloaded");
        isreloading = false;
    }

    public void SetupAudio()
    {
        Audio_Source = gameObject.AddComponent<AudioSource>();
        Audio_Source.volume = 0.6f;
        Audio_Source.clip = Shoot_Sound;
    }
}
