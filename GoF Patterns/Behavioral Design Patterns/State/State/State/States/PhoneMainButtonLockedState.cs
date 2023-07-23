using State.Entities;

namespace State.States;

internal class PhoneMainButtonLockedState : PhoneMainButtonState
{
    public PhoneMainButtonLockedState(PhoneMainButton phoneMainButton) : base(phoneMainButton)
    {
    }

    public override void OnButtonClickedOnce()
    {
        Console.WriteLine("Phone has been unlocked.");
        _phoneMainButton.ChangePhoneState(new PhoneMainButtonUnLockedState(_phoneMainButton));
    }

    public override void OnButtonClickedTwice() => Console.WriteLine("Camera App has been started");
}