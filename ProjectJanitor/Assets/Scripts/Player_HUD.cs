using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_HUD : MonoBehaviour {

    public float speed = 20;
    public int currentHealth;
    public int currentArmor;
    public int currentPrime;
    public int currentSecond;
    public Text healthText;
    public Text armorText;
    public Text primeText;
    public Text secondText;

    public AudioClip shootSound;
    private AudioSource sourceSound;
    
    //public Image test;
    public Image armorBar;
    public Image lifeBar;

    public HUD_ShowPopup cloudAie;
    public HUD_ShowPopup cloudPV;
    public HUD_ShowPopup cloudPrimeAmmo;
    public HUD_ShowPopup cloudSecondAmmo;
    public HUD_ShowPopup cloudArmor;


    private int maxHealth = 100;
    private int maxArmor = 100;
    private int maxPrime;
    private int maxSecond;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        currentArmor = maxArmor;
        currentPrime = 20;
        currentSecond = 5;
        maxPrime = 100;
        maxSecond = 30;
	}

    void Awake()
    {
        sourceSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        Movement();
        HandleHealth();
        HandleArmor();
        HandlePrime();
        HandleSecond();

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("I shot with Primal Weapon");
            currentPrime -= 1;
            sourceSound.PlayOneShot(shootSound);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("I shot with Second Weapon");
            currentSecond -= 1;
        }
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("I reload Primal Weapon");
            currentPrime = 20;
            maxPrime -= 20;
        }
        if (Input.GetKeyDown("t"))
        {
            Debug.Log("I reload Second Weapon");
            currentSecond = 5;
            maxSecond -= 5;
        }
	}

    public void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }

    public void HandleHealth()
    {
        healthText.text = "Health: " + currentHealth;
    }

    public void HandleArmor()
    {
        armorText.text = "Armor: " + currentArmor;
    }

    public void HandlePrime()
    {
        primeText.text = currentPrime + " x " + maxPrime;
    }

    public void HandleSecond()
    {
        secondText.text = currentSecond + " x " + maxSecond;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Explosion_dmg")
        {
            currentHealth -= 10;
            lifeBar.rectTransform.Translate(new Vector3(16f * Time.deltaTime, 0, 0));
            cloudAie.Popup(1);
        }
        if(other.name == "Big_heal")
        {
            currentHealth += 10;
            lifeBar.rectTransform.Translate(new Vector3(-16f * Time.deltaTime, 0, 0));
            cloudPV.Popup(1);
        }
        if(other.name == "PrimeReload")
        {
            maxPrime += 100;
            cloudPrimeAmmo.Popup(1);
        }
        if(other.name == "SecondReload")
        {
            maxSecond += 10;
            cloudSecondAmmo.Popup(1);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.name == "Heal")
        {
            //Debug.Log("^_^");
            if(currentHealth < maxHealth)
            {
                currentHealth += 1;
                //test.rectTransform.Translate(new Vector3(-8f * Time.deltaTime, 0, 0));
                lifeBar.rectTransform.Translate(new Vector3(-8f * Time.deltaTime, 0, 0));
                cloudPV.Popup(1);
            }
            if (currentHealth == maxHealth && currentArmor < maxArmor)
            {
                currentArmor += 1;
                armorBar.rectTransform.Translate(new Vector3(-8f * Time.deltaTime, 0, 0));
                cloudArmor.Popup(1);
            }
        }
        if (other.name == "Damage")
        {
            //Debug.Log("Aie !");
            if (currentArmor > 0)
            {
                currentArmor -= 1;
                //test.rectTransform.Translate(new Vector3(8f * Time.deltaTime, 0, 0));
                armorBar.rectTransform.Translate(new Vector3(8f * Time.deltaTime, 0, 0));
                cloudAie.Popup(1);
            }
            if (currentArmor <= 0 && currentHealth > 0)
            {
                currentHealth -= 1;
                lifeBar.rectTransform.Translate(new Vector3(8f * Time.deltaTime, 0, 0));
                cloudAie.Popup(1);
            }
        }
    }
}
