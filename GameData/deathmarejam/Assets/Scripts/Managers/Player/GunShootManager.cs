using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShootManager : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public int ammoPlayer;
    public int maxMagazine;
    public int pistolMagazine;
    public Text magazineInfoTxt;

    [Header("Audio")]
    public AudioSource source;
    public AudioClip[] clip = new AudioClip[2];
    private float cooldownTimer;
    private bool isReloading;

    private PlayerManager pM;

    // Start is called before the first frame update
    void Start()
    {
        pM = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        magazineInfoTxt.text = pistolMagazine + "/" + maxMagazine;
        if(pM.selectGun != 1)
        {
            source.Stop();
            StopCoroutine("ReloadPistol");
            isReloading = false;
        }

        if((Input.GetKey(KeyCode.J) || Input.GetMouseButton(0)) && cooldownTimer > attackCooldown && pM.selectGun == 1 && !isReloading && PlayerMov.Instance.playerCanMove)
        {
                if(pistolMagazine > 0)
                    FireShoot();
                else if(!isReloading)
                {
                    cooldownTimer = 0;
                    source.PlayOneShot(clip[2]);
                }
                    
        }

        if(pistolMagazine < maxMagazine && ammoPlayer > 0 && Input.GetKeyDown(KeyCode.R) && !isReloading && PlayerMov.Instance.playerCanMove)
        {
            StartCoroutine("ReloadPistol");
        }

        cooldownTimer += Time.deltaTime;
    }

    private void FireShoot()
    {
        if(pM.selectGun == 1)
        {
            pistolMagazine--;
            cooldownTimer = 0;
            AnimationPlayerMain.Instance.pBody.SetTrigger("shoot");
            BulletMain.Instance.DropCap();
            BulletMain.Instance.ShootBullet();
            source.PlayOneShot(clip[0]);
        }
    }

    IEnumerator ReloadPistol()
    {
        isReloading = true;
        AnimationPlayerMain.Instance.pBody.SetTrigger("reload");
        source.PlayOneShot(clip[1]);

        yield return new WaitForSeconds(2.5f);

        bool reloaded = false;

        while(!reloaded)
        {
            if(ammoPlayer > 0)
            {
                ammoPlayer--;
                pistolMagazine++;
            }
            else
                reloaded = true;

            if(pistolMagazine == maxMagazine)
                reloaded = true;
        }

        isReloading = false;

    }

    public void GetAmmo(int q)
    {
        ammoPlayer += q;
    }
}
