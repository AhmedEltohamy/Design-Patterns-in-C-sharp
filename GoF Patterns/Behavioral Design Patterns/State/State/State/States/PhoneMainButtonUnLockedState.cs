using State.Entities;

namespace State.States;

internal class PhoneMainButtonUnLockedState : PhoneMainButtonState
{
    public PhoneMainButtonUnLockedState(PhoneMainButton phoneMainButton) : base(phoneMainButton)
    {
    }

    public override void OnButtonClickedOnce()
    {
        Console.WriteLine("Phone has been locked");
        _phoneMainButton.ChangePhoneState(new PhoneMainButtonLockedState(_phoneMainButton));
    }

    public override void OnButtonClickedTwice() => Console.WriteLine("Screenshot has been captured.");
}