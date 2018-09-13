using CoreGraphics;
using UIKit;

namespace TipCalculator
{
    public class MyViewController : UIViewController
    {
        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.LightGray;

            var totalAmount = new UITextField() {
                Frame = new CGRect(20, 28, View.Bounds.Width - 40, 35),
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Enter total amount"
            };

            var calcButton = new UIButton(UIButtonType.Custom) {
                // 71 == 28 of the UITextField from top + 8 of separation between view + 35 from UITextFild height
                Frame = new CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.Blue                
            };
            calcButton.SetTitle("Calculate", UIControlState.Normal);

            var resultLabel = new UILabel() {
                Frame = new CGRect(20, 124, View.Bounds.Width - 40, 40),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24),
                Text = "Tip is $0,00"
            };

            View.AddSubviews(totalAmount, calcButton, resultLabel);

            calcButton.TouchUpInside += (s, e) => {
                double.TryParse(totalAmount.Text, out double value);
                resultLabel.Text = string.Format("Tip is {0:C}", value * 0.2); // 20% of the total amount
                totalAmount.ResignFirstResponder();
            };
        }
    }
}