using UnityEngine;
using GamepadInput;
public class LaserShoot: MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;


    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    public float effectsDisplayTime = 1f;
    bool shooting = false;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }


    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if ( timer >= timeBetweenBullets && Time.deltaTime != 0)
        {
            Shoot();
        }

        if (shooting == true)
        {
            CheckCollision();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
        shooting = false;
    }


    void Shoot()
    {
        timer = 0f;
        shooting = true;
        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

    }

    void CheckCollision()
    {
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //ON collision
            gunLine.SetPosition(1, shootHit.point);
            shootHit.collider.gameObject.SetActive(false);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

    //Perque torni a apareixer un cop mort
    void RevivePlayer()
    {
        RaceManager.current.player.transform.position += Vector3.back * 5;
        RaceManager.current.player.SetActive(true);
    }
}

