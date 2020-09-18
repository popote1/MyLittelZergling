using UnityEngine;
using UnityEngine.UI;

namespace scripte
{
    public class TestLing : MonoBehaviour
    {
        [Header("Ui Componentes")]
        public Slider SliderPV;
        public Slider SliderFood;
        public Slider SliderPower;
        public Text TxtPV;
        public Text TxtFood;
        public Text TxtPower;
        [Header("Tested")]
        public GameObject Tested;

        private Zergling _zerg;

        private void Start()
        {
            _zerg = Tested.GetComponent<ZerglingHolder>()._zergling;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_zerg == null) return;
             SliderPV.value = Mathf.Lerp(SliderPV.value, (float)_zerg.Health / 100, 0.5f);
             SliderFood.value = Mathf.Lerp(SliderFood.value,(float) _zerg.Food / 100, 0.5f);
             SliderPower.value = Mathf.Lerp(SliderPower.value,(float)_zerg.Power/100,0.5f);
             TxtPV.text = "" + _zerg.Health;
             TxtFood.text = "" + _zerg.Food;
             TxtPower.text = "" + _zerg.Power;
            //Debug.Log("PV =" + _zerg.Health + "    Food =" + _zerg.Food + "      Power=" + _zerg.Power);
        }
    }
}
