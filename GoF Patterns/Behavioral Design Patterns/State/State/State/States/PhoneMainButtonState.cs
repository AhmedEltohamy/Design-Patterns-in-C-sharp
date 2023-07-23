using State.Entities;

namespace State.States;

internal abstract class PhoneMainButtonState
{
    protected readonly PhoneMainButton _phoneMainButton;

    protected PhoneMainButtonState(PhoneMainButton phoneMainButton) => _phoneMainButton = phoneMainButton;

    public abstract void OnButtonClickedOnce();

    public abstract void OnButtonClickedTwice();
}