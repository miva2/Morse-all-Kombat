using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static string TAG_PLAYER = "Player";

    [Header("Damage")]
    public float hurtTime = 0.2f;
    public Color hurtColor = Color.red;
    public GameObject fireBall;

    [Header("movement")]
    public Vector2 moveDirection = new Vector2(1, 0);
    public float stopMovingdistance = 1;
    public float leftLimit, rightLimit;

    [HideInInspector]
    [SerializeField]
    public AttackProperties[] attackProperties;

    [Header("health")]
    public SpriteRenderer[] healthBar;
    public float maxAlpha = 0.56f;

    private float startHealth = 100;
    public float health = 100;

    private int currentAttack;
    private SkinnedMeshRenderer meshRenderer;
    private static List<PlayerScript> playerScripts = new List<PlayerScript>();

    private bool stopMovement = false;
    private bool blockActions = false;

    private float blockTimer;
    private float blockPercentage;

    private Material defaultMaterial;

    private Rigidbody[] rigidbodies;

    public static bool useGlitch = false;
    private bool died = false;

    public AttackProperties GetCurrentAttack
    {
        get
        {
            return currentAttack == -1 ? new AttackProperties() : attackProperties[currentAttack];
        }
    }



    // Use this for initialization
    void Start()
    {
        useGlitch = false;
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        playerScripts.Add(this);
        defaultMaterial = meshRenderer.material;
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        blockTimer -= Time.deltaTime;
        stopMovement = Mathf.Abs(playerScripts[0].transform.position.x - playerScripts[1].transform.position.x) < stopMovingdistance;

        if (healthBar != null && healthBar.Length > 0)
        {
            float totalHealth = health;

            for (int i = 0; i < healthBar.Length; i++)
            {
                Color c = healthBar[i].color;
                c.a = (totalHealth > startHealth / healthBar.Length ? 1.0f : (totalHealth / (startHealth / healthBar.Length)))* maxAlpha;
                totalHealth -= startHealth / healthBar.Length;
                healthBar[i].color = c;
            }
        }

        if(health <= 0)
        {
            if (!died)
            {
                Die();
                MorseSound.morseSound.PlayDeathSound();
                died = true;
                StartCoroutine(DeathHandler.deathHandler.Die(gameObject.name));
                ActiveCamera.activeCamera.Die();
            }
        }
    }
    
    public void DamagePlayer(int damage)
    {
        if (blockTimer > 0)
        {
            health -= damage * (1 - blockPercentage);
        }
        else
        {
            health -= damage;
        }
        StartCoroutine(ChangeColorToRed());
    }

    private void Die()
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        if (!useGlitch)
        {
            GetComponentInChildren<Animator>().enabled = false;
        }
    }

    private IEnumerator ChangeColorToRed()
    {
        float t = 0;
        Material mHurt = new Material(defaultMaterial)
        {
            color = hurtColor
        };
        meshRenderer.sharedMaterial = mHurt;
        while (t < 0.2f)
        { 
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        meshRenderer.sharedMaterial = defaultMaterial;
    }

    private IEnumerator ShootFireball(char attackLetter)
    {
        if (!blockActions)
        {
            blockActions = true;
            AttackProperties properties = new AttackProperties();


            for (int i = 0; i < attackProperties.Length; i++)
            {
                if (attackProperties[i].attackLetters.Contains(attackLetter.ToString()))
                {
                    properties = attackProperties[i];
                    currentAttack = i;
                    break;
                }
            }

            if (properties.animationName != null && properties.animationName != "")
            {
                Animator anim = GetComponentInChildren<Animator>();
                anim.Play(properties.animationName);
                
                yield return new WaitForSeconds(properties.attackTime);
                
            }


            GameObject newFireball = Instantiate(fireBall, transform.position, Quaternion.identity);
            newFireball.GetComponent<FireballScript>().Initialize((int)Mathf.Sign(moveDirection.x), properties.damage);

            yield return new WaitForSeconds(properties.attackTime);

            blockActions = false;
        }
    }

    private IEnumerator StartAttack(char attackLetter)
    {
        if (!blockActions)
        {
            blockActions = true;
            bool initializedProperty = false;
            AttackProperties properties = new AttackProperties();


            for (int i = 0; i < attackProperties.Length; i++)
            {
                if (attackProperties[i].attackLetters.Contains(attackLetter.ToString()))
                {
                    properties = attackProperties[i];
                    currentAttack = i;
                    initializedProperty = true;
                    break;
                }
            }
            if (properties.animationName != null && properties.animationName != "")
            {
                GetComponentInChildren<Animator>().Play(properties.animationName);
            }

            if (!properties.IsAttack)
            {
                blockTimer = properties.attackTime;
                blockPercentage = properties.damage / 100f;
            }

            if (initializedProperty)
            {
                float t = 0;
                Vector3 animationStartPosition = transform.position;
                float previousXMove = 0;
                float xMovement = 0;
                float yMovement = 0;
                while (t < properties.attackTime)
                {
                    xMovement = properties.horizontalAnimation.Evaluate(t / properties.attackTime);
                    yMovement = properties.verticalAnimation.Evaluate(t / properties.attackTime);

                    if (stopMovement && xMovement > 0)
                    {
                        xMovement = previousXMove;
                    }
                    previousXMove = xMovement;
                    transform.position = animationStartPosition +
                        Vector3.Scale(Vector3.Scale(moveDirection, properties.DirectionalMultiplier),
                        new Vector3(xMovement, yMovement));
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
                    yield return new WaitForEndOfFrame();
                    t += Time.deltaTime;

                }
                if (!stopMovement)
                {
                    xMovement = properties.horizontalAnimation.Evaluate(1);
                }
                yMovement = properties.verticalAnimation.Evaluate(1);
                transform.position = animationStartPosition +
                        Vector3.Scale(Vector3.Scale(moveDirection, properties.DirectionalMultiplier),
                        new Vector3(xMovement, yMovement));
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);

            }
            yield return new WaitForSeconds(0.1f);
            currentAttack = -1;
            blockActions = false;
        }
    }

    public void ExecuteAttack(char attackLetter)
    {
        switch (attackLetter)
        {
            case '?':
                useGlitch = true;
                break;
            case 'c':
                StartCoroutine(ShootFireball('c'));
                break;
            default:
                StartCoroutine(StartAttack(attackLetter));
                break;
        }
    }

    [System.Serializable]
    public struct AttackProperties
    {
        public string attackName;
        public string attackLetters;
        public string animationName;
        public float attackTime;
        public int damage;
        public Vector2 DirectionalMultiplier;
        public AnimationCurve horizontalAnimation;
        public AnimationCurve verticalAnimation;

        public bool IsAttack
        {
            get
            {
                return attackLetters != null ? MorseDictionary.IsAttack(attackLetters[0]) : false;
            }
        }
    }

    private void OnDestroy()
    {
        playerScripts.Remove(this);
    }
}