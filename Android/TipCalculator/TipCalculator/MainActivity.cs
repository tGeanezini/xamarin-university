using Android.App;
using Android.OS;
using Android.Widget;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {

        EditText _inputBill;
        Button _calculateButton;
        TextView _outputTip;
        TextView _outputTotal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            _inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            _calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            _outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            _outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            _calculateButton.Click += OnCalculateClick;
        }

        private void OnCalculateClick(object sender, System.EventArgs e)
        {
            string text = _inputBill.Text;
            var bill = double.Parse(text);
            var tip = bill * 0.15;
            var total = bill + tip;

            _outputTip.Text = tip.ToString();
            _outputTotal.Text = total.ToString();
        }
    }
}

