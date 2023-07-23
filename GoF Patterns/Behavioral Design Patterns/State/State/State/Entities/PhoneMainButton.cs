using State.States;

namespace State.Entities;

internal class PhoneMainButton
{
    private PhoneMainButtonState _phoneMainButton;

    public PhoneMainButton() => _phoneMainButton = new PhoneMainButtonLockedState(this);

    public void ChangePhoneState(PhoneMainButtonState newState) => _phoneMainButton = newState;

    public void ClickOnce() => _phoneMainButton.OnButtonClickedOnce();

    public void ClickTwice() => _phoneMainButton.OnButtonClickedTwice();
}