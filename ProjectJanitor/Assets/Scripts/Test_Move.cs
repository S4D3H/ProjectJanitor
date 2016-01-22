using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test_Move : MonoBehaviour {

    float speed = 20;

    public RectTransform healthTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
    private int currentHealth;
    public int maxHealth;
    public Text healthText;
    public Image visualHealth;
    public float coolDown;
    private bool onCD;

    private int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
            HandleHealth();
        }
    }

    // Use this for initialization
    void Start ()
    {
        maxXValue = healthTransform.position.x;
        minXValue = healthTransform.position.x - healthTransform.rect.width;
        CurrentHealth = maxHealth;
        onCD = false;
	}

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void HandleHealth()
    {
        healthText.text = "Health: " + currentHealth;
        float currentXValue = MapValues(currentHealth, 0, maxHealth, minXValue, maxXValue);
        healthTransform.position = new Vector3(currentXValue, cachedY);

        if(CurrentHealth > maxHealth / 2) // more than 50% health
        {
            visualHealth.color = new Color32((byte)MapValues(currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
        }
        else // less than 50% health
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHealth, 0, maxHealth/2, 0, 255), 0, 255);
        }
    }

    IEnumerator CoolDownDmg()
    {
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }

    private void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.name == "Heal")
        {
            //Debug.Log("^_^");
            if (!onCD && currentHealth < maxHealth)
            {
                StartCoroutine(CoolDownDmg());
                CurrentHealth += 1;
            }
        }
        if (other.name == "Damage")
        {
            //Debug.Log("Aie !");
            if(!onCD && currentHealth > 0)
            {
                StartCoroutine(CoolDownDmg());
                CurrentHealth -= 1;
            }
        }
    }
    
    private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
