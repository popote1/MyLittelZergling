using UnityEngine;

namespace scripte
{
    public class ZerglingHolder : MonoBehaviour
    {
        [Header("StartStats")]
        [Range(1, 100)] public int PV=100;
        [Range(1, 100)] public int Food=50;
        [Range(1, 100)] public int Power=75;

        [Header("StatConsomation")] 
        public int FoodConso;
        public int PowerConso;
        public float SleepTime;
        public float TempsConso;
        
    
        public Zergling _zergling;
        [HideInInspector] public bool IsSleeping;
        [HideInInspector] public bool IsDead;
        private float _sleepTimer;
        private float _tempoConso = 0;
        private Animator _animator;
        private CharacterController _cc;

        private void Awake()
        {
            _zergling = new Zergling(PV, Food, Power);
            _animator=GetComponentInChildren<Animator>();
            _cc = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        private void Update()
        {
            _tempoConso += Time.deltaTime;
            if (_tempoConso >= TempsConso)
            {
                UpdateConso();
            }
            if (IsSleeping)
            {
                _sleepTimer += Time.deltaTime;
                
                if (_sleepTimer >= SleepTime)
                {
                    IsSleeping = false;
                    _sleepTimer = 0;
                    Debug.Log("reveille");
                    AnimNormal();
                }
            }

            if (_zergling.ExostStat == 1) AnimSpeed(1);
            else if (_zergling.ExostStat==0)AnimSpeed(2f);
            else if (_zergling.ExostStat==2)AnimSpeed(0.5f);

            if (_zergling.Health <= 0)
            {
                IsDead = true;
                AnimMort();
            }

        }

        private void UpdateConso()
        {
        
            if (_tempoConso >= TempsConso)
            {
                _zergling.Food -= FoodConso;
                _zergling.Power -= PowerConso;
                _tempoConso = 0;
            }
            Debug.Log ("Sa change");

            /* if (_zergling.Food == 74)
         {
             _zergling.Food = 0;
         }*/
        }

        public void AnimBurow()
        {
           _animator.SetInteger("Stat",1);
        }

        public void AnimNormal()
        {
            _animator.SetInteger("Stat",0);
        }

        public void Attack(Vector2 ennemiPos)
        {
            _cc.Move(ennemiPos-(Vector2)transform.position);
            _animator.SetInteger("Stat",4);
            Invoke("AnimNormal",0.1f);
            
        }

        private void AnimMort()
        {
            _animator.SetInteger("Stat",3);
        }

        private void AnimSpeed(float factor)
        {
            _animator.speed = factor;
        }
    }
}
