using System.Diagnostics;
using System.Windows.Input;

namespace MauiGestureTest;

public partial class Joystick : Border
{
	public Joystick()
	{
		InitializeComponent();
    }


    private bool _pointerPressed;

    private void PointerGestureRecognizer_PointerMoved(object sender, PointerEventArgs e)
    {
        if (_pointerPressed)
        {
            Debug.WriteLine("PointerMoved");
            var pos = e.GetPosition(this);
            if(!pos.HasValue)
                return;
            var newX = ((pos.Value.X - Width / 2) / Width) * 2;
            var newY = ((pos.Value.Y - Height / 2) / Height) * 2; 
            if(newX is >= -0.7 and <= 0.7)
                PointerHandler.TranslationX = newX * 150;
            if(newY is >= -0.7 and <= 0.7)
                PointerHandler.TranslationY = newY * 150;
        }
    }

    private void PointerGestureRecognizer_PointerPressed(object sender, PointerEventArgs e)
    {
        _pointerPressed = true;
        Debug.WriteLine("PointerPressed");
    }

    private void PointerGestureRecognizer_PointerReleased(object sender, PointerEventArgs e)
    {
        _pointerPressed = false;
        PointerHandler.TranslateTo(0, 0, 100);
        Debug.WriteLine("PointerReleased");
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        _pointerPressed = false;
        PointerHandler.TranslateTo(0, 0, 100);
        Debug.WriteLine("PointerExited");
    }
}